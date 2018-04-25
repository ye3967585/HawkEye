using HawkTools.Edit;
using HawkTools.IO.Text;
using HawkTools.IO.Data;
using HawkTools.IO.File;
using HawkTools.IO.Graphical;
using HawkEye.HEDS.Dos;
using HawkEye.HEDS.Files;
using HawkEye.HEDS.Mail;
using HawkEye.LevelManager;
using System;

namespace HawkEye
{
    class Program
    {
        static void Main(string[] args)
        {  
            //Console.Title = "HAWK EYE PROJECT";
            LevelList levelList = new LevelList(); 
            FormColum formColum = new FormColum();
            DATA data = new DATA();
            DosSystem dosSystem = new DosSystem();
            //FileSystem fileSystem = new FileSystem();
            FILE file = new FILE();
            TEXT t = new TEXT();
            GRAPHICAL g = new GRAPHICAL();

            Mail mail;
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
            //fileSystem.Command();
            //string Input = "ver -user";
            //Input = data.CutString(Input, 3, "-");
            //Console.WriteLine(Input);
            //Console.ReadKey();
            //t.TwinkleText("\n\n\n\t\t\tI love you bitch!", ConsoleColor.Blue, ConsoleColor.Yellow, 10,20);
            //g.DrawHighGraphics(@"Game\166.jpg",30,30);
            //mail=(Mail)file.GetObjectData("Game\\", "HELLO.mail");
           // Console.WriteLine(mail.Content);
        }
    }
}
