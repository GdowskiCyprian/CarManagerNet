using CarManagerNet.DataServices;
using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarManagerNet.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController
{
    private readonly CarDataService _dataService;
    private DataContext _dataContext;

    public CarController(DataContext context)
    {
        _dataService = new CarDataService();
        _dataContext = context;
    }

    [HttpGet]
    [Route("GetCars")]
    public IEnumerable<Car> GetCars()
    {
        return _dataContext.Cars;
    }
    [HttpPost]
    [Route("PostCar")]
    public void PostCar([FromBody]Car car)
    {
        _dataContext.Add(car);
    }
}



