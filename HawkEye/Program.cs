using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using LevelManager;
using HawkEngine.IO;
using HawkEngine.Edit;

namespace HawkEye
{
    class Program
    {
        static void Main(string[] args)
        {
            Text text = new Text();
            ProgressBar progressBar = new ProgressBar();
            FormColum formColum = new FormColum();
            FILE f = new FILE();
            Console.ReadKey(true);
            Console.CursorVisible = false;
            Console.WriteLine();
            formColum.ShowSimpleFormColumn("  New Form", 30,15);
            Console.WriteLine("\n  1.Button");
            Console.WriteLine("  2.Form");
            Console.WriteLine("  3.Exit\n\n");
            Console.ReadKey(true);
            formColum.ShowRichFormColumn("   Dir", 30, 15, "  ID    ", "Name     ");
            string[] Index = f.GetDirIndex("Game\\");
            for (int i = 0; i < Index.Length; i++)
            {
                text.OutPutText("  "+ i + "         " + Index[i]+"\n",15);
            }
            Console.ReadKey(true);
        }
    }
}
