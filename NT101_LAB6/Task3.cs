using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NT101_LAB6
{
    public partial class Task3 : Form
    {
        public Task3()
        {
            InitializeComponent();
        }

        private void btnVigOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chon file ciphertext (Vigenere)";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                        txtVigCipher.Text = content;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi doc file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnVigCrack_Click(object sender, EventArgs e)
        {
            string cipher = txtVigCipher.Text;
            if (string.IsNullOrWhiteSpace(cipher))
            {
                MessageBox.Show("Chua co ciphertext!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var (key, plain) = VigenereCracker.Crack(cipher);

                txtVigPlain.Text = key + Environment.NewLine + plain;

                MessageBox.Show("Crack Vigenere xong! Key = " + key, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi khi crack Vigenere: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnVigSavePlain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtVigPlain.Text))
            {
                MessageBox.Show("Chua co ket qua de luu!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Luu ket qua Vigenere";
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FileName = "vigenere_plain.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, txtVigPlain.Text, Encoding.UTF8);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi ghi file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
