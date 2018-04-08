using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;
using HawkEngine.IO;
using HawkEngine.Edit;
using HawkEye.EvenManger;
using HawkEye.UserData;

namespace HawkEye.HEDS.Dos
{
    class DosSystem
    {
        string Name;
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
            MaxLine = DrawUI(); // 绘制UI
            GetInfo("user"); // 显示基本的信息
            /*
             * 命令的判断思路：
             * 如果用户输入的命令（主命令代码）为命名列表中的一部分
             * 那么就判断是否包含参数
             * 如果不包含参数，就输出相关指令，如果包含，则输出另一部分相关指令
             */
            while (!BreakThis)
            {
                NowLine = Console.CursorTop;  //移动光标至第二行，防止覆盖标题
                Console.Write("  User>");
                Input = Console.ReadLine();
                if (Input == "cls")
                {
                    Console.Clear();
                    //formColum.ShowSimpleSolidFormColumn("COMMAND WINDOW", 80, 0, ConsoleColor.Black, ConsoleColor.Green);
                    //Console.WriteLine("\n");
                    //Console.ForegroundColor = ConsoleColor.Green;
                    MaxLine = DrawUI();
                }

                #region Info
                else if (Input.Contains("info"))  //如果包含info，进入子判断语句
                {
                    if (Input.Length > 4) //如果>主命令代码的长度，则视为有参数
                    {
                        Input = data.CutString(Input, 4, "-"); //裁字符串，只剩下参数值
                        GetInfo(Input); //输入参数值
                    }
                    else //否则只进行一般无参的输出（如果调用的功能支持无参）
                    {
                        GetInfo(Input);
                    }
                }
                #endregion

                else if (Input.Length < 1) ;
                else
                {
                    Console.WriteLine("  >未知的命令 {0}", Input);
                }
            }
        }
        #endregion

        #region 适用于本模块的私有方法集
        #region --UI
        /// <summary>
        /// 绘制UI
        /// </summary>
        int DrawUI()
        {
            string Name = "MONA";
            playerData = (PlayerData)file.GetObjectData("Game\\Save\\" + Name + "\\", "Gamesave_" + Name + ".hawksav");
            int MaxLine;
            /********* 画顶端UI *********/
            Console.WriteLine();  //+1
            formColum.ShowSimpleSolidFormColumn("COMMAND", 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
            //Console.WriteLine(""); //+4
            Console.ForegroundColor = ConsoleColor.Green;
            /********* 画底部UI *********/
            Console.SetCursorPosition(0, 28);//光标移动到底部
            MaxLine = Console.CursorTop;  //+1
            Name = "MONA";          
            //formColum.ShowSimpleSolidFormColumn("User:"+playerData.Name+"-"+playerData.LevelName+"/IP:"+playerData.IP+"/Date:"+DateTime.Now.AddYears(-30).ToShortDateString().ToString(), 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
            Console.SetCursorPosition(0, 3); //光标移动回原位
            return MaxLine; //向外界返回
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="Input">输入</param>
        void GetInfo(string Input=null)
        {

            Console.Write("  系统信息 : (C)1988-1997 Hawk Eye Dos System V 1.5.1\n");
            if (Input.Contains("user"))
            {
                Console.Write("  用户名 : {0} \\" + " IP : {1} \\ " + " 等级L : {2}-{3}\n\n", playerData.Name, playerData.IP, playerData.Level, playerData.LevelName);
            }
            
        }
        #endregion
        #region --按键检查
        [DllImport("user32.dll", EntryPoint = "GetKeyboardState")]
        public static extern int GetKeyboardState(byte[] pbKeyState);
        public static bool CapsLockStatus {
            get {
                byte[] bs = new byte[256];
                GetKeyboardState(bs);
                return (bs[0x14] == 1);
            }
        }
        /// <summary>
        /// 检查大写是否被打开
        /// </summary>
        /// <returns></returns>
        bool CapsLockCheck()
        {
            if (CapsLockStatus)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
        #endregion
    }
}
