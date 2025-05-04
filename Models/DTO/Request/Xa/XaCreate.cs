using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO.Request.Xa;

public class XaCreate
{
    public Statuss Status { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int IdHuyen { get; set; }

    public XaCreate()
    {
    }

    public XaCreate(Statuss status, string postalCode, string name, DateTime createdDate, DateTime updatedDate, int idHuyen)
    {
        Status = status;
        PostalCode = postalCode;
        Name = name;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        IdHuyen = idHuyen;
    }
}
