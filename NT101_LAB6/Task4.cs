using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NT101_LAB6
{
    public partial class Task4 : Form
    {
        public Task4()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtPlain.Text))
                {
                    MessageBox.Show("Chưa có plaintext.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblStatus.Text = "";
                if(cboMode.SelectedItem == null)
                {
                    MessageBox.Show("Chưa chọn chế độ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string mode = cboMode.SelectedItem.ToString();
                byte[] key = DesCipher.FromHex(txtKey.Text.Trim());
                if (key.Length != 8)
                {
                    MessageBox.Show("Key phải đúng 8 byte (8 ký tự ASCII).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] plaintext = Encoding.UTF8.GetBytes(txtPlain.Text);
                byte[] iv = null;

                if (mode == "CBC")
                {
                    if (!string.IsNullOrWhiteSpace(txtIV.Text))
                    {
                        iv = DesCipher.FromHex(txtIV.Text.Trim());
                        if (iv.Length != 8)
                        {
                            MessageBox.Show("IV phải dài 8 byte (16 hex).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }

                var result = DesCipher.Encrypt(plaintext, key, mode, iv);

                byte[] cipher = result.Ciphertext;
                byte[] usedIv = result.Iv;

                txtCipherHex.Text = DesCipher.ToHex(cipher);

                if (mode == "CBC")
                {
                    txtIV.Text = DesCipher.ToHex(usedIv);
                }

                lblStatus.Text = "Encrypt OK.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Encrypt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Encrypt lỗi.";
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(txtCipherHex.Text))
                {
                    MessageBox.Show("Chưa có ciphertext (hex).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(cboMode.SelectedItem == null)
                {
                    MessageBox.Show("Chưa chọn chế độ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                lblStatus.Text = "";
                
                string mode = cboMode.SelectedItem.ToString();
                byte[] key = DesCipher.FromHex(txtKey.Text.Trim());

                if (key.Length != 8)
                {
                    MessageBox.Show("Key phải đúng 8 byte (8 ký tự ASCII).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCipherHex.Text))
                {
                    MessageBox.Show("Chưa có ciphertext (hex).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                byte[] ciphertext = DesCipher.FromHex(txtCipherHex.Text.Trim());
                byte[] iv = null;

                if (mode == "CBC")
                {
                    if (string.IsNullOrWhiteSpace(txtIV.Text))
                    {
                        MessageBox.Show("CBC cần IV (hex) để giải mã.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    iv = DesCipher.FromHex(txtIV.Text.Trim());
                    if (iv.Length != 8)
                    {
                        MessageBox.Show("IV phải dài 8 byte (16 hex).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                byte[] plain = DesCipher.Decrypt(ciphertext, key, mode, iv);
                txtPlain.Text = Encoding.UTF8.GetString(plain);

                lblStatus.Text = "Decrypt OK.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Decrypt: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Decrypt lỗi.";
            }
        }

        private void btnGenIV_Click(object sender, EventArgs e)
        {
            if(cboMode.SelectedItem == null)
            {
                MessageBox.Show("Chưa chọn chế độ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cboMode.SelectedItem.ToString() != "CBC")
            {
                txtIV.Clear();
                MessageBox.Show("Chỉ tạo IV cho chế độ CBC.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var rnd = new Random();
            byte[] iv = new byte[8];
            rnd.NextBytes(iv);
            txtIV.Text = DesCipher.ToHex(iv);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCipherHex.Clear();
            txtPlain.Clear();
            lblStatus.Text = "Status: Ready...";
        }

        private void btnLoadPlain_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Open plaintext file";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                        txtPlain.Text = content;
                        lblStatus.Text = "Status: Loaded plaintext from file.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading plaintext: " + ex.Message);
                    }
                }
            }
        }

        private void btnSavePlain_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Save plaintext to file";
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, txtPlain.Text, Encoding.UTF8);
                        lblStatus.Text = "Status: Saved plaintext to file.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving plaintext: " + ex.Message);
                    }
                }
            }
        }

        private void btnLoadCipher_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Open cipher (hex) file";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string hex = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                        txtCipherHex.Text = hex;
                        lblStatus.Text = "Status: Loaded cipher (hex) from file.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading cipher: " + ex.Message);
                    }
                }
            }
        }

        private void btnSaveCipher_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Save cipher (hex) to file";
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, txtCipherHex.Text, Encoding.UTF8);
                        lblStatus.Text = "Status: Saved cipher (hex) to file.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving cipher: " + ex.Message);
                    }
                }
            }
        }
    }
}
