using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    internal class RibbonWrappedDropDown
        : ToolStripDropDown
    {
        public RibbonWrappedDropDown()
            : base()
        {
            DoubleBuffered = false;
            SetStyle(ControlStyles.Opaque, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.Selectable, false);
            SetStyle(ControlStyles.ResizeRedraw, false);
            AutoSize = false;
        }
    }
}
