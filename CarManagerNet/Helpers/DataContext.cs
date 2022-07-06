using CarManagerNet.Models;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace CarManagerNet.Helpers;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public DbSet<Car> Cars { get; set; }
    public DbSet<Client> Clients { get; set; }
}