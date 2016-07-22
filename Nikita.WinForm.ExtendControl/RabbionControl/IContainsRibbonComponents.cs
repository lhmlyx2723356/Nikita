/*

 *
 * Please give me credit if you use this code. It's all I ask.
 *
 * Contact me for more info: menendezpoo@gmail.com
 *
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Nikita.WinForm.ExtendControl
{
    /// <summary>
    /// Used to extract all child components from RibbonItem objects
    /// </summary>
    public interface IContainsRibbonComponents
    {
        IEnumerable<Component> GetAllChildComponents();
    }
}