namespace TEST4LABA
{
    partial class StartForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.dGV_main = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add_town = new System.Windows.Forms.Button();
            this.dtn_del_town = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_period = new System.Windows.Forms.TextBox();
            this.textBox_day = new System.Windows.Forms.TextBox();
            this.textBox_month = new System.Windows.Forms.TextBox();
            this.textBox_year = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_VaccineCost = new System.Windows.Forms.TextBox();
            this.textBox_budget = new System.Windows.Forms.TextBox();
            this.btn_model = new System.Windows.Forms.Button();
            this.btn_random_gen = new System.Windows.Forms.Button();
            this.textBox_average_salary = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dorogi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dGV_main)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dGV_main
            // 
            this.dGV_main.AllowUserToAddRows = false;
            this.dGV_main.AllowUserToDeleteRows = false;
            this.dGV_main.AllowUserToResizeColumns = false;
            this.dGV_main.AllowUserToResizeRows = false;
            this.dGV_main.BackgroundColor = System.Drawing.Color.White;
            this.dGV_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dGV_main.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dGV_main.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dGV_main.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(113)))), ((int)(((byte)(96)))), ((int)(((byte)(232)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGV_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGV_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGV_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8,
            this.dorogi});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.SteelBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGV_main.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGV_main.EnableHeadersVisualStyles = false;
            this.dGV_main.GridColor = System.Drawing.Color.LightGray;
            this.dGV_main.Location = new System.Drawing.Point(7, 7);
            this.dGV_main.MultiSelect = false;
            this.dGV_main.Name = "dGV_main";
            this.dGV_main.RowHeadersVisible = false;
            this.dGV_main.RowHeadersWidth = 25;
            this.dGV_main.RowTemplate.DividerHeight = 1;
            this.dGV_main.RowTemplate.Height = 25;
            this.dGV_main.Size = new System.Drawing.Size(754, 509);
            this.dGV_main.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::TEST4LABA.Resources.background_panel;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.dGV_main);
            this.panel1.ForeColor = System.Drawing.Color.SteelBlue;
            this.panel1.Location = new System.Drawing.Point(316, 85);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 15);
            this.panel1.Size = new System.Drawing.Size(777, 528);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(222, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(663, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "Моделирование вирусного заболевания";
            // 
            // btn_add_town
            // 
            this.btn_add_town.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(243)))));
            this.btn_add_town.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_add_town.Location = new System.Drawing.Point(729, 617);
            this.btn_add_town.Name = "btn_add_town";
            this.btn_add_town.Size = new System.Drawing.Size(161, 42);
            this.btn_add_town.TabIndex = 2;
            this.btn_add_town.Text = "Добавить город";
            this.btn_add_town.UseVisualStyleBackColor = false;
            this.btn_add_town.Click += new System.EventHandler(this.btn_Add_Town);
            // 
            // dtn_del_town
            // 
            this.dtn_del_town.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(243)))));
            this.dtn_del_town.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dtn_del_town.Location = new System.Drawing.Point(916, 617);
            this.dtn_del_town.Name = "dtn_del_town";
            this.dtn_del_town.Size = new System.Drawing.Size(161, 42);
            this.dtn_del_town.TabIndex = 3;
            this.dtn_del_town.Text = "Удалить город";
            this.dtn_del_town.UseVisualStyleBackColor = false;
            this.dtn_del_town.Click += new System.EventHandler(this.btn_Delete_Town);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(27, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 54);
            this.label2.TabIndex = 4;
            this.label2.Text = "Период моделирования (месяцы)";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(26, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 37);
            this.label3.TabIndex = 5;
            this.label3.Text = "Дата начала моделирования";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(26, 253);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 45);
            this.label4.TabIndex = 6;
            this.label4.Text = "Стоимость одной прививки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(32, 363);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "Бюджет";
            // 
            // textBox_period
            // 
            this.textBox_period.Location = new System.Drawing.Point(32, 142);
            this.textBox_period.Name = "textBox_period";
            this.textBox_period.Size = new System.Drawing.Size(89, 27);
            this.textBox_period.TabIndex = 9;
            this.textBox_period.Text = "12";
            // 
            // textBox_day
            // 
            this.textBox_day.Location = new System.Drawing.Point(32, 203);
            this.textBox_day.Name = "textBox_day";
            this.textBox_day.Size = new System.Drawing.Size(32, 27);
            this.textBox_day.TabIndex = 10;
            this.textBox_day.Text = "31";
            // 
            // textBox_month
            // 
            this.textBox_month.Location = new System.Drawing.Point(88, 203);
            this.textBox_month.Name = "textBox_month";
            this.textBox_month.Size = new System.Drawing.Size(32, 27);
            this.textBox_month.TabIndex = 11;
            this.textBox_month.Text = "12";
            // 
            // textBox_year
            // 
            this.textBox_year.Location = new System.Drawing.Point(144, 203);
            this.textBox_year.Name = "textBox_year";
            this.textBox_year.Size = new System.Drawing.Size(49, 27);
            this.textBox_year.TabIndex = 12;
            this.textBox_year.Text = "1999";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(126, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 20);
            this.label8.TabIndex = 14;
            this.label8.Text = ".";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(70, 210);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(12, 20);
            this.label9.TabIndex = 15;
            this.label9.Text = ".";
            // 
            // textBox_VaccineCost
            // 
            this.textBox_VaccineCost.Location = new System.Drawing.Point(32, 319);
            this.textBox_VaccineCost.Name = "textBox_VaccineCost";
            this.textBox_VaccineCost.Size = new System.Drawing.Size(89, 27);
            this.textBox_VaccineCost.TabIndex = 16;
            this.textBox_VaccineCost.Text = "2000";
            // 
            // textBox_budget
            // 
            this.textBox_budget.Location = new System.Drawing.Point(32, 387);
            this.textBox_budget.Name = "textBox_budget";
            this.textBox_budget.Size = new System.Drawing.Size(89, 27);
            this.textBox_budget.TabIndex = 17;
            this.textBox_budget.Text = "0";
            // 
            // btn_model
            // 
            this.btn_model.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(243)))));
            this.btn_model.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btn_model.Location = new System.Drawing.Point(43, 441);
            this.btn_model.Name = "btn_model";
            this.btn_model.Size = new System.Drawing.Size(180, 73);
            this.btn_model.TabIndex = 19;
            this.btn_model.Text = "Начать моделирование";
            this.btn_model.UseVisualStyleBackColor = false;
            this.btn_model.Click += new System.EventHandler(this.btn_model_Click);
            // 
            // btn_random_gen
            // 
            this.btn_random_gen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(233)))), ((int)(((byte)(233)))), ((int)(((byte)(243)))));
            this.btn_random_gen.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btn_random_gen.Location = new System.Drawing.Point(323, 619);
            this.btn_random_gen.Name = "btn_random_gen";
            this.btn_random_gen.Size = new System.Drawing.Size(377, 40);
            this.btn_random_gen.TabIndex = 20;
            this.btn_random_gen.Text = "Случайно сгенерировать города";
            this.btn_random_gen.UseVisualStyleBackColor = false;
            this.btn_random_gen.Click += new System.EventHandler(this.btn_random_gen_Click);
            // 
            // textBox_average_salary
            // 
            this.textBox_average_salary.Location = new System.Drawing.Point(168, 319);
            this.textBox_average_salary.Name = "textBox_average_salary";
            this.textBox_average_salary.Size = new System.Drawing.Size(89, 27);
            this.textBox_average_salary.TabIndex = 22;
            this.textBox_average_salary.Text = "50000";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(167, 253);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 63);
            this.label6.TabIndex = 21;
            this.label6.Text = "Средняя зарплата 1-го человека";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column7.FillWeight = 10F;
            this.Column7.HeaderText = "Номер";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 97;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column1.FillWeight = 40F;
            this.Column1.HeaderText = "Название";
            this.Column1.Name = "Column1";
            this.Column1.Width = 110;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.FillWeight = 35F;
            this.Column2.HeaderText = "Население";
            this.Column2.Name = "Column2";
            this.Column2.Width = 138;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column3.FillWeight = 35F;
            this.Column3.HeaderText = "Зараженные";
            this.Column3.Name = "Column3";
            this.Column3.Width = 138;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column4.FillWeight = 35F;
            this.Column4.HeaderText = "Привитые";
            this.Column4.Name = "Column4";
            this.Column4.Width = 139;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column5.FillWeight = 35F;
            this.Column5.HeaderText = "Транспортное сообщение (%)";
            this.Column5.Name = "Column5";
            this.Column5.Width = 139;
            // 
            // Column8
            // 
            this.Column8.FillWeight = 35F;
            this.Column8.HeaderText = "Тип города";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // dorogi
            // 
            this.dorogi.HeaderText = "Дороги";
            this.dorogi.Name = "dorogi";
            // 
            // StartForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImage = global::TEST4LABA.Resources.start_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1105, 681);
            this.Controls.Add(this.textBox_average_salary);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_random_gen);
            this.Controls.Add(this.btn_model);
            this.Controls.Add(this.textBox_budget);
            this.Controls.Add(this.textBox_VaccineCost);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_year);
            this.Controls.Add(this.textBox_month);
            this.Controls.Add(this.textBox_day);
            this.Controls.Add(this.textBox_period);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtn_del_town);
            this.Controls.Add(this.btn_add_town);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Model Start";
            this.Load += new System.EventHandler(this.temp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGV_main)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dGV_main;
        private Panel panel1;
        private Label label1;
        private Button btn_add_town;
        private Button dtn_del_town;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox textBox_period;
        private TextBox textBox_day;
        private TextBox textBox_month;
        private TextBox textBox_year;
        private Label label8;
        private Label label9;
        private TextBox textBox_VaccineCost;
        private TextBox textBox_budget;
        private Button btn_model;
        private Button btn_random_gen;
        private TextBox textBox_average_salary;
        private Label label6;
        private ErrorProvider errorProvider1;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn dorogi;
    }
}