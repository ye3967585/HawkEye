﻿using HawkTools.Edit;
using HawkTools.IO.Data;
using HawkTools.IO.File;
using HawkTools.IO.Text;
using HawkEye.UserData;
using System;
using System.Threading;
using System.IO;

namespace HawkEye.HEDS.Files
{
    /// <summary>
    /// 当前所在的盘符
    /// </summary>
    enum DiskState{
        C,E,F,OUT
    }
    public class FileSystem
    {
        string PlayDataPath = "Game\\Save\\";                                       //玩家信息路径
        string DiskInfoPath = "HEDS\\disk\\";                                       //磁盘信息文件目录
        string RootPath = "HEDS\\disk\\";                                           //根目录
        string C = "HEDS\\disk\\C\\";                                               //C
        string E = "HEDS\\disk\\E\\";                                               //E
        string F = "HEDS\\disk\\E\\";                                               //F
        DiskInfo diskinfo;                                       //磁盘信息对象
        FormColum formColum;
        DiskState diskState;
        TEXT text = new TEXT();
        FILE file = new FILE();
        DATA data = new DATA();

        /// <summary>
        /// 初始化数据
        /// </summary>
        /// <param name="Name">玩家名 以便寻找文件</param>
        public FileSystem(string Name)
        {
            diskState = DiskState.OUT;
            diskinfo = new DiskInfo();
            formColum = new FormColum();
            diskinfo = (DiskInfo)file.GetObjectData(PlayDataPath + Name + @"\" + DiskInfoPath, "diskinfo_D4286d.disk"); //载入磁盘信息
        }

        string Input;
        string Name = File.ReadAllText("Game\\Save\\QuickLoadData.hawksav");        //获取玩家名
        public void Command()
        {
            diskState = DiskState.OUT;;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            GetDiskView();
            while (true)
            {
                Console.Write("  {0}>File>{1}>",Name,diskState);
                Input = Console.ReadLine();
                if (Input == "cls"&&Input.Length==3)
                {
                    Console.Clear();
                    formColum.ShowSimpleSolidFormColumn("DISK", 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
                    Console.ForegroundColor = ConsoleColor.Green;
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
                else if (Input.Contains("list"))
                {
                    ListIndex(diskState, Input);
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
        /// 获取磁盘目录视图
        /// </summary>
        void GetDiskView()
        {
            diskinfo.DISK_C = 64;
            diskinfo.DISK_E = 12;
            diskinfo.DISK_F = 35;
            //图示
            Console.Write("\n  占用比 [ C / D / E ]\n\n");
            GetState(diskinfo.DISK_C); 
            GetState(diskinfo.DISK_E);
            GetState(diskinfo.DISK_F);
            Console.WriteLine("\n");
            //文字数据
            Console.WriteLine("  C:\t{0}/128\n  E:\t{1}/128\n  F:\t{2}/64\n", diskinfo.DISK_C,diskinfo.DISK_E,diskinfo.DISK_F);
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
        }

        /// <summary>
        /// 根据盘符列出文件或文件夹
        /// </summary>
        /// <param name="state"></param>
        void ListIndex(DiskState state,string Input)
        {

            if (Input.Contains("list")&&diskState!=DiskState.OUT)
            {
                Console.WriteLine("\n  Date\t\tTime\t\tName");
                string[] Index = file.GetFileIndex(PlayDataPath + Name + @"\" + RootPath + diskState + "\\");
                for (int i = 0; i < Index.Length; i++)
                {
                    Thread.Sleep(30);
                    Console.WriteLine("  "+File.GetCreationTime(Index[i]).AddYears(-30).ToString("yyyy.M.d") + "\t" + File.GetCreationTime(Index[i]).ToString("HH:mm:ss") + "\t" + Index[i].Substring(27));
                }
                Console.WriteLine();
            }
            else if(diskState == DiskState.OUT)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ERROR: 你尚未进入任何盘符", Input);
                Console.ForegroundColor = ConsoleColor.Green;
            }
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
