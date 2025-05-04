using BaiTapOceanTech.Models;
using BaiTapOceanTech.Models.DTO.Request.Tinh;
using BaiTapOceanTech.Models.DTO.Response;

namespace BaiTapOceanTech.Mapper;

public interface ITinhMapper
{
    Tinh CreateToEntity(TinhCreate create);
    Tinh UpdateToEntity(TinhUpdate update);
    Tinh DeleteToEntity(TinhDelete delete);

    TinhResponse EntityToResponse(Tinh entity);
    IEnumerable<TinhResponse> ListEntityToResponse(IEnumerable<Tinh> entities);
}
