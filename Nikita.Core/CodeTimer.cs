using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Nikita.Core
{
    /// <summary>
    /// ref from http://www.cnblogs.com/jeffreyzhao/archive/2009/03/10/codetimer.html
    /// </summary>
    public sealed class CodeTimer : IDisposable
    {
        private ProcessPriorityClass _cachedProcessPriorityClass;
        private ThreadPriority _cachedThreadPriority;
        private bool _isCachedStatus;

        public void Dispose()
        {
            if (this._isCachedStatus)
            {
                Process.GetCurrentProcess().PriorityClass = _cachedProcessPriorityClass;
                Thread.CurrentThread.Priority = _cachedThreadPriority;
                this._isCachedStatus = false;
            }
        }

        public void Initialize()
        {
            _cachedProcessPriorityClass = Process.GetCurrentProcess().PriorityClass;
            _cachedThreadPriority = Thread.CurrentThread.Priority;

            Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            _isCachedStatus = true;

            Time(1, () => { });
        }

        public CodeTimerResult Time(int iteration, Action action)
        {
            // 1.
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced);
            var gcCounts = new int[GC.MaxGeneration + 1];
            for (var i = 0; i <= GC.MaxGeneration; i++)
            {
                gcCounts[i] = GC.CollectionCount(i);
            }

            // 2.
            var watch = new Stopwatch();
            watch.Start();
            var cycleCount = GetCycleCount();
            for (var i = 0; i < iteration; i++) action();
            var cpuCycles = GetCycleCount() - cycleCount;
            watch.Stop();

            var gens = new[] { 0, 0, 0 };

            for (var i = 0; i < 3; i++)
            {
                if (i <= GC.MaxGeneration)
                {
                    gens[i] = GC.CollectionCount(i) - gcCounts[i];
                }
            }

            return new CodeTimerResult(watch.ElapsedMilliseconds, cpuCycles, gens[0], gens[1], gens[2]);
        }

        [DllImport("kernel32.dll")]
        private static extern IntPtr GetCurrentThread();

        private static ulong GetCycleCount()
        {
            ulong cycleCount = 0;
            QueryThreadCycleTime(GetCurrentThread(), ref cycleCount);
            return cycleCount;
        }

        [DllImport("kernel32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool QueryThreadCycleTime(IntPtr threadHandle, ref ulong cycleTime);
    }
}