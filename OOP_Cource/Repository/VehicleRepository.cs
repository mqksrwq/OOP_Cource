using OOP_Cource.Config;
using OOP_Cource.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OOP_Cource.Repository
{
    public class VehicleRepository : IVehicleRepository
    {
        private static readonly object StorageLock = new object();
        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        private readonly string _databasePath;

        public VehicleRepository()
        {
            _databasePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppConfig.LocalDatabasePath);
            EnsureStorageCreated();
        }

        public Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Vehicle>>(ReadVehicles());
        }

        public Task<Vehicle> GetByIdAsync(int id)
        {
            var vehicle = ReadVehicles().FirstOrDefault(item => item.Id == id);
            return Task.FromResult(vehicle);
        }

        public Task<IEnumerable<Vehicle>> GetByNumberAsync(string number)
        {
            var vehicles = ReadVehicles()
                .Where(vehicle => ContainsIgnoreCase(vehicle.Number, number))
                .ToList();

            return Task.FromResult<IEnumerable<Vehicle>>(vehicles);
        }

        public Task<IEnumerable<Vehicle>> GetByDistrictAsync(string district)
        {
            var vehicles = ReadVehicles()
                .Where(vehicle => ContainsIgnoreCase(vehicle.District, district))
                .ToList();

            return Task.FromResult<IEnumerable<Vehicle>>(vehicles);
        }

        public Task<IEnumerable<Vehicle>> GetByModelAsync(string model)
        {
            var vehicles = ReadVehicles()
                .Where(vehicle => ContainsIgnoreCase(vehicle.Model, model))
                .ToList();

            return Task.FromResult<IEnumerable<Vehicle>>(vehicles);
        }

        public Task<IEnumerable<Vehicle>> GetByCapacityAsync(int capacity)
        {
            var vehicles = ReadVehicles()
                .Where(vehicle => vehicle.Capacity == capacity)
                .ToList();

            return Task.FromResult<IEnumerable<Vehicle>>(vehicles);
        }

        public Task<IEnumerable<Vehicle>> GetByStatusAsync(string status)
        {
            var vehicles = ReadVehicles()
                .Where(vehicle => ContainsIgnoreCase(vehicle.Status, status))
                .ToList();

            return Task.FromResult<IEnumerable<Vehicle>>(vehicles);
        }

        public Task AddAsync(Vehicle newVehicle)
        {
            lock (StorageLock)
            {
                var vehicles = ReadVehiclesUnsafe();
                newVehicle.Id = GetNextId(vehicles);
                vehicles.Add(newVehicle);
                WriteVehiclesUnsafe(vehicles);
            }

            return Task.CompletedTask;
        }

        public Task UpdateAsync(Vehicle editVehicle)
        {
            lock (StorageLock)
            {
                var vehicles = ReadVehiclesUnsafe();
                var vehicle = vehicles.FirstOrDefault(item => item.Id == editVehicle.Id);
                if (vehicle != null)
                {
                    vehicle.Number = editVehicle.Number;
                    vehicle.District = editVehicle.District;
                    vehicle.Model = editVehicle.Model;
                    vehicle.Capacity = editVehicle.Capacity;
                    vehicle.Status = editVehicle.Status;
                    WriteVehiclesUnsafe(vehicles);
                }
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            lock (StorageLock)
            {
                var vehicles = ReadVehiclesUnsafe();
                vehicles.RemoveAll(vehicle => vehicle.Id == id);
                WriteVehiclesUnsafe(vehicles);
            }

            return Task.CompletedTask;
        }

        public Task DeleteAllAsync()
        {
            lock (StorageLock)
            {
                WriteVehiclesUnsafe(new List<Vehicle>());
            }

            return Task.CompletedTask;
        }

        public Task DeleteByDistrictAsync(string district)
        {
            lock (StorageLock)
            {
                var vehicles = ReadVehiclesUnsafe();
                vehicles.RemoveAll(vehicle => string.Equals(vehicle.District, district, StringComparison.OrdinalIgnoreCase));
                WriteVehiclesUnsafe(vehicles);
            }

            return Task.CompletedTask;
        }

        private void EnsureStorageCreated()
        {
            lock (StorageLock)
            {
                var directory = Path.GetDirectoryName(_databasePath);
                if (!string.IsNullOrEmpty(directory))
                    Directory.CreateDirectory(directory);

                if (!File.Exists(_databasePath))
                    WriteVehiclesUnsafe(new List<Vehicle>());
            }
        }

        private List<Vehicle> ReadVehicles()
        {
            lock (StorageLock)
            {
                return ReadVehiclesUnsafe();
            }
        }

        private List<Vehicle> ReadVehiclesUnsafe()
        {
            if (!File.Exists(_databasePath))
                return new List<Vehicle>();

            var json = File.ReadAllText(_databasePath);
            if (string.IsNullOrWhiteSpace(json))
                return new List<Vehicle>();

            try
            {
                return JsonSerializer.Deserialize<List<Vehicle>>(json) ?? new List<Vehicle>();
            }
            catch (JsonException)
            {
                return new List<Vehicle>();
            }
        }

        private void WriteVehiclesUnsafe(List<Vehicle> vehicles)
        {
            var json = JsonSerializer.Serialize(vehicles, JsonOptions);
            File.WriteAllText(_databasePath, json);
        }

        private static int GetNextId(IEnumerable<Vehicle> vehicles)
        {
            return vehicles.Any()
                ? vehicles.Max(vehicle => vehicle.Id) + 1
                : 1;
        }

        private static bool ContainsIgnoreCase(string source, string value)
        {
            if (string.IsNullOrEmpty(value))
                return true;

            return source != null && source.IndexOf(value, StringComparison.OrdinalIgnoreCase) >= 0;
        }
    }
}
