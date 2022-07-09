using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerNet.Models;

public class Repair
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RepairId { get; set; }
    public DateTime ProcessDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    [ForeignKey("CarId")]
    public virtual Car Car{ get; set; }
}