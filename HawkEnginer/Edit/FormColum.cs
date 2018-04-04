
/*********************************************************************************************************
 * Hawk Enginer - Edit 进度条 V0.01  
 * By ChihHuCheYeh
 * 此类继承于HawkEnginer.IO中的Text类，可以定制长度，色彩，表头，表列的表列窗体。
 *********************************************************************************************************/

using HawkEnginer.IO;
using System;

namespace HawkEnginer.Edit
{
    /// <summary>
    /// 表列窗体
    /// </summary>
    public class FormColum : Text
    {
        /// <summary>
        /// 无表头窗体
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Count">标题栏长度</param>
        /// <param name="Speed">显示速度</param>
        /// <param name="color">颜色</param>
        public void ShowSimpleFormColumn(string Title, int Count, int Speed, ConsoleColor color = ConsoleColor.White)
        {
            /*********** 行1：标题栏头***********/
            Console.Write(" ");
            for (int i = 0; i < Count; i++)
            {
                OutPutColorText("-", color, ConsoleColor.Black, Speed);
            }
            /*********** 行2：标题文本 ***********/
            OutPutColorText("\n" + Title, color, ConsoleColor.Black, Speed, true, Count);

            /*********** 行3：标题栏尾***********/
            Console.Write(" ");
            for (int i = 0; i < Count; i++)
            {
                OutPutColorText("-", color, ConsoleColor.Black, Speed);
            }
        }
        /// <summary>
        /// 有表头窗体
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Count">标题栏长度</param>
        /// <param name="Speed">显示速度</param>
        /// <param name="H_1">表头1</param>
        /// <param name="H_2">表头2</param>
        /// <param name="H_3">表头3</param>
        /// <param name="H_4">表头4</param>
        /// <param name="H_5">表头5</param>
        /// <param name="H_6">表头6</param>
        /// <param name="H_7">表头7</param>
        /// <param name="H_8">表头8</param>
        /// <param name="color">颜色</param>
        public void ShowRichFormColumn(
            string Title, int Count, int Speed,
            /******** 表头 ********/
            string H_1 = null,
            string H_2 = null,
            string H_3 = null,
            string H_4 = null,
            string H_5 = null,
            string H_6 = null,
            string H_7 = null,
            string H_8 = null,
            ConsoleColor color = ConsoleColor.White)
        {
            /*********** 行1：标题栏***********/
            ShowSimpleFormColumn(Title, Count, Speed, color);
            /*********** 行2：标题栏***********/
            OutPutColorText("\n" + H_1 + "   " + H_2 + "    " + H_3 + "    " + H_4 + "    " + H_5 + "    " + H_6 + "    " + H_7 + "    " + H_8 + "    \n", color, ConsoleColor.Black, Speed);
        }
    }
}
