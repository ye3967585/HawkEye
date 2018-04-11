
/*********************************************************************************************************
 * Hawk Enginer - Edit 进度条 V0.01  
 * By ChihHuCheYeh
 * 此类继承于HawkEnginer.IO中的Text类，可以定制长度，色彩，表头，表列的表列窗体。
 *********************************************************************************************************/

using HawkEngine.IO;
using System;

namespace HawkEngine.Edit
{
    /// <summary>
    /// 表列窗体
    /// </summary>
    public class FormColum : TEXT
    {
        #region 低级窗体
        /// <summary>
        /// 无表头镂空窗体
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Count">标题栏长度</param>
        /// <param name="Speed">显示速度</param>
        /// <param name="color">颜色</param>
        public void ShowSimpleHollowFormColumn(string Title, int Count, int Speed, ConsoleColor color = ConsoleColor.White)
        {
            /*********** 标题栏***********/
            Console.Write(" ");
            for (int i = 0; i < Count; i++)
            {
                OutPutColorText("=", color, ConsoleColor.Black, Speed);
            }
            /*********** 标题文本 ***********/
            OutPutColorText("\n |" + Title, color, ConsoleColor.Black, Speed, true, Count);

            Console.Write(" ");
            for (int i = 0; i < Count; i++)
            {
                OutPutColorText("=", color, ConsoleColor.Black, Speed);
            }
        }
        /// <summary>
        /// 有表头镂空窗体
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
        public void ShowRichHollowFormColumn(string Title, int Count, int Speed, ConsoleColor color = ConsoleColor.White, string H_1 = null, string H_2 = null, string H_3 = null, string H_4 = null, string H_5 = null, string H_6 = null, string H_7 = null, string H_8 = null)
        {
            /*********** 标题栏***********/
            ShowSimpleHollowFormColumn(Title, Count, Speed, color);
            /*********** 表头栏***********/
            OutPutColorText("\n" + H_1 + "   " + H_2 + "    " + H_3 + "    " + H_4 + "    " + H_5 + "    " + H_6 + "    " + H_7 + "    " + H_8 + "    \n", color, ConsoleColor.Black, Speed);
        }
        /// <summary>
        /// 无表头实心窗体
        /// P.S. Count.Length=Title.Length
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Count">标题栏长度</param>
        /// <param name="Speed">显示速度</param>
        /// <param name="ForegroundColor">前景色</param>
        /// <param name="BackgroundColor">背景色</param>
        public void ShowSimpleSolidFormColumn(string Title, int Count, int Speed, ConsoleColor ForegroundColor = ConsoleColor.Green, ConsoleColor BackgroundColor = ConsoleColor.White)
        {
            /*********** 标题栏 ***********/
            Console.Write(" ");
            OutPutColorText(" ", ForegroundColor, BackgroundColor, Speed);   //输出标题
            OutPutColorText(Title, ForegroundColor, BackgroundColor, Speed); //输出标题
            /*** 以下操作是为了防止标题的长度与实际的长度叠加，导致实际长度与传入Count参数的长度不符 ***/
            for (int j = 0; j < Count - Title.Length; j++) //根据标题栏的长度与标题文本的长度，补差值，直到总体长度和Count参数的值相同
            {
                //输出补充的长度背景
                OutPutColorText(" ", ForegroundColor, BackgroundColor, Speed);
            }
        }
        /// <summary>
        /// 有表头实心窗体
        /// P.S. Count.Length=Title.Length
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Count">标题栏长度</param>
        /// <param name="Speed">显示速度</param>
        /// <param name="TextForegroundColor">文本前景色</param>
        /// <param name="TextBackgroundColor">文本背景色</param>
        /// <param name="ColumForegroundColor">表头前景色</param>
        /// <param name="ColumBackgroundColor">表头背景色</param>
        /// <param name="H_1">表头1</param>
        /// <param name="H_2">表头2</param>
        /// <param name="H_3">表头3</param>
        /// <param name="H_4">表头4</param>
        /// <param name="H_5">表头5</param>
        /// <param name="H_6">表头6</param>
        /// <param name="H_7">表头7</param>
        /// <param name="H_8">表头8</param>
        public void ShowRichSolidFormColumn(string Title, int Count, int Speed, ConsoleColor TextForegroundColor = ConsoleColor.Green, ConsoleColor TextBackgroundColor = ConsoleColor.White, ConsoleColor ColumForegroundColor = ConsoleColor.White, ConsoleColor ColumBackgroundColor = ConsoleColor.White, string H_1 = null, string H_2 = null, string H_3 = null, string H_4 = null, string H_5 = null, string H_6 = null, string H_7 = null, string H_8 = null)
        {
            int ColumBackgroundLength = Count;
            /*********** 标题栏 ***********/
            Console.Write(" ");
            OutPutColorText(" ", TextForegroundColor, TextBackgroundColor, Speed);   //输出标题
            OutPutColorText(Title, TextForegroundColor, TextBackgroundColor, Speed); //输出标题
            /*** 以下操作是为了防止标题的长度与实际的长度叠加，导致实际长度与传入Count参数的长度不符 ***/
            for (int j = 0; j < Count - Title.Length; j++) //根据标题栏的长度与标题文本的长度，补差值，直到总体长度和Count参数的值相同
            {
                //输出补充的长度背景
                OutPutColorText(" ", TextForegroundColor, TextBackgroundColor, Speed);
                //OutPutColorText(" ", ColumForegroundColor, ColumBackgroundColor, Speed);
            }
            /*********** 表头栏***********/
            Console.Write("\n ");
            OutPutColorText(" ", ColumForegroundColor, ColumBackgroundColor, Speed);
            OutPutColorText(H_1 + H_2 + H_3 + H_4 + H_5 + H_6 + H_7 + H_8, ColumForegroundColor, ColumBackgroundColor, Speed);
        }
        #endregion

        #region 高级窗体
        /// <summary>
        /// 高级固定无信息栏无输入窗体
        /// </summary>
        /// <param name="Text">标题</param>
        /// <param name="Top">最大长度</param>
        /// <param name="ForegroundColor"></param>
        /// <param name="BackgroundColor"></param>
        public void ShowAdvanced_NoInfo_NoInput_Form(string Text,int Top,ConsoleColor ForegroundColor,ConsoleColor BackgroundColor)
        {
            
            Console.WriteLine();
            ShowSimpleSolidFormColumn("COMMAND WINDOW", 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
            int MaxLine = Get_Set_WH(Top);
            Console.ForegroundColor = ForegroundColor;
            if (MaxLine > 50)
            {
                Top++;
            }
            ShowSimpleSolidFormColumn(" ", 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
        }
        #endregion(实验)

        #region 私有函数

        /// <summary>
        /// 将光标设定在窗体正中央，并且返回最大行数
        /// </summary>
        /// <param name="Top">顶端坐标</param>
        /// <returns></returns>
        int Get_Set_WH(int Top)
        {
            Console.SetCursorPosition(0, 28);
            int MaxLine = Console.CursorTop; //获取行位置
            Console.SetCursorPosition(0, 3); //回归原位
            return MaxLine;
        }

        #endregion
    }
}
