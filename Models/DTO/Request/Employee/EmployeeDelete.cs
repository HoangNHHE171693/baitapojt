using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO.Request.Employee;

public class EmployeeDelete
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string CCCD { get; set; }
    public EmployeeD Status { get; set; }
    public int Age { get; set; }
    public DateTime Dob { get; set; }
    public Ethnic Ethnic { get; set; }
    public Job Job { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int ActiveCertificateCount { get; set; }
    public int TotalCertificateCount { get; set; }

    public int IdTinh { get; set; }

    public int IdHuyen { get; set; }

    public int IdXa { get; set; }

    public EmployeeDelete()
    {
    }

    public EmployeeDelete(int id, string name, string code, string cCCD, EmployeeD status, int age, DateTime dob, Ethnic ethnic, Job job, string phone, DateTime createdDate, DateTime updatedDate, int activeCertificateCount, int totalCertificateCount, int idTinh, int idHuyen, int idXa)
    {
        Id = id;
        Name = name;
        Code = code;
        CCCD = cCCD;
        Status = status;
        Age = age;
        Dob = dob;
        Ethnic = ethnic;
        Job = job;
        Phone = phone;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        ActiveCertificateCount = activeCertificateCount;
        TotalCertificateCount = totalCertificateCount;
        IdTinh = idTinh;
        IdHuyen = idHuyen;
        IdXa = idXa;
    }
}
