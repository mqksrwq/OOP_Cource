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

        private DataGridView dgvVehicles;
        private DataGridView dgvRoutes;
        private DataGridView dgvDrivers;
        private DataGridView dgvOperations;

        public MainForm()
        {
            InitializeMainForm();
            RefreshVehicleSelectors();
        }

        private void InitializeMainForm()
        {
            Text = "Учет автобусного парка";
            StartPosition = FormStartPosition.CenterScreen;
            WindowState = FormWindowState.Normal;
            Size = new Size(980, 680);
            MinimumSize = new Size(980, 680);

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
            var btnDelete = new Button { Text = "Удалить выбранный", AutoSize = true };
            btnDelete.Click += BtnDeleteVehicle_Click;

            inputPanel.Controls.Add(CreateInputRow("Гос. номер", txtVehicleNumber));
            inputPanel.Controls.Add(CreateInputRow("Модель", txtVehicleModel));
            inputPanel.Controls.Add(CreateInputRow("Вместимость", txtVehicleCapacity));
            inputPanel.Controls.Add(CreateInputRow("Статус", cmbVehicleStatus));
            inputPanel.Controls.Add(CreateButtonRow(btnAdd));
            inputPanel.Controls.Add(CreateButtonRow(btnDelete));

            dgvVehicles = CreateGrid();
            dgvVehicles.DataSource = _vehicles;

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(CreateDynamicGridHost(dgvVehicles));
            ConfigureSplitLayout(split, inputPanel, 220);
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
            var btnDelete = new Button { Text = "Удалить выбранный", AutoSize = true };
            btnDelete.Click += BtnDeleteRoute_Click;

            inputPanel.Controls.Add(CreateInputRow("Код", txtRouteCode));
            inputPanel.Controls.Add(CreateInputRow("Откуда", txtRouteFrom));
            inputPanel.Controls.Add(CreateInputRow("Куда", txtRouteTo));
            inputPanel.Controls.Add(CreateInputRow("Дистанция, км", txtRouteDistance));
            inputPanel.Controls.Add(CreateInputRow("Тариф", txtRouteFare));
            inputPanel.Controls.Add(CreateButtonRow(btnAdd));
            inputPanel.Controls.Add(CreateButtonRow(btnDelete));

            dgvRoutes = CreateGrid();
            dgvRoutes.DataSource = _routes;

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(CreateDynamicGridHost(dgvRoutes));
            ConfigureSplitLayout(split, inputPanel, 250);
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
            var btnDelete = new Button { Text = "Удалить выбранного", AutoSize = true };
            btnDelete.Click += BtnDeleteDriver_Click;

            inputPanel.Controls.Add(CreateInputRow("ФИО", txtDriverName));
            inputPanel.Controls.Add(CreateInputRow("Номер прав", txtDriverLicense));
            inputPanel.Controls.Add(CreateInputRow("Транспорт", cmbDriverVehicle));
            inputPanel.Controls.Add(CreateButtonRow(btnAdd));
            inputPanel.Controls.Add(CreateButtonRow(btnDelete));

            dgvDrivers = CreateGrid();
            dgvDrivers.DataSource = _drivers;

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(CreateDynamicGridHost(dgvDrivers));
            ConfigureSplitLayout(split, inputPanel, 190);
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
            var btnDelete = new Button { Text = "Удалить выбранную", AutoSize = true };
            btnDelete.Click += BtnDeleteOperation_Click;

            inputPanel.Controls.Add(CreateInputRow("Дата", dtOperationDate));
            inputPanel.Controls.Add(CreateInputRow("Тип", cmbOperationType));
            inputPanel.Controls.Add(CreateInputRow("Категория", txtOperationCategory));
            inputPanel.Controls.Add(CreateInputRow("Сумма", txtOperationAmount));
            inputPanel.Controls.Add(CreateInputRow("Комментарий", txtOperationComment));
            inputPanel.Controls.Add(CreateButtonRow(btnAdd));
            inputPanel.Controls.Add(CreateButtonRow(btnDelete));

            dgvOperations = CreateGrid();
            dgvOperations.DataSource = _operations;

            split.Panel1.Controls.Add(inputPanel);
            split.Panel2.Controls.Add(CreateDynamicGridHost(dgvOperations));
            ConfigureSplitLayout(split, inputPanel, 250);
            return page;
        }

        private TabPage CreateReportsTab()
        {
            var page = new TabPage("Отчеты");
            var split = CreateSplitContainer(page, 140);
            var inputPanel = CreateFlowPanel();

            dtReportFrom = new DateTimePicker { Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today.AddMonths(-1) };
            dtReportTo = new DateTimePicker { Width = 120, Format = DateTimePickerFormat.Short, Value = DateTime.Today };

            var btnSummary = new Button { Text = "Сводный отчет", AutoSize = true };
            btnSummary.Click += BtnSummaryReport_Click;

            var btnCategory = new Button { Text = "По категориям", AutoSize = true };
            btnCategory.Click += BtnCategoryReport_Click;

            inputPanel.Controls.Add(CreateInputRow("Период с", dtReportFrom));
            inputPanel.Controls.Add(CreateInputRow("Период по", dtReportTo));
            inputPanel.Controls.Add(CreateButtonRow(btnSummary));
            inputPanel.Controls.Add(CreateButtonRow(btnCategory));

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
            ConfigureSplitLayout(split, inputPanel, 170);
            return page;
        }

        private static SplitContainer CreateSplitContainer(TabPage page, int panel1Height = 250)
        {
            var split = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Horizontal,
                IsSplitterFixed = false,
                FixedPanel = FixedPanel.None
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
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };
        }

        private static Panel CreateInputRow(string labelText, Control control)
        {
            var row = new Panel
            {
                Width = 500,
                Height = 36,
                Margin = new Padding(0, 0, 0, 6)
            };

            var label = new Label
            {
                Text = labelText,
                Width = 140,
                Height = 24,
                Location = new Point(0, 7),
                TextAlign = ContentAlignment.MiddleLeft
            };

            control.Location = new Point(150, 4);
            row.Controls.Add(label);
            row.Controls.Add(control);
            return row;
        }

        private static Panel CreateButtonRow(Button button)
        {
            var row = new Panel
            {
                Width = 500,
                Height = 38,
                Margin = new Padding(0, 4, 0, 0)
            };

            button.Location = new Point(150, 4);
            row.Controls.Add(button);
            return row;
        }

        private static TextBox CreateTextBox(int width)
        {
            return new TextBox { Width = width };
        }

        private static DataGridView CreateGrid()
        {
            return new DataGridView
            {
                Dock = DockStyle.Top,
                ReadOnly = true,
                AutoGenerateColumns = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
        }

        private static void ConfigureSplitLayout(SplitContainer split, FlowLayoutPanel inputPanel, int minHeight)
        {
            Action applyLayout = () =>
            {
                var minTop = 140;
                var minBottom = 180;
                var available = split.ClientSize.Height - split.SplitterWidth;

                if (available <= 0)
                {
                    return;
                }

                if (available < minTop + minBottom)
                {
                    split.SplitterDistance = Math.Max(1, available / 2);
                    return;
                }

                var desired = Math.Max(minHeight, inputPanel.PreferredSize.Height + 14);
                var clamped = Math.Max(minTop, Math.Min(desired, available - minBottom));
                split.SplitterDistance = clamped;
            };

            split.SizeChanged += (sender, args) => applyLayout();
            inputPanel.SizeChanged += (sender, args) => applyLayout();
            applyLayout();
        }

        private static Panel CreateDynamicGridHost(DataGridView grid)
        {
            var host = new Panel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                BackColor = Color.White
            };

            Action resizeGrid = () =>
            {
                var rowsHeight = 0;
                for (var i = 0; i < grid.Rows.Count; i++)
                {
                    rowsHeight += grid.Rows[i].Height;
                }

                var requiredHeight = grid.ColumnHeadersHeight + rowsHeight + 2;
                var maxHeight = Math.Max(140, host.ClientSize.Height - 2);
                grid.Height = Math.Min(requiredHeight, maxHeight);
            };

            host.Resize += (sender, args) => resizeGrid();
            grid.RowsAdded += (sender, args) => resizeGrid();
            grid.RowsRemoved += (sender, args) => resizeGrid();
            grid.DataBindingComplete += (sender, args) => resizeGrid();

            host.Controls.Add(grid);
            resizeGrid();
            return host;
        }

        private void BtnAddVehicle_Click(object sender, EventArgs e)
        {
            int capacity;
            var vehicleNumber = txtVehicleNumber.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtVehicleNumber.Text) ||
                string.IsNullOrWhiteSpace(txtVehicleModel.Text) ||
                !int.TryParse(txtVehicleCapacity.Text, out capacity))
            {
                MessageBox.Show("Введите номер, модель и корректную вместимость.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_vehicles.Any(x => string.Equals(x.Number, vehicleNumber, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Транспорт с таким гос. номером уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _vehicles.Add(new Vehicle
            {
                Id = _vehicleId++,
                Number = vehicleNumber,
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
            var licenseNumber = txtDriverLicense.Text.Trim();
            if (string.IsNullOrWhiteSpace(txtDriverName.Text) ||
                string.IsNullOrWhiteSpace(txtDriverLicense.Text) ||
                selectedVehicle == null)
            {
                MessageBox.Show("Заполните ФИО, номер прав и выберите транспорт.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_drivers.Any(x => string.Equals(x.LicenseNumber, licenseNumber, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Водитель с таким номером прав уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _drivers.Add(new Driver
            {
                Id = _driverId++,
                FullName = txtDriverName.Text.Trim(),
                LicenseNumber = licenseNumber,
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

        private void BtnDeleteVehicle_Click(object sender, EventArgs e)
        {
            var selectedVehicle = dgvVehicles.CurrentRow != null ? dgvVehicles.CurrentRow.DataBoundItem as Vehicle : null;
            if (selectedVehicle == null)
            {
                MessageBox.Show("Выберите транспорт для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var hasAssignedDriver = _drivers.Any(x => x.AssignedVehicle.StartsWith(selectedVehicle.Number + " - ", StringComparison.OrdinalIgnoreCase));
            if (hasAssignedDriver)
            {
                MessageBox.Show("Нельзя удалить транспорт, пока он назначен водителю.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _vehicles.Remove(selectedVehicle);
            RefreshVehicleSelectors();
        }

        private void BtnDeleteRoute_Click(object sender, EventArgs e)
        {
            var selectedRoute = dgvRoutes.CurrentRow != null ? dgvRoutes.CurrentRow.DataBoundItem as Route : null;
            if (selectedRoute == null)
            {
                MessageBox.Show("Выберите маршрут для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _routes.Remove(selectedRoute);
        }

        private void BtnDeleteDriver_Click(object sender, EventArgs e)
        {
            var selectedDriver = dgvDrivers.CurrentRow != null ? dgvDrivers.CurrentRow.DataBoundItem as Driver : null;
            if (selectedDriver == null)
            {
                MessageBox.Show("Выберите водителя для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _drivers.Remove(selectedDriver);
        }

        private void BtnDeleteOperation_Click(object sender, EventArgs e)
        {
            var selectedOperation = dgvOperations.CurrentRow != null ? dgvOperations.CurrentRow.DataBoundItem as FinanceOperation : null;
            if (selectedOperation == null)
            {
                MessageBox.Show("Выберите операцию для удаления.", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            _operations.Remove(selectedOperation);
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

    }
}
