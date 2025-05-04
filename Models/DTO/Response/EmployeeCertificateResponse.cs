using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models.DTO.Response;

public class EmployeeCertificateResponse
{
    public int Id { get; set; }
    public DateTime IssueDate { get; set; }
    public DateTime ExpiredDate { get; set; }
    public CertificateD Status { get; set; }
    public int EmployeeId { get; set; }
    public int CertificateId { get; set; }

    public EmployeeCertificateResponse()
    {
    }

    public EmployeeCertificateResponse(int id, DateTime issueDate, DateTime expiredDate, CertificateD status, int employeeId, int certificateId)
    {
        Id = id;
        IssueDate = issueDate;
        ExpiredDate = expiredDate;
        Status = status;
        EmployeeId = employeeId;
        CertificateId = certificateId;
    }
}
