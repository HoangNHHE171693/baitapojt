using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models.DTO;

public class HuyenDTO
{
    public Statuss Status { get; set; }
    public int Id { get; set; }
    public string PostalCode { get; set; }
    public string Name { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int IdTinh { get; set; }
}
