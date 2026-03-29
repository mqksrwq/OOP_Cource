using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OOP_Cource.Models;

namespace OOP_Cource.Forms
{
    public class MainForm : Form
    {
        private readonly BindingList<Vehicle> _vehicles = new BindingList<Vehicle>();
        private readonly BindingList<Route> _routes = new BindingList<Route>();
        private readonly BindingList<Driver> _drivers = new BindingList<Driver>();
        private readonly BindingList<FinanceOperation> _operations = new BindingList<FinanceOperation>();

        private int _vehicleId = 1;
        private int _routeId = 1;
        private int _driverId = 1;
        private int _operationId = 1;

        private TextBox txtVehicleNumber;
        private TextBox txtVehicleModel;
        private TextBox txtVehicleCapacity;
        private ComboBox cmbVehicleStatus;

        private TextBox txtRouteCode;
        private TextBox txtRouteFrom;
        private TextBox txtRouteTo;
        private TextBox txtRouteDistance;
        private TextBox txtRouteFare;

        private TextBox txtDriverName;
        private TextBox txtDriverLicense;
        private ComboBox cmbDriverVehicle;

        private DateTimePicker dtOperationDate;
        private ComboBox cmbOperationType;
        private TextBox txtOperationCategory;
        private TextBox txtOperationAmount;
        private TextBox txtOperationComment;

        private DateTimePicker dtReportFrom;
        private DateTimePicker dtReportTo;
        private TextBox txtReport;

        public MainForm()
        {
            InitializeMainForm();
            SeedData();
            RefreshVehicleSelectors();
        }

        private void InitializeMainForm()
        {
            Text = "Учет автобусного парка";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Maximized;

            var tabControl = new TabControl { Dock = DockStyle.Fill };
            tabControl.TabPages.Add(CreateVehiclesTab());
            tabControl.TabPages.Add(CreateRoutesTab());
            tabControl.TabPages.Add(CreateDriversTab());
            tabControl.TabPages.Add(CreateFinanceTab());
            tabControl.TabPages.Add(CreateReportsTab());

            Controls.Add(tabControl);
        }

        private TabPage CreateVehiclesTab()
        {
            var page = new TabPage("Транспорт");
            var split = CreateSplitContainer(page);
            var inputPanel = CreateFlowPanel();

            txtVehicleNumber = CreateTextBox(100);
            txtVehicleModel = CreateTextBox(130);
            txtVehicleCapacity = CreateTextBox(70);
            cmbVehicleStatus = new ComboBox { Width = 130, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbVehicleStatus.Items.AddRange(new object[] { "Исправен", "На ремонте", "Резерв" });
            cmbVehicleStatus.SelectedIndex = 0;

            var btnAdd = new Button { Text = "Добавить транспорт", AutoSize = true };
            btnAdd.Click += BtnAddVehicle_Click;

            inputPanel.Controls.AddRange(new Control[]
            {
                new Label { Text = "Гос. номер", AutoSize = true, Padding = new Padding(0, 9, 0, 0) }, txtVehicleNumber,
                new Label { Text = "Модель", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtVehicleModel,
                new Label { Text = "Вместимость", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtVehicleCapacity,
                new Label { Text = "Статус", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, cmbVehicleStatus,
                btnAdd
            });

            var grid = CreateGrid();
            grid.DataSource = _vehicles;

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(grid);
            return page;
        }

        private TabPage CreateRoutesTab()
        {
            var page = new TabPage("Маршруты");
            var split = CreateSplitContainer(page);
            var inputPanel = CreateFlowPanel();

            txtRouteCode = CreateTextBox(90);
            txtRouteFrom = CreateTextBox(120);
            txtRouteTo = CreateTextBox(120);
            txtRouteDistance = CreateTextBox(80);
            txtRouteFare = CreateTextBox(80);

            var btnAdd = new Button { Text = "Добавить маршрут", AutoSize = true };
            btnAdd.Click += BtnAddRoute_Click;

            inputPanel.Controls.AddRange(new Control[]
            {
                new Label { Text = "Код", AutoSize = true, Padding = new Padding(0, 9, 0, 0) }, txtRouteCode,
                new Label { Text = "Откуда", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtRouteFrom,
                new Label { Text = "Куда", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtRouteTo,
                new Label { Text = "Дистанция, км", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtRouteDistance,
                new Label { Text = "Тариф", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtRouteFare,
                btnAdd
            });

            var grid = CreateGrid();
            grid.DataSource = _routes;

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(grid);
            return page;
        }

        private TabPage CreateDriversTab()
        {
            var page = new TabPage("Водители");
            var split = CreateSplitContainer(page);
            var inputPanel = CreateFlowPanel();

            txtDriverName = CreateTextBox(170);
            txtDriverLicense = CreateTextBox(120);
            cmbDriverVehicle = new ComboBox { Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

            var btnAdd = new Button { Text = "Добавить водителя", AutoSize = true };
            btnAdd.Click += BtnAddDriver_Click;

            inputPanel.Controls.AddRange(new Control[]
            {
                new Label { Text = "ФИО", AutoSize = true, Padding = new Padding(0, 9, 0, 0) }, txtDriverName,
                new Label { Text = "Номер прав", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtDriverLicense,
                new Label { Text = "Транспорт", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, cmbDriverVehicle,
                btnAdd
            });

            var grid = CreateGrid();
            grid.DataSource = _drivers;

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(grid);
            return page;
        }

        private TabPage CreateFinanceTab()
        {
            var page = new TabPage("Доходы/Расходы");
            var split = CreateSplitContainer(page);
            var inputPanel = CreateFlowPanel();

            dtOperationDate = new DateTimePicker { Width = 120, Format = DateTimePickerFormat.Short };
            cmbOperationType = new ComboBox { Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbOperationType.Items.AddRange(new object[] { "Доход", "Расход" });
            cmbOperationType.SelectedIndex = 0;
            txtOperationCategory = CreateTextBox(150);
            txtOperationAmount = CreateTextBox(90);
            txtOperationComment = CreateTextBox(180);

            var btnAdd = new Button { Text = "Добавить операцию", AutoSize = true };
            btnAdd.Click += BtnAddOperation_Click;

            inputPanel.Controls.AddRange(new Control[]
            {
                new Label { Text = "Дата", AutoSize = true, Padding = new Padding(0, 9, 0, 0) }, dtOperationDate,
                new Label { Text = "Тип", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, cmbOperationType,
                new Label { Text = "Категория", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtOperationCategory,
                new Label { Text = "Сумма", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtOperationAmount,
                new Label { Text = "Комментарий", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, txtOperationComment,
                btnAdd
            });

            var grid = CreateGrid();
            grid.DataSource = _operations;

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(grid);
            return page;
        }

        private TabPage CreateReportsTab()
        {
            var page = new TabPage("Отчеты");
            var split = CreateSplitContainer(page, 80);
            var inputPanel = CreateFlowPanel();

            dtReportFrom = new DateTimePicker { Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddMonths(-1) };
            dtReportTo = new DateTimePicker { Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

            var btnSummary = new Button { Text = "Сводный отчет", AutoSize = true };
            btnSummary.Click += BtnSummaryReport_Click;

            var btnCategory = new Button { Text = "По категориям", AutoSize = true };
            btnCategory.Click += BtnCategoryReport_Click;

            inputPanel.Controls.AddRange(new Control[]
            {
                new Label { Text = "Период с", AutoSize = true, Padding = new Padding(0, 9, 0, 0) }, dtReportFrom,
                new Label { Text = "по", AutoSize = true, Padding = new Padding(10, 9, 0, 0) }, dtReportTo,
                btnSummary,
                btnCategory
            });

            txtReport = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                ReadOnly = true,
                Font = new Font("Consolas", 10F)
            };

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(txtReport);
            return page;
        }

        private static SplitContainer CreateSplitContainer(TabPage page, int panel1Height = 120)
        {
            var split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                IsSplitterFixed = true,
                FixedPanel = FixedPanel.Panel1,
                SplitterDistance = panel1Height
            };

            page.Controls.Add(split);
            return split;
        }

        private static FlowLayoutPanel CreateFlowPanel()
        {
            return new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                Padding = new Padding(10),
                WrapContents = true
            };
        }

        private static TextBox CreateTextBox(int width)
        {
            return new TextBox { Width = width };
        }

        private static DataGridView CreateGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
        }

        private void BtnAddVehicle_Click(object sender, EventArgs e)
        {
            int capacity;
            if (string.IsNullOrWhiteSpace(txtVehicleNumber.Text) ||
                string.IsNullOrWhiteSpace(txtVehicleModel.Text) ||
                !int.TryParse(txtVehicleCapacity.Text, out capacity))
            {
                MessageBox.Show("Введите номер, модель и корректную вместимость.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _vehicles.Add(new Vehicle
            {
                Id = _vehicleId++,
                Number = txtVehicleNumber.Text.Trim(),
                Model = txtVehicleModel.Text.Trim(),
                Capacity = capacity,
                Status = cmbVehicleStatus.Text
            });

            txtVehicleNumber.Clear();
            txtVehicleModel.Clear();
            txtVehicleCapacity.Clear();
            RefreshVehicleSelectors();
        }

        private void BtnAddRoute_Click(object sender, EventArgs e)
        {
            decimal distance;
            decimal fare;
            if (string.IsNullOrWhiteSpace(txtRouteCode.Text) ||
                string.IsNullOrWhiteSpace(txtRouteFrom.Text) ||
                string.IsNullOrWhiteSpace(txtRouteTo.Text) ||
                !decimal.TryParse(txtRouteDistance.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out distance) ||
                !decimal.TryParse(txtRouteFare.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out fare))
            {
                MessageBox.Show("Заполните данные маршрута и корректные числовые значения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _routes.Add(new Route
            {
                Id = _routeId++,
                Code = txtRouteCode.Text.Trim(),
                StartPoint = txtRouteFrom.Text.Trim(),
                EndPoint = txtRouteTo.Text.Trim(),
                DistanceKm = distance,
                Fare = fare
            });

            txtRouteCode.Clear();
            txtRouteFrom.Clear();
            txtRouteTo.Clear();
            txtRouteDistance.Clear();
            txtRouteFare.Clear();
        }

        private void BtnAddDriver_Click(object sender, EventArgs e)
        {
            var selectedVehicle = cmbDriverVehicle.SelectedItem as VehicleSelector;
            if (string.IsNullOrWhiteSpace(txtDriverName.Text) ||
                string.IsNullOrWhiteSpace(txtDriverLicense.Text) ||
                selectedVehicle == null)
            {
                MessageBox.Show("Заполните ФИО, номер прав и выберите транспорт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _drivers.Add(new Driver
            {
                Id = _driverId++,
                FullName = txtDriverName.Text.Trim(),
                LicenseNumber = txtDriverLicense.Text.Trim(),
                AssignedVehicle = selectedVehicle.Display
            });

            txtDriverName.Clear();
            txtDriverLicense.Clear();
        }

        private void BtnAddOperation_Click(object sender, EventArgs e)
        {
            decimal amount;
            if (string.IsNullOrWhiteSpace(txtOperationCategory.Text) ||
                !decimal.TryParse(txtOperationAmount.Text, NumberStyles.Number, CultureInfo.CurrentCulture, out amount))
            {
                MessageBox.Show("Введите категорию и корректную сумму.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _operations.Add(new FinanceOperation
            {
                Id = _operationId++,
                Date = dtOperationDate.Value.Date,
                Type = cmbOperationType.Text,
                Category = txtOperationCategory.Text.Trim(),
                Amount = amount,
                Comment = txtOperationComment.Text.Trim()
            });

            txtOperationCategory.Clear();
            txtOperationAmount.Clear();
            txtOperationComment.Clear();
        }

        private void BtnSummaryReport_Click(object sender, EventArgs e)
        {
            var filtered = GetOperationsByPeriod();
            var income = filtered.Where(x => x.Type == "Доход").Sum(x => x.Amount);
            var expenses = filtered.Where(x => x.Type == "Расход").Sum(x => x.Amount);

            var report = new StringBuilder();
            report.AppendLine("СВОДНЫЙ ОТЧЕТ");
            report.AppendLine($"Период: {dtReportFrom.Value:dd.MM.yyyy} - {dtReportTo.Value:dd.MM.yyyy}");
            report.AppendLine(new string('-', 50));
            report.AppendLine($"Транспортных средств: {_vehicles.Count}");
            report.AppendLine($"Маршрутов: {_routes.Count}");
            report.AppendLine($"Водителей: {_drivers.Count}");
            report.AppendLine($"Операций за период: {filtered.Count}");
            report.AppendLine();
            report.AppendLine($"Доходы:  {income:N2}");
            report.AppendLine($"Расходы: {expenses:N2}");
            report.AppendLine($"Баланс:  {income - expenses:N2}");

            txtReport.Text = report.ToString();
        }

        private void BtnCategoryReport_Click(object sender, EventArgs e)
        {
            var filtered = GetOperationsByPeriod();
            var grouped = filtered
                .GroupBy(x => new { x.Type, x.Category })
                .OrderBy(x => x.Key.Type)
                .ThenBy(x => x.Key.Category)
                .ToList();

            var report = new StringBuilder();
            report.AppendLine("ОТЧЕТ ПО КАТЕГОРИЯМ");
            report.AppendLine($"Период: {dtReportFrom.Value:dd.MM.yyyy} - {dtReportTo.Value:dd.MM.yyyy}");
            report.AppendLine(new string('-', 50));

            if (grouped.Count == 0)
            {
                report.AppendLine("Нет данных за выбранный период.");
            }
            else
            {
                foreach (var item in grouped)
                {
                    report.AppendLine($"{item.Key.Type,-8} | {item.Key.Category,-20} | {item.Sum(x => x.Amount),10:N2}");
                }
            }

            txtReport.Text = report.ToString();
        }

        private List<FinanceOperation> GetOperationsByPeriod()
        {
            var from = dtReportFrom.Value.Date;
            var to = dtReportTo.Value.Date;
            if (to < from)
            {
                var temp = from;
                from = to;
                to = temp;
            }

            return _operations.Where(x => x.Date.Date >= from && x.Date.Date <= to).ToList();
        }

        private void RefreshVehicleSelectors()
        {
            var items = _vehicles
                .Select(x => new VehicleSelector { Id = x.Id, Display = x.Number + " - " + x.Model })
                .ToList();

            cmbDriverVehicle.DataSource = null;
            cmbDriverVehicle.DataSource = items;
            cmbDriverVehicle.DisplayMember = "Display";
            cmbDriverVehicle.ValueMember = "Id";
        }

        private void SeedData()
        {
            _vehicles.Add(new Vehicle { Id = _vehicleId++, Number = "А123ВС", Model = "ЛиАЗ-5292", Capacity = 95, Status = "Исправен" });
            _vehicles.Add(new Vehicle { Id = _vehicleId++, Number = "В456ОР", Model = "ПАЗ-3204", Capacity = 52, Status = "Резерв" });

            _routes.Add(new Route { Id = _routeId++, Code = "№12", StartPoint = "Центр", EndPoint = "Вокзал", DistanceKm = 14, Fare = 45 });
            _routes.Add(new Route { Id = _routeId++, Code = "№21", StartPoint = "Парк", EndPoint = "Университет", DistanceKm = 11, Fare = 40 });

            _drivers.Add(new Driver { Id = _driverId++, FullName = "Иванов И.И.", LicenseNumber = "77 00 123456", AssignedVehicle = "А123ВС - ЛиАЗ-5292" });

            _operations.Add(new FinanceOperation
            {
                Id = _operationId++,
                Date = DateTime.Today,
                Type = "Доход",
                Category = "Оплата за проезд",
                Amount = 35000,
                Comment = "Смена 1"
            });

            _operations.Add(new FinanceOperation
            {
                Id = _operationId++,
                Date = DateTime.Today,
                Type = "Расход",
                Category = "Ремонт",
                Amount = 8500,
                Comment = "Замена тормозных колодок"
            });
        }
    }
}
