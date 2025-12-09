using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace NT101_LAB6
{
    public partial class Task5 : Form
    {
        public Task5()
        {
            InitializeComponent();
            cmbMode.SelectedIndex = 0;
        }

        private void btnGenIV_Click(object sender, EventArgs e)
        {
            var rnd = new Random();
            byte[] iv = new byte[16];
            rnd.NextBytes(iv);
            txtIVHex.Text = AesCipher.ToHex(iv);
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string mode = cmbMode.SelectedItem.ToString();
                string keyStr = txtKey.Text.Trim();
                if (keyStr.Length != 16)
                {
                    MessageBox.Show("Key must be exactly 16 characters (16 bytes) for AES-128.");
                    return;
                }
                byte[] key = Encoding.ASCII.GetBytes(keyStr);

                byte[] plain = Encoding.UTF8.GetBytes(txtPlain.Text);

                byte[] iv = null;
                if (mode != "ECB")
                {
                    if (!string.IsNullOrWhiteSpace(txtIVHex.Text))
                        iv = AesCipher.FromHex(txtIVHex.Text);
                }

                var result = AesCipher.Encrypt(plain, key, mode, iv);
                byte[] cipher = result.Ciphertext;
                byte[] usedIv = result.Iv;

                txtCipherHex.Text = AesCipher.ToPrettyHex(cipher);

                if (mode != "ECB" && usedIv != null)
                    txtIVHex.Text = AesCipher.ToHex(usedIv);

                lblStatus.Text = "Encrypt OK";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Encrypt error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Encrypt failed";
            }
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            try
            {
                string mode = cmbMode.SelectedItem.ToString();
                string keyStr = txtKey.Text.Trim();

                if (keyStr.Length != 16)
                {
                    MessageBox.Show("Key must be exactly 16 characters (16 bytes) for AES-128.");
                    return;
                }

                byte[] key = Encoding.ASCII.GetBytes(keyStr);
                byte[] cipher = AesCipher.FromHex(txtCipherHex.Text);

                byte[] iv = null;
                if (mode != "ECB")
                {
                    if (string.IsNullOrWhiteSpace(txtIVHex.Text))
                    {
                        MessageBox.Show("IV is required for CBC decryption.");
                        return;
                    }
                    iv = AesCipher.FromHex(txtIVHex.Text);
                }

                byte[] plain = AesCipher.Decrypt(cipher, key, mode, iv);
                txtPlain.Text = Encoding.UTF8.GetString(plain);

                lblStatus.Text = "Decrypt OK";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Decrypt error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblStatus.Text = "Decrypt failed";
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtPlain.Clear();
            txtCipherHex.Clear();
            lblStatus.Text = string.Empty;
        }

        private void btnLoadPlain_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file plaintext";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                        txtPlain.Text = content;
                        lblStatus.Text = "Loaded plaintext from file.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading plaintext file: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblStatus.Text = "Load plaintext failed.";
                    }
                }
            }
        }

        private void btnSavePlain_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Lưu plaintext";
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, txtPlain.Text, Encoding.UTF8);
                        lblStatus.Text = "Saved plaintext to file.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving plaintext file: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblStatus.Text = "Save plaintext failed.";
                    }
                }
            }
        }

        private void btnLoadCipher_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file cipher (hex)";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                        txtCipherHex.Text = content;
                        lblStatus.Text = "Loaded cipher from file.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error loading cipher file: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblStatus.Text = "Load cipher failed.";
                    }
                }
            }
        }

        private void btnSaveCipher_Click(object sender, EventArgs e)
        {
            using (var sfd = new SaveFileDialog())
            {
                sfd.Title = "Lưu cipher (hex)";
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, txtCipherHex.Text, Encoding.UTF8);
                        lblStatus.Text = "Saved cipher to file.";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error saving cipher file: " + ex.Message,
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        lblStatus.Text = "Save cipher failed.";
                    }
                }
            }
        }
    }
}
