using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public string CCCD { get; set; }
    public int Age { get; set; }
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
    
    public int IdHuyen { get; set; }
  
    public int IdXa { get; set; }
}
