using System;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars.Helpers;
using System.Windows.Forms;

namespace RibbonReportDesigner {
    public partial class MainForm : RibbonForm {
        public MainForm(bool showAppearancePage) {
            InitializeComponent();
            if(showAppearancePage)
                SkinHelper.InitSkinGallery(ribbonGallerySkins, true);
            else
                this.ribbonControl1.Pages.Remove(appearanceRibbonPage);
        }
        public MainForm()
            : this(true) {
        }

        [STAThread]
        static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
new System.Globalization.CultureInfo("zh-CN");
            System.Threading.Thread.CurrentThread.CurrentUICulture =
            new System.Globalization.CultureInfo("zh-CN");
            DevExpress.UserSkins.BonusSkins.Register();
            Application.Run(new RibbonReportDesigner.MainForm());
        }

        void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e) {
            Close();
        }
        public void OpenReport(DevExpress.XtraReports.UI.XtraReport newReport) {
            xrDesignMdiController1.OpenReport(newReport);
        }
        public void CreateNewReport() {
            xrDesignMdiController1.CreateNewReport();
        }
        public XRDesignPanel ActiveXRDesignPanel {
            get { return xrDesignMdiController1.ActiveDesignPanel; }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }
}
