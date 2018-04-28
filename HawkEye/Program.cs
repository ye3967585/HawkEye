using HawkTools.Edit;
using HawkTools.IO.Text;
using HawkTools.IO.Data;
using HawkTools.IO.FileCrtl;
using HawkTools.IO.Graphical;
using HawkEye.HEDS.Dos;
using HawkEye.HEDS.Files;
using HawkEye.HEDS.Mail;
using HawkEye.LevelManager;
using System;
using System.Runtime.InteropServices;

namespace HawkEye
{
    class Program
    {
        //[DllImport("kernel32.dll")]
        //public static extern IntPtr GetStdHandle(int nStdHandle);
        //const int STD_OUTPUT_HANDLE = -11;
        //public delegate bool SetConsoleDisplayMode(IntPtr hOut, int dwNewMode, out int lpdwOldMode);
        ////标准输出句柄
        //IntPtr hOut = GetStdHandle(STD_OUTPUT_HANDLE);
        ////调用Win API,设置屏幕最大化
        //SetConsoleDisplayMode s = (SetConsoleDisplayMode)g.Invoke("SetConsoleDisplayMode", typeof(SetConsoleDisplayMode));
        //s(hOut, 1, out int dwOldMode);

        static void Main(string[] args)
        {
            //Console.Title = "HAWK EYE PROJECT";
            LevelList levelList = new LevelList();
            //levelList.Level0();
            HawkDosSystem dosSystem = new HawkDosSystem(System.IO.File.ReadAllText(@"Game\Save\QuickLoadData.hawksav"));
            GRAPHICAL g = new GRAPHICAL("kernel32.dll");
            dosSystem.Command();
        }
    }
}
