using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO.Request.Certificate;

public class CertificateCreate
{
   
    public string Name { get; set; }
    public string Description { get; set; }
    public CertificateD Status { get; set; }
    public int IdTinh { get; set; }

    public CertificateCreate()
    {
    }

    public CertificateCreate(string name, string description, CertificateD status, int idTinh)
    {
        Name = name;
        Description = description;
        Status = status;
        IdTinh = idTinh;
    }
}
