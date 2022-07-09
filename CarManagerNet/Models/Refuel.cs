using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerNet.Models;

public class Refuel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RefuelId { get; set; }
    public FuelType FuelType { get; set; }
    public double Volume { get; set; }
    public double Price { get; set; }
    [ForeignKey("FuelTankId")]
    public virtual FuelTank FuelTank { get; set; }
}