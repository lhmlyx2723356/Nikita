using System.ComponentModel;

namespace Nikita.WinForm.ExtendControl
{
    public abstract class ThemeBase : Component, ITheme
    {
        public abstract void Apply(DockPanel dockPanel);
    }
}