﻿using HawkTools.Edit;
using HawkTools.IO.Data;
using HawkTools.IO.File;
using HawkTools.IO.Text;
using HawkEye.UserData;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using HawkEye.HEDS.Files;

namespace HawkEye.HEDS.Dos
{
    class DosSystem
    {
        string Text;
        string Input;                                                               //输入
        int NowLine;                                                                //光标1的行位置
        int ERROR;                                                                  //错误计数
        bool BreakThis = false;                                                     //是否跳出输入循环

        TEXT text = new TEXT();                                                     //文字输出    
        FILE file = new FILE();                                                     //文件
        DATA data = new DATA();                                                     //数据处理
        FormColum formColum = new FormColum();                                      //表列窗体
        PlayerData playerData = new PlayerData();                                   //玩家数据
        FileSystem fileSystem;
        string PlayDataPath = @"Game\Save\";                                        //存档路径                                       
        string QuickLoad = File.ReadAllText(@"Game\Save\QuickLoadData.hawksav");    //玩家名

        public DosSystem()
        {
            ERROR = 0;
        }

        /// <summary>
        /// 开机动画
        /// </summary>
        public void StartingSystem()
        {
            Text = File.ReadAllText("Game\\Text\\heds.txt");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < Text.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(Text[i]);
                Thread.Sleep(2);
            }
            Thread.Sleep(100);
            Console.WriteLine();
            Console.Write("     ");
            text.OutPutColorText(" Version 1.0.5 Realse CopyRight Hawk Eye 1985-1994\t\t", ConsoleColor.Black, ConsoleColor.Green, 15);

        }

        #region 命令行视口
        public void Command()
        {
            Console.WriteLine();
            formColum.ShowSimpleSolidFormColumn("SYSTEM COMMAND", 80, 3, ConsoleColor.Black, ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            GetInfo("user"); // 显示基本的信息
            /*
             * 命令的判断思路：
             * 如果用户输入的命令（主命令代码）为命名列表中的一部分
             * 那么就判断是否包含参数
             * 如果不包含参数，就输出相关指令，如果包含，则输出另一部分相关指令
             */
            while (!BreakThis)
            {
                ERROR = Tips(ERROR);
                Console.ForegroundColor = ConsoleColor.Green;
                NowLine = Console.CursorTop;  //移动光标至第二行，防止覆盖标题
                Console.Write("  {0}>", playerData.Name);
                Input = Console.ReadLine();
                if (Input == "cls")
                {
                    Console.Clear();
                    Console.WriteLine();
                    formColum.ShowSimpleSolidFormColumn("SYSTEM COMMAND", 80, 3, ConsoleColor.Black, ConsoleColor.Green);
                    Console.WriteLine("\n");
                }

                #region Info
                else if (Input.Contains("info"))  //如果包含info，进入子判断语句
                {
                    Input = data.CutString(Input, 4); //裁字符串，只剩下参数值
                    GetInfo(Input); //输入参数值
                }
                #endregion
                else if (Input.Contains("disk"))
                {
                    fileSystem = new FileSystem(playerData.Name);
                    fileSystem.Command();
                }
                #region Help
                else if (Input.Contains("help"))
                {
                    //如果输入的是无参指令，那么此函数将不会生效
                    Input = data.CutString(Input, 4);
                    Help(Input);
                }
                #endregion

                else if (Input.Length < 1) ;
                else
                {
                    ERROR++;

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  ERROR: 未知的命令 {0}", Input);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
        #endregion

        #region 适用于本模块的私有方法集

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Input">输入</param>
        void GetInfo(string Input = null)
        {
            playerData = (PlayerData)file.GetObjectData(PlayDataPath + QuickLoad + @"\", "Gamesave_" + QuickLoad + ".hawksav");
            //如果没有裁剪，那么肯定就是无参指令，否则就执行相应的参数
            if (Input.Contains("info"))
            {
                Console.Write("  系统信息 : (C)1988-1997 Hawk Eye Dos System V 1.5.1\n");
            }
            else if (Input.Contains("user"))
            {
                Console.Write("  用户名 :\t{0}\n" + "  IP :\t\t{1}\n" + "  等级 :\t{2}-{3}\n\n", playerData.Name, playerData.IP, playerData.Level, playerData.LevelName);
            }
            else
            {
                ERROR++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ERROR: {0} 是 info 命令中未知的参数", Input);
                Console.ForegroundColor = ConsoleColor.Green;
            }

        }

        /// <summary>
        /// 用户帮助
        /// </summary>
        /// <param name="Input"></param>
        void Help(string Input)
        {
            //如果没有裁剪，那么肯定就是无参指令，否则就执行相应的参数
            if (Input.Contains("help"))
            {
                text.OutPutTextFromFiles("Game\\Text\\Help\\help.txt", 1);
            }
            else if (Input.Contains("file"))
            {
                text.OutPutTextFromFiles("Game\\Text\\Help\\file.txt", 1);
            }
            else if (Input.Contains("mail"))
            {
                text.OutPutTextFromFiles("Game\\Text\\Help\\mail.txt", 1);
            }
            else
            {
                ERROR++;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ERROR: {0} 是 help 命令中未知的参数", Input);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

        /// <summary>
        /// 提示
        /// </summary>
        /// <param name="ERROR"></param>
        /// <returns></returns>
        int Tips(int ERROR)
        {
            if (ERROR > 5)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("  TIPS: 遇到困难？请输入命令 help 查阅相关帮助", Input);
                Console.ForegroundColor = ConsoleColor.Green;
                ERROR = 0;
            }
            return ERROR;
        }
        #endregion



    }
}
