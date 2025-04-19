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
        /// <summary>
        /// Reads file location and if it exists -> enables button1
        /// </summary>
        /// <param name="button1">Button for creating the password</param>
        public void ReadLocation(Button button1)
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
        /// <summary>
        /// Saves the password in 'secrets.txt'
        /// </summary>
        /// <param name="textBox1">For password usage</param>
        /// <param name="trackBar1">How big should the password be</param>
        public void WriteToSecrets(TextBox textBox1, TrackBar trackBar1)
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
                _logger.LogError(ex.ToString());
            }
        }
        /// <summary>
        /// Generates password
        /// </summary>
        /// <param name="n">Gets desired password length</param>
        /// <returns>Password</returns>
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
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
        /// <summary>
        /// Sets the path for secrets.txt
        /// </summary>
        /// <param name="button1">Button for password generation</param>
        /// <param name="folderBrowserDialog1">Gets the path for the secrets.txt</param>
        public void WritePath(Button button1, FolderBrowserDialog folderBrowserDialog1)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(@"..\..\loc.txt", false))
                {
                    path = folderBrowserDialog1.SelectedPath;
                    sw.WriteLine(folderBrowserDialog1.SelectedPath + @"\secrets.txt");
                }
                button1.Enabled = true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw ex;
            }
        }
    }
}
