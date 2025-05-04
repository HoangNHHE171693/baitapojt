using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO.Request.Huyen;

public class HuyenCreate
{
    public Statuss Status { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int IdTinh { get; set; }

    public HuyenCreate()
    {
    }

    public HuyenCreate(Statuss status, string postalCode, string name, DateTime createdDate, DateTime updatedDate, int idTinh)
    {
        Status = status;
        PostalCode = postalCode;
        Name = name;
        CreatedDate = createdDate;
        UpdatedDate = updatedDate;
        IdTinh = idTinh;
    }
}
