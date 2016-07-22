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
    /// Exposes GetItems, to indicate that the type contains a collection of RibbonItems
    /// </summary>
    public interface IContainsSelectableRibbonItems
    {
        /// <summary>
        /// When implemented, must return the bounds of the content where items are displayed
        /// </summary>
        /// <returns></returns>
        Rectangle GetContentBounds();

        /// <summary>
        /// When implemented, must return an  enumerator to acces the items inside the type
        /// </summary>
        IEnumerable<RibbonItem> GetItems();
    }
}