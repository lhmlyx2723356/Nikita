using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Nikita.Assist.WcfService
{
    public abstract class ThreadHelper
    {
        public static Thread StartThread(ThreadStart tarGet)
        {
            Thread workTicketThread = new Thread(tarGet) { IsBackground = true };
            workTicketThread.SetApartmentState(ApartmentState.STA);

            workTicketThread.Start();
            return workTicketThread;
        }
    }
}