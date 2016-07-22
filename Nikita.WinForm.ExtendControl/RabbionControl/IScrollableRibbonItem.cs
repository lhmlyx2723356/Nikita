/*

 *
 * Please give me credit if you use this code. It's all I ask.
 *
 * Contact me for more info: menendezpoo@gmail.com
 *
 */

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// Implemented by Ribbon items that has scrollable content
    /// </summary>
    public interface IScrollableRibbonItem
    {
        /// <summary>
        /// Gets the bounds of the content (without scrolling controls)
        /// </summary>
        Rectangle ContentBounds { get; }

        /// <summary>
        /// Scrolls the content down
        /// </summary>
        void ScrollDown();

        /// <summary>
        /// Scrolls the content up
        /// </summary>
        void ScrollUp();
    }
}