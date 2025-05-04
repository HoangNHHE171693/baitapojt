using BaiTapOceanTech.Models.DTO.Request.Tinh;
using BaiTapOceanTech.Models.DTO.Response;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Services;

public interface ITinhService
{
    public Task<IEnumerable<TinhResponse>> GetAllTinhsAsync();
    public Task<IEnumerable<TinhResponse>> SearchTinhByKeyAsync(string key);
    public Task<TinhResponse> UpdateTinhAsync(int id, TinhUpdate update);
    public Task<TinhResponse> CreateTinhAsync(TinhCreate create);
    public Task<bool> HardDeleteTinhAsync(int id);
    public Task<TinhResponse> SoftDeleteTinhAsync(int id, Statuss newStatus);
    public Task<TinhResponse> FindTinhByIdAsync(int postalCode);
    //public Task<string> CheckUniqueCodeAsync();
}
