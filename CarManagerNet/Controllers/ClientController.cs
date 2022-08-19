using CarManagerNet.Helpers;
using CarManagerNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarManagerNet.Controllers;
[ApiController]
[Route("[controller]")]
public class ClientController
{
    private readonly DataContext _dataContext;
    public ClientController(DataContext context)
    {
        _dataContext = context;
    }
    //done GetClientsByRepairShopId
    [HttpGet("{repairShopId:int}")]
    public async Task<List<Client>> GetClientsByRepairShopId(int repairShopId)
    {
        return await _dataContext.Clients
            .Include(x=>x.Auth)
            .Select(x=> new Client()
            {
                ClientId = x.ClientId,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Surname = x.Surname,
                RepairShop = new RepairShop()
                {
                    RepairShopId = x.RepairShop.RepairShopId
                },
                Auth = new Auth()
                {
                    Email = x.Auth.Email
                }
            })
            .Where(x => x.RepairShop.RepairShopId == repairShopId)
            .ToListAsync();
    }
    //done GetClientByMail
    [HttpGet("getClientByMail/{eMail}")]
    public Client GetClientByMail(string eMail)
    {
        return _dataContext.Clients
            .Include(x => x.Auth)
            .Select(x => new Client()
            {
                ClientId = x.ClientId,
                Name = x.Name,
                PhoneNumber = x.PhoneNumber,
                Surname = x.Surname,
                Auth = new Auth()
                {
                    Email = x.Auth.Email
                }
            })
            .First(x => x.Auth.Email == eMail);

    }
    //done DeleteClient
    [HttpDelete("{clientId:int}")]
    public void DeleteClientById(int clientId)
    {
        _dataContext.Clients.RemoveRange(_dataContext.Clients.Where(x => x.ClientId == clientId));
        _dataContext.SaveChanges();
    }
    //done PostClient
    [HttpPost]
    public void PostClient([FromBody] Client client)
    {
        _dataContext.Clients.Add(client);
        _dataContext.SaveChanges();
    }
}