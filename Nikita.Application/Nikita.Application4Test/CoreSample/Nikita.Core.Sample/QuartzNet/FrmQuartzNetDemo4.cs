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
    public partial class FrmQuartzNetDemo4 : Form
    {
        public FrmQuartzNetDemo4()
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

            //Build a trigger that will fire every other minute, between 8am and 5pm, every day:
            ICronTrigger trigger = (ICronTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger3", "group1")
            .WithCronSchedule("0 0/2 8-17 * * ?")
            .ForJob("myJob", "group1")
            .Build();

            //Build a trigger that will fire daily at 10:42 am:
            // we use CronScheduleBuilder's static helper methods here
            trigger = (ICronTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger3", "group1")
            .WithSchedule(CronScheduleBuilder.DailyAtHourAndMinute(10, 42))
            .ForJob(myJob)
            .Build();

            trigger = (ICronTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger3", "group1")
            .WithCronSchedule("0 42 10 * * ?")
            .ForJob("myJob", "group1")
            .Build();


            //Build a trigger that will fire on Wednesdays at 10:42 am, in a TimeZone other than the system's default:
            trigger = (ICronTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger3", "group1")
            .WithSchedule(CronScheduleBuilder
            .WeeklyOnDayAndHourAndMinute(DayOfWeek.Wednesday, 10, 42)
            .InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time")))
            .ForJob(myJob)
            .Build();

            trigger = (ICronTrigger)TriggerBuilder.Create()
            .WithIdentity("trigger3", "group1")
            .WithCronSchedule("0 42 10 ? * WED", x => x
            .InTimeZone(TimeZoneInfo.FindSystemTimeZoneById("Central America Standard Time")))
            .ForJob(myJob)
            .Build();


            //   When building CronTriggers, you specify the misfire instruction as part of the cron schedule (via WithCronSchedule extension method):失败后某人指令
            trigger = (ICronTrigger)TriggerBuilder.Create()
    .WithIdentity("trigger3", "group1")
    .WithCronSchedule("0 0/2 8-17 * * ?", x => x
        .WithMisfireHandlingInstructionFireAndProceed())
    .ForJob("myJob", "group1")
    .Build();  
            sched.ScheduleJob(myJob, trigger);
        }
    }
}
