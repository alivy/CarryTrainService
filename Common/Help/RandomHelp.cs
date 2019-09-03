using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Help
{
    public class RandomHelp
    {

        /// <summary>
        /// 生成指定长度数字字符串
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string GetRandomNumByLength(int length)
        {
            string res = string.Empty;
            if (length <= 0)
                return res;
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                int num = rd.Next(0, 9);
                res += num.ToString();
            }
            return res;
        }
     
    }
}
