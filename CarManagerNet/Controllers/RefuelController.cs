using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarManagerNet.Controllers;

public class RefuelController
{
    private DataContext _dataContext;

    public RefuelController(DataContext context)
    {
        _dataContext = context;
    }
    //done PostRefuel
    [HttpPost]
    public async void PostRefuel([FromBody]Refuel refuel)
    {
        await _dataContext.Refuels.AddAsync(refuel);
        await _dataContext.SaveChangesAsync();
    }
    //done DeleteRefuelById
    [HttpDelete("{refuelId:int}")]
    public void DeleteRefuelById(int refuelId)
    {
        _dataContext.Refuels.RemoveRange(_dataContext.Refuels.Where(x => x.RefuelId == refuelId));
        _dataContext.SaveChanges();
    }
    //done GetRefuelsByRepairShopId
    [HttpGet("{repairShopId:int}")]
    public async Task<List<Refuel>> GetRefuelsByRepairShopId(int repairShopId)
    {
        return await _dataContext.Refuels.Where(x => x.FuelTank.Car.Client.RepairShop.RepairShopId == repairShopId)
            .ToListAsync();
    }
}