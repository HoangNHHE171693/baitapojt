using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Huyen;
using Hoangnhhe171693.Models.DTO.Response;

namespace Hoangnhhe171693.Mapper.impl;

public class HuyenMapper : IHuyenMapper
{
    private readonly Huyen huyen = new Huyen();
    public Huyen CreateToEntity(HuyenCreate create)
    {
        huyen.PostalCode = create.PostalCode;
        huyen.Status = create.Status;
        huyen.Name = create.Name;
        huyen.CreatedDate = DateTime.Now.AddHours(7);
        huyen.UpdatedDate = DateTime.Now.AddHours(7);
        huyen.IdTinh = create.IdTinh;
        return huyen;
    }

    public Huyen DeleteToEntity(HuyenDelete delete)
    {
        huyen.Id = delete.Id;
        huyen.PostalCode = delete.PostalCode;
        huyen.Status = delete.Status;
        huyen.Name = delete.Name;
        huyen.CreatedDate = DateTime.Now.AddHours(7);
        huyen.UpdatedDate = DateTime.Now.AddHours(7);
        huyen.IdTinh = delete.IdTinh;
        return huyen;
    }

    public HuyenResponse EntityToResponse(Huyen entity)
    {
        HuyenResponse response = new HuyenResponse();
        response.Id = entity.Id;
        response.PostalCode = entity.PostalCode;
        response.Status = entity.Status;
        response.Name = entity.Name;
        response.CreatedDate = DateTime.Now.AddHours(7);
        response.UpdatedDate = DateTime.Now.AddHours(7);
        response.IdTinh = entity.IdTinh;
        return response;
    }

    public IEnumerable<HuyenResponse> ListEntityToResponse(IEnumerable<Huyen> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public Huyen UpdateToEntity(HuyenUpdate update)
    {
        
        huyen.PostalCode = update.PostalCode;
        huyen.Status = update.Status;
        huyen.Name = update.Name;
        huyen.CreatedDate = DateTime.Now.AddHours(7);
        huyen.UpdatedDate = DateTime.Now.AddHours(7);
        huyen.IdTinh = update.IdTinh;
        return huyen;
    }
}
