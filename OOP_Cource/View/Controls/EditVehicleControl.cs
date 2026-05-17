using System;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.DTO;

namespace OOP_Cource.View.Controls
{
    /// <summary>
    /// Элемент управления для редактирования данных транспортного средства
    /// </summary>
    public partial class EditVehicleControl : UserControl
    {
        private readonly VehicleController _controller;
        private VehicleDTO _vehicle;

        /// <summary>
        /// Событие нажатия кнопки возврата без сохранения
        /// </summary>
        public event Action BackButtonEvent;

        /// <summary>
        /// Событие успешного сохранения изменений транспортного средства
        /// </summary>
        public event Action SaveButtonEvent;

        /// <summary>
        /// Инициализирует элемент управления с пустым DTO транспортного средства
        /// </summary>
        public EditVehicleControl(VehicleController controller) : this(controller, new VehicleDTO())
        {
        }

        /// <summary>
        /// Инициализирует элемент управления с переданным DTO транспортного средства
        /// </summary>
        public EditVehicleControl(VehicleController controller, VehicleDTO vehicle)
        {
            InitializeComponent();
            _controller = controller;
            _vehicle = vehicle;
        }

        /// <summary>
        /// Заполняет поля ввода данными текущего транспортного средства при загрузке
        /// </summary>
        private void EditVehicleControl_Load(object sender, EventArgs e)
        {
            FillFields();
        }

        /// <summary>
        /// Заполняет поля ввода значениями из DTO транспортного средства
        /// </summary>
        private void FillFields()
        {
            NumberTextBox.Text = _vehicle.Number;
            DistrictTextBox.Text = _vehicle.District;
            ModelTextBox.Text = _vehicle.Model;
            CapacityTextBox.Text = _vehicle.Capacity.ToString();
            StatusComboBox.Text = _vehicle.Status;
        }

        /// <summary>
        /// Обновляет DTO транспортного средства и заполняет поля ввода
        /// </summary>
        public void SetVehicle(VehicleDTO vehicle)
        {
            _vehicle = vehicle;
            FillFields();
        }

        /// <summary>
        /// Валидирует поля, сохраняет изменения и вызывает событие успеха
        /// </summary>
        private async void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                var number = NumberTextBox.Text;
                var district = DistrictTextBox.Text;
                var model = ModelTextBox.Text;
                var status = StatusComboBox.Text;

                if (!int.TryParse(CapacityTextBox.Text, out int capacity))
                    throw new ArgumentException("В поле 'Вместимость' введено не число!");

                await _controller.UpdateAsync(_vehicle.Id, number, district, model, capacity, status);

                MessageBox.Show("Данные успешно обновлены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SaveButtonEvent?.Invoke();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка обновления данных", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Вызывает событие возврата без сохранения изменений
        /// </summary>
        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonEvent?.Invoke();
        }
    }
}
