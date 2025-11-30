namespace NT101_LAB6
{
    partial class Task3
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
            this.txtVigPlain = new System.Windows.Forms.TextBox();
            this.lblVigPlain = new System.Windows.Forms.Label();
            this.btnVigSavePlain = new System.Windows.Forms.Button();
            this.btnVigCrack = new System.Windows.Forms.Button();
            this.btnVigOpenFile = new System.Windows.Forms.Button();
            this.txtVigCipher = new System.Windows.Forms.TextBox();
            this.lblVigCipher = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtVigPlain
            // 
            this.txtVigPlain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVigPlain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVigPlain.Location = new System.Drawing.Point(178, 368);
            this.txtVigPlain.Multiline = true;
            this.txtVigPlain.Name = "txtVigPlain";
            this.txtVigPlain.ReadOnly = true;
            this.txtVigPlain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVigPlain.Size = new System.Drawing.Size(746, 235);
            this.txtVigPlain.TabIndex = 20;
            // 
            // lblVigPlain
            // 
            this.lblVigPlain.AutoSize = true;
            this.lblVigPlain.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblVigPlain.Location = new System.Drawing.Point(42, 368);
            this.lblVigPlain.Name = "lblVigPlain";
            this.lblVigPlain.Size = new System.Drawing.Size(94, 23);
            this.lblVigPlain.TabIndex = 19;
            this.lblVigPlain.Text = "Plaintext:";
            // 
            // btnVigSavePlain
            // 
            this.btnVigSavePlain.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVigSavePlain.Location = new System.Drawing.Point(46, 559);
            this.btnVigSavePlain.Name = "btnVigSavePlain";
            this.btnVigSavePlain.Size = new System.Drawing.Size(104, 44);
            this.btnVigSavePlain.TabIndex = 18;
            this.btnVigSavePlain.Text = "Lưu";
            this.btnVigSavePlain.UseVisualStyleBackColor = true;
            this.btnVigSavePlain.Click += new System.EventHandler(this.btnVigSavePlain_Click);
            // 
            // btnVigCrack
            // 
            this.btnVigCrack.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVigCrack.Location = new System.Drawing.Point(820, 296);
            this.btnVigCrack.Name = "btnVigCrack";
            this.btnVigCrack.Size = new System.Drawing.Size(104, 44);
            this.btnVigCrack.TabIndex = 17;
            this.btnVigCrack.Text = "Crack";
            this.btnVigCrack.UseVisualStyleBackColor = true;
            this.btnVigCrack.Click += new System.EventHandler(this.btnVigCrack_Click);
            // 
            // btnVigOpenFile
            // 
            this.btnVigOpenFile.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVigOpenFile.Location = new System.Drawing.Point(46, 126);
            this.btnVigOpenFile.Name = "btnVigOpenFile";
            this.btnVigOpenFile.Size = new System.Drawing.Size(104, 44);
            this.btnVigOpenFile.TabIndex = 14;
            this.btnVigOpenFile.Text = "Thêm File";
            this.btnVigOpenFile.UseVisualStyleBackColor = true;
            this.btnVigOpenFile.Click += new System.EventHandler(this.btnVigOpenFile_Click);
            // 
            // txtVigCipher
            // 
            this.txtVigCipher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVigCipher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtVigCipher.Location = new System.Drawing.Point(178, 41);
            this.txtVigCipher.Multiline = true;
            this.txtVigCipher.Name = "txtVigCipher";
            this.txtVigCipher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtVigCipher.Size = new System.Drawing.Size(746, 235);
            this.txtVigCipher.TabIndex = 13;
            // 
            // lblVigCipher
            // 
            this.lblVigCipher.AutoSize = true;
            this.lblVigCipher.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVigCipher.Location = new System.Drawing.Point(42, 41);
            this.lblVigCipher.Name = "lblVigCipher";
            this.lblVigCipher.Size = new System.Drawing.Size(108, 23);
            this.lblVigCipher.TabIndex = 12;
            this.lblVigCipher.Text = "Ciphertext:";
            // 
            // Task3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 660);
            this.Controls.Add(this.txtVigPlain);
            this.Controls.Add(this.lblVigPlain);
            this.Controls.Add(this.btnVigSavePlain);
            this.Controls.Add(this.btnVigCrack);
            this.Controls.Add(this.btnVigOpenFile);
            this.Controls.Add(this.txtVigCipher);
            this.Controls.Add(this.lblVigCipher);
            this.Name = "Task3";
            this.Text = "Task3 - Vigenère cipher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtVigPlain;
        private System.Windows.Forms.Label lblVigPlain;
        private System.Windows.Forms.Button btnVigSavePlain;
        private System.Windows.Forms.Button btnVigCrack;
        private System.Windows.Forms.Button btnVigOpenFile;
        private System.Windows.Forms.TextBox txtVigCipher;
        private System.Windows.Forms.Label lblVigCipher;
    }
}