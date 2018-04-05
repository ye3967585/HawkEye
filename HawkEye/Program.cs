using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using HawkEye.LevelManager;
using HawkEngine.IO;
using HawkEngine.Edit;

namespace HawkEye
{
    class Program
    {
        static void Main(string[] args)
        {
            LevelList levelList = new LevelList();
            //levelList.Level0();
            DATA data = new DATA();
            string c = data.CutString("help a", 4);
            Console.WriteLine(c);
        }
    }
}
