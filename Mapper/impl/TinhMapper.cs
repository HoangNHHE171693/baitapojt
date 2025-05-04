using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Tinh;
using BaiTapOceanTech.Models.DTO.Response;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BaiTapOceanTech.Mapper.impl;

public class TinhMapper : ITinhMapper
{
    private readonly Tinh tinh = new Tinh();
    public Tinh CreateToEntity(TinhCreate create)
    {
        tinh.PostalCode = create.PostalCode;
        tinh.Status = create.Status;
        tinh.Name = create.Name;
        tinh.CreatedDate = DateTime.Now.AddHours(7);
        tinh.UpdatedDate = DateTime.Now.AddHours(7);
        return tinh;
    }

    public Tinh DeleteToEntity(TinhDelete delete)
    {
        tinh.Id = delete.Id;
        tinh.PostalCode = delete.PostalCode;
        tinh.Status = delete.Status;
        tinh.Name = delete.Name;
        tinh.CreatedDate = DateTime.Now.AddHours(7);
        tinh.UpdatedDate = DateTime.Now.AddHours(7);
        return tinh;
    }

    public TinhResponse EntityToResponse(Tinh entity)
    {
        TinhResponse response = new TinhResponse();
        response.Id = entity.Id;
        response.PostalCode = entity.PostalCode;
        response.Status = entity.Status;
        response.Name = entity.Name;
        response.CreatedDate = DateTime.Now.AddHours(7);
        response.UpdatedDate = DateTime.Now.AddHours(7);
        return response;
    }

    public IEnumerable<TinhResponse> ListEntityToResponse(IEnumerable<Tinh> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public Tinh UpdateToEntity(TinhUpdate update)
    {
        
        tinh.PostalCode = update.PostalCode;
        tinh.Status = update.Status;
        tinh.Name = update.Name;
        tinh.CreatedDate = DateTime.Now.AddHours(7);
        tinh.UpdatedDate = DateTime.Now.AddHours(7);
        return tinh;
    }
}
