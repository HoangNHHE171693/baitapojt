using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models.DTO.Response;

public class XaResponse
{
    public Statuss Status { get; set; }
    public int Id { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int IdHuyen { get; set; }

    public XaResponse()
    {
    }

    public XaResponse(Statuss status, int id, string postalCode, string name, DateTime createdDate, DateTime updatedDate, int idHuyen)
    {
        Status = status;
        Id = id;
        PostalCode = postalCode;
        Name = name;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        IdHuyen = idHuyen;
    }
}
