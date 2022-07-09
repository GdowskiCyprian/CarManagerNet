using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarManagerNet.Models;

public class Auth
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int AuthId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}