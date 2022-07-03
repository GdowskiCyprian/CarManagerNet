namespace CarManagerNet.Models;

public class FuelTank
{
    public int FuelTankId { get; set; }
    public FuelType FuelType { get; set; }
    public double Capacity { get; set; }
    
    public int CarId { get; set; }
    
}