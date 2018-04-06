using System;
using System.IO;
using System.Threading;
using HawkEngine.IO;
using HawkEngine.Edit;
using HawkEye.EvenManger;
using HawkEye.UserData;

namespace HawkEye.HEDS.Dos
{
    class DosSystem
    {
        string SystemText;
        string Input;
        int NowLine;             //光标1的行位置
        int MaxLine;
        bool BreakThis=false; //是否跳出输入循环
        TEXT text = new TEXT();
        FormColum formColum = new FormColum();
        
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
        public void Command()
        {
            MaxLine = DrawUI();
            while (!BreakThis)
            {
                NowLine = Console.CursorTop;
                Console.WriteLine();
                Console.Write(" User>");
                Input = Console.ReadLine();
                if (Input=="cls"||NowLine>MaxLine-5)
                {
                    Console.Clear();
                    //formColum.ShowSimpleSolidFormColumn("COMMAND WINDOW", 80, 0, ConsoleColor.Black, ConsoleColor.Green);
                    //Console.WriteLine("\n");
                    //Console.ForegroundColor = ConsoleColor.Green;
                    MaxLine = DrawUI();
                }
            }
            
        }

        /// <summary>
        /// 绘制UI
        /// </summary>
        public int DrawUI()
        {
            int MaxLine;
            /********* 画顶端UI *********/
            Console.WriteLine();  //+1
            formColum.ShowSimpleSolidFormColumn("COMMAND WINDOW", 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
            //Console.WriteLine(""); //+4
            Console.ForegroundColor = ConsoleColor.Green;
            /********* 画底部UI *********/
            Console.SetCursorPosition(0, 25);//光标移动到底部
            MaxLine = Console.CursorTop;  //+1
            formColum.ShowSimpleSolidFormColumn("CapsLock[OFF] NUMLock[OFF]", 80, 0, ConsoleColor.Black, ConsoleColor.Green); //+1
            Console.SetCursorPosition(0, 3); //光标移动回原位
            return MaxLine; //向外界返回
        }
    }
}
