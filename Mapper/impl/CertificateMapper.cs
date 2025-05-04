using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Certificate;
using BaiTapOceanTech.Models.DTO.Response;

namespace BaiTapOceanTech.Mapper.impl;

public class CertificateMapper : ICertificateMapper
{
    private readonly Certificate cer = new Certificate();
    public Certificate CreateToEntity(CertificateCreate create)
    {
        cer.Status = create.Status;
        cer.Name = create.Name;
        cer.Description = create.Description;
        cer.IdTinh = create.IdTinh;
        return cer;
    }

    public Certificate DeleteToEntity(CertificateDelete delete)
    {
        cer.Status = delete.Status;
        cer.Id = delete.Id;
        cer.Name = delete.Name;
        cer.Description = delete.Description;
        cer.IdTinh = delete.IdTinh;
        return cer;
    }

    public CertificateResponse EntityToResponse(Certificate entity)
    {
        CertificateResponse response = new CertificateResponse();
        response.Status = entity.Status;
        response.Id = entity.Id;
        response.Name = entity.Name;
        response.Description = entity.Description;
        response.IdTinh = entity.IdTinh;
        return response;
    }

    public IEnumerable<CertificateResponse> ListEntityToResponse(IEnumerable<Certificate> entities)
    {
        return entities.Select(x => EntityToResponse(x)).ToList();
    }

    public Certificate UpdateToEntity(CertificateUpdate update)
    {
        cer.Status = update.Status;
        cer.Name = update.Name;
        cer.Description = update.Description;
        cer.IdTinh = update.IdTinh;
        return cer;
    }
}
