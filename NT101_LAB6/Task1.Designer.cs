namespace NT101_LAB6
{
    partial class Task1
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
            this.txtCaesarCipher = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCaesarPlain = new System.Windows.Forms.TextBox();
            this.btnCaesarOpenFile = new System.Windows.Forms.Button();
            this.btnCaesarCrack = new System.Windows.Forms.Button();
            this.btnCaesarSavePlain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ciphertext:";
            // 
            // txtCaesarCipher
            // 
            this.txtCaesarCipher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaesarCipher.Location = new System.Drawing.Point(221, 44);
            this.txtCaesarCipher.Multiline = true;
            this.txtCaesarCipher.Name = "txtCaesarCipher";
            this.txtCaesarCipher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCaesarCipher.Size = new System.Drawing.Size(482, 116);
            this.txtCaesarCipher.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(71, 270);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Plaintext:";
            // 
            // txtCaesarPlain
            // 
            this.txtCaesarPlain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCaesarPlain.Location = new System.Drawing.Point(221, 270);
            this.txtCaesarPlain.Multiline = true;
            this.txtCaesarPlain.Name = "txtCaesarPlain";
            this.txtCaesarPlain.ReadOnly = true;
            this.txtCaesarPlain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCaesarPlain.Size = new System.Drawing.Size(482, 116);
            this.txtCaesarPlain.TabIndex = 3;
            // 
            // btnCaesarOpenFile
            // 
            this.btnCaesarOpenFile.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaesarOpenFile.Location = new System.Drawing.Point(75, 126);
            this.btnCaesarOpenFile.Name = "btnCaesarOpenFile";
            this.btnCaesarOpenFile.Size = new System.Drawing.Size(104, 34);
            this.btnCaesarOpenFile.TabIndex = 4;
            this.btnCaesarOpenFile.Text = "Thêm File";
            this.btnCaesarOpenFile.UseVisualStyleBackColor = true;
            this.btnCaesarOpenFile.Click += new System.EventHandler(this.btnCaesarOpenFile_Click);
            // 
            // btnCaesarCrack
            // 
            this.btnCaesarCrack.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaesarCrack.Location = new System.Drawing.Point(599, 175);
            this.btnCaesarCrack.Name = "btnCaesarCrack";
            this.btnCaesarCrack.Size = new System.Drawing.Size(104, 34);
            this.btnCaesarCrack.TabIndex = 5;
            this.btnCaesarCrack.Text = "Crack";
            this.btnCaesarCrack.UseVisualStyleBackColor = true;
            this.btnCaesarCrack.Click += new System.EventHandler(this.btnCaesarCrack_Click);
            // 
            // btnCaesarSavePlain
            // 
            this.btnCaesarSavePlain.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCaesarSavePlain.Location = new System.Drawing.Point(75, 352);
            this.btnCaesarSavePlain.Name = "btnCaesarSavePlain";
            this.btnCaesarSavePlain.Size = new System.Drawing.Size(104, 34);
            this.btnCaesarSavePlain.TabIndex = 6;
            this.btnCaesarSavePlain.Text = "Lưu";
            this.btnCaesarSavePlain.UseVisualStyleBackColor = true;
            this.btnCaesarSavePlain.Click += new System.EventHandler(this.btnCaesarSavePlain_Click);
            // 
            // Task1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.btnCaesarSavePlain);
            this.Controls.Add(this.btnCaesarCrack);
            this.Controls.Add(this.btnCaesarOpenFile);
            this.Controls.Add(this.txtCaesarPlain);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCaesarCipher);
            this.Controls.Add(this.label1);
            this.Name = "Task1";
            this.Text = "Task1 - Caesar cipher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCaesarCipher;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCaesarPlain;
        private System.Windows.Forms.Button btnCaesarOpenFile;
        private System.Windows.Forms.Button btnCaesarCrack;
        private System.Windows.Forms.Button btnCaesarSavePlain;
    }
}