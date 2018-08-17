namespace ModbusMaster
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboDatabits = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBaudrate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboAvailablePorts = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBoolValue = new System.Windows.Forms.CheckBox();
            this.textValueToSend = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textRegisterToWrite = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textSlaveID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.checkCoilState = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textCoilAddress = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textCoilSlaveID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(88, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(152, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboDatabits);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBaudrate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboAvailablePorts);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 184);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Connection";
            // 
            // comboDatabits
            // 
            this.comboDatabits.FormattingEnabled = true;
            this.comboDatabits.Items.AddRange(new object[] {
            "8",
            "9"});
            this.comboDatabits.Location = new System.Drawing.Point(88, 86);
            this.comboDatabits.Name = "comboDatabits";
            this.comboDatabits.Size = new System.Drawing.Size(152, 24);
            this.comboDatabits.TabIndex = 5;
            this.comboDatabits.Text = "8";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Databits";
            // 
            // comboBaudrate
            // 
            this.comboBaudrate.FormattingEnabled = true;
            this.comboBaudrate.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "115200"});
            this.comboBaudrate.Location = new System.Drawing.Point(88, 56);
            this.comboBaudrate.Name = "comboBaudrate";
            this.comboBaudrate.Size = new System.Drawing.Size(152, 24);
            this.comboBaudrate.TabIndex = 3;
            this.comboBaudrate.Text = "115200";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Speed";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // comboAvailablePorts
            // 
            this.comboAvailablePorts.FormattingEnabled = true;
            this.comboAvailablePorts.Location = new System.Drawing.Point(88, 27);
            this.comboAvailablePorts.Name = "comboAvailablePorts";
            this.comboAvailablePorts.Size = new System.Drawing.Size(152, 24);
            this.comboAvailablePorts.TabIndex = 0;
            this.comboAvailablePorts.Text = "COM5";
            this.comboAvailablePorts.SelectedIndexChanged += new System.EventHandler(this.comboAvailablePorts_SelectedIndexChanged);
            this.comboAvailablePorts.MouseEnter += new System.EventHandler(this.comboAvailablePorts_MouseEnter);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.checkBoolValue);
            this.groupBox2.Controls.Add(this.textValueToSend);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textRegisterToWrite);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textSlaveID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(272, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(232, 176);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Register";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(104, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 32);
            this.button2.TabIndex = 6;
            this.button2.Text = "Write";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBoolValue
            // 
            this.checkBoolValue.AutoSize = true;
            this.checkBoolValue.Location = new System.Drawing.Point(102, 110);
            this.checkBoolValue.Name = "checkBoolValue";
            this.checkBoolValue.Size = new System.Drawing.Size(96, 21);
            this.checkBoolValue.TabIndex = 8;
            this.checkBoolValue.Text = "Bool value";
            this.checkBoolValue.UseVisualStyleBackColor = true;
            this.checkBoolValue.CheckedChanged += new System.EventHandler(this.checkBoolValue_CheckedChanged);
            // 
            // textValueToSend
            // 
            this.textValueToSend.Location = new System.Drawing.Point(101, 82);
            this.textValueToSend.Name = "textValueToSend";
            this.textValueToSend.Size = new System.Drawing.Size(120, 22);
            this.textValueToSend.TabIndex = 7;
            this.textValueToSend.Text = "0";
            this.textValueToSend.TextChanged += new System.EventHandler(this.textValueToSend_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Value";
            // 
            // textRegisterToWrite
            // 
            this.textRegisterToWrite.Location = new System.Drawing.Point(101, 48);
            this.textRegisterToWrite.Name = "textRegisterToWrite";
            this.textRegisterToWrite.Size = new System.Drawing.Size(120, 22);
            this.textRegisterToWrite.TabIndex = 5;
            this.textRegisterToWrite.Text = "1010";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Register";
            // 
            // textSlaveID
            // 
            this.textSlaveID.Location = new System.Drawing.Point(101, 22);
            this.textSlaveID.Name = "textSlaveID";
            this.textSlaveID.Size = new System.Drawing.Size(120, 22);
            this.textSlaveID.TabIndex = 3;
            this.textSlaveID.Text = "1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Slave ID";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 16;
            this.listBox1.Location = new System.Drawing.Point(8, 200);
            this.listBox1.Name = "listBox1";
            this.listBox1.ScrollAlwaysVisible = true;
            this.listBox1.Size = new System.Drawing.Size(736, 132);
            this.listBox1.TabIndex = 3;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(0, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 32);
            this.button3.TabIndex = 9;
            this.button3.Text = "Read";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.checkCoilState);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.textCoilAddress);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.textCoilSlaveID);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(512, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(232, 176);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Coil";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(0, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 32);
            this.button4.TabIndex = 9;
            this.button4.Text = "Read";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(104, 136);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 32);
            this.button5.TabIndex = 6;
            this.button5.Text = "Write";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // checkCoilState
            // 
            this.checkCoilState.AutoSize = true;
            this.checkCoilState.Location = new System.Drawing.Point(102, 85);
            this.checkCoilState.Name = "checkCoilState";
            this.checkCoilState.Size = new System.Drawing.Size(84, 21);
            this.checkCoilState.TabIndex = 8;
            this.checkCoilState.Text = "coilState";
            this.checkCoilState.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 6;
            this.label7.Text = "Value";
            // 
            // textCoilAddress
            // 
            this.textCoilAddress.Location = new System.Drawing.Point(101, 48);
            this.textCoilAddress.Name = "textCoilAddress";
            this.textCoilAddress.Size = new System.Drawing.Size(120, 22);
            this.textCoilAddress.TabIndex = 5;
            this.textCoilAddress.Text = "1010";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Coil";
            // 
            // textCoilSlaveID
            // 
            this.textCoilSlaveID.Location = new System.Drawing.Point(101, 22);
            this.textCoilSlaveID.Name = "textCoilSlaveID";
            this.textCoilSlaveID.Size = new System.Drawing.Size(120, 22);
            this.textCoilSlaveID.TabIndex = 3;
            this.textCoilSlaveID.Text = "1";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 24);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Slave ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 343);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "ModBus Master Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboAvailablePorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboDatabits;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBaudrate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoolValue;
        private System.Windows.Forms.TextBox textValueToSend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textRegisterToWrite;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textSlaveID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.CheckBox checkCoilState;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textCoilAddress;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textCoilSlaveID;
        private System.Windows.Forms.Label label9;
    }
}

