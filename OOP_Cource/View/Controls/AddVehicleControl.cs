using System;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.Models;
using OOP_Cource.Utils;

namespace OOP_Cource.View.Controls
{
    /// <summary>
    /// Элемент управления для добавления нового транспортного средства
    /// </summary>
    public partial class AddVehicleControl : UserControl
    {
        private readonly VehicleController _controller;
        private DistrictEnum _district;

        /// <summary>
        /// Событие успешного добавления транспортного средства
        /// </summary>
        public event Action AddButtonEvent;

        /// <summary>
        /// Событие нажатия кнопки возврата без добавления
        /// </summary>
        public event Action BackButtonEvent;

        /// <summary>
        /// Инициализирует элемент управления и устанавливает начальный статус
        /// </summary>
        public AddVehicleControl(VehicleController controller)
        {
            InitializeComponent();
            _controller = controller;
            StatusComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Устанавливает выбранный район и отображает его в поле ввода
        /// </summary>
        public void SetDistrict(DistrictEnum district)
        {
            _district = district;
            DistrictTextBox.Text = DistrictExtension.GetDisplayName(district);
        }

        /// <summary>
        /// Валидирует поля, отправляет запрос на добавление транспорта и вызывает событие успеха
        /// </summary>
        private async void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                var number = NumberTextBox.Text;
                var model = ModelTextBox.Text;
                var status = StatusComboBox.Text;

                if (!int.TryParse(CapacityTextBox.Text, out int capacity))
                    throw new ArgumentException("В поле 'Вместимость' введено не число!");

                await _controller.AddAsync(number, DistrictExtension.GetDisplayName(_district), model, capacity, status);

                MessageBox.Show("Транспорт успешно добавлен!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AddButtonEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка добавления транспорта", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Вызывает событие возврата без сохранения
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonEvent?.Invoke();
        }
    }
}
