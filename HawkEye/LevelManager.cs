using HawkTools.Edit;
using HawkTools.IO.FileCrtl;
using HawkTools.IO.Text;
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
        Even even = new Even("AA");
        bool isDead = false;    //是否死亡

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

        }
    }
}
