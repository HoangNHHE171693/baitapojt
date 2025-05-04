using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models;

public class Employee
{
    public int Id { get; set; } 
    public string Name { get; set; }
    public string Code { get; set; }
    public int Age { get; set; }
    public string CCCD { get; set; }
    public DateTime Dob { get; set; }
    public Ethnic Ethnic { get; set; }
    public Job Job { get; set; }
    public string Phone { get; set; }
    public EmployeeD Status { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int ActiveCertificateCount { get; set; }
    public int TotalCertificateCount { get; set; }
    public int IdTinh { get; set; }
    public virtual Tinh Tinh { get; set; }
    public int IdHuyen { get; set; }
    public virtual Huyen Huyen { get; set; }
    public int IdXa { get; set; }
    public virtual Xa Xa { get; set; }
    public virtual ICollection<EmployeeCertificate> EmployeeCertificates { get; set; } = new List<EmployeeCertificate>();
}
