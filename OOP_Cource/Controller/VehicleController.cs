using OOP_Cource.DTO;
using OOP_Cource.Service;

namespace OOP_Cource.Controller
{
    /// <summary>
    /// Контроллер для управления транспортом.
    /// Обрабатывает запросы и преобразует модели в DTO
    /// </summary>
    public class VehicleController
    {
        private readonly VehicleService _vehicleService;

        public VehicleController()
        {
            _vehicleService = new VehicleService();
        }

        public async Task<List<VehicleDTO>> GetAllAsync()
        {
            var vehicles = await _vehicleService.GetAllAsync();

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id = vehicle.Id,
                Number = vehicle.Number,
                District = vehicle.District,
                Model = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status = vehicle.Status
            }).ToList();
        }

        public async Task<VehicleDTO> GetByIdAsync(int id)
        {
            var vehicle = await _vehicleService.GetByIdAsync(id);

            return new VehicleDTO
            {
                Id = vehicle.Id,
                Number = vehicle.Number,
                District = vehicle.District,
                Model = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status = vehicle.Status
            };
        }

        public async Task<List<VehicleDTO>> GetByNumberAsync(string number)
        {
            var vehicles = await _vehicleService.GetByNumberAsync(number);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id = vehicle.Id,
                Number = vehicle.Number,
                District = vehicle.District,
                Model = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status = vehicle.Status
            }).ToList();
        }

        public async Task<List<VehicleDTO>> GetByDistrictAsync(string district)
        {
            var vehicles = await _vehicleService.GetByDistrictAsync(district);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id = vehicle.Id,
                Number = vehicle.Number,
                District = vehicle.District,
                Model = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status = vehicle.Status
            }).ToList();
        }

        public async Task<List<VehicleDTO>> GetByModelAsync(string model)
        {
            var vehicles = await _vehicleService.GetByModelAsync(model);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id = vehicle.Id,
                Number = vehicle.Number,
                District = vehicle.District,
                Model = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status = vehicle.Status
            }).ToList();
        }

        public async Task<List<VehicleDTO>> GetByCapacityAsync(int capacity)
        {
            var vehicles = await _vehicleService.GetByCapacityAsync(capacity);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id = vehicle.Id,
                Number = vehicle.Number,
                District = vehicle.District,
                Model = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status = vehicle.Status
            }).ToList();
        }

        public async Task<List<VehicleDTO>> GetByStatusAsync(string status)
        {
            var vehicles = await _vehicleService.GetByStatusAsync(status);

            return vehicles.Select(vehicle => new VehicleDTO
            {
                Id = vehicle.Id,
                Number = vehicle.Number,
                District = vehicle.District,
                Model = vehicle.Model,
                Capacity = vehicle.Capacity,
                Status = vehicle.Status
            }).ToList();
        }

        public async Task AddAsync(string number, string district, string model, int capacity, string status)
        {
            await _vehicleService.AddAsync(number, district, model, capacity, status);
        }

        public async Task UpdateAsync(int id, string number, string district, string model, int capacity, string status)
        {
            await _vehicleService.UpdateAsync(id, number, district, model, capacity, status);
        }

        public async Task DeleteAsync(int id)
        {
            await _vehicleService.DeleteAsync(id);
        }

        public async Task DeleteAllAsync()
        {
            await _vehicleService.DeleteAllAsync();
        }
    }
}
