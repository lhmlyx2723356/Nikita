using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.FileLoader
{
    public partial class FrmImagePreview : Form
    {
        public FrmImagePreview()
        {
            InitializeComponent();
        }

        public FrmImagePreview(string imgPath)
        {
            InitializeComponent();
            kpImageViewer1.ImagePath = imgPath; 
        }
    }
}
