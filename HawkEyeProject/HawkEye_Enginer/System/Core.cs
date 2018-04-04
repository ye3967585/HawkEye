using System;
using UserData;
using Even;
using LevelManager;
using HawkEnginer.IO;
using HawkEnginer.Edit;


namespace Core
{
    /// <summary>
    /// 主循环
    /// </summary>
    class Core
    {
        static void Main(string[] args)
        {
            Level game = new Level();
            game.Level0();
        }
    }
}
