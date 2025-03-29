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

namespace password_generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static StreamReader str = new StreamReader(@"..\..\loc.txt");
        private Random random = new Random();
        private string path = "";
        const string elements = "abcdefghijklmnopqrstuvwxyzABDEFGHIJKLMNOPRSTUVWXYZ0123456789_!@$#%&{}()?>.<+-";
        private void Form1_Load(object sender, EventArgs e)
        {
            if (str.ReadLine() == null)
            {
                button1.Enabled = false;
            }
            else
            {
                button1.Enabled = true;
                path = str.ReadLine();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter streamWriter = new StreamWriter(path, true);
            File.Encrypt(path);
            streamWriter.WriteLine(textBox1.Text + " : " + PasswordGen(trackBar1.Value));
            streamWriter.WriteLine("-----------------------------------------------------");
            streamWriter.Close();
        }
        private string PasswordGen(int n = 25)
        {
            StringBuilder pass = new StringBuilder(n);
            for (int i = 0; i <= n; i++)
            {
                pass.Append(elements[random.Next(elements.Length)]);
            }
            return pass.ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(@"..\..\loc.txt", false);
                path = folderBrowserDialog1.SelectedPath;
                sw.WriteLine(path + @"\secrets.txt");
                sw.Close();
                button1.Enabled = true;
            }
        }
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
