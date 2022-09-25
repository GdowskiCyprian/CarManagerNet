using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
     //test
     [HttpDelete("{carId:int}")]
     public void DeleteCarById(int carId)
     {
         _dataContext.Cars.RemoveRange(_dataContext.Cars.Where(x => x.CarId == carId));
         _dataContext.SaveChanges();
     }
     //done getCarsByClientId
     [HttpGet("{clientId:int}")]
     public Task<List<Car>> GetCarsByClientId(int clientId)
     {
         return _dataContext.Cars
             .Where(x => x.Client.ClientId == clientId)
             .Include(x => x.Client)
             .Select(x=>new Car()
             {
                 CarId = x.CarId,
                 Displacement = x.Displacement,
                 MakeYear = x.MakeYear,
                 Manufacturer = x.Manufacturer,
                 Mileage = x.Mileage,
                 Model = x.Model,
                 Power = x.Power,
                 Version = x.Version,
                 Client = new Client()
                 {
                     ClientId = x.Client.ClientId //added which properties should be visible to applications that use this API.
                 }
             })
             .ToListAsync();
     }
     //done updateCar
     [HttpPut]
     public void UpdateCar([FromBody] Car car)
     {
         _dataContext.Update(car);
         _dataContext.SaveChanges();
     }

}



