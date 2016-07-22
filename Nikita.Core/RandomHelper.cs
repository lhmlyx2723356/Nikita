//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//-----------------------------------------------------------------

using System;

namespace Nikita.Core
{
    /// <summary>
    /// 产生随机数
    /// </summary>
    public class BaseRandom
    {
        public static int Maximal = 999999;
        public static int Minimum = 100000;
        public static int RandomLength = 6;

        private const string RandomString = "123456789ABCDEFGHIJKMLNPQRSTUVWXYZ";
        private static readonly Random Random = new Random(DateTime.Now.Second);

        #region public static string GetRandomString() 产生随机字符

        /// <summary>
        /// 产生随机字符
        /// </summary>
        /// <returns>字符串</returns>
        public static string GetRandomString()
        {
            string returnValue = string.Empty;
            for (int i = 0; i < RandomLength; i++)
            {
                int r = Random.Next(0, RandomString.Length - 1);
                returnValue += RandomString[r];
            }
            return returnValue;
        }

        #endregion public static string GetRandomString() 产生随机字符

        #region public static int GetRandom()

        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <returns>随机数</returns>
        public static int GetRandom()
        {
            return Random.Next(Minimum, Maximal);
        }

        #endregion public static int GetRandom()

        #region public static int GetRandom(int minimum, int maximal)

        /// <summary>
        /// 产生随机数
        /// </summary>
        /// <param name="minimum">最小值</param>
        /// <param name="maximal">最大值</param>
        /// <returns>随机数</returns>
        public static int GetRandom(int minimum, int maximal)
        {
            return Random.Next(minimum, maximal);
        }

        #endregion public static int GetRandom(int minimum, int maximal)
    }
}