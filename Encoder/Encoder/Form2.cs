using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Encoder
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.Text = Properties.Settings.Default.encodingToRead;
            comboBox2.SelectedItem = Properties.Settings.Default.encodingToWrite;
            comboBox3.Text = Properties.Settings.Default.extensionToSearch;
            checkBox1.Checked = Properties.Settings.Default.goInFolders;
            checkBox2.Checked = Properties.Settings.Default.autoClose;
        }

        private void RestoreDefault()
        {
            comboBox1.Text = "iso-8859-7";
            comboBox2.SelectedItem = "unicode";
            comboBox3.Text = ".srt";
            checkBox1.Checked = true;
            checkBox2.Checked = true;
        }

        private void Apply()
        {
            Properties.Settings.Default.encodingToRead = comboBox1.Text;
            Properties.Settings.Default.encodingToWrite = comboBox2.Text;
            Properties.Settings.Default.extensionToSearch = comboBox3.Text;
            Properties.Settings.Default.goInFolders = checkBox1.Checked;
            Properties.Settings.Default.autoClose = checkBox2.Checked;

            Properties.Settings.Default.Save();

            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RestoreDefault();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dl = MessageBox.Show("Are you sure you want to save the currect settings ?", "Apply Settings ?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
            if (dl == DialogResult.Yes)
                Apply();
            else if (dl == DialogResult.No)
                Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }
    }
}
