using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarManagerNet.Controllers;
[ApiController]
[Route("[controller]")]
public class RepairController
{
    private readonly DataContext _dataContext;

    public RepairController(DataContext context)
    {
        _dataContext = context;
    }
    //done PostRepair
    [HttpPost]
    public void PostRepair([FromBody] Repair repair)
    { 
        _dataContext.Repairs.Add(repair);
        _dataContext.SaveChanges();
    }
    //done DeleteRepairById
    [HttpDelete("{repairId:int}")]
    public void DeleteRepairById(int repairId)
    {
        _dataContext.Repairs.Remove(_dataContext.Repairs.First(x => x.RepairId == repairId));
        _dataContext.SaveChanges();
    }
    //done GetRepairsByRepairShopId
    [HttpGet("getRepairsByClientId/{repairShopId:int}")]
    public async Task<List<Repair>> GetRepairsByRepairShopId(int repairShopId)
    {
        return await _dataContext.Repairs.Where(x => x.Car.Client.RepairShop.RepairShopId == repairShopId).ToListAsync();
    }
    //done GetRepairsByClientId
    [HttpGet("getRepairsByClientId/{clientId:int}")]
    public async Task<List<Repair>> GetRepairsByClientId(int clientId)
    {
        return await _dataContext.Repairs.Where(x => x.Car.Client.ClientId == clientId).ToListAsync();
    }
}