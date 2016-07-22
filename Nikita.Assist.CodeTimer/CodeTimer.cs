using Nikita.Core;
using System;
using System.Text;
using System.Windows.Forms;

namespace Nikita.Assist.CodeTimer
{
    public partial class CodeTimer : Form
    {
        private readonly Core.CodeTimer _timer = new Core.CodeTimer();

        public CodeTimer()
        {
            InitializeComponent();
        }

        public void DoTest()
        {
            string s = "";
            s += "a";
        }

        public void DoTest1()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("a");
        }

        private void btnDoIt_Click(object sender, EventArgs e)
        {
            _timer.Initialize();
            //执行次数
            const int iteration = 100 * 1000;
            CodeTimerResult result = _timer.Time(iteration, DoTest);
            CodeTimerResult result1 = _timer.Time(iteration, DoTest1);
            txtResult.Text =
                @"执行方法:DoTest" + Environment.NewLine +
                @"消耗时间:" + result.TimeElapsed + @"ms" + Environment.NewLine +
                @"CPU时钟周期:" + result.CpuCycles + Environment.NewLine +
                @"垃圾收集回收次数:" + result.Generation0 + @"," + result.Generation1 +
 @"," + result.Generation2
 + Environment.NewLine + Environment.NewLine +
                @"执行方法:DoTest1" + Environment.NewLine +
                 @"消耗时间:" + result.TimeElapsed + @"ms" + Environment.NewLine +
                 @"CPU时钟周期:" + result1.CpuCycles + Environment.NewLine +
                 @"垃圾收集回收次数:" + result1.Generation0 + @"," + result.Generation1 +
@"," + result1.Generation2;
        }
    }
}