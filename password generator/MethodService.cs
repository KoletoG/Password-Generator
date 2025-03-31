using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Microsoft.Extensions.Logging;

namespace password_generator
{
    public class MethodService : IMethodService
    {
        private string readLine;
        private static Random random = new Random();
        private string path = "";
        private const string elements = "abcdefghijklmnopqrstuvwxyzABDEFGHIJKLMNOPRSTUVWXYZ0123456789_!@$#%&{}()?>.<+-";
        private ILogger<MethodService> _logger;
        public MethodService(ILogger<MethodService> logger)
        {
            _logger = logger;
        }
        public void ReadLocation(ref Button button1)
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
        public void WriteToSecrets(ref TextBox textBox1,ref TrackBar trackBar1)
        {
            using (StreamWriter streamWriter = new StreamWriter(path, true))
            {
                streamWriter.WriteLine(textBox1.Text + " : " + PasswordGen(trackBar1.Value));
                streamWriter.WriteLine("-----------------------------------------------------");
            }
            File.Encrypt(path);
        }
        private string PasswordGen(int n = 25)
        {
            try
            {
                int elementsLength = elements.Length;
                StringBuilder pass = new StringBuilder(n);
                for (int i = 0; i < n; i++)
                {
                    pass.Append(elements[random.Next(elementsLength)]);
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
        public void WritePath(ref Button button1, ref FolderBrowserDialog folderBrowserDialog1)
        {
            using (StreamWriter sw = new StreamWriter(@"..\..\loc.txt", false))
            {
                path = folderBrowserDialog1.SelectedPath;
                sw.WriteLine(path + @"\secrets.txt");
            }
            button1.Enabled = true;
        }
    }

}
