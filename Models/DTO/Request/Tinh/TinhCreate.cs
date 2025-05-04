using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models.DTO.Request.Tinh;

public class TinhCreate
{
    public Statuss Status { get; set; }
    
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public TinhCreate()
    {
    }

    public TinhCreate(Statuss status, string postalCode, string name, DateTime createdDate, DateTime updatedDate)
    {
        Status = status;
        PostalCode = postalCode;
        Name = name;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }
}
