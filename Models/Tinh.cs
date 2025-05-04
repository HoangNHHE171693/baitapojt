using BaiTapOceanTech.Utility;
using static BaiTapOceanTech.Utility.Status;

namespace BaiTapOceanTech.Models;

public class Tinh : BaseEntity
{
    public Statuss Status { get; set; }
    public virtual ICollection<Huyen> Huyens { get; set; } = new List<Huyen>();
    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

}
