/*
 

 * 
 * Please give me credit if you use this code. It's all I ask.
 * 
 * Contact me for more info: menendezpoo@gmail.com
 * 
 */

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
    public class RibbonItemRenderEventArgs : RibbonRenderEventArgs
    {
        private RibbonItem _item;

        public RibbonItemRenderEventArgs(Ribbon owner, Graphics g, Rectangle clip, RibbonItem item)
            : base(owner, g, clip)
        {
            Item = item;
        }

        public RibbonItem Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;
            }
        }
    }
}
