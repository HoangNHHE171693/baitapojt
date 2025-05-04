using Hoangnhhe171693.Models;
using Hoangnhhe171693.Models.DTO.Request.Tinh;
using Hoangnhhe171693.Models.DTO.Response;

namespace Hoangnhhe171693.Mapper;

public interface ITinhMapper
{
    Tinh CreateToEntity(TinhCreate create);
    Tinh UpdateToEntity(TinhUpdate update);
    Tinh DeleteToEntity(TinhDelete delete);

    TinhResponse EntityToResponse(Tinh entity);
    IEnumerable<TinhResponse> ListEntityToResponse(IEnumerable<Tinh> entities);
}
