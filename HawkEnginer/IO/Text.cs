
/*********************************************************************************************************
 * Hawk Enginer - IO 文字输出系统 V0.01  
 * By ChihHuCheYeh
 * 基于.net对文字输出的基础上根据个人需求进行改进和修改，对文件文字的输出提供了更为绚丽的输出效果以及更多的可选参数。
 *********************************************************************************************************/

using System;
using System.Threading;
using System.IO;
namespace HawkEngine.IO
{
    /// <summary>
    /// 向视图中输出各种形式的字符或字符串
    /// </summary>
    public class Text
    {
        int LineCrtl;

        /// <summary>
        /// 输出普通文本
        /// </summary>
        /// <param name="Text">文本</param>
        /// <param name="OutSpeed">输出速度</param>
        /// <param name="isLinefeed">是否自动换行（必须与换行控制一同设定）</param>
        /// <param name="LineControl">换行控制（必须与否自动换行制一同设定）</param>
        public void OutPutText(string Text, int OutSpeed = 0, bool isLinefeed = false, int LineControl = 9999)
        {
            LineCrtl = 0;
            /**************输出文本**************/
            if ((isLinefeed && (LineControl < 0 || LineControl != 0))||isLinefeed)        //如果开启了换行模式
            {
                for (int i = 0; i < Text.Length; i++, LineCrtl++)
                {
                    Thread.Sleep(OutSpeed);
                    Console.Write(Text[i]);
                    //换行
                    if (LineCrtl == LineControl)
                    {
                        Console.Write("\n");
                        LineCrtl = 0;
                    }
                }
                Console.Write("\n");
            }
            else
            {
                //普通不换行的输出
                for (int j = 0; j < Text.Length; j++)
                {
                    Thread.Sleep(OutSpeed);
                    Console.Write(Text[j]);
                }
            }
            //在结尾跟进换行
        }
        /// <summary>
        /// 输出有色文本
        /// </summary>
        /// <param name="Text">文本</param>
        /// <param name="ForegroundColor">前景色（仅会改变文本所在范围的颜色）</param>
        /// <param name="BackgroundColor">背景色（仅会改变文本所在范围的颜色）</param>
        /// <param name="OutSpeed">输出速度</param>
        /// <param name="isLinefeed">是否自动换行（必须与换行控制一同设定）</param>
        /// <param name="LineControl">换行控制（必须与否自动换行制一同设定）</param>
        public void OutPutColorText(string Text, ConsoleColor ForegroundColor = ConsoleColor.White, ConsoleColor BackgroundColor = ConsoleColor.Black, int OutSpeed = 0, bool isLinefeed = false, int LineControl = 0)
        {
            LineCrtl = 0;
            /**************调整颜色**************/
            Console.BackgroundColor = BackgroundColor;
            Console.ForegroundColor = ForegroundColor;
            /**************输出文本**************/
            OutPutText(Text, OutSpeed, isLinefeed, LineControl);
            /**************复位颜色**************/
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// 来自文件的普通文本输出
        /// </summary>
        /// <param name="Path">文本文件的路径</param>
        /// <param name="OutSpeed">输出速度</param>
        public void OutPutTextFromFiles(string Path, int OutSpeed = 0)
        {
            string FileText = System.IO.File.ReadAllText(Path);
            OutPutText(FileText, OutSpeed);
        }
        /// <summary>
        /// 来自文件的有色文本输出
        /// </summary>
        /// <param name="Path">文本文件的路径</param>
        /// <param name="ForegroundColor">前景色（仅会改变文本所在范围的颜色）</param>
        /// <param name="BackgroundColor">背景色（仅会改变文本所在范围的颜色）</param>
        /// <param name="OutSpeed">输出速度</param>
        public void OutPutColorTextFromFiles(string Path, ConsoleColor ForegroundColor, ConsoleColor BackgroundColor, int OutSpeed)
        {
            string FileText = System.IO.File.ReadAllText(Path);                          //将文件转换为文本变量
            OutPutColorText(FileText, ForegroundColor, BackgroundColor, OutSpeed);  //输出
        }
    }
}
