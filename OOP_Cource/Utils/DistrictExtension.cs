using OOP_Cource.Models;

namespace OOP_Cource.Utils
{
    /// <summary>
    /// Статический класс-расширение для отображения районов
    /// </summary>
    public static class DistrictExtension
    {
        /// <summary>
        /// Возвращает отображаемое имя района на русском языке
        /// </summary>
        public static string GetDisplayName(DistrictEnum district)
        {
            return district switch
            {
                DistrictEnum.Oktyabrsky => "Октябрьский район",
                DistrictEnum.Zheleznodorozhny => "Железнодорожный район",
                DistrictEnum.Ternovka => "Терновка",
                DistrictEnum.Gpz => "ГПЗ",
                _ => district.ToString()
            };
        }
    }
}
