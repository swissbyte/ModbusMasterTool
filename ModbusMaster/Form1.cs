using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using SharpModbus;
using System.Text.RegularExpressions;

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
            if(System.IO.File.Exists("lastScript.txt"))
            {
                LoadScriptFromFile("lastScript.txt");
                label10.Text = "Script: lastScript.txt";
            }
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
                logBox.Items.Add(ex.Message);
            }
            logBox.TopIndex = logBox.Items.Count - 1;
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
                logBox.Items.Add(ex.Message);
            }
            logBox.Items.Add("Addr: " + textRegisterToWrite.Text+  " Val: " + data);
            logBox.TopIndex = logBox.Items.Count - 1;
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
                logBox.Items.Add(ex.Message);
            }
            logBox.Items.Add("Addr: " + textCoilAddress.Text + " Val: " + data);
            logBox.TopIndex = logBox.Items.Count - 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                master.WriteCoil(byte.Parse(textCoilSlaveID.Text), ushort.Parse(textCoilAddress.Text), checkCoilState.Checked);
            }
            catch (Exception ex)
            {
                logBox.Items.Add(ex.Message);
            }
            logBox.TopIndex = logBox.Items.Count - 1;
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            logBox.BackColor = Color.Indigo;
        }

        bool checkCommand(string line)
        {
            //Check if the command has exactly two letters (WR, WC, RR, RC)
            if (line.Count(char.IsLetter) != 2)
            {
                logBox.Items.Add("ERR: Command has more or less than two command characters!");
                return false;
            }
            string[] chunks = line.Split(new char[0]);
            if (chunks[0] == "WC" || chunks[0] == "WR" || chunks[0] == "PC")
            {
                if (chunks.Length != 3)
                {
                    logBox.Items.Add("ERR: Wrong number of parameters for write command!");
                    return false;
                }
                if(chunks[0] == "WC")
                {
                    //Check for boolean values 0 or 1
                    if(Convert.ToInt16(chunks[2]) > 1)
                    {
                        logBox.Items.Add("WARN: No bool value entered! Value " + chunks[2] + " truncated to 1");
                        chunks[2] = "1";
                        textScriptLine.Text = chunks[0] + " " + chunks[1] + " " + chunks[2];
                    }
                }
            }else
            if (chunks[0] == "RC" || chunks[0] == "RR")
            {
                if (chunks.Length != 2)
                {
                    logBox.Items.Add("ERR: Wrong number of parameters for read command!");
                    return false;
                }
            }
            else
            {
                logBox.Items.Add("ERR: No valid command. Use WR, WC, RR, RC");
                return false;
            }
            return true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
     
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                //Check if there is a string entered
                if (textScriptLine.Text.Trim() != "")
                {
                    textScriptLine.Text = Regex.Replace(textScriptLine.Text.Trim(), @"\s+", " ");
                    textScriptLine.Text = textScriptLine.Text.ToUpper();

                    if (checkCommand(textScriptLine.Text) == false) return; 

                    //logBox.Items.Add("Letter count: " + textScriptLine.Text.Count(char.IsLetter).ToString());
                    if (scriptBox.SelectedIndex > -1)
                    {
                        scriptBox.Items.Insert(scriptBox.SelectedIndex + 1, textScriptLine.Text);
                    }
                    else
                    {
                        scriptBox.Items.Add(Regex.Replace(textScriptLine.Text.Trim(), @"\s+", " "));
                    }
                    scriptBox.TopIndex = scriptBox.Items.Count - 1;
                    textScriptLine.Clear();
                }

                
            }
        }

        private void scriptBox_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                scriptBox.Items.RemoveAt(scriptBox.SelectedIndex);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SaveScriptToFile(string filename)
        {
            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(filename);
            foreach (var item in scriptBox.Items)
            {
                SaveFile.WriteLine(item);
            }
            SaveFile.Close();
        }

        private void LoadScriptFromFile(string filename)
        {
            System.IO.StreamReader ReadFile = new System.IO.StreamReader(filename);
            string line = "";
            while ((line = ReadFile.ReadLine()) != null)
            {
                scriptBox.Items.Add(line);
            }
            ReadFile.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveScriptToFile(saveFileDialog1.FileName);                
                label10.Text = "Script: " + Path.GetFileName(saveFileDialog1.FileName);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                scriptBox.Items.Clear();
                LoadScriptFromFile(openFileDialog1.FileName);                
                label10.Text = "Script: " + Path.GetFileName(openFileDialog1.FileName);
            }
        }

        private void textScriptLine_TextChanged(object sender, EventArgs e)
        {

        }

        void processScriptString(string line)
        {
            ushort ReadResult = 0;
            string[] chunks = line.Split(new char[0]);
            if(chunks[0] == "WC")
            {
                //MessageBox.Show("Addr: " + chunks[1] + " Value: " + chunks[2]);
                DoModBusCommand(chunks[0], Convert.ToByte(textSlaveID.Text), Convert.ToUInt16(chunks[1]), Convert.ToUInt16(chunks[2]));
            }
            if (chunks[0] == "WR")
            {
                if(chunks[1] == "10601")
                {
                    Int32 value = 0;
                    value = Convert.ToInt32(chunks[2]);
                    DoModBusCommand(chunks[0], Convert.ToByte(textSlaveID.Text), 1060, (UInt16)(value & 0xFFFF));
                    DoModBusCommand(chunks[0], Convert.ToByte(textSlaveID.Text), 1061, (UInt16)((value & 0xFFFF0000) >> 16));
                }
                else DoModBusCommand(chunks[0], Convert.ToByte(textSlaveID.Text), Convert.ToUInt16(chunks[1]), Convert.ToUInt16(chunks[2]));
            }
            if (chunks[0] == "RC")
            {
                ReadResult = DoModBusCommand(chunks[0], Convert.ToByte(textSlaveID.Text), Convert.ToUInt16(chunks[1]), 0);
                logBox.Items.Add("ReadResut for Addr: " + chunks[1] + " = " + Convert.ToBoolean(ReadResult).ToString());
            }
            if (chunks[0] == "RR")
            {
                ReadResult = DoModBusCommand(chunks[0], Convert.ToByte(textSlaveID.Text), Convert.ToUInt16(chunks[1]), 0);
                logBox.Items.Add("ReadResut for Addr: " + chunks[1] + " = " + ReadResult.ToString());
            }
            if (chunks[0] == "PC")
            {
                do
                {
                    Task.Delay(50);
                    ReadResult = DoModBusCommand("RR", Convert.ToByte(textSlaveID.Text), Convert.ToUInt16(chunks[1]), 0);
                    //logBox.Items.Add("ReadResut for Addr: " + chunks[1] + " = " + ReadResult.ToString() +" Compare to "+ chunks[2] + " - "+ (0xFFFF & Convert.ToInt16(chunks[2])).ToString());
                } while ( (ReadResult & Convert.ToInt16(chunks[2])) != (0xFFFF & Convert.ToInt16(chunks[2])) );
                logBox.Items.Add("ReadResut for Addr: " + chunks[1] + " = " + ReadResult.ToString());
            }

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            int count = 0;
            if (scriptBox.Items.Count > 0)
            {
                scriptBox.SelectedIndex = 0;

                while(count != scriptBox.Items.Count)
                {
                    processScriptString(scriptBox.GetItemText(scriptBox.SelectedItem));
                    if(scriptBox.SelectedIndex+1 < scriptBox.Items.Count) scriptBox.SelectedIndex++;
                    count++;
                }

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveScriptToFile("lastScript.txt");
        }

        private void scriptBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if(textScriptLine.Text = "")
            textScriptLine.Text = scriptBox.GetItemText(scriptBox.SelectedItem);
        }


        private ushort DoModBusCommand(string cmd,byte slaveID, ushort address, ushort value)
        {
            serialPort1.DiscardInBuffer();
            if(cmd == "WR")
            {
                try
                {
                    master.WriteRegister(slaveID, address, value);
                }
                catch (Exception ex)
                {
                    logBox.Items.Add(ex.Message);
                }
                logBox.TopIndex = logBox.Items.Count - 1;
                return 1;
            }

            if (cmd == "WC")
            {
                try
                {
                    master.WriteCoil(slaveID, address, Convert.ToBoolean(value));
                }
                catch (Exception ex)
                {
                    logBox.Items.Add(ex.Message);
                }
                logBox.TopIndex = logBox.Items.Count - 1;
                return 1;
            }

            if (cmd == "RC")
            {
                bool rValue = false;
                try
                {
                    rValue = master.ReadCoil(slaveID, address);
                }
                catch (Exception ex)
                {
                    logBox.Items.Add(ex.Message);
                }
                
                logBox.TopIndex = logBox.Items.Count - 1;
                return Convert.ToUInt16(rValue);
            }

            if (cmd == "RR")
            {
                ushort rValue = 0;
                try
                {
                    rValue = master.ReadInputRegister(slaveID, address);
                }
                catch (Exception ex)
                {
                    logBox.Items.Add(ex.Message);
                }

                logBox.TopIndex = logBox.Items.Count - 1;
                return Convert.ToUInt16(rValue);
            }
            return 0;
        }
       
    }
}
