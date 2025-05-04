using Hoangnhhe171693.Models.DTO.Request.Huyen;
using Hoangnhhe171693.Models.DTO.Response;
using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Xa;

namespace Hoangnhhe171693.Mapper;

public interface IXaMapper
{
    Xa CreateToEntity(XaCreate create);
    Xa UpdateToEntity(XaUpdate update);
    Xa DeleteToEntity(XaDelete delete);

    XaResponse EntityToResponse(Xa entity);
    IEnumerable<XaResponse> ListEntityToResponse(IEnumerable<Xa> entities);
}
