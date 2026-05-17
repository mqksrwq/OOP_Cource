using System;
using System.Collections.Generic;
using System.Windows.Forms;
using OOP_Cource.Controller;
using OOP_Cource.Models;
using OOP_Cource.Utils;

namespace OOP_Cource.View.Controls
{
    /// <summary>
    /// Главный элемент управления администратора с вкладками по районам
    /// </summary>
    public partial class AdminControl : UserControl
    {
        private readonly VehicleController _controller;
        private readonly Dictionary<DistrictEnum, AdminDistrictControl> _districts;

        /// <summary>
        /// Событие запроса добавления транспорта в указанный район
        /// </summary>
        public event Action<DistrictEnum> AddVehicleRequested;

        /// <summary>
        /// Событие запроса редактирования транспорта по идентификатору
        /// </summary>
        public event Func<int, System.Threading.Tasks.Task> ChangeVehicleRequested;

        /// <summary>
        /// Событие запроса закрытия главной формы
        /// </summary>
        public event Action CloseFormRequest;

        /// <summary>
        /// Инициализирует элемент управления и словарь дочерних элементов по районам
        /// </summary>
        public AdminControl(VehicleController controller)
        {
            InitializeComponent();
            _controller = controller;
            _districts = new Dictionary<DistrictEnum, AdminDistrictControl>();
        }

        /// <summary>
        /// Инициализирует вкладки по районам при загрузке элемента управления
        /// </summary>
        private void AdminControl_Load(object sender, EventArgs e)
        {
            InitializeDistrictTabs();
        }

        /// <summary>
        /// Создаёт вкладку для каждого района и добавляет соответствующий элемент управления
        /// </summary>
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
