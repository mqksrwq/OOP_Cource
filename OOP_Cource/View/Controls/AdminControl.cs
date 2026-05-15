using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.Models;
using OOP_Cource.Utils;

namespace OOP_Cource.View.Controls
{
    public partial class AdminControl : UserControl
    {
        private readonly VehicleController _controller;
        private readonly Dictionary<DistrictEnum, AdminDistrictControl> _districts;

        public event Action<DistrictEnum> AddVehicleRequested;
        public event Func<int, System.Threading.Tasks.Task> ChangeVehicleRequested;
        public event Action CloseFormRequest;

        public AdminControl(VehicleController controller)
        {
            InitializeComponent();
            _controller = controller;
            _districts = new Dictionary<DistrictEnum, AdminDistrictControl>();
        }

        private void AdminControl_Load(object sender, EventArgs e)
        {
            InitializeDistrictTabs();
        }

        public void InitializeDistrictTabs()
        {
            DistrictTabControl.TabPages.Clear();

            foreach (DistrictEnum district in Enum.GetValues(typeof(DistrictEnum)))
            {
                var control = new AdminDistrictControl(_controller, district);
                _districts[district] = control;

                control.AddButtonEvent += d => AddVehicleRequested?.Invoke(d);
                control.CloseButtonEvent += () => CloseFormRequest?.Invoke();
                control.ChangeButtonEvent += async id =>
                {
                    if (ChangeVehicleRequested != null)
                        await ChangeVehicleRequested(id);
                };

                control.Dock = DockStyle.Fill;

                var tabPage = new TabPage(DistrictExtension.GetDisplayName(district));
                tabPage.Controls.Add(control);

                DistrictTabControl.TabPages.Add(tabPage);
            }
        }
    }
}
