using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace password_generator
{
    public interface IMethodService
    {
        void ReadLocation(Button button1);
        void WriteToSecrets(TextBox textBox1, TrackBar trackBar1);
        void WritePath(Button button1, FolderBrowserDialog folderBrowserDialog1);
    }
}
