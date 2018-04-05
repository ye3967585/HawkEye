using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HawkEngine.IO
{
    /// <summary>
    /// 对于即时数据的处理
    /// </summary>
    public class DATA
    {
        /// <summary>
        /// 以标识符或空格符为界，删除其左边的所有字符，包括标识符与空格符本身。
        /// </summary>
        /// <param name="SourceText">源字符串</param>
        /// <param name="CutLenth">删除长度</param>
        /// <param name="id">标识符</param>
        /// <returns>处理后的字符串</returns>
        public string CutString(string SourceText,int CutLenth,string id=null)
        {
            string SubText=SourceText;
            int space = 0; //空格计算
            for (int i = 0; i < SourceText.Length; i++)
            {
                if (id != null) //如果用户指定了标识符，则在原有的删除空格的基础上也删除标识符，只留下标识符右侧的字符串。
                {
                    //公式:处理后的字符串=源字符串-删除长度+空格数量+标识符长度-1
                    SubText = SourceText.Substring(CutLenth +space+id.Length+1);
                }
                else if (SourceText[i]==' ') //如遇空格，计算空格数量
                {
                    //公式:处理后的字符串=源字符串-删除长度+空格数量
                    ++space;
                    SubText = SourceText.Substring(CutLenth+space);
                    
                }
            }
            return SubText;
        }
    }
}
