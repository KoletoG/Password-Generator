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
        void ReadLocation(ref Button button1);
        void WriteToSecrets(ref TextBox textBox1, ref TrackBar trackBar1);
        void WritePath(ref Button button1, ref FolderBrowserDialog folderBrowserDialog1);
    }
}
