namespace CarManagerNet.Models;

public class Repair
{
    public int RepairId { get; set; }
    public DateTime ProcessDate { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    
    public int CarId { get; set; }
}