using System;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.Models;
using OOP_Cource.View.Controls;

namespace OOP_Cource.Forms
{
    /// <summary>
    /// Форма администратора для управления транспортом
    /// </summary>
    public partial class AdminForm : Form
    {
        private readonly VehicleController _controller;
        private readonly AdminControl _control;
        private AddVehicleControl _addControl;
        private EditVehicleControl _editControl;

        public AdminForm()
        {
            InitializeComponent();

            ShowHelloForm();

            _controller = new VehicleController();
            _control = new AdminControl(_controller);
            _addControl = new AddVehicleControl(_controller);
            _editControl = new EditVehicleControl(_controller);

            _control.AddVehicleRequested += OnAddVehicleRequested;
            _control.ChangeVehicleRequested += OnEditVehicleRequest;
            _control.CloseFormRequest += OnCloseFormRequest;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            _control.Dock = DockStyle.Fill;
            Controls.Add(_control);
        }

        private void ShowHelloForm()
        {
            using var helloForm = new HelloForm();
            helloForm.ShowDialog();
        }

        private void OnAddVehicleRequested(DistrictEnum district)
        {
            Controls.Remove(_control);

            _addControl.SetDistrict(district);
            _addControl.Dock = DockStyle.Fill;
            Controls.Add(_addControl);

            _addControl.AddButtonEvent += () =>
            {
                Controls.Remove(_addControl);
                _control.InitializeDistrictTabs();
                _control.Dock = DockStyle.Fill;
                Controls.Add(_control);
            };

            _addControl.BackButtonEvent += () =>
            {
                Controls.Remove(_addControl);
                _control.Dock = DockStyle.Fill;
                Controls.Add(_control);
            };
        }

        private async System.Threading.Tasks.Task OnEditVehicleRequest(int id)
        {
            Controls.Remove(_control);
            _editControl.SetVehicle(await _controller.GetByIdAsync(id));
            _editControl.Dock = DockStyle.Fill;
            Controls.Add(_editControl);

            _editControl.BackButtonEvent += () =>
            {
                Controls.Remove(_editControl);
                _control.Dock = DockStyle.Fill;
                Controls.Add(_control);
            };

            _editControl.SaveButtonEvent += () =>
            {
                Controls.Remove(_editControl);
                _control.InitializeDistrictTabs();
                _control.Dock = DockStyle.Fill;
                Controls.Add(_control);
            };
        }

        private void OnCloseFormRequest()
        {
            foreach (var control in Controls)
            {
                Controls.Remove(control as Control);
            }
            Application.Exit();
        }
    }
}
