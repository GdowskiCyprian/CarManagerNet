using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerNet.Models;

public class Client
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ClientId { get; set; }
    public int PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    [ForeignKey("RepairShopId")]
    public virtual RepairShop RepairShop { get; set; }
    [ForeignKey("AuthId")]
    public virtual Auth Auth { get; set; }
}