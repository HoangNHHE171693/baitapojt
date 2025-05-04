using Hoangnhhe171693.Utility;
using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models;

public class Tinh : BaseEntity
{
    public Statuss Status { get; set; }
    public virtual ICollection<Huyen> Huyens { get; set; } = new List<Huyen>();
    public virtual ICollection<Certificate> Certificates { get; set; } = new List<Certificate>();
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

}
