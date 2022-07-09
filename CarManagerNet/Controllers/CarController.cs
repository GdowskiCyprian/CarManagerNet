using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarManagerNet.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController
{
    //todo postCar
    //todo deleteCar
    //todo getCarsByClientId
    //todo updateCar
    
    private DataContext _dataContext;
    public CarController(DataContext context)
    {
        _dataContext = context;
    }

    [HttpGet]
    public async Task<List<Car>> GetCars()
    {
        return await _dataContext.Cars.ToListAsync();
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Car))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<Car> GetCarById(int id)
    {
        return await _dataContext.Cars.FindAsync(id);
    }
    [HttpPost]
    public async void PostCar([FromBody]Car car)
    {
        await _dataContext.Cars.AddAsync(car);
        await _dataContext.SaveChangesAsync();
    }
}



