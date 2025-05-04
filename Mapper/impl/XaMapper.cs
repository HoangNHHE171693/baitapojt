using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Xa;
using BaiTapOceanTech.Models.DTO.Response;
using Microsoft.AspNetCore.Http.HttpResults;

namespace BaiTapOceanTech.Mapper.impl;

public class XaMapper : IXaMapper
{
    private readonly Xa xa = new Xa();
    public Xa CreateToEntity(XaCreate create)
    {
        xa.PostalCode = create.PostalCode;
        xa.Status = create.Status;
        xa.Name = create.Name;
        xa.CreatedDate = DateTime.Now.AddHours(7);
        xa.UpdatedDate = DateTime.Now.AddHours(7);
        xa.IdHuyen = create.IdHuyen;
        return xa;
    }

    public Xa DeleteToEntity(XaDelete delete)
    {
        xa.Id = delete.Id;
        xa.PostalCode = delete.PostalCode;
        xa.Status = delete.Status;
        xa.Name = delete.Name;
        xa.CreatedDate = DateTime.Now.AddHours(7);
        xa.UpdatedDate = DateTime.Now.AddHours(7);
        xa.IdHuyen = delete.IdHuyen;
        return xa;
    }

    public XaResponse EntityToResponse(Xa entity)
    {
        XaResponse response = new XaResponse();
        response.Id = entity.Id;
        response.PostalCode = entity.PostalCode;
        response.Status = entity.Status;
        response.Name = entity.Name;
        response.CreatedDate = DateTime.Now.AddHours(7);
        response.UpdatedDate = DateTime.Now.AddHours(7);
        response.IdHuyen = entity.IdHuyen;
        return response;
    }

    public IEnumerable<XaResponse> ListEntityToResponse(IEnumerable<Xa> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public Xa UpdateToEntity(XaUpdate update)
    {
        xa.PostalCode = update.PostalCode;
        xa.Status = update.Status;
        xa.Name = update.Name;
        xa.CreatedDate = DateTime.Now.AddHours(7);
        xa.UpdatedDate = DateTime.Now.AddHours(7);
        xa.IdHuyen = update.IdHuyen;
        return xa;
    }
}
