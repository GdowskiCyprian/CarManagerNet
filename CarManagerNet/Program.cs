using CarManagerNet.Helpers;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options =>
{
    var connection = new MySqlConnectionStringBuilder
    {
        Server = "localhost",
        Database = "carmanager",
        UserID = "root",
        Password = "Plokiploki1"
    };
    options.UseMySql(connection.ConnectionString, ServerVersion.AutoDetect(connection.ConnectionString));
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//todo fix warning in models
//todo JSON serialization blocking
//todo JWT token authorization