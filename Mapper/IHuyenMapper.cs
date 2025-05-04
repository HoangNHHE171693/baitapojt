using BaiTapOceanTech.Models.DTO.Request.Huyen;
using BaiTapOceanTech.Models.DTO.Request;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Models;

namespace BaiTapOceanTech.Mapper;

public interface IHuyenMapper
{
    Huyen CreateToEntity(HuyenCreate create);
    Huyen UpdateToEntity(HuyenUpdate update);
    Huyen DeleteToEntity(HuyenDelete delete);

    HuyenResponse EntityToResponse(Huyen entity);
    IEnumerable<HuyenResponse> ListEntityToResponse(IEnumerable<Huyen> entities);
}
