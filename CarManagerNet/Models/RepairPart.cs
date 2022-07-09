using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerNet.Models;

public class RepairPart
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RepairPartId{ get; set; }
    
    public string Name{ get; set; }
    public string Description{ get; set; }
    public double Price{ get; set; }
    [ForeignKey("RepairId")]
    public virtual Repair Repair { get; set; }
}