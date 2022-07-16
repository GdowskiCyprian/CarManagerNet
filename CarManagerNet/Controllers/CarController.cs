using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarManagerNet.Controllers;

[ApiController]
[Route("[controller]")]
public class CarController
{
    private readonly DataContext _dataContext;
    public CarController(DataContext context)
    {
        _dataContext = context;
    }
    //done postCar
     [HttpPost]
     public async void PostCar([FromBody]Car car)
     {
         await _dataContext.Cars.AddAsync(car);
         await _dataContext.SaveChangesAsync();
     }
     //done deleteCar
     [HttpDelete("{carId:int}")]
     public void DeleteCarById(int carId)
     {
         _dataContext.Cars.RemoveRange(_dataContext.Cars.Where(x => x.CarId == carId));
     }
     //done getCarsByClientId
     [HttpGet("{clientId:int}")]
     public async Task<List<Car>> GetCarsByClientId(int clientId)
     {
         return await _dataContext.Cars.Where(x => x.Client.ClientId == clientId).ToListAsync();
     }
     //done updateCar
     [HttpPut]
     public void UpdateCar([FromBody]Car car)
     {
         _dataContext.Update(car);
     }
    
    //
    // //dont think this is going to be needed later in application
    // [HttpGet]
    // public async Task<List<Car>> GetCars()
    // {
    //     return await _dataContext.Cars.ToListAsync();
    // }
    //
    // [HttpGet("{id}")]
    // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Car))]
    // [ProducesResponseType(StatusCodes.Status404NotFound)]
    // public async Task<Car> GetCarById(int id)
    // {
    //     return (await _dataContext.Cars.FindAsync(id))!;
    // }

}



