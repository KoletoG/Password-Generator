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
        private static StreamWriter sw = new StreamWriter(@"..\..\loc.txt", true);
        private Random random = new Random();
        private string path = "";
        const string elements = "abcdefghijklmnopqrstuvwxyzABDEFGHIJKLMNOPRSTUVWXYZ0123456789_!@$#%&{}()?>.<+-";
        private void Form1_Load(object sender, EventArgs e)
        {
            if(str.ReadLine()==null)
            {
                button1.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path1 = str.ReadLine();
            StreamWriter streamWriter = new StreamWriter(path1+@"\secrets.txt",true);
            File.Encrypt(path1 + @"\secrets.txt");
            streamWriter.WriteLine(textBox1.Text + " : " + PasswordGen(trackBar1.Value));
            streamWriter.WriteLine("-----------------------------------------------------");
        }
        private string PasswordGen(int n=25)
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
            if(folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                path =folderBrowserDialog1.SelectedPath;
                StreamWriter sw = new StreamWriter(@"..\..\loc.txt",false);
                sw.WriteLine(path);
                sw.Close();
            }
            button1.Enabled = true;
        }
    }
}
