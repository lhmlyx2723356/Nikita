using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nikita.Core
{
    public class ThreadHelperTest
    {
        //    /// <summary>
        //    /// 线程帮助类使用范例 http://www.cnblogs.com/loncin/p/4223889.html
        //    /// </summary>
        //    private ThreadHelper threadHelper;

        //    public void Test()
        //    {
        //        // 开启方法方法并行执行
        //        int funcCount = 5;

        //        this.threadHelper = new ThreadHelper(funcCount);

        //        for (int i = 0; i < funcCount; i++)
        //        {
        //            Action<int> action = new Action<int>(TestFunc);
        //            action.BeginInvoke(i, null, null);
        //        }

        //        // 等待方法执行，超时时间12ms，12ms后强制结束
        //        threadHelper.WaitAll(12);

        //        Console.WriteLine("所有方法执行完毕！");
        //    }

        //    private void TestFunc(int i)
        //    {
        //        try
        //        {
        //            Console.WriteLine("方法{0}执行！");
        //            Thread.Sleep(10);
        //        }
        //        finally
        //        {
        //            // 方法执行结束
        //            this.threadHelper.SetOne();
        //        }
        //    }
        //}
        public class ThreadHelper
        {
            /// <summary>
            /// 总线程数
            /// </summary>
            private readonly int _totalThreadCount;

            /// <summary>
            /// 当前执行完毕线程数
            /// </summary>
            private int _currThreadCount;

            /// <summary>
            /// 构造函数
            /// </summary>
            /// <param name="totalThreadCount">总线程数</param>
            public ThreadHelper(int totalThreadCount)
            {
                Interlocked.Exchange(ref this._totalThreadCount, totalThreadCount);
                Interlocked.Exchange(ref this._currThreadCount, 0);
            }

            /// <summary>
            /// 设置信号量，表示单线程执行完毕
            /// </summary>
            public void SetOne()
            {
                Interlocked.Increment(ref this._currThreadCount);
            }

            /// <summary>
            /// 等待所有线程执行完毕
            /// </summary>
            /// <param name="overMiniseconds">超时时间（毫秒）</param>
            public void WaitAll(int overMiniseconds = 0)
            {
                int checkCount = 0;

                // 自旋
                while (Interlocked.CompareExchange(ref this._currThreadCount, 0, this._totalThreadCount) !=
                       this._totalThreadCount)
                {
                    // 超过超时时间返回
                    if (overMiniseconds > 0)
                    {
                        if (checkCount >= overMiniseconds)
                        {
                            break;
                        }
                    }

                    checkCount++;

                    Thread.Sleep(1);
                }
            }
        }
    }
}