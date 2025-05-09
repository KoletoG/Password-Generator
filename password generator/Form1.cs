﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Microsoft.Extensions.Logging;

namespace password_generator
{
    public partial class Form1 : Form
    {
        private IMethodService methodService;
        private Logger<Form1> _logger;
        public Form1(Logger<Form1> logger, IMethodService _methodService)
        {
            InitializeComponent();
            _logger = logger;
            methodService = _methodService;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
               methodService.ReadLocation(ref button1);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                methodService.WriteToSecrets(ref textBox1,ref trackBar1);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {
                    methodService.WritePath(ref button1,ref folderBrowserDialog1);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }
        }
        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }
    }
}
