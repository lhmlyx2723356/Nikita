using System;
using System.Windows.Forms;

namespace Nikita.WinForm.ExtendControl
{
    internal class DummyControl : Control
    {
        public DummyControl()
        {
            SetStyle(ControlStyles.Selectable, false);
        }
    }
}