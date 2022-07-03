namespace CarManagerNet.Models;

public class RepairPart
{
    public int RepairPartId;
    public string Name;
    public string Description;
    public double Price;
    
    public int RepairId { get; set; }
}