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
            this.PortsComboBox = new System.Windows.Forms.ComboBox();
            this.OpenButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SendTextBox = new System.Windows.Forms.TextBox();
            this.ChatTextBox = new System.Windows.Forms.TextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.BaudComboBox = new System.Windows.Forms.ComboBox();
            this.BaudLabel = new System.Windows.Forms.Label();
            this.dataConflictLabel = new System.Windows.Forms.Label();
            this.dataConflictCheckBox = new System.Windows.Forms.CheckBox();
            this.chatInfoTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // PortsComboBox
            // 
            this.PortsComboBox.FormattingEnabled = true;
            this.PortsComboBox.Location = new System.Drawing.Point(474, 25);
            this.PortsComboBox.Name = "PortsComboBox";
            this.PortsComboBox.Size = new System.Drawing.Size(139, 24);
            this.PortsComboBox.TabIndex = 0;
            // 
            // OpenButton
            // 
            this.OpenButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OpenButton.Location = new System.Drawing.Point(478, 59);
            this.OpenButton.Name = "OpenButton";
            this.OpenButton.Size = new System.Drawing.Size(75, 32);
            this.OpenButton.TabIndex = 1;
            this.OpenButton.Text = "Open";
            this.OpenButton.UseVisualStyleBackColor = true;
            this.OpenButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.Location = new System.Drawing.Point(478, 97);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 29);
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
            this.BaudComboBox.Location = new System.Drawing.Point(474, 180);
            this.BaudComboBox.Name = "BaudComboBox";
            this.BaudComboBox.Size = new System.Drawing.Size(139, 24);
            this.BaudComboBox.TabIndex = 6;
            // 
            // BaudLabel
            // 
            this.BaudLabel.AutoSize = true;
            this.BaudLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BaudLabel.Location = new System.Drawing.Point(474, 153);
            this.BaudLabel.Name = "BaudLabel";
            this.BaudLabel.Size = new System.Drawing.Size(97, 20);
            this.BaudLabel.TabIndex = 7;
            this.BaudLabel.Text = "Baud rate:";
            // 
            // dataConflictLabel
            // 
            this.dataConflictLabel.AutoSize = true;
            this.dataConflictLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataConflictLabel.Location = new System.Drawing.Point(484, 255);
            this.dataConflictLabel.Name = "dataConflictLabel";
            this.dataConflictLabel.Size = new System.Drawing.Size(97, 17);
            this.dataConflictLabel.TabIndex = 8;
            this.dataConflictLabel.Text = "data conflict";
            // 
            // dataConflictCheckBox
            // 
            this.dataConflictCheckBox.AutoSize = true;
            this.dataConflictCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataConflictCheckBox.Location = new System.Drawing.Point(478, 231);
            this.dataConflictCheckBox.Name = "dataConflictCheckBox";
            this.dataConflictCheckBox.Size = new System.Drawing.Size(98, 21);
            this.dataConflictCheckBox.TabIndex = 9;
            this.dataConflictCheckBox.Text = "Generate";
            this.dataConflictCheckBox.UseVisualStyleBackColor = true;
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
            // ChatForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(621, 648);
            this.Controls.Add(this.chatInfoTextBox);
            this.Controls.Add(this.dataConflictCheckBox);
            this.Controls.Add(this.dataConflictLabel);
            this.Controls.Add(this.BaudLabel);
            this.Controls.Add(this.BaudComboBox);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ChatTextBox);
            this.Controls.Add(this.SendTextBox);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.OpenButton);
            this.Controls.Add(this.PortsComboBox);
            this.Name = "ChatForm";
            this.Text = "Serial port";
            this.Load += new System.EventHandler(this.ChatForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox PortsComboBox;
        private System.Windows.Forms.Button OpenButton;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox SendTextBox;
        private System.Windows.Forms.TextBox ChatTextBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ComboBox BaudComboBox;
        private System.Windows.Forms.Label BaudLabel;
        private System.Windows.Forms.Label dataConflictLabel;
        private System.Windows.Forms.CheckBox dataConflictCheckBox;
        private System.Windows.Forms.TextBox chatInfoTextBox;
    }
}

