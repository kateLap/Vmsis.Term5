namespace Battery
{
    partial class Battery
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
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.timeLeft = new System.Windows.Forms.TextBox();
            this.BatteryPercents = new System.Windows.Forms.TextBox();
            this.State = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.AcModeTextBox = new System.Windows.Forms.TextBox();
            this.BatteryModeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timeLeft
            // 
            this.timeLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLeft.Location = new System.Drawing.Point(282, 99);
            this.timeLeft.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.timeLeft.Name = "timeLeft";
            this.timeLeft.ReadOnly = true;
            this.timeLeft.Size = new System.Drawing.Size(204, 22);
            this.timeLeft.TabIndex = 24;
            // 
            // BatteryPercents
            // 
            this.BatteryPercents.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.BatteryPercents.Location = new System.Drawing.Point(282, 61);
            this.BatteryPercents.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BatteryPercents.Name = "BatteryPercents";
            this.BatteryPercents.ReadOnly = true;
            this.BatteryPercents.Size = new System.Drawing.Size(204, 22);
            this.BatteryPercents.TabIndex = 25;
            // 
            // State
            // 
            this.State.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.State.Location = new System.Drawing.Point(282, 25);
            this.State.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Size = new System.Drawing.Size(205, 22);
            this.State.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(13, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(226, 20);
            this.label2.TabIndex = 27;
            this.label2.Text = "Уровень заряда батареи:";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 20);
            this.label1.TabIndex = 26;
            this.label1.Text = "Тип энергопитания:";
            // 
            // AcModeTextBox
            // 
            this.AcModeTextBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.AcModeTextBox.Location = new System.Drawing.Point(218, 208);
            this.AcModeTextBox.Name = "AcModeTextBox";
            this.AcModeTextBox.Size = new System.Drawing.Size(269, 22);
            this.AcModeTextBox.TabIndex = 33;
            // 
            // BatteryModeTextBox
            // 
            this.BatteryModeTextBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.BatteryModeTextBox.Location = new System.Drawing.Point(218, 170);
            this.BatteryModeTextBox.Name = "BatteryModeTextBox";
            this.BatteryModeTextBox.Size = new System.Drawing.Size(269, 22);
            this.BatteryModeTextBox.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(54, 133);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(360, 24);
            this.label5.TabIndex = 35;
            this.label5.Text = "Текущий режим энергосбережения";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(12, 172);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 36;
            this.label6.Text = "Батарея:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(12, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(199, 20);
            this.label7.TabIndex = 37;
            this.label7.Text = "Зарядное устройство:";
            // 
            // Battery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.ClientSize = new System.Drawing.Size(505, 268);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.BatteryModeTextBox);
            this.Controls.Add(this.AcModeTextBox);
            this.Controls.Add(this.timeLeft);
            this.Controls.Add(this.BatteryPercents);
            this.Controls.Add(this.State);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Battery";
            this.Text = "Энергопитание";
            this.Load += new System.EventHandler(this.BatteryLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.TextBox timeLeft;
        private System.Windows.Forms.TextBox BatteryPercents;
        private System.Windows.Forms.TextBox State;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AcModeTextBox;
        private System.Windows.Forms.TextBox BatteryModeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

