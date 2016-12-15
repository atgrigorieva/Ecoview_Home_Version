using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.IO;
using SWF = System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Ecoview_Home_Version
{
    public partial class Ecoview : Form
    {
        public SerialPort newPort;
        public Ecoview()
        {
            InitializeComponent();
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
            if (ComPort1 == false)
            {
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;
            }

            WLREMOVESTR1();
            WLADD1();
            
        }

        public void WLADD1()
        {

            for (double i = 428.0; i <= 434.0; i += 0.5)
            {

                DataGridViewTextBoxColumn firstColumn1 =
                new DataGridViewTextBoxColumn();
                firstColumn1.HeaderText = string.Format("{0:0.0}", i);
                firstColumn1.Name = "Wl" + i;
                firstColumn1.ValueType = Type.GetType("System.Double");
                Table1.Columns.Add(firstColumn1);


            }
            for (double i = 582.5; i <= 588.5; i += 0.5)
            {

                DataGridViewTextBoxColumn firstColumn2 =
                new DataGridViewTextBoxColumn();
                firstColumn2.HeaderText = string.Format("{0:0.0}", i);
                firstColumn2.Name = "Wl" + i;
                firstColumn2.ValueType = Type.GetType("System.Double");
                Table1.Columns.Add(firstColumn2);


            }
            for (double i = 682.0; i <= 688.0; i += 0.5)
            {

                DataGridViewTextBoxColumn firstColumn3 =
                new DataGridViewTextBoxColumn();
                firstColumn3.HeaderText = string.Format("{0:0.0}", i);
                firstColumn3.Name = "Wl" + i;
                firstColumn3.ValueType = Type.GetType("System.Double");
                Table1.Columns.Add(firstColumn3);


            }
            // MessageBox.Show(Table1.ColumnCount.ToString());
            Table1.Rows.Add();
            Table2.Rows.Add();
        }
        public void WLREMOVESTR1()
        {
            Table1.Rows.Clear();
            Table2.Rows.Clear();

        }

        //public bool ComPort = false;
        public bool ComPodkl = false;
        public bool ComPort1 = false;
        public string portsName = "";
        public string GW1_2 = "";
        public string wavelength1;
        public void button2_Click(object sender, EventArgs e)
        {
            ComPort();

        }
        public bool nonPort = false;
        public bool nonPort1 = false;
        public void ComPort()
        {
            ComPortTrue _ComPortTrue = new ComPortTrue(this);
            if (nonPort == true)
            {
                _ComPortTrue.ShowDialog();
            }
            else
            {
                _ComPortTrue.Dispose();
            }
            if (nonPort == true && Izmerenie1 != false)
            {
                newPort = new SerialPort();

                try
                {
                    // настройки порта (Communication interface)
                    newPort.PortName = portsName;
                    newPort.BaudRate = 19200;
                    newPort.DataBits = 8;
                    newPort.Parity = System.IO.Ports.Parity.None;
                    newPort.StopBits = System.IO.Ports.StopBits.One;
                    // Установка таймаутов чтения/записи (read/write timeouts)
                    newPort.ReadTimeout = 500;
                    newPort.WriteTimeout = 500;
                    //    newPort.DataReceived += new SerialDataReceivedEventHandler(newPort_DataReceived);
                    newPort.RtsEnable = false;
                    newPort.DtrEnable = true;
                    newPort.Open();
                    //      MessageBox.Show("ПОРТ ОТКРЫТ " + newPort.PortName);


                    newPort.DiscardInBuffer();
                    newPort.DiscardOutBuffer();
                }
                catch (Exception)
                {
                    MessageBox.Show("Порт не был выбран!");
                    return;

                }

                Analis__Activated();
                CO();

                RD();

                Izmerenie1 = false;
                ComPodkl = true;
                SAGE(ref countSA, ref GE5_1_0);

                button2.Enabled = false;
                button1.Enabled = true;
                button3.Enabled = true;
               // button4.Enabled = true;
                ComPort1 = true;
                button1.Enabled = true;

                wavelength1 = GWNew.Text;
            }
        }
        int count = 0;

        public string[] Stroka;
        // public int[] mass1;
        public string GE5_1_0 = "";
        public string GE5_1_1 = "";
        public string GE5_1_0_1 = "";
        public int resulcCountSA1;


        public int[] mass0;
        public int[] massSA;
        public void Analis__Activated()
        {
            newPort.Write("CO\r");

        }
        public string versionPribor;
        public void CO()
        {

            string b = "";
            int byteRecieved = newPort.ReadBufferSize;
            Thread.Sleep(500);
            byte[] buffer = new byte[byteRecieved];
            newPort.Read(buffer, 0, byteRecieved);

            string GW1 = "";

            for (int i = 0; i <= 50; i++)
            {
                GW1 = GW1 + Convert.ToChar(buffer[i]);
            }
            var GWarr = GW1.Split("\r".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            // GW1 = Convert.ToString(GWbuffer[0]);

            GW1_2 = GWarr[2];
            GWNew.Text = GW1_2;
            versionPribor = GWarr[1];
            MessageBox.Show(versionPribor);
           //// Regex regex = new Regex(pattern);
           // string GW1_2_string = regex
        }
        public void RD()
        {
            newPort.Write("RD\r");

            int RDbyteRecieved = newPort.ReadBufferSize;

            Thread.Sleep(100);
            byte[] RDbuffer = new byte[RDbyteRecieved];
            newPort.Read(RDbuffer, 0, RDbyteRecieved);

        }
        public int countSA;
        bool Izmerenie1 = true;
        public void LogoForm()
        {
            Form LogoForm = new Form();
            // LogoForm.BackColor = System.Drawing.Color.White;
            LogoForm.BackgroundImage = System.Drawing.Image.FromFile("Calibrovka.png");
            LogoForm.AutoScaleMode = AutoScaleMode.Font;
            LogoForm.Size = new Size(430, 107);
            LogoForm.Text = "Калибровка...";
            LogoForm.MinimizeBox = false;
            LogoForm.MaximizeBox = false;
            LogoForm.AutoSize = false;
            LogoForm.Name = "LogoFrm";
            LogoForm.ShowInTaskbar = false;
            LogoForm.StartPosition = FormStartPosition.CenterScreen;
            LogoForm.ControlBox = false;
            LogoForm.FormBorderStyle = FormBorderStyle.None;

            LogoForm.Show();
        }
        public void SAGE(ref int countSA, ref string GE5_1_0)
        {
            bool message1 = true;
            if (versionPribor.Contains('2'))
            {    countSA = 8; }
            else
            {
                countSA = 4;
            }

         //   LogoForm();
            //Thread.Sleep(5000);
            newPort.Write("SA " + countSA + "\r");
            // int SAAnalisByteRecieved1 = newPort.ReadBufferSize;
            // Thread.Sleep(100);
            //byte[] SAAnalisBuffer1 = new byte[SAAnalisByteRecieved1];
            // newPort.Read(SAAnalisBuffer1, 0, SAAnalisByteRecieved1);
            string indata = newPort.ReadExisting();
            int indata_zero = 0;
            string indata_0;
            bool indata_bool = true;
            while (indata_bool == true)
            {
                
                if (indata.Contains('>'))
                {

                    indata_bool = false;

                }

                else {
                    indata = newPort.ReadExisting();

                }
            }

            newPort.Write("GE 1\r");

            string GE5_1 = "";
            int GEbyteRecieved4_1 = newPort.ReadBufferSize;
            byte[] GEbuffer4_1 = new byte[GEbyteRecieved4_1];
            //Thread.Sleep(100);
            newPort.Read(GEbuffer4_1, 0, GEbyteRecieved4_1);
           
            indata = newPort.ReadExisting();
            indata_zero = 0;
            indata_0 = "";
            indata_bool = true;
            while (indata_bool == true)
            {
                if (indata.Contains('>') && indata_zero == 0)
                {
                    //    indata_0 = "";
                    indata_0 = indata.Substring(3);
                    indata_bool = false;

                }

                else {
                    indata_zero++;
                    if (indata.Contains('>'))
                    {
                        //    indata_0 = "";
                        //  indata_0 = indata;
                        indata_bool = false;

                    }
                    else {
                        indata = newPort.ReadExisting();
                        indata_0 += indata;
                    }

                }
            }
            Regex regex = new Regex(@"\W");
            int indata_int = Convert.ToInt32(regex.Replace(indata_0, ""));
            GE5_1 = indata_int.ToString();
            GE5_1_0 = indata_int.ToString();
            GEText.Text = GE5_1_0;
            double GAText1 = (Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1_0)) * 100;

            GAText.Text = string.Format("{0:0.00}", GAText1);

            double OptPlot = Math.Log10(Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1));

            double OptPlot1 = OptPlot - Math.Truncate(OptPlot);
            OptichPlot.Text = string.Format("{0:0.0000}", OptPlot1);
            while (Convert.ToInt32(GE5_1) > 30000 && countSA > 1)
            {
                countSA--;
                newPort.Write("SA " + countSA + "\r");
                int SAAnalisByteRecieved1_1_1 = newPort.ReadBufferSize;
                // Thread.Sleep(100);
                indata = newPort.ReadExisting();
                indata_zero = 0;
                indata_0 = "";
                indata_bool = true;
                while (indata_bool == true)
                {
                   
                    if (indata.Contains('>'))
                    {

                        indata_bool = false;

                    }

                    else {
                        indata = newPort.ReadExisting();
                    }
                }
             //   byte[] SAAnalisBuffer1_1_1 = new byte[SAAnalisByteRecieved1_1_1];
              //  newPort.Read(SAAnalisBuffer1_1_1, 0, SAAnalisByteRecieved1_1_1);

                newPort.Write("GE 1\r");
               GEbyteRecieved4_1 = newPort.ReadBufferSize;
               GEbuffer4_1 = new byte[GEbyteRecieved4_1];
                newPort.Read(GEbuffer4_1, 0, GEbyteRecieved4_1);

                indata = newPort.ReadExisting();
                indata_zero = 0;
                indata_0 = "";
                indata_bool = true;
                while (indata_bool == true)
                {

                    if (indata.Contains('>') && indata_zero == 0)
                    {
                        //    indata_0 = "";
                        indata_0 = indata.Substring(3);                        
                        indata_bool = false;

                    }

                    else {
                        indata_zero++;
                        if (indata.Contains('>'))
                        {
                            //    indata_0 = "";
                          //  indata_0 = indata;
                            indata_bool = false;

                        }
                        else {
                            indata = newPort.ReadExisting();
                            indata_0 += indata;
                        }
                        
                    }
                }

                regex = new Regex(@"\W");
                indata_int = Convert.ToInt32(regex.Replace(indata_0, ""));
                GE5_1 = indata_int.ToString();
                GE5_1_0 = indata_int.ToString();
                GEText.Text = GE5_1_0;

                GAText1 = (Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1_0)) * 100;

                GAText.Text = string.Format("{0:0.00}", GAText1);

                OptPlot = Math.Log10(Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5_1));

                OptPlot1 = OptPlot - Math.Truncate(OptPlot);

            }
        //    SWF.Application.OpenForms["LogoFrm"].Close();

          /*  if (Izmerenie1 == false)
            {
                InitializeTimer();
            }*/
        }
        public void InitializeTimer()
        {
            // Run this procedure in an appropriate event.
            if (Izmerenie1 == false)
            {
                timer1.Interval = 6000;
                timer1.Enabled = true;
                // Hook up timer's tick event handler.
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);

            }

            //break;

        }
        public void timer1_Tick(object sender, System.EventArgs e)
        {
            GE4();
        }
        double GAText1;
        public void GE4()
        {
            if (Izmerenie1 == false)
            {
                newPort.Write("GE 1\r");

                int GEbyteRecieved4_1 = newPort.ReadBufferSize;
                byte[] GEbuffer4_1 = new byte[GEbyteRecieved4_1];
                newPort.Read(GEbuffer4_1, 0, GEbyteRecieved4_1);

                string indata = newPort.ReadExisting();
      
               string indata_0 = "";
               bool indata_bool = true;
                while (indata_bool == true)
                {

                    if (indata.Contains('>'))
                    {

                        indata_bool = false;

                    }

                    else {

                        indata = newPort.ReadExisting();
                        indata_0 += indata;
                    }
                }
                string GE5 = "";
                GE5 = indata_0.Substring(0, indata_0.Length - 2);
                GEText.Text = GE5;

                GAText1 = (Convert.ToDouble(GE5) / Convert.ToDouble(GE5_1_0)) * 100;

                GAText.Text = string.Format("{0:0.00}", GAText1);

                double OptPlot = Math.Log10(Convert.ToDouble(GE5_1_0) / Convert.ToDouble(GE5));

                double OptPlot1 = OptPlot - Math.Truncate(OptPlot);
                OptichPlot.Text = string.Format("{0:0.0000}", OptPlot1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ComPort1 == true)
            {
                char[] ClosePribor = { Convert.ToChar('Q'), Convert.ToChar('U'), Convert.ToChar('\r') };
                newPort.Write("QU\r");
                Thread.Sleep(500);
                //  byte[] buffer1 = new byte[byteRecieved1];
                string indata = newPort.ReadExisting();

                bool indata_bool = true;
                while (indata_bool == true)
                {
                    if (indata.Contains('>'))
                    {

                        indata_bool = false;

                    }

                    else {
                        indata = newPort.ReadExisting();
                    }
                }

                GWNew.Text = null;
                GEText.Text = null;
                GAText.Text = null;
                OptichPlot.Text = null;
                Izmerenie1 = true;


                button2.Enabled = true;
                button1.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = false;

                button1.Enabled = false;
                newPort.Close();


            }
            ComPort1 = false;

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ComPort1 == true)
            {
                char[] ClosePribor = { Convert.ToChar('Q'), Convert.ToChar('U'), Convert.ToChar('\r') };
                newPort.Write("QU\r");
                Thread.Sleep(500);
                //  byte[] buffer1 = new byte[byteRecieved1];
                string indata = newPort.ReadExisting();

                bool indata_bool = true;
                while (indata_bool == true)
                {
                    if (indata.Contains('>'))
                    {

                        indata_bool = false;

                    }

                    else {
                        indata = newPort.ReadExisting();
                    }
                }

                newPort.Close();
            }
            else
            {
                SWF.Application.Exit();
            }
        }
        public int Table1StartIzmer;
        private void button3_Click(object sender, EventArgs e)
        {
            Izmerenie1 = true;
            if (tabControl1.SelectedIndex == 0)
            {
                
                if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
                {
                    SA = new int[14];
                    GE = new int[14];
                    Table1CountIzmer = 12;
                    Table1StartIzmer = 0;
                    IzmerSAGE();

                }
                else
                {
                    if (checkBox2.Checked == true && checkBox1.Checked == false && checkBox3.Checked == false)
                    {
                        SA = new int[14];
                        GE = new int[14];
                        Table1CountIzmer = 25;
                        Table1StartIzmer = 13;
                        IzmerSAGE();
                    }
                    else
                    {
                        if (checkBox3.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false)
                        {
                            SA = new int[14];
                            GE = new int[14];
                            Table1CountIzmer = 38;
                            Table1StartIzmer = 26;
                            IzmerSAGE();
                        }
                        else
                        {
                            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                            {
                                SA = new int[27];
                                GE = new int[27];
                                Table1CountIzmer = 25;
                                Table1StartIzmer = 0;
                                IzmerSAGE();
                            }
                            else
                            {
                                if (checkBox1.Checked == true && checkBox3.Checked == true && checkBox2.Checked == false)
                                {
                                    SA = new int[27];
                                    GE = new int[27];
                                    Table1StartIzmer = 0;
                                    Table1CountIzmer = 12;
                                    IzmerSAGE();
                                    Table1StartIzmer = 26;
                                    Table1CountIzmer = 38;
                                    IzmerSAGE1();
                                }
                                else
                                {
                                    if (checkBox2.Checked == true && checkBox3.Checked == true && checkBox1.Checked == false)
                                    {
                                        SA = new int[27];
                                        GE = new int[27];
                                        Table1CountIzmer = 38;
                                        Table1StartIzmer = 13;
                                        IzmerSAGE();
                                    }
                                    else
                                    {
                                        if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                                        {
                                            SA = new int[40];
                                            GE = new int[40];
                                            Table1CountIzmer = 38;
                                            Table1StartIzmer = 0;
                                            IzmerSAGE();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                
             //   countIzmer++;
               Table1.CurrentCell = Table1.Rows[countIzmer].Cells[0];
                button4.Enabled = true;
            }
            else
            {
                
                IzmerSAGE();
                //    IzmerGE();

              //  countIzmer1++;
                //  Table2.Rows.Add();
                Table2.CurrentCell = Table2.Rows[countIzmer1].Cells[0];
                button4.Enabled = true;
            }
        }
        int countIzmer = 0;
        int countIzmer1 = 0;
        public void button4_Click(object sender, EventArgs e)
        {
            Izmerenie1 = true;
            if (tabControl1.SelectedIndex == 0)
            {
                // Table1.Rows.Add();
                if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
                {
                    GEIzmer = new double[13];
                    GEIzmer_1 = new double[13];
                    Table1CountIzmer = 12;
                    Table1StartIzmer = 0;
                    IzmerGE();

                }
                else
                {
                    if (checkBox2.Checked == true && checkBox1.Checked == false && checkBox3.Checked == false)
                    {
                        GEIzmer = new double[13];
                        GEIzmer_1 = new double[13];
                        Table1CountIzmer = 25;
                        Table1StartIzmer = 13;
                        IzmerGE();
                    }
                    else
                    {
                        if (checkBox3.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false)
                        {
                            GEIzmer = new double[13];
                            GEIzmer_1 = new double[13];
                            Table1CountIzmer = 38;
                            Table1StartIzmer = 26;
                            IzmerGE();
                        }
                        else
                        {
                            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                            {
                                GEIzmer = new double[26];
                                GEIzmer_1 = new double[13];
                                GEIzmer_2 = new double[13];
                                Table1CountIzmer = 25;
                                Table1StartIzmer = 0;
                                IzmerGE();
                            }
                            else
                            {
                                if (checkBox1.Checked == true && checkBox3.Checked == true && checkBox2.Checked == false)
                                {
                                    GEIzmer = new double[26];
                                    GEIzmer_1 = new double[13];
                                    GEIzmer_2 = new double[13];
                                    Table1StartIzmer = 0;
                                    Table1CountIzmer = 12;
                                    IzmerGE();
                                    Table1StartIzmer = 26;
                                    Table1CountIzmer = 38;
                                    IzmerGE1();
                                }
                                else
                                {
                                    if (checkBox2.Checked == true && checkBox3.Checked == true && checkBox1.Checked == false)
                                    {
                                        GEIzmer = new double[26];
                                        GEIzmer_1 = new double[13];
                                        GEIzmer_2 = new double[13];
                                        Table1CountIzmer = 38;
                                        Table1StartIzmer = 13;
                                        IzmerGE();
                                    }
                                    else
                                    {
                                        if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                                        {
                                            GEIzmer = new double[39];
                                            GEIzmer_1 = new double[13];
                                            GEIzmer_2 = new double[13];
                                            GEIzmer_3 = new double[13];
                                            Table1CountIzmer = 38;
                                            Table1StartIzmer = 0;
                                            IzmerGE();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                countIzmer++;
                Table1.Rows.Add();
                Table1.CurrentCell = Table1.Rows[countIzmer].Cells[0];
               // MessageBox.Show("Находим минимумы");
                if (checkBox1.Checked == true && checkBox2.Checked == false && checkBox3.Checked == false)
                {
                    for (int i = 0; i < 13; i++)
                    {
                        GEIzmer_1[i] = GEIzmer[i];
                    }
                    Array.Sort(GEIzmer_1);                   
                    double minEl = GEIzmer_1[0];
                    textBox1.Text = string.Format("{0:0.00}", minEl);
                    textBox2.Text = "";
                    textBox3.Text = "";
                    label1.Text = "от 428,0 до 582,5";
                    label2.Text = "";
                    label3.Text = "";
                    bool minEl_bool = true;
                    int minEl_zero = 0;
                    int selRowNum = Table1.CurrentCell.RowIndex;
                    while (minEl_bool == true)
                    {
                      //  double minEl1 = Convert.ToDouble(Table1.Rows[selRowNum-1].Cells[minEl_zero].Value);
                      //  double minel2 = Convert.ToDouble(Table1.Rows[selRowNum-1].Cells[minEl_zero+1].Value);
                        if (Convert.ToDouble(Table1.Rows[selRowNum - 1].Cells[minEl_zero].Value) == Convert.ToDouble(string.Format("{0:0.00}", minEl)))
                        {
                            label4.Text = Table1.Columns[minEl_zero].HeaderText;
                            label5.Text = "";
                            label6.Text = "";
                            minEl_bool = false;
                        }
                        else
                        {
                           // MessageBox.Show(Table1.Rows[selRowNum-1].Cells[minEl_zero].Value.ToString());
                            minEl_zero++;

                        }
                    } 
                }
                else
                {
                    if (checkBox2.Checked == true && checkBox1.Checked == false && checkBox3.Checked == false)
                    {
                        for (int i = 0; i < 13; i++)
                        {
                            GEIzmer_1[i] = GEIzmer[i];
                        }
                        Array.Sort(GEIzmer_1);
                        double minEl = GEIzmer_1[0];
                        textBox1.Text = string.Format("{0:0.00}", minEl);
                        textBox2.Text = "";
                        textBox3.Text = "";
                        label1.Text = "от 582,5 до 682,0";
                        label2.Text = "";
                        label3.Text = "";
                        bool minEl_bool = true;
                        int minEl_zero = 0;
                        int selRowNum = Table1.CurrentCell.RowIndex;
                        while (minEl_bool == true)
                        {
                            if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", minEl))
                            {
                                label4.Text = Table1.Columns[minEl_zero].HeaderText;
                                label5.Text = "";
                                label6.Text = "";
                                minEl_bool = false;
                            }
                            else
                            {
                                minEl_zero++;

                            }
                        }

                    }
                    else
                    {
                        if (checkBox3.Checked == true && checkBox1.Checked == false && checkBox2.Checked == false)
                        {
                            for (int i = 0; i < 13; i++)
                            {
                                GEIzmer_1[i] = GEIzmer[i];
                            }
                            Array.Sort(GEIzmer_1);
                            double minEl = GEIzmer_1[0];
                            textBox1.Text = string.Format("{0:0.00}", minEl);
                            textBox2.Text = "";
                            textBox3.Text = "";
                            label1.Text = "от 682,0 до 688,0";
                            label2.Text = "";
                            label3.Text = "";
                            bool minEl_bool = true;
                            int minEl_zero = 0;
                            int selRowNum = Table1.CurrentCell.RowIndex;
                            while (minEl_bool == true)
                            {
                                if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", minEl))
                                {
                                    label4.Text = Table1.Columns[minEl_zero].HeaderText;
                                    label5.Text = "";
                                    label6.Text = "";
                                    minEl_bool = false;
                                }
                                else
                                {
                                    minEl_zero++;

                                }
                            }
                        }
                        else
                        {
                            if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == false)
                            {
                                int massEl = 0;
                                for (int i = 0; i < 13; i++)
                                {
                                    GEIzmer_1[i] = GEIzmer[i];
                                }
                                for (int i = 13; i < 26; i++)
                                {
                                    GEIzmer_2[massEl] = GEIzmer[i];
                                    massEl++;
                                }
                             
                                Array.Sort(GEIzmer_1);
                                double minEl = GEIzmer_1[0];
                                textBox1.Text = string.Format("{0:0.00}", minEl);
                                bool minEl_bool = true;
                                int minEl_zero = 0;
                                int selRowNum = Table1.CurrentCell.RowIndex;
                                while (minEl_bool == true)
                                {
                                    if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox1.Text))
                                    {
                                        label4.Text = Table1.Columns[minEl_zero].HeaderText;
                                        label5.Text = "";
                                        label6.Text = "";
                                        minEl_bool = false;
                                    }
                                    else
                                    {
                                        minEl_zero++;

                                    }
                                }
                                Array.Sort(GEIzmer_2);
                                double minEl_2 = GEIzmer_2[0];
                                textBox2.Text = string.Format("{0:0.00}", minEl_2);
                                minEl_bool = true;
                                minEl_zero = 0;
                                selRowNum = Table1.CurrentCell.RowIndex;
                                while (minEl_bool == true)
                                {
                                    if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox2.Text))
                                    {
                                        label5.Text = Table1.Columns[minEl_zero].HeaderText;
                                        
                                        minEl_bool = false;
                                    }
                                    else
                                    {
                                        minEl_zero++;

                                    }
                                }
                                textBox3.Text = "";
                                label1.Text = "от 428,0 до 582,5";
                                label2.Text = "от 582,5 до 682,0";
                                label3.Text = "";
                            }
                            else
                            {
                                if (checkBox1.Checked == true && checkBox3.Checked == true && checkBox2.Checked == false)
                                {
                                    int massEl = 0;
                                    for (int i = 0; i < 13; i++)
                                    {
                                        GEIzmer_1[i] = GEIzmer[i];
                                    }
                                    for (int i = 13; i < 26; i++)
                                    {
                                        GEIzmer_2[massEl] = GEIzmer[i];
                                        massEl++;
                                    }
                                    Array.Sort(GEIzmer_1);
                                    double minEl = GEIzmer_1[0];
                                    textBox1.Text = string.Format("{0:0.00}", minEl);
                                    bool minEl_bool = true;
                                    int minEl_zero = 0;
                                    int selRowNum = Table1.CurrentCell.RowIndex;
                                    while (minEl_bool == true)
                                    {
                                        if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox1.Text))
                                        {
                                            label4.Text = Table1.Columns[minEl_zero].HeaderText;
                                            label5.Text = "";
                                            label6.Text = "";
                                            minEl_bool = false;
                                        }
                                        else
                                        {
                                            minEl_zero++;

                                        }
                                    }
                                    Array.Sort(GEIzmer_2);
                                    double minEl_2 = GEIzmer_2[0];
                                    textBox2.Text = string.Format("{0:0.00}", minEl_2);
                                    minEl_bool = true;
                                    minEl_zero = 0;
                                    selRowNum = Table1.CurrentCell.RowIndex;
                                    while (minEl_bool == true)
                                    {
                                        if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox2.Text))
                                        {
                                            label5.Text = Table1.Columns[minEl_zero].HeaderText;
                                            
                                            minEl_bool = false;
                                        }
                                        else
                                        {
                                            minEl_zero++;

                                        }
                                    }
                                    textBox3.Text = "";
                                    label1.Text = "от 428,0 до 582,5";
                                    label2.Text = "от 682,0 до 688,0";
                                    label3.Text = "";

                                }
                                else
                                {
                                    if (checkBox2.Checked == true && checkBox3.Checked == true && checkBox1.Checked == false)
                                    {
                                        int massEl = 0;
                                        for (int i = 0; i < 13; i++)
                                        {
                                            GEIzmer_1[i] = GEIzmer[i];
                                        }
                                        for (int i = 13; i < 26; i++)
                                        {
                                            GEIzmer_2[massEl] = GEIzmer[i];
                                            massEl++;
                                        }
                                        Array.Sort(GEIzmer_1);
                                        double minEl = GEIzmer_1[0];
                                        textBox1.Text = string.Format("{0:0.00}", minEl);
                                        bool minEl_bool = true;
                                        int minEl_zero = 0;
                                        int selRowNum = Table1.CurrentCell.RowIndex;
                                        while (minEl_bool == true)
                                        {
                                            if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox1.Text))
                                            {
                                                label4.Text = Table1.Columns[minEl_zero].HeaderText;
                                                label5.Text = "";
                                                label6.Text = "";
                                                minEl_bool = false;
                                            }
                                            else
                                            {
                                                minEl_zero++;

                                            }
                                        }
                                        Array.Sort(GEIzmer_2);
                                        double minEl_2 = GEIzmer_2[0];
                                        textBox2.Text = string.Format("{0:0.00}", minEl_2);
                                        minEl_bool = true;
                                        minEl_zero = 0;
                                        selRowNum = Table1.CurrentCell.RowIndex;
                                        while (minEl_bool == true)
                                        {
                                            if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox2.Text))
                                            {
                                                label5.Text = Table1.Columns[minEl_zero].HeaderText;
                                               
                                                minEl_bool = false;
                                            }
                                            else
                                            {
                                                minEl_zero++;

                                            }
                                        }
                                        textBox3.Text = "";
                                        label1.Text = "от 582,5 до 682,0";
                                        label2.Text = "от 682,0 до 688,0";
                                        label3.Text = "";
                                    }
                                    else
                                    {
                                        if (checkBox1.Checked == true && checkBox2.Checked == true && checkBox3.Checked == true)
                                        {
                                            int massEl = 0;

                                            for (int i = 0; i < 13; i++)
                                            {
                                                GEIzmer_1[i] = GEIzmer[i];
                                            }
                                            for (int i = 13; i < 26; i++)
                                            {
                                                GEIzmer_2[massEl] = GEIzmer[i];
                                                massEl++;
                                            }
                                            massEl = 0;
                                            for (int i = 26; i < 39; i++)
                                            {
                                                GEIzmer_3[massEl] = GEIzmer[i];
                                                massEl++;
                                            }
                                            Array.Sort(GEIzmer_1);
                                            double minEl = GEIzmer_1[0];
                                            textBox1.Text = string.Format("{0:0.00}", minEl);
                                            bool minEl_bool = true;
                                            int minEl_zero = 0;
                                            int selRowNum = Table1.CurrentCell.RowIndex;
                                            while (minEl_bool == true)
                                            {
                                                if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox1.Text))
                                                {
                                                    label4.Text = Table1.Columns[minEl_zero].HeaderText;
                                                    label5.Text = "";
                                                    label6.Text = "";
                                                    minEl_bool = false;
                                                }
                                                else
                                                {
                                                    minEl_zero++;

                                                }
                                            }
                                            Array.Sort(GEIzmer_2);
                                            double minEl_2 = GEIzmer_2[0];
                                            textBox2.Text = string.Format("{0:0.00}", minEl_2);
                                            minEl_bool = true;
                                            minEl_zero = 0;
                                            selRowNum = Table1.CurrentCell.RowIndex;
                                            while (minEl_bool == true)
                                            {
                                                if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox2.Text))
                                                {
                                                    label5.Text = Table1.Columns[minEl_zero].HeaderText;
                                                   
                                                    minEl_bool = false;
                                                }
                                                else
                                                {
                                                    minEl_zero++;

                                                }
                                            }
                                            Array.Sort(GEIzmer_3);
                                            double minEl_3 = GEIzmer_3[0];
                                            textBox3.Text = string.Format("{0:0.00}", minEl_3);
                                            minEl_bool = true;
                                            minEl_zero = 0;
                                            selRowNum = Table1.CurrentCell.RowIndex;
                                            while (minEl_bool == true)
                                            {
                                                if (string.Format("{0:0.00}", (Table1.Rows[selRowNum-1].Cells[minEl_zero].Value)) == string.Format("{0:0.00}", textBox3.Text))
                                                {
                                                    label6.Text = Table1.Columns[minEl_zero].HeaderText;
                                                   
                                                    minEl_bool = false;
                                                }
                                                else
                                                {
                                                    minEl_zero++;

                                                }
                                            }
                                            label1.Text = "от 428,0 до 582,5";
                                            label2.Text = "от 582,5 до 682,0";
                                            label3.Text = "от 682,0 до 688,0";
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
             //   Table2.Rows.Add();
                IzmerGE();
                //    IzmerGE();

                countIzmer1++;
               Table2.Rows.Add();
                Table2.CurrentCell = Table2.Rows[countIzmer1].Cells[0];
            }
        }
        public void LogoForm1()
        {
            Form LogoForm = new Form();
            // LogoForm.BackColor = System.Drawing.Color.White;
            LogoForm.BackgroundImage = System.Drawing.Image.FromFile("Yasnovka_DLWALVE.png");
            LogoForm.AutoScaleMode = AutoScaleMode.Font;
            LogoForm.Size = new Size(430, 107);
            LogoForm.Text = "Установка длины волны...";
            LogoForm.MinimizeBox = false;
            LogoForm.MaximizeBox = false;
            LogoForm.AutoSize = false;
            LogoForm.Name = "LogoFrm";
            LogoForm.ShowInTaskbar = false;
            LogoForm.StartPosition = FormStartPosition.CenterScreen;
            LogoForm.ControlBox = false;
            LogoForm.FormBorderStyle = FormBorderStyle.None;

            LogoForm.Show();
        }
      
        public int[] SA;
        public int[] GE;
        public double[] GEIzmer;
        public double[] GEIzmer_1;
        public double[] GEIzmer_2;
        public double[] GEIzmer_3;
        public int[] SA1;
        public int[] GE1;
        public int Table1CountIzmer;
        public void IzmerSAGE()
        {

            if (tabControl1.SelectedIndex == 0)
            {

                //  SA = new int[39];
                // GE = new int[39];
                int i = 0;
                for (int j = Table1StartIzmer; j <= Table1CountIzmer; j++)
                {
                    // GW();
                    Table1.CurrentCell = Table1.Rows[countIzmer].Cells[j];
                   // LogoForm1();
                    string SWText1 = Table1.Columns[j].HeaderText;
                    double SWText1_double = Convert.ToDouble(SWText1);
                    double GWNew_double = double.Parse(GWNew.Text.Replace(".", ","));
                    newPort.Write("SW " + SWText1_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");
  
                   // int byteRecieved1 = newPort.ReadBufferSize;
                    Thread.Sleep(500);
                 //   byte[] buffer1 = new byte[byteRecieved1];
                   
                    string indata = newPort.ReadExisting();
                   
                    bool indata_bool = true;
                    while (indata_bool == true)
                    {
                        if (indata.Contains('>'))
                        {
                         
                            indata_bool = false;
                     
                        }
               
                        else {
                            indata = newPort.ReadExisting();
                        }
                    }
                                  

                            GWNew.Text = SWText1;
               
                 //   SWF.Application.OpenForms["LogoFrm"].Close();
                    SAGE(ref countSA, ref GE5_1_0);
                   
                    SA[i] = Convert.ToInt32(countSA);
                    GE[i] = Convert.ToInt32(GE5_1_0);
                 //   double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE[j]) * 100;
               //     Table1.CurrentCell.Value = string.Format("{0:0.0}", GE[i]);
                    i++;
                }
           //     IzmerGE();
            }
            else
            {
                int massEl = 0;
                SA1 = new int[5];
                GE1 = new int[5];
                if (versionPribor.Contains('U'))
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        Table2.CurrentCell = Table2.Rows[countIzmer1].Cells[j];
                        double GWNew_double = 0.0;
                        //     GW();
                  //      LogoForm1();
                        string SWText1 = Table2.Columns[j].HeaderText;
                        double SWText1_double = Convert.ToDouble(SWText1);
                        GWNew_double = double.Parse(GWNew.Text.Replace(".", ","));
                        newPort.Write("SW " + SWText1_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");                       
                        Thread.Sleep(500);
                  
                       string indata = newPort.ReadExisting();

                        bool indata_bool = true;
                        while (indata_bool == true)
                        {
                            if (indata.Contains('>'))
                            {

                                indata_bool = false;

                            }

                            else {
                                indata = newPort.ReadExisting();
                            }
                        }


                        GWNew.Text = SWText1;

                   //     SWF.Application.OpenForms["LogoFrm"].Close();
                        SAGE(ref countSA, ref GE5_1_0);
                        SA1[j] = Convert.ToInt32(countSA);
                        GE1[j] = Convert.ToInt32(GE5_1_0);
                    }
                }
                else {
                    for (int j = 2; j <= 4; j++)
                    {
                        Table2.CurrentCell = Table2.Rows[countIzmer1].Cells[j];
                        double GWNew_double = 0.0;
                        //     GW();
               //         LogoForm1();
                        string SWText1 = Table2.Columns[j].HeaderText;
                        double SWText1_double = Convert.ToDouble(SWText1);
                        GWNew_double = double.Parse(GWNew.Text.Replace(".", ","));
                        newPort.Write("SW " + SWText1_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");
                        //  double raznica = SWText1_double - GWNew_double;

                        // string GW_string = "";
                      //  int byteRecieved1 = newPort.ReadBufferSize;
                        Thread.Sleep(500);
                       // byte[] buffer1 = new byte[byteRecieved1];
                        string indata = newPort.ReadExisting();

                        bool indata_bool = true;
                        while (indata_bool == true)
                        {
                            if (indata.Contains('>'))
                            {

                                indata_bool = false;

                            }

                            else {
                                indata = newPort.ReadExisting();
                            }
                        }


                        GWNew.Text = SWText1;

               //         SWF.Application.OpenForms["LogoFrm"].Close();
                        SAGE(ref countSA, ref GE5_1_0);
                        SA1[massEl] = Convert.ToInt32(countSA);
                        GE1[massEl] = Convert.ToInt32(GE5_1_0);
                        Table2.CurrentCell.Value = string.Format("{0:0.0}", GE1[massEl]);
                        massEl++;
                        
                    }
                }
                   
                
               // Thread.Sleep(10000);
      //          IzmerGE();
            }
        }
        public void IzmerSAGE1()
        {
           int i = 13;
            for (int j = Table1StartIzmer; j <= Table1CountIzmer; j++)
            {
                // GW();
                Table1.CurrentCell = Table1.Rows[countIzmer].Cells[j];
          //      LogoForm1();
                string SWText1 = Table1.Columns[j].HeaderText;
                double SWText1_double = Convert.ToDouble(SWText1);
                double GWNew_double = double.Parse(GWNew.Text.Replace(".", ","));
                newPort.Write("SW " + SWText1_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");
      
                // string GW_string = "";
               // int byteRecieved1 = newPort.ReadBufferSize;
                Thread.Sleep(500);
              //  byte[] buffer1 = new byte[byteRecieved1];
                string indata = newPort.ReadExisting();

                bool indata_bool = true;
                while (indata_bool == true)
                {
                    if (indata.Contains('>'))
                    {

                        indata_bool = false;

                    }

                    else {
                        indata = newPort.ReadExisting();
                    }
                }


                GWNew.Text = SWText1;

         //       SWF.Application.OpenForms["LogoFrm"].Close();
                SAGE(ref countSA, ref GE5_1_0);

                SA[i] = Convert.ToInt32(countSA);
                GE[i] = Convert.ToInt32(GE5_1_0);
                //   double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE[j]) * 100;
               // Table1.CurrentCell.Value = string.Format("{0:0.0}", GE[i]);
                i++;
            }
        }
        public void IzmerGE()
        {
            if (tabControl1.SelectedIndex == 0)
            {
                int i = 0;
                //GWNew.Text = Table1.Columns[Table1CountIzmer-1].HeaderText;
                for (int j = Table1StartIzmer; j <= Table1CountIzmer; j++)
                {
                    //    GW();
                    Table1.CurrentCell = Table1.Rows[countIzmer].Cells[j];
                 //   LogoForm1();
                    string SWText1 = Table1.Columns[j].HeaderText;
                    double SWText1_double = Convert.ToDouble(SWText1);
                    double GWNew_double = double.Parse(GWNew.Text.Replace(".", ","));
                    newPort.Write("SW " + SWText1_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");

                    // string GW_string = "";
                   // int byteRecieved1 = newPort.ReadBufferSize;
                    Thread.Sleep(500);
                  //  byte[] buffer1 = new byte[byteRecieved1];
                    string indata = newPort.ReadExisting();

                    bool indata_bool = true;
                    while (indata_bool == true)
                    {
                        if (indata.Contains('>'))
                        {

                            indata_bool = false;

                        }

                        else {
                            indata = newPort.ReadExisting();
                        }
                    }


                    GWNew.Text = SWText1;

                    //  SWF.Application.OpenForms["LogoFrm"].Close();
                    newPort.Write("SA " + SA[i] + "\r");

                    indata = newPort.ReadExisting();
                    string indata_0;
                    indata_bool = true;
                    while (indata_bool == true)
                    {

                        if (indata.Contains('>'))
                        {

                            indata_bool = false;

                        }

                        else {
                            indata = newPort.ReadExisting();

                        }
                    }

                    newPort.Write("GE 1\r");

                    string GE5Izmer = "";
                    int GEbyteRecieved4_1 = newPort.ReadBufferSize;
                    byte[] GEbuffer4_1 = new byte[GEbyteRecieved4_1];
                    newPort.Read(GEbuffer4_1, 0, GEbyteRecieved4_1);

                    indata = newPort.ReadExisting();

                    indata_0 = "";
                    indata_bool = true;
                    while (indata_bool == true)
                    {

                        if (indata.Contains('>'))
                        {

                            indata_bool = false;

                        }

                        else {

                            indata = newPort.ReadExisting();
                            indata_0 += indata;
                        }
                    }
                    GE5Izmer = indata_0.Substring(0, indata_0.Length - 2);



                    // MessageBox.Show(GE5Izmer);
                    // string GE1 = GE[j].ToString();
                    // double GE1_double = double.Parse(GE1.Replace(".", ","));
                    double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE[i]) * 100;
                    Table1.CurrentCell.Value = string.Format("{0:0.00}", Aser);
                    GEIzmer[i] = Aser;
                    i++;
                }
                //Table1.Rows.Add();
            }
            else
            {
                int massEl = 0;
                GWNew.Text = Table2.Columns[4].HeaderText;
                if (versionPribor.Contains('U'))
                {
                    for (int j = 0; j <= 4; j++)
                    {
                        // GW();
                        Table2.CurrentCell = Table2.Rows[countIzmer1].Cells[j];
                        //     LogoForm1();
                        string SWText1 = Table2.Columns[j].HeaderText;
                        double SWText1_double = Convert.ToDouble(SWText1);
                        double GWNew_double = double.Parse(GWNew.Text.Replace(".", ","));
                        double raznica = SWText1_double - GWNew_double;
                        newPort.Write("SW " + SWText1_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");


                        // string GW_string = "";
                        // int byteRecieved1 = newPort.ReadBufferSize;

                        Thread.Sleep(500);

                        // byte[] buffer1 = new byte[byteRecieved1];
                        string indata = newPort.ReadExisting();

                        bool indata_bool = true;
                        while (indata_bool == true)
                        {
                            if (indata.Contains('>'))
                            {

                                indata_bool = false;

                            }

                            else {
                                indata = newPort.ReadExisting();
                            }
                        }


                        GWNew.Text = SWText1;

                        //    SWF.Application.OpenForms["LogoFrm"].Close();
                        newPort.Write("SA " + SA1[j] + "\r");

                        indata = newPort.ReadExisting();
                        string indata_0;
                        indata_bool = true;
                        while (indata_bool == true)
                        {

                            if (indata.Contains('>'))
                            {

                                indata_bool = false;

                            }

                            else {
                                indata = newPort.ReadExisting();

                            }
                        }

                        newPort.Write("GE 1\r");

                        string GE5Izmer = "";
                        int GEbyteRecieved4_1 = newPort.ReadBufferSize;
                        byte[] GEbuffer4_1 = new byte[GEbyteRecieved4_1];
                        newPort.Read(GEbuffer4_1, 0, GEbyteRecieved4_1);

                        indata = newPort.ReadExisting();

                        indata_0 = "";
                        indata_bool = true;
                        while (indata_bool == true)
                        {

                            if (indata.Contains('>'))
                            {

                                indata_bool = false;

                            }

                            else {

                                indata = newPort.ReadExisting();
                                indata_0 += indata;
                            }
                        }
                        Regex regex = new Regex(@"\W");
                        GE5Izmer = regex.Replace(indata_0, "");

                        // MessageBox.Show(GE5Izmer);
                        //string GE1 = GE[j+1].ToString();
                        //        double GE1_double = double.Parse(GE1.Replace(".", ","));
                        double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE1[j]) * 100;
                        Table2.CurrentCell.Value = string.Format("{0:0.00}", Aser);
                        // j--;
                    }
                }
                else
                    
                {
                    for (int j = 2; j <= 4; j++)
                    {
                        // GW();

                        Table2.CurrentCell = Table2.Rows[countIzmer1].Cells[j];
                   //     LogoForm1();
                        string SWText1 = Table2.Columns[j].HeaderText;
                        double SWText1_double = Convert.ToDouble(SWText1);
                        double GWNew_double = double.Parse(GWNew.Text.Replace(".", ","));
                        double raznica = SWText1_double - GWNew_double;
                        newPort.Write("SW " + SWText1_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");


                        // string GW_string = "";
                      //  int byteRecieved1 = newPort.ReadBufferSize;

                        Thread.Sleep(500);

                       // byte[] buffer1 = new byte[byteRecieved1];
                        string indata = newPort.ReadExisting();

                        bool indata_bool = true;
                        while (indata_bool == true)
                        {
                            if (indata.Contains('>'))
                            {

                                indata_bool = false;

                            }

                            else {
                                indata = newPort.ReadExisting();
                            }
                        }


                        GWNew.Text = SWText1;

                  //      SWF.Application.OpenForms["LogoFrm"].Close();
                        newPort.Write("SA " + SA1[j-2] + "\r");
                       
                        // int SAAnalisByteRecieved1 = newPort.ReadBufferSize;
                        // Thread.Sleep(100);
                        //byte[] SAAnalisBuffer1 = new byte[SAAnalisByteRecieved1];
                        // newPort.Read(SAAnalisBuffer1, 0, SAAnalisByteRecieved1);
                        indata = newPort.ReadExisting();                        
                        string indata_0;
                        indata_bool = true;
                        while (indata_bool == true)
                        {

                            if (indata.Contains('>'))
                            {

                                indata_bool = false;

                            }

                            else {
                                indata = newPort.ReadExisting();

                            }
                        }

                        newPort.Write("GE 1\r");
                        string GE5Izmer = "";
                        int GEbyteRecieved4_1 = newPort.ReadBufferSize;
                        byte[] GEbuffer4_1 = new byte[GEbyteRecieved4_1];
                        newPort.Read(GEbuffer4_1, 0, GEbyteRecieved4_1);

                        indata = newPort.ReadExisting();
                       
                        indata_0 = "";
                        indata_bool = true;
                        while (indata_bool == true)
                        {

                            if (indata.Contains('>'))
                            {

                                indata_bool = false;

                            }

                            else {

                                indata = newPort.ReadExisting();
                                indata_0 += indata;
                            }
                        }
                        Regex regex = new Regex(@"\W");
                        GE5Izmer = regex.Replace(indata_0, "");

                        // MessageBox.Show(GE5Izmer);
                        //string GE1 = GE[j+1].ToString();
                        //        double GE1_double = double.Parse(GE1.Replace(".", ","));
                        double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE1[massEl]) * 100;
                        Table2.CurrentCell.Value = string.Format("{0:0.00}", Aser);
                        massEl++;
                        // j--;
                    }
                
            }
               // Table2.Rows.Add();
            }

        }



        public void IzmerGE1()
        {
            int i = 13;
               //  GWNew.Text = Table1.Columns[Table1CountIzmer - 1].HeaderText;
                for (int j = Table1StartIzmer; j <= Table1CountIzmer; j++)
                {
                    //    GW();
                    Table1.CurrentCell = Table1.Rows[countIzmer].Cells[j];
               //     LogoForm1();
                    string SWText1 = Table1.Columns[j].HeaderText;
                    double SWText1_double = Convert.ToDouble(SWText1);
                    double GWNew_double = double.Parse(GWNew.Text.Replace(".", ","));
                    newPort.Write("SW " + SWText1_double.ToString(System.Globalization.CultureInfo.GetCultureInfo("en-US")) + "\r");
                   
                    // string GW_string = "";
                    //int byteRecieved1 = newPort.ReadBufferSize;
                    Thread.Sleep(500);
                   // byte[] buffer1 = new byte[byteRecieved1];
                string indata = newPort.ReadExisting();

                bool indata_bool = true;
                while (indata_bool == true)
                {
                    if (indata.Contains('>'))
                    {

                        indata_bool = false;

                    }

                    else {
                        indata = newPort.ReadExisting();
                    }
                }


                GWNew.Text = SWText1;

                //  SWF.Application.OpenForms["LogoFrm"].Close();
                newPort.Write("SA " + SA[i] + "\r");

                indata = newPort.ReadExisting();
                string indata_0;
                indata_bool = true;
                while (indata_bool == true)
                {

                    if (indata.Contains('>'))
                    {

                        indata_bool = false;

                    }

                    else {
                        indata = newPort.ReadExisting();

                    }
                }

                newPort.Write("GE 1\r");
                string GE5Izmer = "";
                int GEbyteRecieved4_1 = newPort.ReadBufferSize;
                byte[] GEbuffer4_1 = new byte[GEbyteRecieved4_1];
                newPort.Read(GEbuffer4_1, 0, GEbyteRecieved4_1);

                indata = newPort.ReadExisting();

                indata_0 = "";
                indata_bool = true;
                while (indata_bool == true)
                {

                    if (indata.Contains('>'))
                    {

                        indata_bool = false;

                    }

                    else {

                        indata = newPort.ReadExisting();
                        indata_0 += indata;
                    }
                }
                Regex regex = new Regex(@"\W");                
                GE5Izmer = regex.Replace(indata_0, "");

                // MessageBox.Show(GE5Izmer);
                // string GE1 = GE[j].ToString();
                // double GE1_double = double.Parse(GE1.Replace(".", ","));
                double Aser = Convert.ToDouble(GE5Izmer) / Convert.ToDouble(GE[i]) * 100;
                    Table1.CurrentCell.Value = string.Format("{0:0.00}", Aser);
                GEIzmer[i] = Aser;
                i++;
                }
                
            }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            button4.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button4.Enabled = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            button4.Enabled = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            button4.Enabled = false;
        }
    }
}

