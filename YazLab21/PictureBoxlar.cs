using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YazLab21
{
    class PictureBoxlar : System.Windows.Forms.PictureBox
    {
        int index;
        int imageindex;

        public int Index { get => index; set => index = value; }
        public int ImageIndex { get => imageindex; set => imageindex = value; }

        
    }
}
