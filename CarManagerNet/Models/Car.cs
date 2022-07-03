namespace CarManagerNet.Models;

public class Car
{
    public int CarId { get; set; }
    public int MakeYear { get; set; }
    public string Manufacturer { get; set; }
    public string Model { get; set; }
    public string Version { get; set; }
    public int Displacement { get; set; }
    public int Power { get; set; }
    public int Mileage { get; set; }
    
    public int ClientId { get; set; }
}