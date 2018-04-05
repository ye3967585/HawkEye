using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using HawkEye.UserData;
using HawkEngine.IO;
using HawkEngine.Edit;
using HawkEye.EvenManger;

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
        Even even = new Even();
        bool isDead = false;    //是否死亡

        public void Level0()
        {
            LevelText = "Game\\TEXT\\Level\\0\\Text_1.txt";
            Console.CursorVisible = false;
            Console.WriteLine();
            text.OutPutTextFromFiles(LevelText, 2);
            Thread.Sleep(5000);
            Console.Clear();
            text.OutPutColorText("\n\n\n\n\n\n\n\n\n\t\t\t\t      按任意键继续 \t\t\t\t\t", ConsoleColor.Yellow, ConsoleColor.Blue, 10);
            Console.ReadKey(true);
            Console.Clear();
            even.SignUpUser();
        }
    }
}
