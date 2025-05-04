using BaiTapOceanTech.DB;
using BaiTapOceanTech.Mapper;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Employee;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Utility;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace BaiTapOceanTech.Services.impl;

public class EmployeeService : IEmployeeService
{
    private readonly ApplicationDbContext _context;
    private readonly IEmployeeMapper _mapper;
    private readonly Validation<Employee> _validation;

    public EmployeeService(ApplicationDbContext context, IEmployeeMapper mapper, Validation<Employee> validation)
    {
        _context = context;
        _mapper = mapper;
        _validation = validation;
    }
    public async Task<string> CheckUniqueCodeAsync()
    {
        string newCode;
        bool isExist;

        do
        {
            newCode = GenerateCode.GenerateEmployeeCode();
            _context.ChangeTracker.Clear();
            isExist = await _context.Employees.AnyAsync(p => p.Code == newCode);
        }
        while (isExist);

        return newCode;
    }
    public async Task<bool> ValidateLocation(int idTinh, int idHuyen, int idXa)
    {
        var xa = await _context.Xas.FindAsync(idXa);
        if (xa == null) return false;

        var huyen = await _context.Huyen.FindAsync(idHuyen);
        if (huyen == null || xa.IdHuyen != idHuyen) return false;

        var tinh = await _context.Tinh.FindAsync(idTinh);
        if (tinh == null || huyen.IdTinh != idTinh) return false;

        return true;
    }

    public async Task<EmployeeResponse> CreateEmployeeAsync(EmployeeCreate create)
    {
        

        if (string.IsNullOrEmpty(create.Name))
        {
            throw new Exception("Không được để trống tên");
        }

        create.Name = Regex.Replace(create.Name.Trim(), @"\s+", " ");
        if (!Regex.IsMatch(create.Name, @"^[a-zA-ZÀ-Ỹà-ỹ\s]+$"))
        {
            throw new Exception("Tên không được chứa kí tự đặc biệt");
        }

        var today = DateTime.Today;
        var age = today.Year - create.Dob.Year;
        if (create.Dob.Date > today.AddYears(-age))
        {
            age--;
        }

        if (age < 18)
        {
            throw new Exception("Nhân viên phải từ 18 tuổi trở lên");
        }
        create.CCCD = Regex.Replace(create.CCCD.Trim(), @"\s+", " ");
        if (await _context.Employees.AnyAsync(x => x.CCCD == create.CCCD))
        {
            throw new Exception("CCCD đã tồn tại");
        }
        Employee entity = _mapper.CreateToEntity(create);

        bool isValidLocation = await ValidateLocation(create.IdTinh, create.IdHuyen, create.IdXa);
        if (!isValidLocation)
        {
            throw new Exception("Địa điểm không hợp lệ.");
        }

        if (!string.IsNullOrEmpty(create.Code) && create.Code != "string")
        {
            entity.Code = create.Code;
        }
        else
        {
            entity.Code = await CheckUniqueCodeAsync();
        }

        while (await _context.Employees.AnyAsync(p => p.Code == entity.Code))
        {
            entity.Code = await CheckUniqueCodeAsync();
        }

        await _context.Employees.AddAsync(entity);

        await _context.SaveChangesAsync();
        var response = _mapper.EntityToResponse(entity);
        return response;
    }

    public async Task<EmployeeResponse> FindEmployeeByIdAsync(int id)
    {
        var coId = _context.Employees.FirstOrDefault(co => co.Id == id);
        if (coId == null)
        {
            throw new Exception($"Không có Id {id} tồn tại");
        }
        var response = _mapper.EntityToResponse(coId);
        return response;
    }

    public async Task<IEnumerable<EmployeeResponse>> GetAllEmployeesAsync()
    {
        var co = await _context.Employees.ToListAsync();
        if (co == null) throw new Exception($"Không có bản ghi nào");

        var response = _mapper.ListEntityToResponse(co);

        return response;
    }

    public async Task<bool> HardDeleteEmployeeAsync(int id)
    {
        var co = _context.Employees.FirstOrDefault(co => co.Id == id);
        if (co == null)
        {
            throw new Exception($"Không có Id {id} tồn tại");
        }
        _context.Employees.Remove(co);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<EmployeeResponse>> SearchEmployeeByKeyAsync(string key)
    {
        var coKey = await _context.Employees
               .FromSqlRaw("Select * from Employees where Name like {0}", "%" + key + "%").ToListAsync();

        if (coKey == null) throw new Exception($"Không có tên {key} nào");
        var response = _mapper.ListEntityToResponse(coKey);
        return response;
    }


    public async Task<EmployeeResponse> SoftDeleteEmployeeAsync(int id, Status.EmployeeD newStatus)
    {
        var coId = await _context.Employees.FindAsync(id);
        if (coId == null) throw new Exception($"Không có Id {id} tồn tại");

        coId.Status = newStatus;

        await _context.SaveChangesAsync();

        var response = _mapper.EntityToResponse(coId);
        return response;
    }

    public async Task<EmployeeResponse> UpdateEmployeeAsync(int id, EmployeeUpdate update)
    {
        var coId = await _context.Employees.FirstOrDefaultAsync(co => co.Id == id);
        if (coId == null)
        {
            throw new Exception($"Không có Id {id} tồn tại");
        }

        coId.Code = await _validation.CheckAndUpdateAPIAsync(coId, coId.Code, update.Code, co => co.Code == update.Code);
        coId.Name = await _validation.CheckAndUpdateAPIAsync(coId, coId.Name, update.Name, co => co.Name == update.Name);
        coId.ActiveCertificateCount = await _validation.CheckAndUpdateQuantityAsync(coId, coId.ActiveCertificateCount, update.ActiveCertificateCount, co => co.ActiveCertificateCount == update.ActiveCertificateCount);
        coId.TotalCertificateCount = await _validation.CheckAndUpdateQuantityAsync(coId, coId.TotalCertificateCount, update.TotalCertificateCount, co => co.TotalCertificateCount == update.TotalCertificateCount);
        coId.Dob = await _validation.CheckAndUpdateDate2Async(coId, coId.Dob, update.Dob);
        coId.CCCD = await _validation.CheckAndUpdateAPIAsync(coId, coId.CCCD, update.CCCD, co => co.CCCD == update.CCCD);
        //coId.Age = await _validation.CheckAndUpdateQuantityAsync(coId, coId.Age, update.Age, co => co.Age == update.Age);
        coId.Phone = await _validation.CheckAndUpdateAPIAsync(coId, coId.Phone, update.Phone, co => co.Phone == update.Phone);

        var result = _mapper.UpdateToEntity(update);
        coId.IdTinh = result.IdTinh;
        coId.IdHuyen = result.IdHuyen;
        coId.IdXa = result.IdXa;
        coId.Age = result.Age;
        coId.Status = result.Status;
        coId.Ethnic = result.Ethnic;
        coId.Job = result.Job;
        coId.CreatedDate = result.CreatedDate;
        coId.UpdatedDate = result.UpdatedDate;
        await _context.SaveChangesAsync();

        var response = _mapper.EntityToResponse(coId);
        return response;
    }
}
