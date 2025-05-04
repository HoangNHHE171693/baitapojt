using BaiTapOceanTech.Models.DTO.Request.Huyen;
using BaiTapOceanTech.Models.DTO.Response;
using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Xa;

namespace BaiTapOceanTech.Mapper;

public interface IXaMapper
{
    Xa CreateToEntity(XaCreate create);
    Xa UpdateToEntity(XaUpdate update);
    Xa DeleteToEntity(XaDelete delete);

    XaResponse EntityToResponse(Xa entity);
    IEnumerable<XaResponse> ListEntityToResponse(IEnumerable<Xa> entities);
}
