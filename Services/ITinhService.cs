using Hoangnhhe171693.Models.DTO.Request.Tinh;
using Hoangnhhe171693.Models.DTO.Response;
using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Services;

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
