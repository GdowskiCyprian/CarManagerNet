using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerNet.Models;

public class RepairShop
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int RepairShopId { get; set; }
    public int PhoneNumber { get; set; }
    public string Name { get; set; }
    public int Nip { get; set; }
    [ForeignKey("AuthId")]
    public virtual Auth Auth { get; set; }
}