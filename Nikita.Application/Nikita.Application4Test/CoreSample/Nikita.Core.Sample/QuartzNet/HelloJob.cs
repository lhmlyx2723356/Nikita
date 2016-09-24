using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;

namespace Nikita.Core.Sample 
{
  public   class HelloJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            MessageBox.Show("Greetings from HelloJob!");
        }
    }
}
