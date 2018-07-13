/********************************************************************************

 By ChinHuCheYeh 20  /  /  
 
 Function : 
 
 
 

*********************************************************************************/
using RetroTime;
using RetroTime.IO;
using HawkEyeProject.GameData;
using System;

namespace HawkEyeProject.HEDS.SUBS
{
    [Serializable]
    public class Command 
    {
        private Player player;
        private string input;
        private bool isOut;

        public Command()
        {
            isOut = false;
            //player=(Player)FILE.ReadObject(@"GAME_SAVE\YANG\YANG.SAV");
        }

        public void Run()
        {
            Control();
        }

        private void Control()
        {
            while (!isOut)
            {
                Printer.Print(/*player.UserName*/"USER"+">");
                input = System.Console.ReadLine().ToUpper();

                if (input == "CLS")
                {
                    CLS.Run();
                }
            }
        }
    }
}
