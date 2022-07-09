using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerNet.Models;

public class FuelTank
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FuelTankId { get; set; }
    public FuelType FuelType { get; set; }
    public double Capacity { get; set; }
    [ForeignKey("CarId")]
    public virtual Car Car { get; set; }
    
}