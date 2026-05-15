using OOP_Cource.Models;

namespace OOP_Cource.Repository
{
    /// <summary>
    /// Интерфейс репозитория транспорта
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Асинхронный метод для получения всех объектов репозитория
        /// </summary>
        Task<IEnumerable<Vehicle>> GetAllAsync();

        /// <summary>
        /// Асинхронный метод для получения объекта по id
        /// </summary>
        Task<Vehicle?> GetByIdAsync(int id);

        /// <summary>
        /// Асинхронный метод для получения объектов по гос. номеру
        /// </summary>
        Task<IEnumerable<Vehicle>> GetByNumberAsync(string number);

        /// <summary>
        /// Асинхронный метод для получения объектов по району
        /// </summary>
        Task<IEnumerable<Vehicle>> GetByDistrictAsync(string district);

        /// <summary>
        /// Асинхронный метод для получения объектов по модели
        /// </summary>
        Task<IEnumerable<Vehicle>> GetByModelAsync(string model);

        /// <summary>
        /// Асинхронный метод для получения объектов по вместимости
        /// </summary>
        Task<IEnumerable<Vehicle>> GetByCapacityAsync(int capacity);

        /// <summary>
        /// Асинхронный метод для получения объектов по статусу
        /// </summary>
        Task<IEnumerable<Vehicle>> GetByStatusAsync(string status);

        /// <summary>
        /// Асинхронный метод для добавления нового объекта
        /// </summary>
        Task AddAsync(Vehicle newVehicle);

        /// <summary>
        /// Асинхронный метод для обновления свойств объекта
        /// </summary>
        Task UpdateAsync(Vehicle editVehicle);

        /// <summary>
        /// Асинхронный метод для удаления объекта по id
        /// </summary>
        Task DeleteAsync(int id);

        /// <summary>
        /// Асинхронный метод для удаления всех записей
        /// </summary>
        Task DeleteAllAsync();
    }
}
