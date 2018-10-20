namespace RedisTest
{
    partial class Form1
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
            this.btnSetKey = new System.Windows.Forms.Button();
            this.btnDeleteKey = new System.Windows.Forms.Button();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.btnReadKey = new System.Windows.Forms.Button();
            this.btnResetFields = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSetKey
            // 
            this.btnSetKey.Location = new System.Drawing.Point(325, 26);
            this.btnSetKey.Name = "btnSetKey";
            this.btnSetKey.Size = new System.Drawing.Size(75, 23);
            this.btnSetKey.TabIndex = 0;
            this.btnSetKey.Text = "Set Key";
            this.btnSetKey.UseVisualStyleBackColor = true;
            // 
            // btnDeleteKey
            // 
            this.btnDeleteKey.Location = new System.Drawing.Point(325, 57);
            this.btnDeleteKey.Name = "btnDeleteKey";
            this.btnDeleteKey.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteKey.TabIndex = 1;
            this.btnDeleteKey.Text = "Delete Key";
            this.btnDeleteKey.UseVisualStyleBackColor = true;
            // 
            // txtKey
            // 
            this.txtKey.Location = new System.Drawing.Point(24, 29);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(249, 20);
            this.txtKey.TabIndex = 2;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(24, 80);
            this.txtValue.Multiline = true;
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(249, 138);
            this.txtValue.TabIndex = 4;
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Location = new System.Drawing.Point(21, 9);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(28, 13);
            this.lblKey.TabIndex = 5;
            this.lblKey.Text = "Key:";
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(21, 57);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(37, 13);
            this.lblValue.TabIndex = 6;
            this.lblValue.Text = "Value:";
            // 
            // btnReadKey
            // 
            this.btnReadKey.Location = new System.Drawing.Point(325, 86);
            this.btnReadKey.Name = "btnReadKey";
            this.btnReadKey.Size = new System.Drawing.Size(75, 23);
            this.btnReadKey.TabIndex = 7;
            this.btnReadKey.Text = "Read Key";
            this.btnReadKey.UseVisualStyleBackColor = true;
            // 
            // btnResetFields
            // 
            this.btnResetFields.Location = new System.Drawing.Point(325, 115);
            this.btnResetFields.Name = "btnResetFields";
            this.btnResetFields.Size = new System.Drawing.Size(75, 23);
            this.btnResetFields.TabIndex = 8;
            this.btnResetFields.Text = "Reset Fields";
            this.btnResetFields.UseVisualStyleBackColor = true;
            this.btnResetFields.Click += new System.EventHandler(this.btnResetFields_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(443, 242);
            this.Controls.Add(this.btnResetFields);
            this.Controls.Add(this.btnReadKey);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.btnDeleteKey);
            this.Controls.Add(this.btnSetKey);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSetKey;
        private System.Windows.Forms.Button btnDeleteKey;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.Button btnReadKey;
        private System.Windows.Forms.Button btnResetFields;
    }
}

