using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Nikita.WinForm.ExtendControl
{
    public class RibbonOrbDropDownEventArgs
        : RibbonRenderEventArgs
    {
        #region Fields
        private RibbonOrbDropDown _dropDown;
        #endregion

        #region Ctor
        public RibbonOrbDropDownEventArgs(Ribbon ribbon, RibbonOrbDropDown dropDown, Graphics g, Rectangle clip)
            : base(ribbon, g, clip)
        {
            _dropDown = dropDown;
        }
        #endregion

        #region Props
        /// <summary>
        /// Gets the RibbonOrbDropDown related to the event
        /// </summary>
        public RibbonOrbDropDown RibbonOrbDropDown
        {
            get { return _dropDown; }
        }

        #endregion
    }
}
