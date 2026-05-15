using System;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.Models;
using OOP_Cource.Utils;

namespace OOP_Cource.View.Controls
{
    public partial class AddVehicleControl : UserControl
    {
        private readonly VehicleController _controller;
        private DistrictEnum _district;

        public event Action AddButtonEvent;
        public event Action BackButtonEvent;

        public AddVehicleControl(VehicleController controller)
        {
            InitializeComponent();
            _controller = controller;
        }

        public void SetDistrict(DistrictEnum district)
        {
            _district = district;
            DistrictTextBox.Text = DistrictExtension.GetDisplayName(district);
        }

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

        private void BackButton_Click(object sender, EventArgs e)
        {
            BackButtonEvent?.Invoke();
        }
    }
}
