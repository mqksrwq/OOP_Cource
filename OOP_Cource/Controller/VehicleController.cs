using OOP_Cource.DTO;
using OOP_Cource.Service;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OOP_Cource.Controller
{
    /// <summary>
    /// Контроллер управления транспортом — обрабатывает запросы и преобразует модели в DTO
    /// </summary>
    public class VehicleController
    {
        private readonly VehicleService _vehicleService;

        /// <summary>
        /// Инициализирует контроллер и создаёт экземпляр сервиса
        /// </summary>
        public VehicleController()
        {
            _vehicleService = new VehicleService();
        }

        /// <summary>
        /// Возвращает список всех транспортных средств в виде DTO
        /// </summary>
        public async Task<List<VehicleDTO>> GetAllAsync()
        {
            var vehicles = await _vehicleService.GetAllAsync();

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id       = vehicle.Id,
                Number   = vehicle.Number,
                District = vehicle.District,
                Model    = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status   = vehicle.Status
            }).ToList();
        }

        /// <summary>
        /// Возвращает транспортное средство по идентификатору в виде DTO
        /// </summary>
        public async Task<VehicleDTO> GetByIdAsync(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);

            return new VehicleDTO
            {
                Id       = vehicle.Id,
                Number   = vehicle.Number,
                District = vehicle.District,
                Model    = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status   = vehicle.Status
            };
        }

        /// <summary>
        /// Возвращает транспорт по вхождению гос. номера в виде списка DTO
        /// </summary>
        public async Task<List<VehicleDTO>> GetByNumberAsync(string number)
        {
            var vehicles = await _vehicleService.GetByNumberAsync(number);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id       = vehicle.Id,
                Number   = vehicle.Number,
                District = vehicle.District,
                Model    = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status   = vehicle.Status
            }).ToList();
        }

        /// <summary>
        /// Возвращает транспорт по вхождению названия района в виде списка DTO
        /// </summary>
        public async Task<List<VehicleDTO>> GetByDistrictAsync(string district)
        {
            var vehicles = await _vehicleService.GetByDistrictAsync(district);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id       = vehicle.Id,
                Number   = vehicle.Number,
                District = vehicle.District,
                Model    = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status   = vehicle.Status
            }).ToList();
        }

        /// <summary>
        /// Возвращает транспорт по вхождению названия модели в виде списка DTO
        /// </summary>
        public async Task<List<VehicleDTO>> GetByModelAsync(string model)
        {
            var vehicles = await _vehicleService.GetByModelAsync(model);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id       = vehicle.Id,
                Number   = vehicle.Number,
                District = vehicle.District,
                Model    = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status   = vehicle.Status
            }).ToList();
        }

        /// <summary>
        /// Возвращает транспорт по вместимости в виде списка DTO
        /// </summary>
        public async Task<List<VehicleDTO>> GetByCapacityAsync(int capacity)
        {
            var vehicles = await _vehicleService.GetByCapacityAsync(capacity);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id       = vehicle.Id,
                Number   = vehicle.Number,
                District = vehicle.District,
                Model    = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status   = vehicle.Status
            }).ToList();
        }

        /// <summary>
        /// Возвращает транспорт по вхождению статуса в виде списка DTO
        /// </summary>
        public async Task<List<VehicleDTO>> GetByStatusAsync(string status)
        {
            var vehicles = await _vehicleService.GetByStatusAsync(status);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id       = vehicle.Id,
                Number   = vehicle.Number,
                District = vehicle.District,
                Model    = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status   = vehicle.Status
            }).ToList();
        }

        /// <summary>
        /// Добавляет новое транспортное средство через сервис
        /// </summary>
        public async Task AddAsync(string number, string district, string model, int capacity, string status)
        {
            await _vehicleService.AddAsync(number, district, model, capacity, status);
        }

        /// <summary>
        /// Обновляет данные транспортного средства через сервис
        /// </summary>
        public async Task UpdateAsync(int id, string number, string district, string model, int capacity, string status)
        {
            await _vehicleService.UpdateAsync(id, number, district, model, capacity, status);
        }

        /// <summary>
        /// Удаляет транспортное средство по идентификатору через сервис
        /// </summary>
        public async Task DeleteAsync(int id)
        {
            await _vehicleService.DeleteAsync(id);
        }

        /// <summary>
        /// Удаляет все транспортные средства через сервис
        /// </summary>
        public async Task DeleteAllAsync()
        {
            await _vehicleService.DeleteAllAsync();
        }

        /// <summary>
        /// Удаляет все транспортные средства выбранного района через сервис
        /// </summary>
        public async Task DeleteByDistrictAsync(string district)
        {
            await _vehicleService.DeleteByDistrictAsync(district);
        }
    }
}
