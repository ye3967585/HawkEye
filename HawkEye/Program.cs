using HawkTools.Edit;
using HawkTools.IO.Text;
using HawkTools.IO.Data;
using HawkTools.IO.FileCrtl;
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
            Console.Title = "HAWK EYE PROJECT";
            LevelList levelList = new LevelList();
            HawkDosSystem dosSystem = new HawkDosSystem();
            //FormColum formColum = new FormColum();
            //DATA data = new DATA();
            //HawkDosSystem dosSystem = new HawkDosSystem();
            //FileSystem fileSystem = new FileSystem();
            //FILE file = new FILE();
            //TEXT t = new TEXT();
            //GRAPHICAL g = new GRAPHICAL();

            levelList.Level0();

           //dosSystem.Command();
            //Console.WriteLine(mail.Content);
        }
    }
}
