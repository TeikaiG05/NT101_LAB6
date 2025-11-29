using System;
using System.IO;
using System.Windows.Forms;


namespace NT101_LAB6
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }

        private void btnCaesarOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chọn file ciphertext (Caesar)";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = File.ReadAllText(ofd.FileName);
                        txtCaesarCipher.Text = content;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi doc file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCaesarSavePlain_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Luu plaintext (Caesar)";
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FileName = "caesar_plain.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, txtCaesarPlain.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi ghi file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCaesarCrack_Click(object sender, EventArgs e)
        {
            string cipher = txtCaesarCipher.Text;
            if (string.IsNullOrWhiteSpace(cipher))
            {
                MessageBox.Show("Chua co ciphertext!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var (key, plain) = CaesarCracker.Crack(cipher);

                txtCaesarPlain.Text = $"Best key: " + key.ToString() + Environment.NewLine + plain;

                MessageBox.Show("Crack xong! Key = " + key, "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi khi crack Caesar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
