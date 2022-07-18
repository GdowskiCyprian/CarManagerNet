using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarManagerNet.Controllers;
[ApiController]
[Route("[controller]")]
public class FuelTankController
{
    private readonly DataContext _dataContext;
    public FuelTankController(DataContext context)
    {
        _dataContext = context;
    }
    //done PostFuelTank
    [HttpPost]
    public void PostFuelTank([FromBody] FuelTank fuelTank)
    {
        _dataContext.FuelTanks.Add(fuelTank);
        _dataContext.SaveChanges();
    }
}