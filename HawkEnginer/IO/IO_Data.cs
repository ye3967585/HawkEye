using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkTools.IO.Data
{
    /// <summary>
    /// 对于即时数据的处理
    /// </summary>
    public class DATA
    {
        /// <summary>
        /// 以空格符为界，删除其左边的所有字符，包空格符本身。
        /// </summary>
        /// <param name="SourceText">源字符串</param>
        /// <param name="CutLenth">删除长度</param>
        /// <returns>处理后的字符串</returns>
        public string CutString(string SourceText, int CutLenth)
        {
            string SubText = SourceText;
            int space = 0; //空格计算
            for (int i = 0; i < SourceText.Length; i++)
            {
                if (SourceText[i] == ' ') //如遇空格，计算空格数量
                {
                    //公式:处理后的字符串=源字符串-删除长度+空格数量
                    ++space;
                    SubText = SourceText.Substring(CutLenth + space);

                }
            }
            return SubText;
        }
    }
}
