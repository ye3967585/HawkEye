using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using UserData;
using HawkEnginer.IO;
using HawkEnginer.Edit;

namespace LevelManager
{
    /// <summary>
    /// 关卡管理器
    /// </summary>
    class Level
    {
        string LevelText;
        Text text = new Text();
        FILE file = new FILE();
        FormColum formColum = new FormColum();
        ProgressBar progressBar = new ProgressBar();

        public void Level0()
        {
            LevelText = "Game\\Text\\Level\\0\\Text_1.txt";
            Console.CursorVisible = false;
            Console.WriteLine();
            text.OutPutTextFromFiles(LevelText, 45);
            Thread.Sleep(5000);
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            text.OutPutColorText("\n\n\n\n\n\n\t\t\t\t      按任意键继续 \t\t\t\t\t", ConsoleColor.Yellow, ConsoleColor.Blue, 10);
            Console.ReadKey(true);
        }
    }
}
