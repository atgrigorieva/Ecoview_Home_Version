namespace Ecoview_Home_Version
{
    partial class Ecoview
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ecoview));
            this.Table2 = new System.Windows.Forms.DataGridView();
            this.WL220 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WL300 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WL400 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WL550 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WL750 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.OptichPlot = new System.Windows.Forms.TextBox();
            this.Table1 = new System.Windows.Forms.DataGridView();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.GAText = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.GWNew = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.GEText = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.Table2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table1)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Table2
            // 
            this.Table2.AllowUserToAddRows = false;
            this.Table2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WL220,
            this.WL300,
            this.WL400,
            this.WL550,
            this.WL750});
            this.Table2.Location = new System.Drawing.Point(6, 6);
            this.Table2.Name = "Table2";
            this.Table2.Size = new System.Drawing.Size(854, 361);
            this.Table2.TabIndex = 1;
            // 
            // WL220
            // 
            this.WL220.HeaderText = "220";
            this.WL220.Name = "WL220";
            // 
            // WL300
            // 
            this.WL300.HeaderText = "300";
            this.WL300.Name = "WL300";
            // 
            // WL400
            // 
            this.WL400.HeaderText = "400";
            this.WL400.Name = "WL400";
            // 
            // WL550
            // 
            this.WL550.HeaderText = "550";
            this.WL550.Name = "WL550";
            // 
            // WL750
            // 
            this.WL750.HeaderText = "750";
            this.WL750.Name = "WL750";
            // 
            // OptichPlot
            // 
            this.OptichPlot.Location = new System.Drawing.Point(748, 61);
            this.OptichPlot.Name = "OptichPlot";
            this.OptichPlot.ReadOnly = true;
            this.OptichPlot.Size = new System.Drawing.Size(100, 20);
            this.OptichPlot.TabIndex = 36;
            // 
            // Table1
            // 
            this.Table1.AllowUserToAddRows = false;
            this.Table1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Table1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Table1.Location = new System.Drawing.Point(6, 6);
            this.Table1.Name = "Table1";
            this.Table1.Size = new System.Drawing.Size(854, 361);
            this.Table1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Table1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(866, 373);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "30 Волн";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(620, 64);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 13);
            this.label11.TabIndex = 35;
            this.label11.Text = "Оптическая плотность";
            // 
            // GAText
            // 
            this.GAText.Location = new System.Drawing.Point(514, 61);
            this.GAText.Name = "GAText";
            this.GAText.ReadOnly = true;
            this.GAText.Size = new System.Drawing.Size(100, 20);
            this.GAText.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(363, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(145, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "Коэффициент пропускания";
            // 
            // GWNew
            // 
            this.GWNew.Location = new System.Drawing.Point(96, 61);
            this.GWNew.Name = "GWNew";
            this.GWNew.ReadOnly = true;
            this.GWNew.Size = new System.Drawing.Size(100, 20);
            this.GWNew.TabIndex = 32;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 64);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Длина волны";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(202, 64);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Энергия";
            // 
            // GEText
            // 
            this.GEText.Location = new System.Drawing.Point(257, 61);
            this.GEText.Name = "GEText";
            this.GEText.ReadOnly = true;
            this.GEText.Size = new System.Drawing.Size(100, 20);
            this.GEText.TabIndex = 29;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Table2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(866, 373);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "4 Волны";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(9, 87);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(874, 399);
            this.tabControl1.TabIndex = 28;
            // 
            // button4
            // 
            this.button4.Image = global::Ecoview_Home_Version.Properties.Resources.Meas_btn;
            this.button4.Location = new System.Drawing.Point(157, 17);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(34, 34);
            this.button4.TabIndex = 27;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Image = global::Ecoview_Home_Version.Properties.Resources.Reziro_btn;
            this.button3.Location = new System.Drawing.Point(117, 17);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(34, 34);
            this.button3.TabIndex = 26;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Image = global::Ecoview_Home_Version.Properties.Resources.Connect_btn;
            this.button2.Location = new System.Drawing.Point(53, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 34);
            this.button2.TabIndex = 25;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Image = global::Ecoview_Home_Version.Properties.Resources.Exit_btn;
            this.button1.Location = new System.Drawing.Point(13, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 34);
            this.button1.TabIndex = 24;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(337, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 17);
            this.checkBox1.TabIndex = 37;
            this.checkBox1.Text = "от 428,0 до 582,5";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(469, 27);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(112, 17);
            this.checkBox2.TabIndex = 38;
            this.checkBox2.Text = "от 582,5 до 682,0";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(610, 27);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(112, 17);
            this.checkBox3.TabIndex = 39;
            this.checkBox3.Text = "от 682,0 до 688,0";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // Ecoview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(892, 502);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.OptichPlot);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.GAText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.GWNew);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.GEText);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ecoview";
            this.Text = "Эковью Home Version 1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Table2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Table1)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView Table2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox OptichPlot;
        private System.Windows.Forms.DataGridView Table1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox GAText;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox GWNew;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox GEText;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WL220;
        private System.Windows.Forms.DataGridViewTextBoxColumn WL300;
        private System.Windows.Forms.DataGridViewTextBoxColumn WL400;
        private System.Windows.Forms.DataGridViewTextBoxColumn WL550;
        private System.Windows.Forms.DataGridViewTextBoxColumn WL750;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
    }
}

