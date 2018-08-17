using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpModbus;

namespace ModbusMaster
{
    public partial class Form1 : Form
    {
        private
        ModbusSerialStream stream;
        ModbusRTUProtocol protocol;
        SharpModbus.ModbusMaster master;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Connect")
            {
                serialPort1.PortName = comboAvailablePorts.Text;
                serialPort1.BaudRate = int.Parse(comboBaudrate.Text);
                serialPort1.DataBits = int.Parse(comboDatabits.Text);
                serialPort1.Open();

                stream = new ModbusSerialStream(serialPort1, 400);
                protocol = new ModbusRTUProtocol();
                master = new SharpModbus.ModbusMaster(stream, protocol);
                button1.Text = "Disconnect";
            }
            else
            {
                serialPort1.Close();
                button1.Text = "Connect";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboAvailablePorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboAvailablePorts_MouseEnter(object sender, EventArgs e)
        {
            comboAvailablePorts.Items.Clear();
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboAvailablePorts.Items.Add(s);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoolValue_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoolValue.Checked) textValueToSend.Text = "1";
            else textValueToSend.Text = "0";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                master.WriteRegister(byte.Parse(textSlaveID.Text), ushort.Parse(textRegisterToWrite.Text), ushort.Parse(textValueToSend.Text));
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
        private void textValueToSend_TextChanged(object sender, EventArgs e)
        {
            if (textValueToSend.Text.Length > 0)
            {
                checkBoolValue.Enabled = true;
                if (int.Parse(textValueToSend.Text) == 1) checkBoolValue.Checked = true;
                else if (int.Parse(textValueToSend.Text) == 0) checkBoolValue.Checked = false;
                else checkBoolValue.Enabled = false;
            }
            else textValueToSend.Text = "0";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string data = "";
            try
            {
                data = Convert.ToString(master.ReadInputRegister(byte.Parse(textSlaveID.Text), ushort.Parse(textRegisterToWrite.Text)));
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
            listBox1.Items.Add("Addr: " + textRegisterToWrite.Text+  " Val: " + data);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string data = "";
            try
            {
                data = Convert.ToString(master.ReadCoil(byte.Parse(textCoilSlaveID.Text), ushort.Parse(textCoilAddress.Text)));
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
            listBox1.Items.Add("Addr: " + textCoilAddress.Text + " Val: " + data);
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                master.WriteCoil(byte.Parse(textCoilSlaveID.Text), ushort.Parse(textCoilAddress.Text), checkCoilState.Checked);
            }
            catch (Exception ex)
            {
                listBox1.Items.Add(ex.Message);
            }
            listBox1.TopIndex = listBox1.Items.Count - 1;
        }
    }
}
