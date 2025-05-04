using BaiTapOceanTech.Utility;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models;

public class Huyen : BaseEntity
{
    public Statuss Status { get; set; }
    public int IdTinh { get; set; }
    public virtual Tinh Tinh { get; set; } = null!;
    public virtual ICollection<Xa> Xas { get; set; } = new List<Xa>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
