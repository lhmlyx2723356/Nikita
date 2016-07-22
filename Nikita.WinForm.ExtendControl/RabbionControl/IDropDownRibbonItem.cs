using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nikita.WinForm.ExtendControl
{
    public interface IDropDownRibbonItem
    {
        Rectangle DropDownButtonBounds { get; }
        bool DropDownButtonPressed { get; }
        bool DropDownButtonSelected { get; }
        bool DropDownButtonVisible { get; }
        RibbonItemCollection DropDownItems { get; }
    }
}