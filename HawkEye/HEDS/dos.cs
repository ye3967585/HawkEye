using HawkEngine.Edit;
using HawkEngine.IO.Data;
using HawkEngine.IO.File;
using HawkEngine.IO.Text;
using HawkEye.UserData;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace HawkEye.HEDS.Dos
{
    class DosSystem
    {
        string Name;              //玩家名
        string SystemText;
        string Input;
        int NowLine;             //光标1的行位置
        int MaxLine;
        bool BreakThis = false; //是否跳出输入循环
        TEXT text = new TEXT();
        FILE file = new FILE();
        DATA data = new DATA();
        FormColum formColum = new FormColum();
        PlayerData playerData = new PlayerData();

        string HelpPath = "Game\\Text\\Help\\help.txt";
        string PlayDataPath = "Game\\Save\\";
        /// <summary>
        /// 开机动画
        /// </summary>
        public void StartingSystem()
        {
            SystemText = File.ReadAllText("Game\\Text\\heds.txt");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < SystemText.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(SystemText[i]);
                Thread.Sleep(2);
            }
            Thread.Sleep(100);
            Console.WriteLine();
            Console.Write("     ");
            text.OutPutColorText(" Version 1.0.5 Realse CopyRight Hawk Eye 1985-1994          \n", ConsoleColor.Black, ConsoleColor.Green, 15);

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
                Console.ForegroundColor = ConsoleColor.Green;
                NowLine = Console.CursorTop;  //移动光标至第二行，防止覆盖标题
                Console.Write("\n  User>");
                Input = Console.ReadLine();
                if (Input == "cls")
                {
                    Console.Clear();
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("  >未知的命令 {0}", Input);
                    Console.ForegroundColor = ConsoleColor.Green;
                }
            }
        }
        #endregion

        #region 适用于本模块的私有方法集
        #region --UI
        
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Input">输入</param>
        void GetInfo(string Input=null)
        {
            //如果没有裁剪，那么肯定就是无参指令，否则就执行相应的参数
            if (Input.Contains("info"))
            {
                Console.Write("  系统信息 : (C)1988-1997 Hawk Eye Dos System V 1.5.1\n");
            }
            else if (Input.Contains("user"))
            {
                Console.Write("  系统信息 : (C)1988-1997 Hawk Eye Dos System V 1.5.1\n");
                Console.Write("  用户名 : {0} \\" + " IP : {1} \\ " + " 等级L : {2}-{3}\n\n", playerData.Name, playerData.IP, playerData.Level, playerData.LevelName);
            }
            
        }

        void Help(string Input)
        {
            //如果没有裁剪，那么肯定就是无参指令，否则就执行相应的参数
            if (Input.Contains("help"))
            {
                text.OutPutTextFromFiles("Game\\Text\\Help\\help.txt", 1);
            }else if (Input.Contains("file"))
            {
                text.OutPutTextFromFiles("Game\\Text\\Help\\file.txt", 1);
            }else if (Input.Contains("mail"))
            {
                text.OutPutTextFromFiles("Game\\Text\\Help\\mail.txt", 1);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  >{0} 是 help 命令中未知的参数", Input);
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }
        #endregion
        #endregion
    }
}
