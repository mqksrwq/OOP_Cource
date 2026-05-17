using OOP_Cource.Models;
using OOP_Cource.Repository;
using OOP_Cource.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_Cource.Service
{
    /// <summary>
    /// Сервис работы с транспортом — основной слой бизнес-логики
    /// </summary>
    public class VehicleService
    {
        private readonly VehicleRepository _vehicleRepository;

        /// <summary>
        /// Инициализирует сервис и создаёт экземпляр репозитория
        /// </summary>
        public VehicleService()
        {
            _vehicleRepository = new VehicleRepository();
        }

        /// <summary>
        /// Валидирует данные и добавляет новый транспорт в репозиторий
        /// </summary>
        public async Task AddAsync(string number, string district, string model, int capacity, string status)
        {
            Validator.ValidateVehicle(number, district, model, capacity, status);

            var vehicles = await _vehicleRepository.GetByNumberAsync(number);
            if (vehicles.Any())
                throw new ArgumentException("Транспорт с таким гос. номером уже существует!");

            var newVehicle = new Vehicle(number, district, model, capacity, status);
            await _vehicleRepository.AddAsync(newVehicle);
        }

        /// <summary>
        /// Возвращает все транспортные средства из репозитория
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetAllAsync()
        {
            return await _vehicleRepository.GetAllAsync();
        }

        /// <summary>
        /// Возвращает транспортное средство по идентификатору
        /// </summary>
        public async Task<Vehicle> GetByIdAsync(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id не может быть отрицательным!");

            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
                throw new ArgumentException($"Транспорт с id = {id} не найден!");

            return vehicle;
        }

        /// <summary>
        /// Возвращает транспорт по вхождению гос. номера
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByNumberAsync(string number)
        {
            return await _vehicleRepository.GetByNumberAsync(number);
        }

        /// <summary>
        /// Возвращает транспорт по вхождению названия района
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByDistrictAsync(string district)
        {
            return await _vehicleRepository.GetByDistrictAsync(district);
        }

        /// <summary>
        /// Возвращает транспорт по вхождению названия модели
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByModelAsync(string model)
        {
            return await _vehicleRepository.GetByModelAsync(model);
        }

        /// <summary>
        /// Валидирует вместимость и возвращает транспорт с указанной вместимостью
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByCapacityAsync(int capacity)
        {
            Validator.ValidateCapacity(capacity);
            return await _vehicleRepository.GetByCapacityAsync(capacity);
        }

        /// <summary>
        /// Возвращает транспорт по вхождению статуса
        /// </summary>
        public async Task<IEnumerable<Vehicle>> GetByStatusAsync(string status)
        {
            return await _vehicleRepository.GetByStatusAsync(status);
        }

        /// <summary>
        /// Валидирует данные и обновляет транспорт в репозитории
        /// </summary>
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

        /// <summary>
        /// Проверяет существование транспорта и удаляет его по идентификатору
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            if (id < 0)
                throw new ArgumentException("Id не может быть отрицательным!");

            var vehicle = await _vehicleRepository.GetByIdAsync(id);
            if (vehicle == null)
                throw new ArgumentException($"Транспорт с id = {id} не найден!");

            await _vehicleRepository.DeleteAsync(id);
        }

        /// <summary>
        /// Удаляет все транспортные средства из репозитория
        /// </summary>
        public async Task DeleteAllAsync()
        {
            await _vehicleRepository.DeleteAllAsync();
        }

        /// <summary>
        /// Валидирует район и удаляет все транспортные средства выбранного района
        /// </summary>
        public async Task DeleteByDistrictAsync(string district)
        {
            Validator.ValidateDistrict(district);
            await _vehicleRepository.DeleteByDistrictAsync(district);
        }
    }
}
