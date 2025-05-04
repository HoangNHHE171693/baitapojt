using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models.DTO.Response;

public class CertificateResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CertificateD Status { get; set; }
    
    public int IdTinh { get; set; }

    public CertificateResponse()
    {
    }

    public CertificateResponse(int id, string name, string description, CertificateD status, int idTinh)
    {
        Id = id;
        Name = name;
        Description = description;
        Status = status;
        
        IdTinh = idTinh;
    }
}
