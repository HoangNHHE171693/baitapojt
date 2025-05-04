using Hoangnhhe171693.Models.DTO.Request.Huyen;
using Hoangnhhe171693.Models.DTO.Request;
using Hoangnhhe171693.Models.DTO.Response;
using Hoangnhhe171693.Models;

namespace Hoangnhhe171693.Mapper;

public interface IHuyenMapper
{
    Huyen CreateToEntity(HuyenCreate create);
    Huyen UpdateToEntity(HuyenUpdate update);
    Huyen DeleteToEntity(HuyenDelete delete);

    HuyenResponse EntityToResponse(Huyen entity);
    IEnumerable<HuyenResponse> ListEntityToResponse(IEnumerable<Huyen> entities);
}
