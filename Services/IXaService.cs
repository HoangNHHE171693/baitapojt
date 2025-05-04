using BaiTapOceanTech.Models.DTO.Request.Xa;
using BaiTapOceanTech.Models.DTO.Response;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Services;

public interface IXaService 
{
    public Task<IEnumerable<XaResponse>> GetAllXasAsync();
    public Task<IEnumerable<XaResponse>> SearchXaByKeyAsync(string key);
    public Task<IEnumerable<XaResponse>> FindXaByIdHuyenAsync(int id);
    public Task<XaResponse> UpdateXaAsync(int id, XaUpdate update);
    public Task<XaResponse> CreateXaAsync(XaCreate create);
    public Task<bool> HardDeleteXaAsync(int id);
    public Task<XaResponse> SoftDeleteXaAsync(int id, Statuss newStatus);
    public Task<XaResponse> FindXaByIdAsync(int postalCode);
    //public Task<string> CheckUniqueCodeAsync();
}
