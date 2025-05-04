using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models;

public class Certificate
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public CertificateD Status { get; set; }
    public virtual ICollection<EmployeeCertificate> EmployeeCertificates { get; set; } = new List<EmployeeCertificate>();

    public int IdTinh { get; set; }
    public virtual Tinh Tinh { get; set; }
}
