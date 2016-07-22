using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Z.IconLibrary.Fugue;

namespace Nikita.Assist.IconLibarary.Web
{
    public partial class index : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.AddIconStyleSheet();
            PageExtensions.AddIconStyleSheet(this);

            if (!Page.IsPostBack)
            {
                //uiCssClass16.CssClass = Icon.AcceptButton.GetCssClass16(); // required web.config setup
                //uiCssClass32.CssClass = Icon.AcceptButton.GetCssClass32(); // required web.config setup

                //uiUrl16.ImageUrl = Icon.AcceptButton.GetUrl16(); // required web.config setup
                //uiUrl32.ImageUrl = Icon.AcceptButton.GetUrl32(); // required web.config setup

                //uiWebResourceUrl16.ImageUrl = Icon.AcceptButton.GetWebResourceUrl16(); // no requirement
                //uiWebResourceUrl32.ImageUrl = Icon.AcceptButton.GetWebResourceUrl32(); // no requirement

                //IEnumerable<Icon> values = Enum.GetValues(typeof(Icon)).Cast<Icon>().ToList().Take(100);

                //uiCssClass16.CssClass = IconExtensions.GetCssClass16(Icon.AcceptButton); // required web.config setup
                //uiCssClass32.CssClass = IconExtensions.GetCssClass32(Icon.AcceptButton); // required web.config setup

                //uiUrl16.ImageUrl = IconExtensions.GetUrl16(Icon.AcceptButton); // required web.config setup
                //uiUrl32.ImageUrl = IconExtensions.GetUrl32(Icon.AcceptButton); // required web.config setup

                //uiWebResourceUrl16.ImageUrl = IconExtensions.GetWebResourceUrl16(Icon.AcceptButton); // no requirement
                //uiWebResourceUrl32.ImageUrl = IconExtensions.GetWebResourceUrl32(Icon.AcceptButton); // no requirement

                //uiCssClass16.CssClass = Icon.Accept.GetCssClass(); // required web.config setup
                //uiUrl16.ImageUrl = Icon.Accept.GetUrl(); // required web.config setup
                //uiWebResourceUrl16.ImageUrl = Icon.Accept.GetWebResourceUrl(); // no requirement
          
                uiCssClass16.CssClass = IconExtensions.GetCssClass(Z.IconLibrary.Fugue.Icon.Acorn); // required web.config setup
                uiUrl16.ImageUrl = IconExtensions.GetUrl(Z.IconLibrary.Fugue.Icon.Acorn); // required web.config setup
                uiWebResourceUrl16.ImageUrl = IconExtensions.GetWebResourceUrl(Z.IconLibrary.Fugue.Icon.Acorn); // no requirement

                //uiCssClass16.CssClass = IconExtensions.GetCssClass16(Icon.AcceptButton); // required web.config setup
                //uiUrl16.ImageUrl = IconExtensions.GetUrl16(Icon.AcceptButton); // required web.config setup
                //uiWebResourceUrl16.ImageUrl = IconExtensions.GetWebResourceUrl16(Icon.AcceptButton); // no requirement




                IEnumerable<Z.IconLibrary.Fugue.Icon> values = Enum.GetValues(typeof(Z.IconLibrary.Fugue.Icon)).Cast<Z.IconLibrary.Fugue.Icon>().ToList().Take(100);

                //uiCssClass16.CssClass = Icon.AcceptButton.GetCssClass(); // required web.config setup
                //uiUrl16.ImageUrl = Icon.AcceptButton.GetUrl(); // required web.config setup
                //uiWebResourceUrl16.ImageUrl = Icon.AcceptButton.GetWebResourceUrl(); // no requirement

                //uiCssClass16.CssClass = Icon.Accept.GetCssClass(); // required web.config setup
                //uiUrl16.ImageUrl = Icon.Accept.GetUrl(); // required web.config setup
                //uiWebResourceUrl16.ImageUrl = Icon.Accept.GetWebResourceUrl(); // no requirement


                uiIcon.DataSource = values;
                uiIcon.DataBind();
            }

            uiIcon.SelectedIndexChanged += uiIcon_SelectedIndexChanged;
        }

        private void uiIcon_SelectedIndexChanged(object sender, EventArgs e)
        {
            var icon = (Z.IconLibrary.Fugue.Icon)Enum.Parse(typeof(Z.IconLibrary.Fugue.Icon), uiIcon.SelectedValue);

            //uiDynamicCssClass16.CssClass = IconExtensions.GetCssClass16(icon);
            //uiDynamicCssClass32.CssClass = IconExtensions.GetCssClass32(icon);

            //uiDynamicUrl16.ImageUrl = IconExtensions.GetUrl16(icon);
            //uiDynamicUrl32.ImageUrl = IconExtensions.GetUrl32(icon);

            //uiDynamicWebResourceUrl16.ImageUrl = IconExtensions.GetWebResourceUrl16(icon);
            //uiDynamicWebResourceUrl32.ImageUrl = IconExtensions.GetWebResourceUrl32(icon);

            //uiDynamicCssClass16.CssClass = icon.GetCssClass();
            //uiDynamicUrl16.ImageUrl = icon.GetUrl();
            //uiDynamicWebResourceUrl16.ImageUrl = icon.GetWebResourceUrl();

            uiDynamicCssClass16.CssClass = IconExtensions.GetCssClass(icon);
            uiDynamicUrl16.ImageUrl = IconExtensions.GetUrl(icon);
            uiDynamicWebResourceUrl16.ImageUrl = IconExtensions.GetWebResourceUrl(icon);

            //uiDynamicCssClass16.CssClass = icon.GetCssClass();

            //uiDynamicUrl16.ImageUrl = icon.GetUrl();

            //uiDynamicWebResourceUrl16.ImageUrl = icon.GetWebResourceUrl();
        }
    }
}