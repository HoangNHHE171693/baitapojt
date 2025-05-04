using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO;

public class EmployeeCertificateDTO
{
    public int Id { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public CertificateD Status { get; set; }
    public int EmployeeId { get; set; }
    public int CertificateId { get; set; }
}
