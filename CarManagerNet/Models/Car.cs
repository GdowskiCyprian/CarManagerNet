using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CarManagerNet.Models;

public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int CarId { get; set; }
    public int MakeYear { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string Version { get; set; }
    public int Displacement { get; set; }
    public int Power { get; set; }
    public int Mileage { get; set; }
    
    [ForeignKey("ClientId")]
    public virtual Client Client { get; set; }
}