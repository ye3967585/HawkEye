/*********************************************************************************************************
 * Hawk Enginer - Graphical 图形输出系统 V0.01  
 * By ChihHuCheYeh
 * 
 * 绘图原理：
 * 以#和空格为标识符，以#为背景，空格为实际图形。
 *********************************************************************************************************/
using HawkTools.IO.File;
using HawkTools.IO.Text;
using System.Threading;
using System;
using System.IO;

namespace HawkTools.IO.Graphical
{

    /// <summary>
    /// 图形输出
    /// </summary>
    public class GRAPHICAL
    {
        int BufferHight;                  //缓冲区高度
        int BufferWeghit;                 //缓冲区宽度
        int CursorPos;                    //光标位置
        char F_Draw, B_Draw;              //前景/背景标识符


        /// <summary>
        /// 指定标识符
        /// </summary>
        /// <param name="F">前景标识符</param>
        /// <param name="B">背景标识符</param>
        public GRAPHICAL(char F, char B)
        {
            F_Draw = F;
            B_Draw = B;
        }

        /// <summary>
        /// 绘制一副图形
        /// </summary>
        /// <param name="Source">文件图形数据</param>
        /// <param name="Color">色</param>
        /// <param name="Speed">输出速度</param>
        public void DrawGraphics(char[] Source,ConsoleColor Color,int Speed=100)
        {
            for (int i = 0; i < Source.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(2);
                if (Source[i] == B_Draw)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (Source[i] == F_Draw && Source[i] != '\t')
                {
                    Console.BackgroundColor = Color;
                }
                Console.Write(Source[i]);
            }
        }

        /// <summary>
        /// 绘制一副图形，来自于数据文件
        /// </summary>
        /// <param name="File">文件图形数据</param>
        /// <param name="Color">前景色</param>
        /// <param name="Speed">输出速度</param>
        public void DrawGraphicsFormFiles(string File,ConsoleColor Color, int Speed = 100)
        {
            string ReadData = System.IO.File.ReadAllText(File);
            for (int i = 0; i < ReadData.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(2);
                if (ReadData[i] == B_Draw)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (ReadData[i] == F_Draw && ReadData[i] != '\t')
                {
                    Console.BackgroundColor = Color;
                }
                Console.Write(ReadData[i]);
            }
        }
    }
}
