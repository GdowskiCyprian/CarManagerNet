namespace CarManagerNet.Models;

public class Client
{
    public int ClientId { get; set; }
    public int PhoneNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    
    public int RepairShopId { get; set; }
    
    public int AuthId { get; set; }
}