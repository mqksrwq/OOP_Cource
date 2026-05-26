using System;

namespace KursProject_Boyarkin_OOP
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            menuStrip1 = new System.Windows.Forms.MenuStrip();
            файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            создатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            открытьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            сохранитьКакToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            удалитьБДToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            создатьОтчётToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            comboBoxField = new System.Windows.Forms.ComboBox();
            comboBoxSort = new System.Windows.Forms.ComboBox();
            btnSort = new System.Windows.Forms.Button();
            textBoxFilter = new System.Windows.Forms.TextBox();
            btnFilter = new System.Windows.Forms.Button();
            textBoxSearch = new System.Windows.Forms.TextBox();
            btnFind = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            btnResetFilter = new System.Windows.Forms.Button();
            btnResetSort = new System.Windows.Forms.Button();
            btnResetSearch = new System.Windows.Forms.Button();
            btnExit = new System.Windows.Forms.Button();
            tabControl1 = new System.Windows.Forms.TabControl();
            tabPage1 = new System.Windows.Forms.TabPage();
            label2 = new System.Windows.Forms.Label();
            textBoxPlate = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBoxDriver = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            comboBoxRoute = new System.Windows.Forms.ComboBox();
            label5 = new System.Windows.Forms.Label();
            numericIncome = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            numericExpense = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            numericMileage = new System.Windows.Forms.NumericUpDown();
            btnAdd = new System.Windows.Forms.Button();
            tabPage2 = new System.Windows.Forms.TabPage();
            label13 = new System.Windows.Forms.Label();
            textBoxPlateUpdate = new System.Windows.Forms.TextBox();
            label12 = new System.Windows.Forms.Label();
            textBoxDriverUpdate = new System.Windows.Forms.TextBox();
            label11 = new System.Windows.Forms.Label();
            comboBoxRouteUpdate = new System.Windows.Forms.ComboBox();
            label10 = new System.Windows.Forms.Label();
            numericIncomeUpdate = new System.Windows.Forms.NumericUpDown();
            label9 = new System.Windows.Forms.Label();
            numericExpenseUpdate = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            numericMileageUpdate = new System.Windows.Forms.NumericUpDown();
            btnUpdate = new System.Windows.Forms.Button();
            bindingSource1 = new System.Windows.Forms.BindingSource(components);
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericIncome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericExpense).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMileage).BeginInit();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericIncomeUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericExpenseUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericMileageUpdate).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = System.Drawing.Color.FromArgb(40, 55, 71);
            menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            menuStrip1.ForeColor = System.Drawing.Color.White;
            menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(1735, 44);
            menuStrip1.TabIndex = 0;
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] { создатьToolStripMenuItem, открытьБДToolStripMenuItem, сохранитьКакToolStripMenuItem, удалитьБДToolStripMenuItem, создатьОтчётToolStripMenuItem });
            файлToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new System.Drawing.Size(96, 40);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // создатьToolStripMenuItem
            // 
            создатьToolStripMenuItem.Name = "создатьToolStripMenuItem";
            создатьToolStripMenuItem.Size = new System.Drawing.Size(320, 44);
            создатьToolStripMenuItem.Text = "Создать";
            // 
            // открытьБДToolStripMenuItem
            // 
            открытьБДToolStripMenuItem.Name = "открытьБДToolStripMenuItem";
            открытьБДToolStripMenuItem.Size = new System.Drawing.Size(320, 44);
            открытьБДToolStripMenuItem.Text = "Открыть БД";
            // 
            // сохранитьКакToolStripMenuItem
            // 
            сохранитьКакToolStripMenuItem.Name = "сохранитьКакToolStripMenuItem";
            сохранитьКакToolStripMenuItem.Size = new System.Drawing.Size(320, 44);
            сохранитьКакToolStripMenuItem.Text = "Сохранить как";
            // 
            // удалитьБДToolStripMenuItem
            // 
            удалитьБДToolStripMenuItem.Name = "удалитьБДToolStripMenuItem";
            удалитьБДToolStripMenuItem.Size = new System.Drawing.Size(320, 44);
            удалитьБДToolStripMenuItem.Text = "Удалить БД";
            // 
            // создатьОтчётToolStripMenuItem
            // 
            создатьОтчётToolStripMenuItem.Name = "создатьОтчётToolStripMenuItem";
            создатьОтчётToolStripMenuItem.Size = new System.Drawing.Size(320, 44);
            создатьОтчётToolStripMenuItem.Text = "Создать отчёт";
            // 
            // dataGridView1
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(235, 242, 250);
            dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dataGridView1.BackgroundColor = System.Drawing.Color.White;
            dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(40, 55, 71);
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.GridColor = System.Drawing.Color.FromArgb(189, 195, 199);
            dataGridView1.Location = new System.Drawing.Point(486, 32);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 82;
            dataGridView1.Size = new System.Drawing.Size(1241, 959);
            dataGridView1.TabIndex = 1;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(comboBoxField);
            groupBox1.Controls.Add(comboBoxSort);
            groupBox1.Controls.Add(btnSort);
            groupBox1.Controls.Add(textBoxFilter);
            groupBox1.Controls.Add(btnFilter);
            groupBox1.Controls.Add(textBoxSearch);
            groupBox1.Controls.Add(btnFind);
            groupBox1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            groupBox1.Location = new System.Drawing.Point(7, 630);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(473, 418);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Поиск и операции";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(8, 59);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(88, 36);
            label1.TabIndex = 4;
            label1.Text = "Поле:";
            // 
            // comboBoxField
            // 
            comboBoxField.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            comboBoxField.FormattingEnabled = true;
            comboBoxField.Items.AddRange(new object[] { "Номер ТС", "Водитель", "Маршрут", "Доход (руб/д)", "Расход (руб/д)", "Пробег (км/д)" });
            comboBoxField.Location = new System.Drawing.Point(128, 52);
            comboBoxField.Name = "comboBoxField";
            comboBoxField.Size = new System.Drawing.Size(345, 43);
            comboBoxField.TabIndex = 0;
            comboBoxField.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // comboBoxSort
            // 
            comboBoxSort.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            comboBoxSort.FormattingEnabled = true;
            comboBoxSort.Items.AddRange(new object[] { "По возрастанию", "По убыванию" });
            comboBoxSort.Location = new System.Drawing.Point(8, 113);
            comboBoxSort.Name = "comboBoxSort";
            comboBoxSort.Size = new System.Drawing.Size(459, 43);
            comboBoxSort.TabIndex = 1;
            comboBoxSort.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // btnSort
            // 
            btnSort.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnSort.FlatAppearance.BorderSize = 0;
            btnSort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSort.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnSort.ForeColor = System.Drawing.Color.White;
            btnSort.Location = new System.Drawing.Point(8, 162);
            btnSort.Name = "btnSort";
            btnSort.Size = new System.Drawing.Size(459, 48);
            btnSort.TabIndex = 6;
            btnSort.Text = "Сортировать";
            btnSort.UseVisualStyleBackColor = false;
            btnSort.Click += button2_Click;
            // 
            // textBoxFilter
            // 
            textBoxFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            textBoxFilter.Location = new System.Drawing.Point(8, 216);
            textBoxFilter.Name = "textBoxFilter";
            textBoxFilter.Size = new System.Drawing.Size(459, 41);
            textBoxFilter.TabIndex = 2;
            textBoxFilter.TextChanged += textBox1_TextChanged;
            // 
            // btnFilter
            // 
            btnFilter.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnFilter.FlatAppearance.BorderSize = 0;
            btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnFilter.ForeColor = System.Drawing.Color.White;
            btnFilter.Location = new System.Drawing.Point(8, 263);
            btnFilter.Name = "btnFilter";
            btnFilter.Size = new System.Drawing.Size(459, 50);
            btnFilter.TabIndex = 5;
            btnFilter.Text = "Фильтровать";
            btnFilter.UseVisualStyleBackColor = false;
            btnFilter.Click += button1_Click;
            // 
            // textBoxSearch
            // 
            textBoxSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            textBoxSearch.Location = new System.Drawing.Point(6, 319);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new System.Drawing.Size(461, 41);
            textBoxSearch.TabIndex = 3;
            textBoxSearch.TextChanged += textBox2_TextChanged;
            // 
            // btnFind
            // 
            btnFind.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnFind.FlatAppearance.BorderSize = 0;
            btnFind.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnFind.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnFind.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnFind.ForeColor = System.Drawing.Color.White;
            btnFind.Location = new System.Drawing.Point(8, 366);
            btnFind.Name = "btnFind";
            btnFind.Size = new System.Drawing.Size(459, 43);
            btnFind.TabIndex = 7;
            btnFind.Text = "Найти";
            btnFind.UseVisualStyleBackColor = false;
            btnFind.Click += button3_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnDelete.BackColor = System.Drawing.Color.FromArgb(169, 50, 38);
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(203, 67, 53);
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(486, 997);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(147, 55);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Удалить";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += button4_Click;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnResetFilter.BackColor = System.Drawing.Color.FromArgb(100, 110, 120);
            btnResetFilter.FlatAppearance.BorderSize = 0;
            btnResetFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(130, 145, 155);
            btnResetFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnResetFilter.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnResetFilter.ForeColor = System.Drawing.Color.White;
            btnResetFilter.Location = new System.Drawing.Point(639, 997);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new System.Drawing.Size(330, 55);
            btnResetFilter.TabIndex = 9;
            btnResetFilter.Text = "Сбросить фильтр";
            btnResetFilter.UseVisualStyleBackColor = false;
            btnResetFilter.Click += button5_Click;
            // 
            // btnResetSort
            // 
            btnResetSort.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnResetSort.BackColor = System.Drawing.Color.FromArgb(100, 110, 120);
            btnResetSort.FlatAppearance.BorderSize = 0;
            btnResetSort.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(130, 145, 155);
            btnResetSort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnResetSort.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnResetSort.ForeColor = System.Drawing.Color.White;
            btnResetSort.Location = new System.Drawing.Point(975, 997);
            btnResetSort.Name = "btnResetSort";
            btnResetSort.Size = new System.Drawing.Size(356, 55);
            btnResetSort.TabIndex = 10;
            btnResetSort.Text = "Отменить сортировку";
            btnResetSort.UseVisualStyleBackColor = false;
            btnResetSort.Click += button6_Click;
            // 
            // btnResetSearch
            // 
            btnResetSearch.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            btnResetSearch.BackColor = System.Drawing.Color.FromArgb(100, 110, 120);
            btnResetSearch.FlatAppearance.BorderSize = 0;
            btnResetSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(130, 145, 155);
            btnResetSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnResetSearch.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnResetSearch.ForeColor = System.Drawing.Color.White;
            btnResetSearch.Location = new System.Drawing.Point(1337, 997);
            btnResetSearch.Name = "btnResetSearch";
            btnResetSearch.Size = new System.Drawing.Size(254, 55);
            btnResetSearch.TabIndex = 11;
            btnResetSearch.Text = "Отменить поиск";
            btnResetSearch.UseVisualStyleBackColor = false;
            btnResetSearch.Click += button7_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            btnExit.BackColor = System.Drawing.Color.FromArgb(40, 55, 71);
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 73, 94);
            btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExit.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnExit.ForeColor = System.Drawing.Color.White;
            btnExit.Location = new System.Drawing.Point(1597, 997);
            btnExit.Name = "btnExit";
            btnExit.Size = new System.Drawing.Size(126, 55);
            btnExit.TabIndex = 12;
            btnExit.Text = "Выйти";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += button8_Click;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            tabControl1.Location = new System.Drawing.Point(7, 73);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new System.Drawing.Size(467, 551);
            tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = System.Drawing.Color.White;
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBoxPlate);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(textBoxDriver);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(comboBoxRoute);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(numericIncome);
            tabPage1.Controls.Add(label6);
            tabPage1.Controls.Add(numericExpense);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(numericMileage);
            tabPage1.Controls.Add(btnAdd);
            tabPage1.Location = new System.Drawing.Point(8, 49);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new System.Windows.Forms.Padding(3);
            tabPage1.Size = new System.Drawing.Size(451, 494);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "  Добавление  ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(8, 23);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(194, 36);
            label2.TabIndex = 15;
            label2.Text = "Гос. номер ТС:";
            // 
            // textBoxPlate
            // 
            textBoxPlate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            textBoxPlate.Location = new System.Drawing.Point(208, 23);
            textBoxPlate.Name = "textBoxPlate";
            textBoxPlate.Size = new System.Drawing.Size(237, 41);
            textBoxPlate.TabIndex = 9;
            textBoxPlate.TextChanged += textBoxPlate_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(8, 70);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(144, 36);
            label3.TabIndex = 16;
            label3.Text = "Водитель:";
            // 
            // textBoxDriver
            // 
            textBoxDriver.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            textBoxDriver.Location = new System.Drawing.Point(208, 70);
            textBoxDriver.Name = "textBoxDriver";
            textBoxDriver.Size = new System.Drawing.Size(237, 41);
            textBoxDriver.TabIndex = 10;
            textBoxDriver.TextChanged += textBoxDriver_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(11, 117);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(141, 36);
            label4.TabIndex = 17;
            label4.Text = "Маршрут:";
            // 
            // comboBoxRoute
            // 
            comboBoxRoute.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            comboBoxRoute.FormattingEnabled = true;
            comboBoxRoute.Items.AddRange(new object[] { "№ 1", "№ 2", "№ 4", "№ 5", "№ 6", "№ 7", "№ 29", "№ 54", "№ 66", "№ 70", "№ 75", "№ 82С", "№ 93", "№ 101", "№ 105", "№ 130", "№ 149" });
            comboBoxRoute.Location = new System.Drawing.Point(208, 117);
            comboBoxRoute.Name = "comboBoxRoute";
            comboBoxRoute.Size = new System.Drawing.Size(237, 43);
            comboBoxRoute.TabIndex = 11;
            comboBoxRoute.SelectedIndexChanged += comboBoxRoute_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label5.Location = new System.Drawing.Point(11, 168);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(155, 36);
            label5.TabIndex = 18;
            label5.Text = "Доход р/д:";
            // 
            // numericIncome
            // 
            numericIncome.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            numericIncome.Location = new System.Drawing.Point(208, 166);
            numericIncome.Maximum = new decimal(new int[] { 15000, 0, 0, 0 });
            numericIncome.Minimum = new decimal(new int[] { 8000, 0, 0, 0 });
            numericIncome.Name = "numericIncome";
            numericIncome.Size = new System.Drawing.Size(237, 41);
            numericIncome.TabIndex = 12;
            numericIncome.Value = new decimal(new int[] { 8000, 0, 0, 0 });
            numericIncome.ValueChanged += numericIncome_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label6.Location = new System.Drawing.Point(11, 218);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(160, 36);
            label6.TabIndex = 19;
            label6.Text = "Расход р/д:";
            // 
            // numericExpense
            // 
            numericExpense.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            numericExpense.Location = new System.Drawing.Point(208, 213);
            numericExpense.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericExpense.Minimum = new decimal(new int[] { 5000, 0, 0, 0 });
            numericExpense.Name = "numericExpense";
            numericExpense.Size = new System.Drawing.Size(237, 41);
            numericExpense.TabIndex = 13;
            numericExpense.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            numericExpense.ValueChanged += numericExpense_ValueChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label7.Location = new System.Drawing.Point(8, 265);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(185, 36);
            label7.TabIndex = 20;
            label7.Text = "Пробег км/д:";
            // 
            // numericMileage
            // 
            numericMileage.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            numericMileage.Location = new System.Drawing.Point(208, 260);
            numericMileage.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericMileage.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            numericMileage.Name = "numericMileage";
            numericMileage.Size = new System.Drawing.Size(237, 41);
            numericMileage.TabIndex = 14;
            numericMileage.Value = new decimal(new int[] { 200, 0, 0, 0 });
            numericMileage.ValueChanged += numericMileage_ValueChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAdd.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnAdd.ForeColor = System.Drawing.Color.White;
            btnAdd.Location = new System.Drawing.Point(3, 441);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new System.Drawing.Size(442, 47);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Добавить";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = System.Drawing.Color.White;
            tabPage2.Controls.Add(label13);
            tabPage2.Controls.Add(textBoxPlateUpdate);
            tabPage2.Controls.Add(label12);
            tabPage2.Controls.Add(textBoxDriverUpdate);
            tabPage2.Controls.Add(label11);
            tabPage2.Controls.Add(comboBoxRouteUpdate);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(numericIncomeUpdate);
            tabPage2.Controls.Add(label9);
            tabPage2.Controls.Add(numericExpenseUpdate);
            tabPage2.Controls.Add(label8);
            tabPage2.Controls.Add(numericMileageUpdate);
            tabPage2.Controls.Add(btnUpdate);
            tabPage2.Location = new System.Drawing.Point(8, 49);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new System.Windows.Forms.Padding(3);
            tabPage2.Size = new System.Drawing.Size(451, 494);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "  Обновление  ";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label13.Location = new System.Drawing.Point(9, 18);
            label13.Name = "label13";
            label13.Size = new System.Drawing.Size(194, 36);
            label13.TabIndex = 27;
            label13.Text = "Гос. номер ТС:";
            // 
            // textBoxPlateUpdate
            // 
            textBoxPlateUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            textBoxPlateUpdate.Location = new System.Drawing.Point(209, 18);
            textBoxPlateUpdate.Name = "textBoxPlateUpdate";
            textBoxPlateUpdate.Size = new System.Drawing.Size(236, 41);
            textBoxPlateUpdate.TabIndex = 21;
            textBoxPlateUpdate.TextChanged += textBoxPlateUpdate_TextChanged;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label12.Location = new System.Drawing.Point(9, 65);
            label12.Name = "label12";
            label12.Size = new System.Drawing.Size(144, 36);
            label12.TabIndex = 28;
            label12.Text = "Водитель:";
            // 
            // textBoxDriverUpdate
            // 
            textBoxDriverUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            textBoxDriverUpdate.Location = new System.Drawing.Point(209, 65);
            textBoxDriverUpdate.Name = "textBoxDriverUpdate";
            textBoxDriverUpdate.Size = new System.Drawing.Size(236, 41);
            textBoxDriverUpdate.TabIndex = 22;
            textBoxDriverUpdate.TextChanged += textBox1_TextChanged_1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label11.Location = new System.Drawing.Point(9, 112);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(141, 36);
            label11.TabIndex = 29;
            label11.Text = "Маршрут:";
            // 
            // comboBoxRouteUpdate
            // 
            comboBoxRouteUpdate.DisplayMember = "1";
            comboBoxRouteUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            comboBoxRouteUpdate.FormattingEnabled = true;
            comboBoxRouteUpdate.Items.AddRange(new object[] { "№ 1", "№ 2", "№ 4", "№ 5", "№ 6", "№ 7", "№ 29", "№ 54", "№ 66", "№ 70", "№ 75", "№ 82С", "№ 93", "№ 101", "№ 105", "№ 130", "№ 149" });
            comboBoxRouteUpdate.Location = new System.Drawing.Point(209, 112);
            comboBoxRouteUpdate.Name = "comboBoxRouteUpdate";
            comboBoxRouteUpdate.Size = new System.Drawing.Size(236, 43);
            comboBoxRouteUpdate.TabIndex = 23;
            comboBoxRouteUpdate.SelectedIndexChanged += comboBoxRouteUpdate_SelectedIndexChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label10.Location = new System.Drawing.Point(6, 166);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(155, 36);
            label10.TabIndex = 30;
            label10.Text = "Доход р/д:";
            // 
            // numericIncomeUpdate
            // 
            numericIncomeUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            numericIncomeUpdate.Location = new System.Drawing.Point(209, 161);
            numericIncomeUpdate.Maximum = new decimal(new int[] { 15000, 0, 0, 0 });
            numericIncomeUpdate.Minimum = new decimal(new int[] { 8000, 0, 0, 0 });
            numericIncomeUpdate.Name = "numericIncomeUpdate";
            numericIncomeUpdate.Size = new System.Drawing.Size(236, 41);
            numericIncomeUpdate.TabIndex = 24;
            numericIncomeUpdate.Value = new decimal(new int[] { 8000, 0, 0, 0 });
            numericIncomeUpdate.ValueChanged += numericIncomeUpdate_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label9.Location = new System.Drawing.Point(9, 213);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(160, 36);
            label9.TabIndex = 31;
            label9.Text = "Расход р/д:";
            // 
            // numericExpenseUpdate
            // 
            numericExpenseUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            numericExpenseUpdate.Location = new System.Drawing.Point(209, 208);
            numericExpenseUpdate.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericExpenseUpdate.Minimum = new decimal(new int[] { 5000, 0, 0, 0 });
            numericExpenseUpdate.Name = "numericExpenseUpdate";
            numericExpenseUpdate.Size = new System.Drawing.Size(236, 41);
            numericExpenseUpdate.TabIndex = 25;
            numericExpenseUpdate.Value = new decimal(new int[] { 5000, 0, 0, 0 });
            numericExpenseUpdate.ValueChanged += numericExpenseUpdate_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            label8.Location = new System.Drawing.Point(9, 260);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(185, 36);
            label8.TabIndex = 32;
            label8.Text = "Пробег км/д:";
            // 
            // numericMileageUpdate
            // 
            numericMileageUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            numericMileageUpdate.Location = new System.Drawing.Point(209, 255);
            numericMileageUpdate.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numericMileageUpdate.Minimum = new decimal(new int[] { 200, 0, 0, 0 });
            numericMileageUpdate.Name = "numericMileageUpdate";
            numericMileageUpdate.Size = new System.Drawing.Size(236, 41);
            numericMileageUpdate.TabIndex = 26;
            numericMileageUpdate.Value = new decimal(new int[] { 200, 0, 0, 0 });
            numericMileageUpdate.ValueChanged += numericMileageUpdate_ValueChanged;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = System.Drawing.Color.FromArgb(41, 128, 185);
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(52, 152, 219);
            btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnUpdate.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            btnUpdate.ForeColor = System.Drawing.Color.White;
            btnUpdate.Location = new System.Drawing.Point(6, 441);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new System.Drawing.Size(439, 47);
            btnUpdate.TabIndex = 33;
            btnUpdate.Text = "Обновить";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // bindingSource1
            // 
            bindingSource1.CurrentChanged += bindingSource1_CurrentChanged;
            // 
            // MainForm
            // 
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            BackColor = System.Drawing.Color.FromArgb(236, 240, 244);
            ClientSize = new System.Drawing.Size(1735, 1060);
            Controls.Add(menuStrip1);
            Controls.Add(tabControl1);
            Controls.Add(groupBox1);
            Controls.Add(dataGridView1);
            Controls.Add(btnDelete);
            Controls.Add(btnResetFilter);
            Controls.Add(btnResetSort);
            Controls.Add(btnResetSearch);
            Controls.Add(btnExit);
            Font = new System.Drawing.Font("Segoe UI", 9.5F);
            MainMenuStrip = menuStrip1;
            MinimumSize = new System.Drawing.Size(1216, 792);
            Name = "MainForm";
            Text = "Автобусный парк — Бояркин М.К.";
            Load += MainForm_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericIncome).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericExpense).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMileage).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericIncomeUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericExpenseUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericMileageUpdate).EndInit();
            ((System.ComponentModel.ISupportInitialize)bindingSource1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьКакToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem удалитьБДToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem создатьОтчётToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxFilter;
        private System.Windows.Forms.ComboBox comboBoxSort;
        private System.Windows.Forms.ComboBox comboBoxField;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnSort;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.Button btnResetSort;
        private System.Windows.Forms.Button btnResetSearch;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericMileageUpdate;
        private System.Windows.Forms.NumericUpDown numericExpenseUpdate;
        private System.Windows.Forms.NumericUpDown numericIncomeUpdate;
        private System.Windows.Forms.ComboBox comboBoxRouteUpdate;
        private System.Windows.Forms.TextBox textBoxDriverUpdate;
        private System.Windows.Forms.TextBox textBoxPlateUpdate;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericMileage;
        private System.Windows.Forms.NumericUpDown numericExpense;
        private System.Windows.Forms.NumericUpDown numericIncome;
        private System.Windows.Forms.ComboBox comboBoxRoute;
        private System.Windows.Forms.TextBox textBoxDriver;
        private System.Windows.Forms.TextBox textBoxPlate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
