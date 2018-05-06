using HawkEye.HEDS.Files;
using HawkEye.HEDS.Mail;
using HawkEye.UserData;
using HawkEye.EvenManger;
using HawkEye.LevelManager;
using HawkTools.Edit;
using HawkTools.IO.Data;
using HawkTools.IO.FileCrtl;
using HawkTools.IO.Text;
using HawkTools.IO.Graphical;
using System;
using System.IO;
using System.Threading;

namespace HawkEye.HEDS.Dos
{
    /// <summary>
    /// 玩家操作的主系统
    /// </summary>
    class HawkDosSystem
    {
        string Text;
        string Input;                                                               //输入
        int NowLine;                                                                //光标1的行位置
        int ERROR;                                                                  //错误计数
        bool BreakThis;                                                             //是否跳出输入循环
        string PlayerName;
        TEXT text;
        FILE file;
        DATA data;
        Even even;
        LevelList level;
        FormColum formColum;
        GRAPHICAL graphical;
        PlayerData playerData;
        FileSystem fileSystem;
        MailSystem mailSystem;

        public HawkDosSystem(string Name)
        {
            PlayerName = Name;
            even = new Even(PlayerName);
            level = new LevelList();
            ERROR = 0;
            BreakThis = false;
            text = new TEXT();
            file = new FILE();
            data = new DATA();
            formColum = new FormColum();
            graphical = new GRAPHICAL();
        }

        /// <summary>
        /// 开机动画
        /// </summary>
        public void StartingSystem()
        {
            Text = "Game\\Text\\heds.txt";
            //graphical.DrawLowGraphicsFromFiles(Text, ConsoleColor.Green);
            Thread.Sleep(1000);
            Console.WriteLine();
            Console.Write("\t ");
            text.OutPutColorText("  Version 1.0.5 Realse CopyRight Hawk Eye 1985-1994\t\n", ConsoleColor.Black, ConsoleColor.Green, 15);
            Thread.Sleep(2000);
            Console.Write("\t ");
            text.OutPutColorText("  Loading ....\t\t\t\t\t\t", ConsoleColor.Black, ConsoleColor.DarkGreen, 15);
            Thread.Sleep(2000);
            Console.Clear();
        }

        #region 命令行视口
        public void Command()
        {
            //StartingSystem();
            Console.WriteLine();
            formColum.ShowSimpleSolidFormColumn("COMMAND", 80, 3, ConsoleColor.Black, ConsoleColor.Green);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n");
            GetInfo("info");                                // 显示基本的信息
            GetInfo("user");                                // 显示基本的信息
            level.LevelCrtl(1);
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
                NowLine = Console.CursorTop;                //移动光标至第二行，防止覆盖标题
                Console.Write("  {0}\\SYSTEM>", playerData.Name);
                Input = Console.ReadLine();
                if (Input == "cls")
                {
                    Console.Clear();
                    Console.WriteLine();
                    formColum.ShowSimpleSolidFormColumn("COMMAND", 80, 3, ConsoleColor.Black, ConsoleColor.Green);
                    Console.WriteLine("\n");
                }

                #region Info
                else if (Input.Contains("info"))                //如果包含info，进入子判断语句
                {
                    Input = data.CutString(Input, 4);           //裁字符串，只剩下参数值
                    GetInfo(Input);                             //输入参数值
                }
                #endregion
                else if (Input.Contains("disk"))
                {
                    fileSystem = new FileSystem(playerData.Name);
                    fileSystem.Command();
                }
                else if (Input.Contains("mail"))
                {
                    mailSystem = new MailSystem();
                    mailSystem.Command();
                }
                else if (Input == "a")
                {
                    even.GetNewMail("Game\\Save\\" + PlayerName + "\\HEDS\\Mail\\", "MISSION_1015", "kYLE",
                        "  来自于社会人口与管理总署的请求。\n" +
                        "  近日，在北部国立中学一名教师 James Marsh 被家人反应其已失踪5天之久，目前无法使用任何的通\n" +
                        "  用途径与其取得联系，我们已经调查了他的家人与朋友，无法取得任何有价值的信息.与此同时，与他\n" +
                        "  一起失踪的人还有 Johon Dabrowski，此人是一名社会无业人员，他早在10年前就与他的家庭断绝联\n" +
                        "  系。令人值得注意的是，两人竟在同一时间消失，这期间肯定有某种密切的联系。由于法律明文规定我们\n" +
                        "  无权对公民的私人物品进行调查，我们希望你能够通过技术手段秘密调查\n" +
                        "  James Marsh 与 Johon Dabrowski 的个人电脑，从中获取一些对于案件有所进展的讯息。", "来自于社会人口与管理总署的请求", true);
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

            playerData = (PlayerData)file.GetObjectData(@"Game\Save\" + PlayerName + @"\", "Gamesave_" + PlayerName + ".hawksav");
            //如果没有裁剪，那么肯定就是无参指令，否则就执行相应的参数
            if (Input.Contains("info"))
            {
                Console.Write("\n  (C)1988-1997 Hawk Eye Dos System V 1.5.1\n\n");
            }
            else if (Input.Contains("user"))
            {
                Console.Write("\n  用户名 :\t{0}\n" + "  IP :\t\t{1}\n" + "  等级 :\t{2}-{3}\n\n", playerData.Name, playerData.IP, playerData.Level, playerData.LevelName);
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
            else if (Input.Contains("f"))
            {
                text.OutPutTextFromFiles("Game\\Text\\Help\\file.txt", 1);
            }
            else if (Input.Contains("m"))
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
    #region  渗透对象
    /// <summary>
    /// 通用DOS接口
    /// </summary>
    public interface IEmptyDosSystem
    {
        /// <summary>
        /// 开机动画
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="isImage"></param>
        void StartingSystem(string Path, bool isImage);
        /// <summary>
        /// 命令行窗口
        /// </summary>
        void Command();
        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="Input"></param>
        void GetInfo(string Input = null);
        /// <summary>
        /// 帮助信息
        /// </summary>
        /// <param name="Input"></param>
        void Help(string Input);
    }
    /// <summary>
    /// 空的预置系统，用于玩家需要连接渗透的对象
    /// </summary>
    class EmptyDosSystem : IEmptyDosSystem
    {
        string Name;

        public EmptyDosSystem(string Name)
        {

        }

        public void Command()
        {

        }

        public void GetInfo(string Input = null)
        {

        }

        public void Help(string Input)
        {

        }

        public void StartingSystem(string Path, bool isImage)
        {

        }
    }
    #endregion
}
