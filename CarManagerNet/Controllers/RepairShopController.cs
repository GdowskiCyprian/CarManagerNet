using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarManagerNet.Controllers;
[ApiController]
[Route("[controller]")]
public class RepairShopController
{
    private readonly DataContext _dataContext;

    public RepairShopController(DataContext context)
    {
        _dataContext = context;
    }
    //done GetRepairShops
    [HttpGet]
    public async Task<List<RepairShop>> GetRepairShops()
    {
        return await _dataContext.RepairShops.Include(x => x.Auth).ToListAsync();
    }
    //done GetRepairShopByEmail
    [HttpGet("getRepairShopByEmail/{eMail}")]
    public RepairShop GetRepairShopByEmail(string eMail)
    {
        return _dataContext.RepairShops.Include(x=>x.Auth).First(x => x.Auth.Email == eMail);
    }
    //done DeleteRepairShopById
    [HttpDelete("{repairShopId:int}")]
    public void DeleteRepairShopById(int repairShopId)
    {
        _dataContext.RepairShops.Remove(_dataContext.RepairShops.First(x => x.RepairShopId == repairShopId));
        _dataContext.SaveChanges();
    }
    //done PostRepairShop
    [HttpPost]
    public void PostRepairShop([FromBody] RepairShop repairShop)
    {
        _dataContext.RepairShops.Add(repairShop);
        _dataContext.SaveChanges();
    }
}