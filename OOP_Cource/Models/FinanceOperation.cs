using System;

namespace OOP_Cource.Models
{
    /// <summary>
    /// Модель финансовой операции (доход или расход) автопарка
    /// </summary>
    public class FinanceOperation
    {
        /// <summary>
        /// Уникальный идентификатор операции
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Дата проведения операции
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Тип операции: доход или расход
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Категория финансовой операции
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Сумма финансовой операции
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Комментарий к финансовой операции
        /// </summary>
        public string Comment { get; set; }
    }
}
