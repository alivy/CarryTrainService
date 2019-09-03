using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Help
{
    public static class ExtendedCategory
    {
        /// <summary>
        /// 除去12306回调，返回json格式数据
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CallBackJson(this string str)
        {
            int IndexofA = str.IndexOf("{");
            int IndexofB = str.IndexOf("}");
            string resStr = str.Substring(IndexofA, IndexofB - IndexofA + 1);
            return resStr;
        }
    }
}
