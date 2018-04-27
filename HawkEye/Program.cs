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
            HawkDosSystem dosSystem = new HawkDosSystem(System.IO.File.ReadAllText(@"Game\Save\QuickLoadData.hawksav"));
            //levelList.Level0();
            dosSystem.Command();
        }
    }
}
