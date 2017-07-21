namespace EndavaInternship.WindowsFormApp
{
    partial class EndavaInternshipForm
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
            this.submitButton = new System.Windows.Forms.Button();
            this.logLabel = new System.Windows.Forms.Label();
            this.logsBox = new System.Windows.Forms.TextBox();
            this.leftOperand = new System.Windows.Forms.TextBox();
            this.rightOperand = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(12, 77);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(101, 23);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "=";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.SubmitButtonOnClick);
            // 
            // logLabel
            // 
            this.logLabel.AutoSize = true;
            this.logLabel.Location = new System.Drawing.Point(116, 9);
            this.logLabel.Name = "logLabel";
            this.logLabel.Size = new System.Drawing.Size(30, 13);
            this.logLabel.TabIndex = 1;
            this.logLabel.Text = "Logs";
            // 
            // logsBox
            // 
            this.logsBox.Location = new System.Drawing.Point(119, 25);
            this.logsBox.Multiline = true;
            this.logsBox.Name = "logsBox";
            this.logsBox.Size = new System.Drawing.Size(386, 285);
            this.logsBox.TabIndex = 2;
            // 
            // leftOperand
            // 
            this.leftOperand.Location = new System.Drawing.Point(13, 25);
            this.leftOperand.Name = "leftOperand";
            this.leftOperand.Size = new System.Drawing.Size(100, 20);
            this.leftOperand.TabIndex = 3;
            // 
            // rightOperand
            // 
            this.rightOperand.Location = new System.Drawing.Point(13, 51);
            this.rightOperand.Name = "rightOperand";
            this.rightOperand.Size = new System.Drawing.Size(100, 20);
            this.rightOperand.TabIndex = 4;
            // 
            // EndavaInternshipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 322);
            this.Controls.Add(this.rightOperand);
            this.Controls.Add(this.leftOperand);
            this.Controls.Add(this.logsBox);
            this.Controls.Add(this.logLabel);
            this.Controls.Add(this.submitButton);
            this.Name = "EndavaInternshipForm";
            this.Text = "EndavaInternshipForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label logLabel;
        private System.Windows.Forms.TextBox logsBox;
        private System.Windows.Forms.TextBox leftOperand;
        private System.Windows.Forms.TextBox rightOperand;
    }
}

