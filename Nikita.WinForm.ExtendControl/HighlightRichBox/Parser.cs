using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



using System.Xml;
using System.IO;
using System.Collections;
using System.Reflection;
using System.Drawing;
namespace Nikita.WinForm.ExtendControl
{
    class Parser
    {
        private XmlDocument xd = null;
        private ArrayList al = null; //对xml流解析后，会把每一个关键字字符串放入这个容器中
        private bool caseSensitive = false; //记录当前语言大小写敏感否
        private ArrayList cl = null;//对xml流解析后，把每一个C关键字颜色保留



        internal Parser(SyntaxEditor.Languages language) //构造函数接受一个枚举变量
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string filename = "";
            switch (language) //取得xml文件名
            {
                case SyntaxEditor.Languages.CSHARP:
                    filename = "csharp.xml";
                    break;
                case SyntaxEditor.Languages.JSHARP:
                    filename = "jsharp.xml";
                    break;
                case SyntaxEditor.Languages.SQL:
                    filename = "sql.xml";
                    break;
                case SyntaxEditor.Languages.VBSCRIPT:
                    filename = "vbscript.xml";
                    break;
                default:
                    break;
            }

            StreamReader reader = new StreamReader(filename,
        System.Text.Encoding.UTF8
); //下面的代码解析xml流

            xd = new XmlDocument();
            xd.Load(reader);

            al = new ArrayList();
            cl = new ArrayList();
            XmlElement root = xd.DocumentElement;
            XmlNodeList xnl = root.SelectNodes("/definition/word");
            for (int i = 0; i < xnl.Count; i++)
            {
                al.Add(xnl[i].ChildNodes[0].Value); //将关键子收集到al
                cl.Add(xnl[i].Attributes["color"].Value);//收集关键字的颜色

            }
            //检测是否判断大小写
            //this.caseSensitive = bool.Parse(root.Attributes["caseSensitive"].Value);

        }

        public Color IsKeyWord(string word) //判断字符串是否为关键字
        {
            for (int i = 0; i < al.Count; i++)
            {
                if (string.Compare(word, al[i].ToString(), !caseSensitive) == 0)
                {
                    string ColorTemp = (cl[i].ToString() != string.Empty ? cl[i].ToString() : "Black");
                    Color c;
                    try
                    {
                        c = Color.FromName(ColorTemp);
                    }
                    catch (Exception )
                    {
                        c = Color.Black;
                    }
                    return c;
                }
            }
            return Color.Black;
        }
    }
}
