using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HawkEngine.IO;
using HawkEngine.Edit;
using HawkEye.EvenManger;
using HawkEye.UserData;
using System.IO;
using System.Threading;

namespace HawkEye.HEDS.Files
{
    /// <summary>
    /// 当前所在的盘符
    /// </summary>
    enum DiskState{
        C,E,F,OUT
    }
    class FileSystem
    {
        string PlayDataPath = "Game\\Save\\";  //玩家信息路径
        string DiskInfoPath = "HEDS\\disk\\"; //磁盘信息文件目录
        string RootPath = "HEDS\\disk\\";      //根目录
        string C = "HEDS\\disk\\C\\";          //C
        string E = "HEDS\\disk\\E\\";          //E
        string F = "HEDS\\disk\\E\\";          //F
        DiskInfo diskinfo = new DiskInfo();    //磁盘信息对象
        DiskState diskState;

        FormColum formColum = new FormColum();
        TEXT text = new TEXT();
        FILE file = new FILE();
        DATA data = new DATA();
        string Input;
        string Name = File.ReadAllText("Game\\Save\\QuickLoadData.hawksav"); //获取玩家名
        public void Command()
        {
            diskState = DiskState.OUT;;
            diskinfo = (DiskInfo)file.GetObjectData("Game\\Save\\" + Name + "\\HEDS\\disk\\", "diskinfo.disk");//获取玩家磁盘信息与大小
            DrawUI("FILE COMMAND");
            GetDiskView();
            while (true)
            {
                Console.Write("  User>File>");
                Input = Console.ReadLine();
                if (Input == "cls"&&Input.Length==3)
                {
                    Console.Clear();
                    DrawUI("FILE COMMAND");
                    Console.WriteLine();
                }
                //进入指定盘符
                else if(Input.Contains("c")|| Input.Contains("e") || Input.Contains("f") || Input.Contains("C") || Input.Contains("E") || Input.Contains("F"))
                {
                    if (Input == "c"|| Input == "C")
                    {
                        GoDiskInfo("C");
                    }
                    else if (Input == "e" || Input == "E")
                    {
                        GoDiskInfo("E");
                    }
                    else if (Input == "f" || Input == "F")
                    {
                        GoDiskInfo("F");
                    }
                }
                else if(Input.Length==0)
                {
                    Console.WriteLine("  空指令");
                }
                else if (Input.Length > 0)
                {
                    OpenFile(diskState, Input);
                }          
            }
        }

        /// <summary>
        /// 显示UI
        /// </summary>
        /// <returns></returns>
        void DrawUI(string titile)
        {
            int MaxLine = 1;
            Console.WriteLine();  //+1
            formColum.ShowSimpleSolidFormColumn(titile, 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(0, 28);//光标移动到底部
            MaxLine = Console.CursorTop;  //+1
            //formColum.ShowSimpleSolidFormColumn("User:", 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
            Console.SetCursorPosition(0, 2);
            //return MaxLine;
        }

        /// <summary>
        /// 获取磁盘目录视图
        /// </summary>
        void GetDiskView()
        {
            //diskinfo.DISK_C = 64;
            //diskinfo.DISK_E = 35;
            //diskinfo.DISK_F = 128;
            //图示
            Console.Write("\n  占用比 [ C / D / E ]\n\n  ");
            GetState(diskinfo.DISK_C); 
            GetState(diskinfo.DISK_E);
            GetState(diskinfo.DISK_F);
            Console.WriteLine("\n");
            //文字数据
            Console.WriteLine("  C:\\  {0}/128\n  E:\\  {1}/128\n  F:\\  {2}/64\n", diskinfo.DISK_C,diskinfo.DISK_E,diskinfo.DISK_F);
        }
        /// <summary>
        /// 获取磁盘状态
        /// </summary>
        /// <param name="Size">大小</param>
        void GetState(int Size)
        {
            if (Size < 50 && Size > 30)
            {
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("  {0}        ",Size);
            }
            else if (Size < 30&&Size>0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("  {0}     ", Size);
            }
            else if (Size == 0)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write(" !!FULL!! ");
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write("  {0}               ", Size);
            }
            
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
        }

        /// <summary>
        /// 前往盘符
        /// </summary>
        /// <param name="Disk"></param>
        void GoDiskInfo(string Disk)
        {
            //状态判断
            //例如，状态为C，那么，打开文件则只打开C目录下的，以此类推。
            if (Disk == "C") { diskState = DiskState.C; }else if (Disk == "E") { diskState = DiskState.E; }else if (Disk == "F") { diskState = DiskState.F; }

            Console.Clear();
            Console.WriteLine();
            formColum.ShowSimpleSolidFormColumn(diskState+ ":\\", 80, 0, ConsoleColor.Black, ConsoleColor.Green);
            Console.WriteLine();
            formColum.ShowSimpleSolidFormColumn("ID       Name            Time", 80, 0, ConsoleColor.Black, ConsoleColor.DarkGreen);
            string[] a = file.GetFileIndex("Game\\Save\\" + Name + "\\HEDS\\disk\\" + Disk + "\\");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            if (a.Length > 0)
            {
                for (int i = 0; i < a.Length; i++)
                {
                    Console.WriteLine("  {0}        " + a[i].Substring(27)+"      "+Directory.GetCreationTime(a[i]), i);

                }
            }
            else
            {
                formColum.ShowSimpleSolidFormColumn("!!NULL!!", 80, 0, ConsoleColor.Black, ConsoleColor.Red);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// 根据所在盘符搜寻并打开文件
        /// </summary>
        /// <param name="disk">所在盘符</param>
        /// <param name="FileName">文件名</param>
        void OpenFile(DiskState disk,string FileName)
        {
            string Path = "Game\\Save\\"+Name+"\\HEDS\\disk\\" + disk.ToString().ToLower()+"\\";
            string conect = file.GetTextData(Path, FileName);
            Console.WriteLine(conect);

        }
    }
}
