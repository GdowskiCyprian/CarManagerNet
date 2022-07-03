using CarManagerNet.DataServices;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarManagerNet.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController
{
    private readonly CarDataService _dataService;


    public CarController()
    {
        _dataService = new CarDataService();
    }

    [HttpGet]
    [Route("GetCars")]
    public IEnumerable<Car> GetCars()
    {
        return _dataService.GetCarsFromDb();
    }
    [HttpPost]
    [Route("PostCar")]
    public void PostCar([FromBody]Car car)
    {
        _dataService.SaveCarToDb(car);
    }
}



