using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO.Response;

public class TinhResponse
{
    public Statuss Status { get; set; }
    public int Id { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

    public TinhResponse()
    {
    }

    public TinhResponse(Statuss status, int id, string postalCode, string name, DateTime createdDate, DateTime updatedDate)
    {
        Status = status;
        Id = id;
        PostalCode = postalCode;
        Name = name;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
    }
}
