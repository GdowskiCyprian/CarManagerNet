using System.Data;
using CarManagerNet.Helpers;
using CarManagerNet.Models;
using CarManagerNet.SqlProvider;
using Microsoft.AspNetCore.Http.Extensions;
using MySql.Data.MySqlClient;

namespace CarManagerNet.DataServices;

public class CarDataService
{
    private readonly MySqlProvider _mySqlProvider;

    public CarDataService()
    {
        _mySqlProvider = new MySqlProvider();
    }

    public IEnumerable<Car> GetCarsFromDb()
    {
        _mySqlProvider.ExecuteQuery(out DataTable table, "carmanager.car.getAll");
        foreach (DataRow row in table.Rows)
        {
            yield return RowToModelCar(row);
        }
        
    }

    public void SaveCarToDb(Car car)
    {
        _mySqlProvider.AddSqlParameter("CarId", car.CarId, MySqlDbType.Int32, ParameterDirection.Input);
        _mySqlProvider.AddSqlParameter("MakeYear", car.MakeYear, MySqlDbType.Int32, ParameterDirection.Input);
        _mySqlProvider.AddSqlParameter("Manufacturer", car.Manufacturer, MySqlDbType.String, ParameterDirection.Input);
        _mySqlProvider.AddSqlParameter("Model", car.Model, MySqlDbType.String, ParameterDirection.Input);
        _mySqlProvider.AddSqlParameter("Version", car.Version, MySqlDbType.String, ParameterDirection.Input);
        _mySqlProvider.AddSqlParameter("Displacement", car.Displacement, MySqlDbType.Int32, ParameterDirection.Input);
        _mySqlProvider.AddSqlParameter("Power", car.Power, MySqlDbType.Int32, ParameterDirection.Input);
        _mySqlProvider.AddSqlParameter("Mileage", car.Mileage, MySqlDbType.Int32, ParameterDirection.Input);
        _mySqlProvider.AddSqlParameter("ClientId", car.ClientId, MySqlDbType.Int32, ParameterDirection.Input);
        _mySqlProvider.ExecuteNonQuery("carmanager.car.postCar");
    }

    #region  DataMapping

    private Car RowToModelCar(DataRow row) =>
        new Car
        {
            CarId = row.GetValueAsInt("CarId"),
            MakeYear = row.GetValueAsInt("MakeYear"),
            Manufacturer = row.GetValueAsString("Manufacturer"),
            Model = row.GetValueAsString("Model"),
            Version = row.GetValueAsString("Version"),
            Displacement = row.GetValueAsInt("Displacement"),
            Power = row.GetValueAsInt("Power"),
            Mileage = row.GetValueAsInt("Mileage"),
            ClientId = row.GetValueAsInt("ClientId")
        };

    #endregion
    
}