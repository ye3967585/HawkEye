using System;
using FileTypeLirbary;
using RetroTime.IO;

namespace FilePackager
{
    class Program
    {
        static void Main(string[] args)
        {
            TEXT text = new TEXT();
            FILE.Create(args[0], text);
        }
    }
}
