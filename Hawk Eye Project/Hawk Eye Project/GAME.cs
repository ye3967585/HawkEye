/********************************************************************************

 By ChinHuCheYeh 20  /  /  
 
 Function : 
 
 
 游戏的入口

*********************************************************************************/
using System;
using RetroTime.IO;
using HawkEyeProject.HEDS.SUBS;
using HawkEyeProject.GameData;
namespace HawkEyeProject
{
    public class GAME
    {
        static GAME()
        {
            Console.Title = "Hawk Eye Project";
        }

        public static void Run()
        {
            PlayerData.DEV_Create_Player();
            

        }
    }
}
