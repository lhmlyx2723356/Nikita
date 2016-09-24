using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using HtmlAgilityPack;
using Nikita.WinForm.ExtendControl;
using WeifenLuo.WinFormsUI.Docking;

namespace Nikita.Core.Sample
{
    public partial class FrmHtmlAgilityPackTest : DockContentEx
    {
        public FrmHtmlAgilityPackTest()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string content = getContent();
            //HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument(); 
            //document.LoadHtml(content ); 
            HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
            document.Load(Application.StartupPath+"\\cnblogs.html",Encoding.Default);
            HtmlNode node = document.GetElementbyId("post_list");
            foreach (HtmlNode child in node.ChildNodes)
            {
                if (child.Attributes["class"] == null || child.Attributes["class"].Value != "post_item")
                    continue;
                HtmlNode hn = HtmlNode.CreateNode(child.OuterHtml);

                string msg = Encoding.Default.GetString(Encoding.Default.GetBytes(hn.SelectSingleNode("//*[@class=\"titlelnk\"]").InnerText.Trim()));

                listBox1.Items.Add(msg);

            }
        }

        private string getContent()
        {

              WebClient MyWebClient = new WebClient();

        
        MyWebClient.Credentials = CredentialCache.DefaultCredentials;//获取或设置用于向Internet资源的请求进行身份验证的网络凭据

        Byte[] pageData = MyWebClient.DownloadData("http://www.cnblogs.com/"); //从指定网站下载数据

        //  string pageHtml = Encoding.Default.GetString(pageData);  //如果获取网站页面采用的是GB2312，则使用这句            

          string pageHtml = Encoding.UTF8.GetString(pageData); //如果获取网站页面采用的是UTF-8，则使用这句
            
            return pageHtml;
        }
    }
}
