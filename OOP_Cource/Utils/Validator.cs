using System.Text.RegularExpressions;
using System;

namespace OOP_Cource.Utils
{
    /// <summary>
    /// Статический утилитный класс для валидации значений параметров модели
    /// </summary>
    public static class Validator
    {
        public static void ValidateNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Гос. номер не может быть пустым");

            if (number.Length < 4)
                throw new ArgumentException("Гос. номер должен содержать минимум 4 символа");

            if (number.Length > 20)
                throw new ArgumentException("Гос. номер не может превышать 20 символов");

            if (!Regex.IsMatch(number, @"^[a-zA-Zа-яА-ЯёЁ0-9\s\-]+$"))
                throw new ArgumentException("Гос. номер содержит недопустимые символы");
        }

        public static void ValidateDistrict(string district)
        {
            if (string.IsNullOrWhiteSpace(district))
                throw new ArgumentException("Район движения не может быть пустым");

            if (district.Length < 2)
                throw new ArgumentException("Район движения должен содержать минимум 2 символа");
        }

        public static void ValidateModel(string model)
        {
            if (string.IsNullOrWhiteSpace(model))
                throw new ArgumentException("Модель не может быть пустой");

            if (model.Length < 2)
                throw new ArgumentException("Модель должна содержать минимум 2 символа");
        }

        public static void ValidateCapacity(int capacity)
        {
            if (capacity <= 0)
                throw new ArgumentException("Вместимость должна быть больше нуля");

            if (capacity > 200)
                throw new ArgumentException("Вместимость не может превышать 200 мест");
        }

        public static void ValidateStatus(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
                throw new ArgumentException("Статус не может быть пустым");
        }

        public static void ValidateVehicle(string number, string district, string model, int capacity, string status)
        {
            ValidateNumber(number);
            ValidateDistrict(district);
            ValidateModel(model);
            ValidateCapacity(capacity);
            ValidateStatus(status);
        }
    }
}
