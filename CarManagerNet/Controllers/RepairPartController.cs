using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarManagerNet.Controllers;
[ApiController]
[Route("[controller]")]
public class RepairPartController
{
    private readonly DataContext _dataContext;

    public RepairPartController(DataContext context)
    {
        _dataContext = context;
    }
    //done PostRepairPart
    [HttpPost]
    public async void PostRepairPart([FromBody] RepairPart repairPart)
    {
        await _dataContext.AddAsync(repairPart);
        await _dataContext.SaveChangesAsync();
    }
    //done DeleteRepairPartById
    [HttpDelete("{repairPartId:int}")]
    public void DeleteRepairPartById(int repairPartId)
    {
        _dataContext.RepairParts.Remove(_dataContext.RepairParts.First(x => x.RepairPartId == repairPartId));
    }
}