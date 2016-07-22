using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikita.Core
{
    [DebuggerDisplay("[Time Elapsed] {TimeElapsed} [CPU Cycles] {CPUCycles} [Gen 0] {Generation0} [Gen 1] {Generation1} [Gen 2] {Generation2}")]
    public struct CodeTimerResult
    {
        private readonly ulong _cpuCycles;
        private readonly int _generation0;
        private readonly int _generation1;
        private readonly int _generation2;
        private readonly long _timeElapsed;

        internal CodeTimerResult(long timeElapsed, ulong cpuCycles, int generation0, int generation1, int generation2)
        {
            this._timeElapsed = timeElapsed;
            this._cpuCycles = cpuCycles;
            this._generation0 = generation0;
            this._generation1 = generation1;
            this._generation2 = generation2;
        }

        public ulong CpuCycles
        {
            get { return _cpuCycles; }
        }

        public int Generation0
        {
            get { return _generation0; }
        }

        public int Generation1
        {
            get { return _generation1; }
        }

        public int Generation2
        {
            get { return _generation2; }
        }

        public long TimeElapsed
        {
            get { return _timeElapsed; }
        }

        public override string ToString()
        {
            return String.Concat(
                "[Time Elapsed]\t", this._timeElapsed.ToString(), " ms",
                "[CPU Cycles]\t", this._cpuCycles.ToString(),
                "[Gen 0]\t", this._generation0.ToString(),
                "[Gen 1]\t", this._generation1.ToString(),
                "[Gen 2]\t", this._generation2.ToString());
        }
    }
}