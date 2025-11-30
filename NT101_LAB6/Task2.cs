using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace NT101_LAB6
{
    public partial class Task2 : Form
    {
        public Task2()
        {
            InitializeComponent();
            numSubIterations.Value = 10000;
        }

        private void btnSubOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Chon file ciphertext (Substitution)";
                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string content = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                        txtSubCipher.Text = content;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Loi doc file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnSubCrack_Click(object sender, EventArgs e)
        {
            string cipher = txtSubCipher.Text;
            if (string.IsNullOrWhiteSpace(cipher))
            {
                MessageBox.Show("Chua co ciphertext!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int iterations = (int)numSubIterations.Value;

            try
            {
                var result = SubstitutionCracker.Crack(cipher, iterations);
                string mappingStr = SubstitutionCracker.MappingToString(result.Mapping);

                txtSubPlain.Text = result.Score.ToString("F2") + Environment.NewLine + mappingStr + Environment.NewLine + result.Plaintext;

                MessageBox.Show("Crack substitution xong!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Co loi khi crack substitution: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSubSavePlain_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSubPlain.Text))
            {
                MessageBox.Show("Chua co ket qua de luu!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Luu ket qua Substitution";
                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                sfd.FileName = "substitution_plain.txt";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(sfd.FileName, txtSubPlain.Text, Encoding.UTF8);
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
