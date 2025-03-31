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
        private static Random random = new Random();
        private string path = "";
        private string readLine;
        private const string elements = "abcdefghijklmnopqrstuvwxyzABDEFGHIJKLMNOPRSTUVWXYZ0123456789_!@$#%&{}()?>.<+-";
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(@"..\..\loc.txt"))
                {
                    using (StreamReader str = new StreamReader(@"..\..\loc.txt"))
                    {
                        readLine = str.ReadLine();
                        if (String.IsNullOrEmpty(readLine))
                        {
                            button1.Enabled = false;
                        }
                        else
                        {
                            button1.Enabled = true;
                            path = readLine;
                        }
                    }
                }
                else
                {
                    using (FileStream fs = File.Create(@"..\..\loc.txt")) { }
                    button1.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(path, true))
                {
                    streamWriter.WriteLine(textBox1.Text + " : " + PasswordGen(trackBar1.Value));
                    streamWriter.WriteLine("-----------------------------------------------------");
                }
                File.Encrypt(path);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private string PasswordGen(int n = 25)
        {
            try
            {
                StringBuilder pass = new StringBuilder(n);
                for (int i = 0; i < n; i++)
                {
                    pass.Append(elements[random.Next(elements.Length)]);
                }
                return pass.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                throw new Exception("Error");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(@"..\..\loc.txt", false))
                    {
                        path = folderBrowserDialog1.SelectedPath;
                        sw.WriteLine(path + @"\secrets.txt");
                    }
                    button1.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
