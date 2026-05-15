using OOP_Cource.Models;
using OOP_Cource.Repository;
using OOP_Cource.Utils;

namespace OOP_Cource.Service
{
    /// <summary>
    /// Класс, представляющий сервис работы с моделью.
    /// Основной слой бизнес-логика
    /// </summary>
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;

        public VehicleService()
        {
            _vehicleRepository = new VehicleRepository();
        }

        public async Task AddAsync(string number, string district, string model, int capacity, string status)
        {
            Validator.ValidateVehicle(number, district, model, capacity, status);

            var vehicles = await _vehicleRepository.GetByNumberAsync(number);
            if (vehicles.Any())
                throw new ArgumentException("Транспорт с таким гос. номером уже существует!");

            var newVehicle = new Vehicle(number, district, model, capacity, status);
            await _vehicleRepository.AddAsync(newVehicle);
        }

        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _vehicleRepository.GetAllAsync();
        }

        public async Task<Vehicle> GetByIdAsync(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id не может быть отрицательным!");

            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
                throw new ArgumentException($"Транспорт с id = {id} не найден!");

            return vehicle;
        }

        public async Task<IEnumerable<Vehicle>> GetByNumberAsync(string number)
        {
            return await _vehicleRepository.GetByNumberAsync(number);
        }

        public async Task<IEnumerable<Vehicle>> GetByDistrictAsync(string district)
        {
            return await _vehicleRepository.GetByDistrictAsync(district);
        }

        public async Task<IEnumerable<Vehicle>> GetByModelAsync(string model)
        {
            return await _vehicleRepository.GetByModelAsync(model);
        }

        public async Task<IEnumerable<Vehicle>> GetByCapacityAsync(int capacity)
        {
            Validator.ValidateCapacity(capacity);
            return await _vehicleRepository.GetByCapacityAsync(capacity);
        }

        public async Task<IEnumerable<Vehicle>> GetByStatusAsync(string status)
        {
            return await _vehicleRepository.GetByStatusAsync(status);
        }

        public async Task UpdateAsync(int id, string number, string district, string model, int capacity, string status)
        {
            if (id < 0)
                throw new ArgumentException("Указан неверный Id!");

            Validator.ValidateVehicle(number, district, model, capacity, status);

            var editVehicle = await _vehicleRepository.GetByIdAsync(id);
            if (editVehicle == null)
                throw new ArgumentException($"Транспорт с id = {id} не найден!");

            editVehicle.Number = number;
            editVehicle.District = district;
            editVehicle.Model = model;
            editVehicle.Capacity = capacity;
            editVehicle.Status = status;

            await _vehicleRepository.UpdateAsync(editVehicle);
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id не может быть отрицательным!");

            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
                throw new ArgumentException($"Транспорт с id = {id} не найден!");

            await _vehicleRepository.DeleteAsync(id);
        }

        public async Task DeleteAllAsync()
        {
            await _vehicleRepository.DeleteAllAsync();
        }
    }
}
