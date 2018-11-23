namespace toks
{
    partial class ChatForm
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
            this.InPortComboBox = new System.Windows.Forms.ComboBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.BaudComboBox = new System.Windows.Forms.ComboBox();
            this.BaudLabel = new System.Windows.Forms.Label();
            this.chatInfoTextBox = new System.Windows.Forms.TextBox();
            this.OutPortComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DestinationTextBox = new System.Windows.Forms.TextBox();
            this.DestinationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InPortComboBox
            // 
            this.InPortComboBox.FormattingEnabled = true;
            this.InPortComboBox.Location = new System.Drawing.Point(474, 49);
            this.InPortComboBox.Name = "InPortComboBox";
            this.InPortComboBox.Size = new System.Drawing.Size(139, 24);
            this.InPortComboBox.TabIndex = 0;
            this.InPortComboBox.SelectedIndexChanged += new System.EventHandler(this.PortsComboBox_SelectedIndexChanged);
            // 
            // OpenButton
            // 
            this.OpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenButton.Location = new System.Drawing.Point(479, 136);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(60, 29);
            this.OpenButton.TabIndex = 1;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(550, 136);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(67, 29);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SendTextBox
            // 
            this.SendTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendTextBox.Location = new System.Drawing.Point(12, 532);
            this.SendTextBox.Multiline = true;
            this.SendTextBox.Name = "SendTextBox";
            this.SendTextBox.Size = new System.Drawing.Size(443, 88);
            this.SendTextBox.TabIndex = 3;
            // 
            // ChatTextBox
            // 
            this.ChatTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ChatTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChatTextBox.Location = new System.Drawing.Point(12, 12);
            this.ChatTextBox.Multiline = true;
            this.ChatTextBox.Name = "ChatTextBox";
            this.ChatTextBox.Size = new System.Drawing.Size(443, 493);
            this.ChatTextBox.TabIndex = 4;
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SendButton.Location = new System.Drawing.Point(478, 544);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(117, 64);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "Send message";
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.ButtonSend_Click);
            // 
            // BaudComboBox
            // 
            this.BaudComboBox.FormattingEnabled = true;
            this.BaudComboBox.Location = new System.Drawing.Point(478, 262);
            this.BaudComboBox.Name = "BaudComboBox";
            this.BaudComboBox.Size = new System.Drawing.Size(139, 24);
            this.BaudComboBox.TabIndex = 6;
            // 
            // BaudLabel
            // 
            this.BaudLabel.AutoSize = true;
            this.BaudLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BaudLabel.Location = new System.Drawing.Point(478, 235);
            this.BaudLabel.Name = "BaudLabel";
            this.BaudLabel.Size = new System.Drawing.Size(97, 20);
            this.BaudLabel.TabIndex = 7;
            this.BaudLabel.Text = "Baud rate:";
            // 
            // chatInfoTextBox
            // 
            this.chatInfoTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.chatInfoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chatInfoTextBox.Location = new System.Drawing.Point(474, 301);
            this.chatInfoTextBox.Multiline = true;
            this.chatInfoTextBox.Name = "chatInfoTextBox";
            this.chatInfoTextBox.Size = new System.Drawing.Size(139, 204);
            this.chatInfoTextBox.TabIndex = 10;
            // 
            // OutPortComboBox
            // 
            this.OutPortComboBox.FormattingEnabled = true;
            this.OutPortComboBox.Location = new System.Drawing.Point(474, 103);
            this.OutPortComboBox.Name = "OutPortComboBox";
            this.OutPortComboBox.Size = new System.Drawing.Size(139, 24);
            this.OutPortComboBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Input port";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(475, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 13;
            this.label2.Text = "Output port";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // DestinationTextBox
            // 
            this.DestinationTextBox.Location = new System.Drawing.Point(474, 199);
            this.DestinationTextBox.Name = "DestinationTextBox";
            this.DestinationTextBox.Size = new System.Drawing.Size(65, 22);
            this.DestinationTextBox.TabIndex = 14;
            // 
            // DestinationLabel
            // 
            this.DestinationLabel.AutoSize = true;
            this.DestinationLabel.Location = new System.Drawing.Point(472, 178);
            this.DestinationLabel.Name = "DestinationLabel";
            this.DestinationLabel.Size = new System.Drawing.Size(79, 17);
            this.DestinationLabel.TabIndex = 15;
            this.DestinationLabel.Text = "Destination";
            // 
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(621, 648);
            this.Controls.Add(this.DestinationLabel);
            this.Controls.Add(this.DestinationTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OutPortComboBox);
            this.Controls.Add(this.chatInfoTextBox);
            this.Controls.Add(this.BaudLabel);
            this.Controls.Add(this.BaudComboBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.SendTextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.InPortComboBox);
            this.Name = "ChatForm";
            this.Text = "Serial port";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox InPortComboBox;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox SendTextBox;
        private System.Windows.Forms.TextBox ChatTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ComboBox BaudComboBox;
        private System.Windows.Forms.Label BaudLabel;
        private System.Windows.Forms.TextBox chatInfoTextBox;
        private System.Windows.Forms.ComboBox OutPortComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox DestinationTextBox;
        private System.Windows.Forms.Label DestinationLabel;
    }
}

