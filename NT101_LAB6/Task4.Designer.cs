namespace NT101_LAB6
{
    partial class Task4
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
            this.cboMode = new System.Windows.Forms.ComboBox();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.txtIV = new System.Windows.Forms.TextBox();
            this.btnGenIV = new System.Windows.Forms.Button();
            this.txtCipherHex = new System.Windows.Forms.TextBox();
            this.txtPlain = new System.Windows.Forms.TextBox();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblMode = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.lblIV = new System.Windows.Forms.Label();
            this.lblPlain = new System.Windows.Forms.Label();
            this.lblCipher = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnLoadCipher = new System.Windows.Forms.Button();
            this.btnSaveCipher = new System.Windows.Forms.Button();
            this.btnSavePlain = new System.Windows.Forms.Button();
            this.btnLoadPlain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cboMode
            // 
            this.cboMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMode.FormattingEnabled = true;
            this.cboMode.Items.AddRange(new object[] {
            "ECB",
            "CBC"});
            this.cboMode.Location = new System.Drawing.Point(181, 20);
            this.cboMode.Name = "cboMode";
            this.cboMode.Size = new System.Drawing.Size(121, 24);
            this.cboMode.TabIndex = 0;
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(181, 79);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(121, 22);
            this.txtKey.TabIndex = 1;
            this.txtKey.Text = "12345678";
            // 
            // txtIV
            // 
            this.txtIV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIV.Location = new System.Drawing.Point(181, 140);
            this.txtIV.Multiline = true;
            this.txtIV.Name = "txtIV";
            this.txtIV.Size = new System.Drawing.Size(789, 51);
            this.txtIV.TabIndex = 2;
            // 
            // btnGenIV
            // 
            this.btnGenIV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenIV.Location = new System.Drawing.Point(63, 168);
            this.btnGenIV.Name = "btnGenIV";
            this.btnGenIV.Size = new System.Drawing.Size(101, 23);
            this.btnGenIV.TabIndex = 3;
            this.btnGenIV.Text = "Generate IV";
            this.btnGenIV.UseVisualStyleBackColor = true;
            this.btnGenIV.Click += new System.EventHandler(this.btnGenIV_Click);
            // 
            // txtCipherHex
            // 
            this.txtCipherHex.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCipherHex.Location = new System.Drawing.Point(531, 254);
            this.txtCipherHex.Multiline = true;
            this.txtCipherHex.Name = "txtCipherHex";
            this.txtCipherHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCipherHex.Size = new System.Drawing.Size(436, 169);
            this.txtCipherHex.TabIndex = 4;
            // 
            // txtPlain
            // 
            this.txtPlain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlain.Location = new System.Drawing.Point(63, 254);
            this.txtPlain.Multiline = true;
            this.txtPlain.Name = "txtPlain";
            this.txtPlain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlain.Size = new System.Drawing.Size(436, 169);
            this.txtPlain.TabIndex = 5;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(244, 429);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 6;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(712, 429);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 7;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(57, 484);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(116, 16);
            this.lblStatus.TabIndex = 8;
            this.lblStatus.Text = "Status: Ready...";
            // 
            // lblMode
            // 
            this.lblMode.AutoSize = true;
            this.lblMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMode.Location = new System.Drawing.Point(63, 24);
            this.lblMode.Name = "lblMode";
            this.lblMode.Size = new System.Drawing.Size(50, 16);
            this.lblMode.TabIndex = 9;
            this.lblMode.Text = "Mode:";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.Location = new System.Drawing.Point(63, 82);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(101, 16);
            this.lblKey.TabIndex = 10;
            this.lblKey.Text = "Key (8 bytes):";
            // 
            // lblIV
            // 
            this.lblIV.AutoSize = true;
            this.lblIV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIV.Location = new System.Drawing.Point(63, 140);
            this.lblIV.Name = "lblIV";
            this.lblIV.Size = new System.Drawing.Size(104, 16);
            this.lblIV.TabIndex = 11;
            this.lblIV.Text = "IV (Hex, CBC):";
            // 
            // lblPlain
            // 
            this.lblPlain.AutoSize = true;
            this.lblPlain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlain.Location = new System.Drawing.Point(63, 223);
            this.lblPlain.Name = "lblPlain";
            this.lblPlain.Size = new System.Drawing.Size(66, 16);
            this.lblPlain.TabIndex = 12;
            this.lblPlain.Text = "Plaintext";
            // 
            // lblCipher
            // 
            this.lblCipher.AutoSize = true;
            this.lblCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCipher.Location = new System.Drawing.Point(531, 223);
            this.lblCipher.Name = "lblCipher";
            this.lblCipher.Size = new System.Drawing.Size(93, 16);
            this.lblCipher.TabIndex = 13;
            this.lblCipher.Text = "Cipher (Hex)";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(892, 474);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnLoadCipher
            // 
            this.btnLoadCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLoadCipher.Location = new System.Drawing.Point(531, 429);
            this.btnLoadCipher.Name = "btnLoadCipher";
            this.btnLoadCipher.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCipher.TabIndex = 26;
            this.btnLoadCipher.Text = "Load";
            this.btnLoadCipher.UseVisualStyleBackColor = true;
            this.btnLoadCipher.Click += new System.EventHandler(this.btnLoadCipher_Click);
            // 
            // btnSaveCipher
            // 
            this.btnSaveCipher.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveCipher.Location = new System.Drawing.Point(892, 429);
            this.btnSaveCipher.Name = "btnSaveCipher";
            this.btnSaveCipher.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCipher.TabIndex = 25;
            this.btnSaveCipher.Text = "Save";
            this.btnSaveCipher.UseVisualStyleBackColor = true;
            this.btnSaveCipher.Click += new System.EventHandler(this.btnSaveCipher_Click);
            // 
            // btnSavePlain
            // 
            this.btnSavePlain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSavePlain.Location = new System.Drawing.Point(424, 429);
            this.btnSavePlain.Name = "btnSavePlain";
            this.btnSavePlain.Size = new System.Drawing.Size(75, 23);
            this.btnSavePlain.TabIndex = 24;
            this.btnSavePlain.Text = "Save";
            this.btnSavePlain.UseVisualStyleBackColor = true;
            this.btnSavePlain.Click += new System.EventHandler(this.btnSavePlain_Click);
            // 
            // btnLoadPlain
            // 
            this.btnLoadPlain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLoadPlain.Location = new System.Drawing.Point(63, 429);
            this.btnLoadPlain.Name = "btnLoadPlain";
            this.btnLoadPlain.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPlain.TabIndex = 23;
            this.btnLoadPlain.Text = "Load";
            this.btnLoadPlain.UseVisualStyleBackColor = true;
            this.btnLoadPlain.Click += new System.EventHandler(this.btnLoadPlain_Click);
            // 
            // Task4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 511);
            this.Controls.Add(this.btnLoadCipher);
            this.Controls.Add(this.btnSaveCipher);
            this.Controls.Add(this.btnSavePlain);
            this.Controls.Add(this.btnLoadPlain);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblCipher);
            this.Controls.Add(this.lblPlain);
            this.Controls.Add(this.lblIV);
            this.Controls.Add(this.lblKey);
            this.Controls.Add(this.lblMode);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtPlain);
            this.Controls.Add(this.txtCipherHex);
            this.Controls.Add(this.btnGenIV);
            this.Controls.Add(this.txtIV);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.cboMode);
            this.Name = "Task4";
            this.Text = "Task4 - DES";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboMode;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.TextBox txtIV;
        private System.Windows.Forms.Button btnGenIV;
        private System.Windows.Forms.TextBox txtCipherHex;
        private System.Windows.Forms.TextBox txtPlain;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblMode;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label lblIV;
        private System.Windows.Forms.Label lblPlain;
        private System.Windows.Forms.Label lblCipher;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnLoadCipher;
        private System.Windows.Forms.Button btnSaveCipher;
        private System.Windows.Forms.Button btnSavePlain;
        private System.Windows.Forms.Button btnLoadPlain;
    }
}