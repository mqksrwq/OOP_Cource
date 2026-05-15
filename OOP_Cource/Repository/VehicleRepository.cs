using Dapper;
using Npgsql;
using OOP_Cource.Config;
using OOP_Cource.Models;

namespace OOP_Cource.Repository
{
    /// <summary>
    /// Класс репозитория транспорта.
    /// Наследует методы интерфейса IVehicleRepository
    /// </summary>
    public class VehicleRepository : IVehicleRepository
    {
        private readonly string _connectionString;

        public VehicleRepository()
        {
            _connectionString = AppConfig.ConnectionString;
        }

        private NpgsqlConnection CreateConnection()
        {
            return new NpgsqlConnection(_connectionString);
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Vehicles";
            return await connection.QueryAsync<Vehicle>(sql);
        }

        public async Task<Vehicle?> GetByIdAsync(int id)
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Vehicles WHERE Id = @Id";
            return await connection.QueryFirstOrDefaultAsync<Vehicle>(sql, new { Id = id });
        }

        public async Task<IEnumerable<Vehicle>> GetByNumberAsync(string number)
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Vehicles WHERE Number LIKE @Number";
            return await connection.QueryAsync<Vehicle>(sql, new { Number = $"%{number}%" });
        }

        public async Task<IEnumerable<Vehicle>> GetByDistrictAsync(string district)
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Vehicles WHERE District LIKE @District";
            return await connection.QueryAsync<Vehicle>(sql, new { District = $"%{district}%" });
        }

        public async Task<IEnumerable<Vehicle>> GetByModelAsync(string model)
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Vehicles WHERE Model LIKE @Model";
            return await connection.QueryAsync<Vehicle>(sql, new { Model = $"%{model}%" });
        }

        public async Task<IEnumerable<Vehicle>> GetByCapacityAsync(int capacity)
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Vehicles WHERE Capacity = @Capacity";
            return await connection.QueryAsync<Vehicle>(sql, new { Capacity = capacity });
        }

        public async Task<IEnumerable<Vehicle>> GetByStatusAsync(string status)
        {
            using var connection = CreateConnection();
            var sql = "SELECT * FROM Vehicles WHERE Status LIKE @Status";
            return await connection.QueryAsync<Vehicle>(sql, new { Status = $"%{status}%" });
        }

        public async Task AddAsync(Vehicle newVehicle)
        {
            using var connection = CreateConnection();
            var sql = @"
            INSERT INTO Vehicles (Number, District, Model, Capacity, Status)
            VALUES (@Number, @District, @Model, @Capacity, @Status)
            RETURNING Id";

            newVehicle.Id = await connection.QuerySingleAsync<int>(sql, new
            {
                newVehicle.Number,
                newVehicle.District,
                newVehicle.Model,
                newVehicle.Capacity,
                newVehicle.Status
            });
        }

        public async Task UpdateAsync(Vehicle editVehicle)
        {
            using var connection = CreateConnection();
            var sql = @"
            UPDATE Vehicles
            SET Number = @Number,
                District = @District,
                Model = @Model,
                Capacity = @Capacity,
                Status = @Status
            WHERE Id = @Id";

            await connection.ExecuteAsync(sql, new
            {
                editVehicle.Id,
                editVehicle.Number,
                editVehicle.District,
                editVehicle.Model,
                editVehicle.Capacity,
                editVehicle.Status
            });
        }

        public async Task DeleteAsync(int id)
        {
            using var connection = CreateConnection();
            var sql = "DELETE FROM Vehicles WHERE Id = @Id";
            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task DeleteAllAsync()
        {
            using var connection = CreateConnection();
            var sql = "DELETE FROM Vehicles";
            await connection.ExecuteAsync(sql);
        }
    }
}
