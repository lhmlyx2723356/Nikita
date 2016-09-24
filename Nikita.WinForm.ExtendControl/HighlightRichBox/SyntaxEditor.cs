using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using System.Collections;
using System.Runtime.InteropServices;
using HWND = System.IntPtr;
namespace Nikita.WinForm.ExtendControl
{
    public partial class SyntaxEditor : System.Windows.Forms.RichTextBox
    {

        /// <summary> 
        /// 必需的设计器变量。

        /// </summary>
        private System.ComponentModel.Container components = null;
        int line;
        private Parser parser;
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        //使用win32api：SendMessage来防止控件着色时的闪烁现象
        [DllImport("user32")]
        private static extern int SendMessage(HWND hwnd, int wMsg, int wParam, IntPtr lParam);
        private const int WM_SETREDRAW = 0xB;
        public SyntaxEditor()
        {
            // 该调用是 Windows.Forms 窗体设计器所必需的。
            InitializeComponent();
            base.WordWrap = false;
        }
        // TODO: 在 InitComponent 调用后添加任何初始化
        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region 组件设计器生成的代码
        /// <summary>
        /// 设计器支持所需的方法 - 不要使用代码编辑器 
        /// 修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.Name = "SyntaxEditor";
        }
        #endregion
        //重写基类的OnTextChanged方法。为了提高效率，程序是对当前文本插入点所在行进行扫描，
        //以空格为分割符，判断每个单词是否为关键字，并进行着色。
        protected override void OnTextChanged(EventArgs e)
        {
            if (base.Text != "")
            {
                
                int selectStart = base.SelectionStart;
                 line = base.GetLineFromCharIndex(selectStart);
                 //line = base.Text.Split('\n').Length-1;
                string lineStr = base.Lines[line];
                int linestart = 0;
                for (int i = 0; i < line; i++)
                {
                    linestart += base.Lines[i].Length + 1;
                }

                 SendMessage(base.Handle, WM_SETREDRAW, 0, IntPtr.Zero);

                base.SelectionStart = linestart;
                base.SelectionLength = lineStr.Length;
                base.SelectionColor = Color.Black;
                base.SelectionStart = selectStart;
                base.SelectionLength = 0;


                parser = new Parser(this.language);


                //对一行字符串用空格或者.分开
                string[] words = lineStr.Split(new char[] { ' ', '.', '\n', '(', ')', '}', '{', '"', '[', ']' });
                for (int i = 0; i < words.Length; i++)//一个字符段一个字符段来判断
                {

                    //判断是否是程序保留字 是的话高亮显示
                    if (parser.IsKeyWord(words[i]) != Color.Empty)
                    {
                        int length = 0;
                        for (int j = 0; j < i; j++)
                        {
                            length += words[j].Length;
                        }
                        length += i;
                        int index = lineStr.IndexOf(words[i], length);


                        base.SelectionStart = linestart + index;
                        base.SelectionLength = words[i].Length;
                        //base.SelectionFont
                        base.SelectionColor = parser.IsKeyWord(words[i]);


                        base.SelectionStart = selectStart;
                        base.SelectionLength = 0;
                        base.SelectionColor = Color.Black;
                    }


                }
                SendMessage(base.Handle, WM_SETREDRAW, 1, IntPtr.Zero);
                base.Refresh();
            }
            base.OnTextChanged(e);

        }

        public new bool WordWrap
        {
            get { return base.WordWrap; }
            set { base.WordWrap = value; }
        }

        public enum Languages
        {
            SQL,
            VBSCRIPT,
            CSHARP,
            JSHARP
        }

        private Languages language = Languages.CSHARP;

        public Languages Language
        {
            get { return this.language; }
            set { this.language = value; }
        }



    }
}
