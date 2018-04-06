using HawkEngine.Edit;
using HawkEngine.IO;
using HawkEye.UserData;
using System;
using System.Threading;

namespace HawkEye.EvenManger
{
    /// <summary>
    /// 事件
    /// </summary>
    public class Even
    {
        FILE file = new FILE();
        TEXT text = new TEXT();
        ProgressBar progressBar = new ProgressBar();
        FormColum formColum = new FormColum();
        PlayerData playerData = new PlayerData();
        DiskInfo diskInfo = new DiskInfo();
        Random random = new Random();
        /// <summary>
        /// 注册新账户
        /// </summary>
        public void SignUpUser()
        {
            Console.CursorVisible = true;
            string UserName, Password, OKPassword, DiskInfo;
            text.OutPutText("\n\n  接下来，将创建一份属于你的雇员档案，并上传至H.E.N.I.S.C.中央托管数据库中。", 15, true);
            text.OutPutColorText("\n\n  按任意键继续 [Press Any Key]\t\t\t\t\t\t\t\t\t", ConsoleColor.Yellow, ConsoleColor.Blue, 10);
            Console.ReadKey(true);
            Console.Clear();
            //UserName
            while (true)
            {
                Console.Clear();
                text.OutPutText("\n\n\n   用户名 : ", 15);
                UserName = Console.ReadLine();
                //判断用户名长度是否符合规则，防止空的用户名出现
                if (UserName.Length >= 4)
                {
                    playerData.Name = UserName;
                    break;
                }
                else
                {
                    text.OutPutColorText("\n   error> 用户名长度太短，长度应在4个字符或4个字符以上\t\t\t\t\t", ConsoleColor.White, ConsoleColor.Red, 15, true);
                    Thread.Sleep(3000);
                }
            }
            //Password
            while (true)
            {
                Console.Clear();
                text.OutPutText("\n\n\n   用户名 : " + playerData.Name + "\n", 5);
                text.OutPutText("\n   密码 : ", 15);
                Password = Console.ReadLine();
                text.OutPutText("\n   确认密码 : ", 15);
                OKPassword = Console.ReadLine();
                //判断两次输入的密码是否相等
                if (string.Equals(Password, OKPassword) && (Password.Length >= 8 && OKPassword.Length >= 8))
                {
                    playerData.Password = Password;
                    Console.Clear();
                    break;
                }
                else
                {
                    text.OutPutColorText("\n   error>密码太短或两次密码输入不同，长度应在8个字符或8个字符以上\t\t\t", ConsoleColor.White, ConsoleColor.Red, 15, true);
                    Thread.Sleep(3000);
                }

            }

            //Upload
            Console.CursorVisible = false;
            Console.Clear();
            //playerData.Health = 100;
            //playerData.Level = 1;
            //playerData.MaxLevel = 10;
            //playerData.Exp = 0;
            //playerData.MaxExp = 50;
            //playerData.LevelName = State_LeveName.D.ToString();
            //playerData.IP = random.Next(50, 100) + "." + random.Next(52, 100) + "." + random.Next(100, 200) + "." + random.Next(100, 200);
            //diskInfo.DISK_C = 128;
            //diskInfo.DISK_E = 128;
            //diskInfo.DISK_F = 64;
            //file.CreateDir("Game\\Save\\", UserName + "\\");
            //file.CreateDir("Game\\Save\\" + UserName + "\\", "HEDS\\");
            //file.CreateDir("Game\\Save\\" + UserName + "\\HEDS\\","mail\\");
            //file.CreateDir("Game\\Save\\" + UserName + "\\HEDS\\", "disk\\");
            //file.CreateDir("Game\\Save\\" + UserName + "\\HEDS\\disk\\","C\\");
            //file.CreateDir("Game\\Save\\" + UserName + "\\HEDS\\disk\\", "E\\");
            //file.CreateDir("Game\\Save\\" + UserName + "\\HEDS\\disk\\", "F\\");
            //file.CreateTextData(UserName, "Game\\Save\\", "QuickLoadData.hawksav"); //快速读取信息
            //file.CreateObjectData(diskInfo, "Game\\Save\\" + UserName + "\\HEDS\\disk\\", "diskinfo_D" + random.Next(1000, 9999) + "d.disk"); //磁盘信息
            //file.CreateObjectData(playerData, "Game\\Save\\" + UserName + "\\", "Gamesave_" + UserName + ".hawksav"); //玩家信息信息
            text.OutPutText("\n\n  检查数据格式  ", 15);
            progressBar.ShowProgressBar(15, 55, ConsoleColor.Green);
            text.OutPutText("\n\n  提交信息      ", 15);
            progressBar.ShowProgressBar(15, 35, ConsoleColor.Green);
            text.OutPutText("\n\n  分配信息      ", 15);
            progressBar.ShowProgressBar(15, 120, ConsoleColor.Green);
            text.OutPutText("\n\n  完成！      ", 15);
            Thread.Sleep(3000);
            Console.Clear();
            text.OutPutText("\n\n  接下来，将在你的工作站中安装 Hawk Eye Dos System [HEDS] ", 15);
            text.OutPutText("\n\n  这可能需要一些时间，请静候....", 15);
            Thread.Sleep(500);
            text.OutPutText("\n\n  HEDS Install.....  ", 15);
            progressBar.ShowProgressBar(15, 500, ConsoleColor.Green);
            text.OutPutText("\n\n  完成！      ", 15);
            Thread.Sleep(3000);
        }
    }
}
