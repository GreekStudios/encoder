using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Encoder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            Encode(Application.StartupPath);
            SearchDir();
        }

        private void SearchDir()
        {
            if (Properties.Settings.Default.goInFolders)
            {
                string[] folders = System.IO.Directory.GetDirectories(Application.StartupPath, "*", System.IO.SearchOption.AllDirectories);
                foreach (string folder in folders)
                    Encode(folder);
            }
        }

        private void Encode(string dir)
        {
            try
            {

                string[] filePaths = Directory.GetFiles(dir, "*.srt");
                if (filePaths.Length > 0)
                {
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        FileInfo fl = new FileInfo(filePaths[i]);
                        string input = File.ReadAllText(filePaths[i], Encoding.GetEncoding(Properties.Settings.Default.encodingToRead));
                        Encoding encoding = null;
                        if (Properties.Settings.Default.encodingToWrite == "unicode")
                            encoding = Encoding.Unicode;
                        else if (Properties.Settings.Default.encodingToWrite == "utf-8")
                            encoding = Encoding.UTF8;
                        else if (Properties.Settings.Default.encodingToWrite == "ascii")
                            encoding = Encoding.ASCII;

                        File.WriteAllText(filePaths[i], input, encoding);

                        listBox1.Items.Add(fl.Name + " - Converted!");
                    }

                    if (Properties.Settings.Default.autoClose)
                        timer1.Start();
                }
                else
                {
                    Form2 f = new Form2();
                    f.ShowDialog();
                    listBox1.Items.Add("No " + Properties.Settings.Default.extensionToSearch + " files found !");
                    if (Properties.Settings.Default.autoClose)
                        timer1.Start();
                }

            }
            catch { }
        }
        int timer = 3;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timer > 0)
            {
                timer--;
                listBox1.Items.Add("Closing (" + timer.ToString() + ")..");
            }

            if (timer <= 0)
                Application.Exit();
        }
    }
}
