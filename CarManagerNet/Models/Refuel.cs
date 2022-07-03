namespace CarManagerNet.Models;

public class Refuel
{
    public int RefuelId { get; set; }
    public FuelType FuelType { get; set; }
    public double Volume { get; set; }
    public double Price { get; set; }
    
    public int FuelTankId { get; set; }
}