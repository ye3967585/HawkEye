using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Threading;
using HawkEye.LevelManager;
using HawkEngine.IO;
using HawkEngine.Edit;
using HawkEye.HEDS.Dos;

namespace HawkEye
{
    class Program
    {
        static void Main(string[] args)
        {
            LevelList levelList = new LevelList();
            DosSystem dosSystem = new DosSystem();
            FormColum formColum = new FormColum();
            DATA data = new DATA();
            //levelList.Level0();
            //DATA data = new DATA();
            //string c = data.CutString("help a", 4);
            //Console.WriteLine(c);
            //dosSystem.StartingSystem();
            //Console.WriteLine();
            //formColum.ShowSimpleSolidFormColumn("Console", 50,0,ConsoleColor.Black,ConsoleColor.Green);
            //Console.WriteLine();
            //Console.WriteLine();
            //formColum.ShowSimpleSolidFormColumn("Hello Man asdasd", 50, 0, ConsoleColor.Black, ConsoleColor.Green);
            //Console.WriteLine();
            //Console.WriteLine();
            dosSystem.Command();
            //string Input = "ver -user";
            //Input = data.CutString(Input, 3, "-");
            //Console.WriteLine(Input);
        }
    }
}
