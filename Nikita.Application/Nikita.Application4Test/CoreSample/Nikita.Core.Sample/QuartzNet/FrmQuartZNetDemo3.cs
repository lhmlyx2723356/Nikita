using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Quartz;
using Quartz.Impl;

namespace Nikita.Core.Sample
{
    public partial class FrmQuartZNetDemo3 : Form
    {
        public FrmQuartZNetDemo3()
        {
            InitializeComponent();
        }

        private void btnTest1_Click(object sender, EventArgs e)
        {
            // construct a scheduler factory
            ISchedulerFactory schedFact = new StdSchedulerFactory();
            // get a scheduler
            IScheduler sched = schedFact.GetScheduler();

            IJobDetail myJob = JobBuilder.Create<HelloJob>()
            .WithIdentity("myJob", "group1")
            .Build();

            // trigger builder creates simple trigger by default, actually an ITrigger is returned
            ISimpleTrigger trigger = (ISimpleTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger1", "group1")
            .StartAt(DateTime.UtcNow) // some Date 
            .ForJob("job1", "group1") // identify job with name, group strings
            .Build();

            //Build a trigger for a specific moment in time, then repeating every ten seconds ten times:

            trigger = (ISimpleTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger3", "group1")
            .StartAt(new DateTime(2015, 6, 9, 21, 55, 0)) // if a start time is not given (if this line were omitted), "now" is implied
            .WithSimpleSchedule(x => x
            .WithIntervalInSeconds(10)
            .WithRepeatCount(10)) // note that 10 repeats will give a total of 11 firings
            .ForJob(myJob) // identify job with handle to its JobDetail itself                   
            .Build();

            //Build a trigger that will fire once, five minutes in the future:
            trigger = (ISimpleTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger5", "group1")
            .StartAt(DateBuilder.FutureDate(5, IntervalUnit.Minute)) // use DateBuilder to create a date in the future
            .ForJob(myJob) // identify job with its JobKey
            .Build();

            //  Build a trigger that will fire now, then repeat every five minutes, until the hour 22:00:
            trigger = (ISimpleTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger7", "group1")
            .WithSimpleSchedule(x => x
            .WithIntervalInMinutes(5)
            .RepeatForever())
            .EndAt(DateBuilder.DateOf(22, 0, 0))
            .Build();


            //  Build a trigger that will fire at the top of the next hour, then repeat every 2 hours, forever:
            trigger = (ISimpleTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger8") // because group is not specified, "trigger8" will be in the default group
            .StartAt(DateBuilder.EvenHourDate(null)) // get the next even-hour (minutes and seconds zero ("00:00"))
            .WithSimpleSchedule(x => x
            .WithIntervalInHours(2)
            .RepeatForever())
                // note that in this example, 'forJob(..)' is not called 
                //  - which is valid if the trigger is passed to the scheduler along with the job  
            .Build();



            //  When building SimpleTriggers, you specify the misfire instruction as part of the simple schedule (via SimpleSchedulerBuilder):失败后某人指令
            trigger = (ISimpleTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger7", "group1")
            .WithSimpleSchedule(x => x
            .WithIntervalInMinutes(5)
            .RepeatForever()
            .WithMisfireHandlingInstructionNextWithExistingCount())
            .Build();

            sched.ScheduleJob(myJob, trigger);
        }
    }
}
