using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models.DTO;

public class CertificateDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CertificateD Status { get; set; }
    public int IdTinh { get; set; }
}
