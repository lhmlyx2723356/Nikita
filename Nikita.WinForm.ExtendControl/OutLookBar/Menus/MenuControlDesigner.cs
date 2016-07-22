
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Nikita.WinForm.ExtendControl.Menus
{
	public class MenuControlDesigner :  System.Windows.Forms.Design.ParentControlDesigner
	{
		public override ICollection AssociatedComponents
		{
			get 
			{
				if (base.Control is Nikita.WinForm.ExtendControl.Menus.MenuControl)
					return ((Nikita.WinForm.ExtendControl.Menus.MenuControl)base.Control).MenuCommands;
				else
					return base.AssociatedComponents;
			}
		}

		protected override bool DrawGrid
		{
			get { return false; }
		}
	}
}
