using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO.Request.EmployeeCertificate;

public class EmployeeCertificateUpdate
{
    public int Id { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public CertificateD Status { get; set; }
    public int EmployeeId { get; set; }
    public int CertificateId { get; set; }

    public EmployeeCertificateUpdate()
    {
    }

    public EmployeeCertificateUpdate(int id, DateTime issueDate, DateTime expiredDate, CertificateD status, int employeeId, int certificateId)
    {
        Id = id;
        IssueDate = issueDate;
        ExpiredDate = expiredDate;
        Status = status;
        EmployeeId = employeeId;
        CertificateId = certificateId;
    }
}
