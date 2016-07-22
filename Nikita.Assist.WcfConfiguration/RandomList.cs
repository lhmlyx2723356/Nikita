using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nikita.Assist.WcfConfiguration
{
    public class RandomList
    {
        public static void Random(ref List<string> lstInfo)
        {
            Random ran = new Random();
            int k = 0;
            string strtmp = "";
            for (int i = 0; i < lstInfo.Count; i++)
            { 
                k = ran.Next(0, 20);
                if (k != i)
                {
                    strtmp = lstInfo[i];
                    lstInfo[i] = lstInfo[k];
                    lstInfo[k] = strtmp;
                }
            } 
        }
    }
}
