using CarManagerNet.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace CarManagerNet.Helpers;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Auth> Auths { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<FuelTank> FuelTanks { get; set; }
    public DbSet<Refuel> Refuels { get; set; }
    public DbSet<Repair> Repairs { get; set; }
    public DbSet<RepairPart> RepairParts { get; set; }
    public DbSet<RepairShop> RepairShops { get; set; }
    
}