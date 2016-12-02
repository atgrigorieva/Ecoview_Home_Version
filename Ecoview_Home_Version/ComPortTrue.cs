using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace Ecoview_Home_Version
{
    public partial class ComPortTrue : Form
    {
        Ecoview _Ecoview;
        public ComPortTrue(Ecoview parent)
        {
            InitializeComponent();
            this._Ecoview = parent;
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(ports);
            if (ports.Length != 0)
            {
                comboBox1.SelectedIndex = 0;
                _Ecoview.nonPort = true;
            }
            else
            {
                MessageBox.Show("Подсоедините спектрофотометр и попробуйте подключиться снова!");
                _Ecoview.nonPort = false;
                Close();
                // Dispose();
            }
        }

        public void ComPortTrue_Load(object sender, EventArgs e)
        {
            
        }

        public void button1_Click(object sender, EventArgs e)
        {
            _Ecoview.portsName = comboBox1.SelectedItem.ToString();

            Close();
        }

        public void ComPortTrue_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void ComPortTrue_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_Ecoview.nonPort == false)
            {
                _Ecoview.nonPort = false;
                MessageBox.Show("Порт не выбран!");
                Close();
            }
            else
            {
                _Ecoview.nonPort = true;

                Close();
            }
        }
    }
}
