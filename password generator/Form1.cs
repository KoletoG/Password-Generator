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

        private string path = "";
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter(@"..\..\loc.txt",true);
            sw.Close();
            StreamReader sr = new StreamReader(@"..\..\loc.txt");
            if(sr.ReadLine()==null)
            {
                button1.Enabled = false;
            }
            sr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader str = new StreamReader(@"..\..\loc.txt");
            string path1 = str.ReadLine();
            str.Close();
            StreamWriter streamWriter = new StreamWriter(path1+@"\secrets.txt",true);
            File.Encrypt(path1 + @"\secrets.txt");
            streamWriter.WriteLine(textBox1.Text + " : " + PasswordGen(trackBar1.Value));
            streamWriter.WriteLine("-----------------------------------------------------");
            streamWriter.Close();
        }
        private string PasswordGen(int n=25)
        {
            string elements = "abcdefghijklmnopqrstuvwxyzABDEFGHIJKLMNOPRSTUVWXYZ0123456789_!@$#%&{}()?>.<+-";
            string pass = "";
            Random random = new Random();
            for (int i = 0; i <= n; i++)
            {
                pass += elements[random.Next(77)];
            }
            return pass;
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

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
