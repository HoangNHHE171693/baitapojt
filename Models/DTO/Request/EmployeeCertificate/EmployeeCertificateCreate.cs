using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO.Request.EmployeeCertificate;

public class EmployeeCertificateCreate
{
    public DateTime IssueDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public CertificateD Status { get; set; }
    public int EmployeeId { get; set; }
    public int CertificateId { get; set; }

    public EmployeeCertificateCreate()
    {
    }

    public EmployeeCertificateCreate(DateTime issueDate, DateTime expiredDate, CertificateD status, int employeeId, int certificateId)
    {
        IssueDate = issueDate;
        ExpiredDate = expiredDate;
        Status = status;
        EmployeeId = employeeId;
        CertificateId = certificateId;
    }
}
