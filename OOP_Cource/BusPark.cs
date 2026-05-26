using System;
using System.Collections.Generic;

namespace KursProject_Boyarkin_OOP
{
    /// <summary>
    /// Модель транспортного средства автобусного парка.
    /// Хранит данные об одной единице подвижного состава и предоставляет
    /// статический список всех зарегистрированных ТС.
    /// </summary>
    public class BusPark
    {
        /// <summary>
        /// Уникальный идентификатор записи в базе данных.
        /// Присваивается сервером при INSERT и используется при UPDATE/DELETE.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Государственный регистрационный номер транспортного средства.
        /// </summary>
        public string PlateNumber { get; set; }

        /// <summary>
        /// Фамилия, имя и отчество водителя, закреплённого за ТС.
        /// </summary>
        public string Driver { get; set; }

        /// <summary>
        /// Номер или наименование маршрута, по которому работает ТС.
        /// </summary>
        public string Route { get; set; }

        /// <summary>
        /// Суточный доход по маршруту в рублях.
        /// </summary>
        public decimal Income { get; set; }

        /// <summary>
        /// Суточный расход по маршруту в рублях.
        /// </summary>
        public decimal Expense { get; set; }

        /// <summary>
        /// Суточный пробег транспортного средства в километрах.
        /// </summary>
        public int Mileage { get; set; }

        /// <summary>
        /// Глобальный список всех загруженных транспортных средств.
        /// Синхронизируется с базой данных при каждом открытии или создании БД.
        /// </summary>
        public static List<BusPark> Buses = new List<BusPark>();

        /// <summary>
        /// Создаёт новый экземпляр транспортного средства с заданными параметрами.
        /// </summary>
        /// <param name="plateNumber">Государственный регистрационный номер.</param>
        /// <param name="driver">ФИО водителя.</param>
        /// <param name="route">Номер или название маршрута.</param>
        /// <param name="income">Суточный доход в рублях.</param>
        /// <param name="expense">Суточный расход в рублях.</param>
        /// <param name="mileage">Суточный пробег в километрах.</param>
        public BusPark(string plateNumber, string driver, string route,
                       decimal income, decimal expense, int mileage)
        {
            PlateNumber = plateNumber;
            Driver      = driver;
            Route       = route;
            Income      = income;
            Expense     = expense;
            Mileage     = mileage;
        }

        /// <summary>
        /// Добавляет транспортное средство в статический список <see cref="Buses"/>.
        /// </summary>
        /// <param name="bus">Экземпляр ТС, который требуется добавить.</param>
        public static void AddBus(BusPark bus)
        {
            Buses.Add(bus);
        }

        /// <summary>
        /// Удаляет транспортное средство из статического списка <see cref="Buses"/>.
        /// </summary>
        /// <param name="bus">Экземпляр ТС, который требуется удалить.</param>
        public static void RemoveBus(BusPark bus)
        {
            Buses.Remove(bus);
        }
    }
}
