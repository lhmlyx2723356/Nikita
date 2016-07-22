using ICSharpCode.TextEditor.Document;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nikita.Base.Define;

namespace Nikita.Assist.CodeMaker
{
    public partial class FrmPreviewCode : Form
    {
        public FrmPreviewCode()
        {
            InitializeComponent();
        }

        public FrmPreviewCode(CodeType codeType, string strCode)
        {
            InitializeComponent();

            #region 设置高亮显示属性

            txtCode.ShowEOLMarkers = false;
            txtCode.ShowHRuler = false;
            txtCode.ShowInvalidLines = false;
            txtCode.ShowMatchingBracket = true;
            txtCode.ShowSpaces = false;
            txtCode.ShowTabs = false;
            txtCode.ShowVRuler = false;
            txtCode.AllowCaretBeyondEOL = false;
            switch (codeType)
            {
                case CodeType.TSQL:
                    txtCode.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("TSQL");
                    break;

                case CodeType.CSharp:
                    txtCode.Document.HighlightingStrategy = HighlightingStrategyFactory.CreateHighlightingStrategy("C#");
                    break;
            }
            txtCode.Encoding = Encoding.GetEncoding("GB2312");

            txtCode.Text = strCode;

            #endregion 设置高亮显示属性
        }
    }
}