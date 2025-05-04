using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models.DTO;

public class HuyenDTO
{
    public Statuss Status { get; set; }
    public int Id { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int IdTinh { get; set; }
}
