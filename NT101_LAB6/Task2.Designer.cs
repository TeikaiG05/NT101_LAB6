namespace NT101_LAB6
{
    partial class Task2
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
            this.lblSubCipher = new System.Windows.Forms.Label();
            this.txtSubCipher = new System.Windows.Forms.TextBox();
            this.btnSubOpenFile = new System.Windows.Forms.Button();
            this.lblSubIterations = new System.Windows.Forms.Label();
            this.numSubIterations = new System.Windows.Forms.NumericUpDown();
            this.btnSubCrack = new System.Windows.Forms.Button();
            this.btnSubSavePlain = new System.Windows.Forms.Button();
            this.lblSubPlain = new System.Windows.Forms.Label();
            this.txtSubPlain = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numSubIterations)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubCipher
            // 
            this.lblSubCipher.AutoSize = true;
            this.lblSubCipher.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubCipher.Location = new System.Drawing.Point(44, 26);
            this.lblSubCipher.Name = "lblSubCipher";
            this.lblSubCipher.Size = new System.Drawing.Size(108, 23);
            this.lblSubCipher.TabIndex = 0;
            this.lblSubCipher.Text = "Ciphertext:";
            // 
            // txtSubCipher
            // 
            this.txtSubCipher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubCipher.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubCipher.Location = new System.Drawing.Point(180, 26);
            this.txtSubCipher.Multiline = true;
            this.txtSubCipher.Name = "txtSubCipher";
            this.txtSubCipher.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubCipher.Size = new System.Drawing.Size(746, 235);
            this.txtSubCipher.TabIndex = 4;
            // 
            // btnSubOpenFile
            // 
            this.btnSubOpenFile.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubOpenFile.Location = new System.Drawing.Point(48, 111);
            this.btnSubOpenFile.Name = "btnSubOpenFile";
            this.btnSubOpenFile.Size = new System.Drawing.Size(104, 44);
            this.btnSubOpenFile.TabIndex = 5;
            this.btnSubOpenFile.Text = "Thêm File";
            this.btnSubOpenFile.UseVisualStyleBackColor = true;
            this.btnSubOpenFile.Click += new System.EventHandler(this.btnSubOpenFile_Click);
            // 
            // lblSubIterations
            // 
            this.lblSubIterations.AutoSize = true;
            this.lblSubIterations.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblSubIterations.Location = new System.Drawing.Point(44, 310);
            this.lblSubIterations.Name = "lblSubIterations";
            this.lblSubIterations.Size = new System.Drawing.Size(100, 23);
            this.lblSubIterations.TabIndex = 6;
            this.lblSubIterations.Text = "Số lần lặp:";
            // 
            // numSubIterations
            // 
            this.numSubIterations.Location = new System.Drawing.Point(180, 311);
            this.numSubIterations.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numSubIterations.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSubIterations.Name = "numSubIterations";
            this.numSubIterations.Size = new System.Drawing.Size(120, 20);
            this.numSubIterations.TabIndex = 7;
            this.numSubIterations.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // btnSubCrack
            // 
            this.btnSubCrack.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubCrack.Location = new System.Drawing.Point(822, 281);
            this.btnSubCrack.Name = "btnSubCrack";
            this.btnSubCrack.Size = new System.Drawing.Size(104, 44);
            this.btnSubCrack.TabIndex = 8;
            this.btnSubCrack.Text = "Crack";
            this.btnSubCrack.UseVisualStyleBackColor = true;
            this.btnSubCrack.Click += new System.EventHandler(this.btnSubCrack_Click);
            // 
            // btnSubSavePlain
            // 
            this.btnSubSavePlain.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubSavePlain.Location = new System.Drawing.Point(48, 560);
            this.btnSubSavePlain.Name = "btnSubSavePlain";
            this.btnSubSavePlain.Size = new System.Drawing.Size(104, 44);
            this.btnSubSavePlain.TabIndex = 9;
            this.btnSubSavePlain.Text = "Lưu";
            this.btnSubSavePlain.UseVisualStyleBackColor = true;
            this.btnSubSavePlain.Click += new System.EventHandler(this.btnSubSavePlain_Click);
            // 
            // lblSubPlain
            // 
            this.lblSubPlain.AutoSize = true;
            this.lblSubPlain.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblSubPlain.Location = new System.Drawing.Point(44, 369);
            this.lblSubPlain.Name = "lblSubPlain";
            this.lblSubPlain.Size = new System.Drawing.Size(94, 23);
            this.lblSubPlain.TabIndex = 10;
            this.lblSubPlain.Text = "Plaintext:";
            // 
            // txtSubPlain
            // 
            this.txtSubPlain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubPlain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSubPlain.Location = new System.Drawing.Point(180, 369);
            this.txtSubPlain.Multiline = true;
            this.txtSubPlain.Name = "txtSubPlain";
            this.txtSubPlain.ReadOnly = true;
            this.txtSubPlain.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSubPlain.Size = new System.Drawing.Size(746, 235);
            this.txtSubPlain.TabIndex = 11;
            // 
            // Task2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(966, 660);
            this.Controls.Add(this.txtSubPlain);
            this.Controls.Add(this.lblSubPlain);
            this.Controls.Add(this.btnSubSavePlain);
            this.Controls.Add(this.btnSubCrack);
            this.Controls.Add(this.numSubIterations);
            this.Controls.Add(this.lblSubIterations);
            this.Controls.Add(this.btnSubOpenFile);
            this.Controls.Add(this.txtSubCipher);
            this.Controls.Add(this.lblSubCipher);
            this.Name = "Task2";
            this.Text = "Task2 - Mono-alphabetic substitution cipher";
            ((System.ComponentModel.ISupportInitialize)(this.numSubIterations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSubCipher;
        private System.Windows.Forms.TextBox txtSubCipher;
        private System.Windows.Forms.Button btnSubOpenFile;
        private System.Windows.Forms.Label lblSubIterations;
        private System.Windows.Forms.NumericUpDown numSubIterations;
        private System.Windows.Forms.Button btnSubCrack;
        private System.Windows.Forms.Button btnSubSavePlain;
        private System.Windows.Forms.Label lblSubPlain;
        private System.Windows.Forms.TextBox txtSubPlain;
    }
}