namespace NT101_LAB6
{
    partial class Task5
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbMode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnGenIV = new System.Windows.Forms.Button();
            this.txtIVHex = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPlain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCipherHex = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnLoadPlain = new System.Windows.Forms.Button();
            this.btnSavePlain = new System.Windows.Forms.Button();
            this.btnLoadCipher = new System.Windows.Forms.Button();
            this.btnSaveCipher = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(60, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode:";
            // 
            // cmbMode
            // 
            this.cmbMode.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMode.FormattingEnabled = true;
            this.cmbMode.Items.AddRange(new object[] {
            "ECB",
            "CBC"});
            this.cmbMode.Location = new System.Drawing.Point(179, 29);
            this.cmbMode.Name = "cmbMode";
            this.cmbMode.Size = new System.Drawing.Size(121, 24);
            this.cmbMode.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(60, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Key (16 bytes):";
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(179, 74);
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(336, 24);
            this.txtKey.TabIndex = 3;
            // 
            // btnGenIV
            // 
            this.btnGenIV.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenIV.Location = new System.Drawing.Point(532, 120);
            this.btnGenIV.Name = "btnGenIV";
            this.btnGenIV.Size = new System.Drawing.Size(75, 23);
            this.btnGenIV.TabIndex = 4;
            this.btnGenIV.Text = "Generate";
            this.btnGenIV.UseVisualStyleBackColor = true;
            this.btnGenIV.Click += new System.EventHandler(this.btnGenIV_Click);
            // 
            // txtIVHex
            // 
            this.txtIVHex.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIVHex.Location = new System.Drawing.Point(179, 119);
            this.txtIVHex.Name = "txtIVHex";
            this.txtIVHex.Size = new System.Drawing.Size(336, 24);
            this.txtIVHex.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(60, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "IV (Hex, CBC):";
            // 
            // txtPlain
            // 
            this.txtPlain.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlain.Location = new System.Drawing.Point(63, 196);
            this.txtPlain.Multiline = true;
            this.txtPlain.Name = "txtPlain";
            this.txtPlain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtPlain.Size = new System.Drawing.Size(327, 148);
            this.txtPlain.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 7;
            this.label4.Text = "Plaintext";
            // 
            // txtCipherHex
            // 
            this.txtCipherHex.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCipherHex.Location = new System.Drawing.Point(461, 196);
            this.txtCipherHex.Multiline = true;
            this.txtCipherHex.Name = "txtCipherHex";
            this.txtCipherHex.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCipherHex.Size = new System.Drawing.Size(327, 148);
            this.txtCipherHex.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(468, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Cipher (Hex)";
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(713, 416);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecrypt.Location = new System.Drawing.Point(587, 362);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 23);
            this.btnDecrypt.TabIndex = 16;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEncrypt.Location = new System.Drawing.Point(189, 362);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 23);
            this.btnEncrypt.TabIndex = 15;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(60, 419);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(102, 16);
            this.lblStatus.TabIndex = 18;
            this.lblStatus.Text = "Status: Ready...";
            // 
            // btnLoadPlain
            // 
            this.btnLoadPlain.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadPlain.Location = new System.Drawing.Point(63, 362);
            this.btnLoadPlain.Name = "btnLoadPlain";
            this.btnLoadPlain.Size = new System.Drawing.Size(75, 23);
            this.btnLoadPlain.TabIndex = 19;
            this.btnLoadPlain.Text = "Load";
            this.btnLoadPlain.UseVisualStyleBackColor = true;
            this.btnLoadPlain.Click += new System.EventHandler(this.btnLoadPlain_Click);
            // 
            // btnSavePlain
            // 
            this.btnSavePlain.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePlain.Location = new System.Drawing.Point(315, 362);
            this.btnSavePlain.Name = "btnSavePlain";
            this.btnSavePlain.Size = new System.Drawing.Size(75, 23);
            this.btnSavePlain.TabIndex = 20;
            this.btnSavePlain.Text = "Save";
            this.btnSavePlain.UseVisualStyleBackColor = true;
            this.btnSavePlain.Click += new System.EventHandler(this.btnSavePlain_Click);
            // 
            // btnLoadCipher
            // 
            this.btnLoadCipher.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoadCipher.Location = new System.Drawing.Point(461, 362);
            this.btnLoadCipher.Name = "btnLoadCipher";
            this.btnLoadCipher.Size = new System.Drawing.Size(75, 23);
            this.btnLoadCipher.TabIndex = 22;
            this.btnLoadCipher.Text = "Load";
            this.btnLoadCipher.UseVisualStyleBackColor = true;
            this.btnLoadCipher.Click += new System.EventHandler(this.btnLoadCipher_Click);
            // 
            // btnSaveCipher
            // 
            this.btnSaveCipher.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveCipher.Location = new System.Drawing.Point(713, 362);
            this.btnSaveCipher.Name = "btnSaveCipher";
            this.btnSaveCipher.Size = new System.Drawing.Size(75, 23);
            this.btnSaveCipher.TabIndex = 21;
            this.btnSaveCipher.Text = "Save";
            this.btnSaveCipher.UseVisualStyleBackColor = true;
            this.btnSaveCipher.Click += new System.EventHandler(this.btnSaveCipher_Click);
            // 
            // Task5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(860, 474);
            this.Controls.Add(this.btnLoadCipher);
            this.Controls.Add(this.btnSaveCipher);
            this.Controls.Add(this.btnSavePlain);
            this.Controls.Add(this.btnLoadPlain);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.txtCipherHex);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPlain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtIVHex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGenIV);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbMode);
            this.Controls.Add(this.label1);
            this.Name = "Task5";
            this.Text = "Task5";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnGenIV;
        private System.Windows.Forms.TextBox txtIVHex;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPlain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCipherHex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnLoadPlain;
        private System.Windows.Forms.Button btnSavePlain;
        private System.Windows.Forms.Button btnLoadCipher;
        private System.Windows.Forms.Button btnSaveCipher;
    }
}