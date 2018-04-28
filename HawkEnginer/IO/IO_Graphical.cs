/*********************************************************************************************************
 * Hawk Enginer - Graphical 图形输出系统 V0.01  
 * By ChihHuCheYeh & Gordon Walkdby
 * 
 * 功能：
 * 1.根据相应数据文件输出指定的图形
 * 2.指定png、jpg文件，在屏幕输出指定的图形
 *********************************************************************************************************/
using HawkTools.IO.FileCrtl;
using HawkTools.IO.Text;
using System.Threading;
using System;
using System.Drawing;
using DrawImageForConsole;
using System.Runtime.InteropServices;

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
        Bitmap bitmap;
        Image Image;
        TEXT text;
        FILE file;
        DRAW draw;
        private IntPtr hLib;

        #region WinAPI
        [DllImport("kernel32.dll")]
        private extern static IntPtr LoadLibrary(string path);
        [DllImport("kernel32.dll")]
        private extern static IntPtr GetProcAddress(IntPtr lib, string funcName);
        [DllImport("kernel32.dll")]
        private extern static bool FreeLibrary(IntPtr lib);
        #endregion


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="DLLPath">是否使用win API</param>
        public GRAPHICAL(String DLLPath=null)
        {
            text = new TEXT();
            file = new FILE();
            draw = new DRAW();
            if (DLLPath != null)
            {
                hLib = LoadLibrary(DLLPath);
            }
        }
        ~GRAPHICAL()
        {
            FreeLibrary(hLib);
        }

        public Delegate Invoke(string APIName, Type t)
        {
            IntPtr api = GetProcAddress(hLib, APIName);
            return (Delegate)Marshal.GetDelegateForFunctionPointer(api, t);
        }

        /// <summary>
        /// 绘制一副低级图形
        /// </summary>
        /// <param name="Source">文件图形数据</param>
        /// <param name="B">背景标识符</param>
        /// <param name="F">前景标识符</param>
        /// <param name="Color">色</param>
        /// <param name="Speed">输出速度</param>
        public void DrawLowGraphics(char[] Source,char B,char F,ConsoleColor Color,int Speed=100)
        {
            for (int i = 0; i < Source.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(2);
                if (Source[i] == B)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (Source[i] == F && Source[i] != '\t')
                {
                    Console.BackgroundColor = Color;
                }
                Console.Write(Source[i]);
            }
        }
        /// <summary>
        /// 绘制一副低级图形，来自于数据文件
        /// </summary>
        /// <param name="File">文件</param>
        /// <param name="B">背景标识符</param>
        /// <param name="F">前景标识符</param>
        /// <param name="Color">颜色</param>
        /// <param name="Speed">速度</param>
        public void DrawLowGraphicsFromFiles(string File, char B, char F, ConsoleColor Color, int Speed = 100)
        {
            string ReadData = System.IO.File.ReadAllText(File);
            for (int i = 0; i < ReadData.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Thread.Sleep(2);
                if (ReadData[i] == B)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                if (ReadData[i] == F && ReadData[i] != '\t')
                {
                    Console.BackgroundColor = Color;
                }
                Console.Write(ReadData[i]);
            }
        }
        /// <summary>
        /// 根据提供的文件，绘制一副高级图形
        /// （此方法基于VB.NET By Gordon Walkdby）
        /// </summary>
        /// <param name="File">文件</param>
        /// <param name="Width">宽度</param>
        /// <param name="Hight">高度</param>
        public void DrawHighGraphics(string File,int Width,int Hight)
        {
            draw.刻画图片(File, Width, Hight);
        }



        #region 私有方法集
       
        #endregion
    }
}
