using BaiTapOceanTech.Utility;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models;

public class Xa : BaseEntity
{
    public Statuss Status { get; set; }
    public int IdHuyen { get; set; }
    public virtual Huyen Huyen { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
