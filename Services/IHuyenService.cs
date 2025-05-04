using BaiTapOceanTech.Models.DTO.Request.Huyen;
using BaiTapOceanTech.Models.DTO.Response;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Services;

public interface IHuyenService
{
    public Task<IEnumerable<HuyenResponse>> GetAllHuyensAsync();
    public Task<IEnumerable<HuyenResponse>> SearchHuyenByKeyAsync(string key);
    public Task<IEnumerable<HuyenResponse>> getHuyenByIdTinhAsync(int id);
    public Task<HuyenResponse> UpdateHuyenAsync(int id, HuyenUpdate update);
    public Task<HuyenResponse> CreateHuyenAsync(HuyenCreate create);
    public Task<bool> HardDeleteHuyenAsync(int id);
    public Task<HuyenResponse> SoftDeleteHuyenAsync(int id, Statuss newStatus);
    public Task<HuyenResponse> FindHuyenByIdAsync(int postalCode);
    //public Task<string> CheckUniqueCodeAsync();
}
