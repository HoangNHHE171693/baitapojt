using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO.Request.Tinh;

public class TinhUpdate
{
    public Statuss Status { get; set; }
    public int Id { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public TinhUpdate()
    {
    }

    public TinhUpdate(Statuss status, string postalCode, string name, DateTime createdDate, DateTime updatedDate, int id)
    {
        Status = status;
        PostalCode = postalCode;
        Name = name;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        Id = id;
    }
}
