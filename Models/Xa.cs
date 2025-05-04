using Hoangnhhe171693.Utility;
using static Hoangnhhe171693.Utility.Status;

namespace Hoangnhhe171693.Models;

public class Xa : BaseEntity
{
    public Statuss Status { get; set; }
    public int IdHuyen { get; set; }
    public virtual Huyen Huyen { get; set; } = null!;
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
