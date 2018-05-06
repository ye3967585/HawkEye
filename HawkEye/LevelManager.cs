using HawkTools.Edit;
using HawkTools.IO.FileCrtl;
using HawkTools.IO.Text;
using HawkEye.HEDS.Mail;
using HawkEye.EvenManger;
using System;

namespace HawkEye.LevelManager
{
    /// <summary>
    /// 关卡管理器
    /// </summary>
    public class LevelList
    {
        string LevelText;
        TEXT text = new TEXT();
        FILE file = new FILE();
        FormColum formColum = new FormColum();
        ProgressBar progressBar = new ProgressBar();
        
        bool isDead = false;                            //是否死亡

        static string Name = System.IO.File.ReadAllText(@"Game\Save\QuickLoadData.hawksav");
        Even even = new Even(Name);
        MailSystem mail = new MailSystem(Name);

        public void MainMenu()
        {
            
        }



        public void Level0()
        {
            LevelText = "Game\\TEXT\\Level\\0\\Text_1.txt";
            Console.CursorVisible = false;
            Console.WriteLine();
            text.OutPutTextFromFiles(LevelText, 2);
            //Thread.Sleep(5000);
            Console.Clear();
            text.OutPutColorText("\n\n  按任意键继续 [Press Any Key]\t\t\t\t\t\t\t\t\t", ConsoleColor.Yellow, ConsoleColor.Blue, 10);
            Console.ReadKey(true);
            Console.Clear();
            even.SignUpUser();
        }

        public void Level_1()
        {
            even.GetNewMail("Game\\Save\\" + Name + "\\HEDS\\Mail\\","JOKE","MONA","FUCK YOU","一个不好笑的笑话",false);
            even.GetNewMail("Game\\Save\\" + Name + "\\HEDS\\Mail\\", "WELCOME", "KYLE", "WELCOME", "欢迎你加入HAWK EYE", false);
            even.GetNewMail("Game\\Save\\" + Name + "\\HEDS\\Mail\\", "MISSION_1015", "kYLE",
                        "  来自于社会人口与管理总署的请求。\n" +
                        "  近日，在北部国立中学一名教师 James Marsh 被家人反应其已失踪5天之久，目前无法使用任何的通\n" +
                        "  用途径与其取得联系，我们已经调查了他的家人与朋友，无法取得任何有价值的信息.与此同时，与他\n" +
                        "  一起失踪的人还有 Johon Dabrowski，此人是一名社会无业人员，他早在10年前就与他的家庭断绝联\n" +
                        "  系。令人值得注意的是，两人竟在同一时间消失，这期间肯定有某种密切的联系。由于法律明文规定我们\n" +
                        "  无权对公民的私人物品进行调查，我们希望你能够通过技术手段秘密调查\n" +
                        "  James Marsh 与 Johon Dabrowski 的个人电脑，从中获取一些对于案件有所进展的讯息。", "来自于社会人口与管理总署的请求", true);
        }

        /// <summary>
        /// 关卡控制器
        /// </summary>
        /// <param name="LevelInfo">关卡信息</param>
        public void LevelCrtl(int LevelInfo)
        {
            if (LevelInfo == 1)
            {
                Level_1();
            }
        }
    }
}
