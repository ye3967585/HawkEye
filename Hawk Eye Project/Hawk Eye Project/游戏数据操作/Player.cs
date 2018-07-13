/********************************************************************************

 By ChinHuCheYeh 2018/6/25 
 
 Function : 界定了玩家数据保存的格式与处理
 
*********************************************************************************/
using System;
using RetroTime.IO;
using RetroTime;
using FileTypeLirbary;
using System.Collections.Generic;

namespace HawkEyeProject.GameData
{
    /// <summary>
    /// 玩家数据
    /// </summary>
    [Serializable]
    public struct Player
    {
        private string userName;
        private string passWord;
        private string nickName;
        private string ip;
        private int maxExp;
        private int hp;
        private int maxHp;
        private int level;
        private int maxLevel;
        private int exp;
        private List<string> subList;

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get => userName; set => userName = value; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get => passWord; set => passWord = value; }
        /// <summary>
        /// 代称
        /// </summary>
        public string NickName { get => nickName; set => nickName = value; }
        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get => ip; set => ip = value; }
        /// <summary>
        /// 生命值
        /// </summary>
        public int Hp { get => hp; set => hp = value; }
        /// <summary>
        /// 最大生命值
        /// </summary>
        public int MaxHp { get => maxHp; set => maxHp = value; }
        /// <summary>
        /// 等级
        /// </summary>
        public int Level { get => level; set => level = value; }
        /// <summary>
        /// 最大等级
        /// </summary>
        public int MaxLevel { get => maxLevel; set => maxLevel = value; }
        /// <summary>
        /// 经验值
        /// </summary>
        public int Exp { get => exp; set => exp = value; }
        /// <summary>
        /// 最大经验值
        /// </summary>
        public int MaxExp { get => maxExp; set => maxExp = value; }
        /// <summary>
        /// 子程序目录
        /// </summary>
        public List<string> SubList { get => subList; set => subList = value; }
    }
    /// <summary>
    /// 磁盘信息
    /// </summary>
    [Serializable]
    public struct Disk
    {
        float _C, _E, _F;
        string id;

        public float C { get => _C; set => _C = value; }
        public float E { get => _E; set => _E = value; }
        public float F { get => _F; set => _F = value; }
        public string Id { get => id; set => id = value; }
    }

    /// <summary>
    /// 数据封装与操作
    /// </summary>
    public static class PlayerData
    {
        private static Player p;
        private static Disk d;

        static PlayerData()
        {
            p = new Player();
            d = new Disk();
            p.SubList = new List<string>();
        }

        private const string extensionName = ".SAV";
        private const string path = @"GAME_SAVE\";

        private const string SAV_PLAYER = "INFO_PLAYER" + extensionName;
        private const string SAV_DISK = "INFO_DISK" + extensionName;

        private const string HEDS_ROOT = @"HEDS\";
        private const string HEDS_DISK_ROOT = HEDS_ROOT + @"DISK\";
        private const string HEDS_DISK_C = HEDS_DISK_ROOT + @"C\";
        private const string HEDS_DISK_E = HEDS_DISK_ROOT + @"E\";
        private const string HEDS_DISK_F = HEDS_DISK_ROOT + @"F\";
        private const string HEDS_MAIL = HEDS_ROOT + @"MAIL\";

        /// <summary>
        /// 创建新玩家存档文件
        /// </summary>
        /// <param name="name"></param>
        /// <param name="player"></param>
        /// <param name="disk"></param>
        public static void CreateNewPlayerObject(string name, Player player, Disk disk)
        {
            System.IO.Directory.CreateDirectory(path + name.ToUpper());
            System.IO.Directory.CreateDirectory(path + name.ToUpper() + @"\" + HEDS_ROOT);
            System.IO.Directory.CreateDirectory(path + name.ToUpper() + @"\" + HEDS_DISK_ROOT);
            System.IO.Directory.CreateDirectory(path + name.ToUpper() + @"\" + HEDS_DISK_C);
            System.IO.Directory.CreateDirectory(path + name.ToUpper() + @"\" + HEDS_DISK_E);
            System.IO.Directory.CreateDirectory(path + name.ToUpper() + @"\" + HEDS_DISK_F);
            System.IO.Directory.CreateDirectory(path + name.ToUpper() + @"\" + HEDS_MAIL);
            FILE.Create(path + name.ToUpper() + @"\" + SAV_PLAYER, player);
            FILE.Create(path + name.ToUpper() + @"\" + SAV_DISK, disk);
        }

        /// <summary>
        /// 保存游戏
        /// </summary>
        /// <param name="name">用户名（将用于创建存档文件夹与存档文件）</param>
        public static void SaveGame(string name, Player player, Disk disk)
        {
            FILE.Create(path + name.ToUpper() + @"\" + SAV_PLAYER, player);
            FILE.Create(path + name.ToUpper() + @"\" + SAV_DISK, disk);
        }


        #region DEV_FUNCTION
        /// <summary>
        /// 读取玩家存档对象信息
        /// </summary>
        /// <param name="name"></param>
        /// <param name="SAV"></param>
        public static void DEV_Load(string name, Player SAV)
        {
            SAV = (Player)FILE.ReadObject(path + name.ToUpper() + @"\" + SAV_PLAYER);
            Console.WriteLine(SAV.UserName);
            Console.WriteLine(SAV.NickName);
        }
        /// <summary>
        /// 读取TEXT文件信息
        /// </summary>
        /// <param name="path"></param>
        public static void DEV_Load_TEXT(string path)
        {
            TEXT text = new TEXT();
            text = (TEXT)FILE.ReadObject(path);
            Console.WriteLine(text.Size);
            Console.WriteLine(text.Info);
            Console.WriteLine(text.Time);
            Console.WriteLine(text.Name);
            Console.WriteLine(text.Body);
        }
        /// <summary>
        /// 创立玩家对象信息
        /// </summary>
        public static void DEV_Create_Player()
        {
            d.C = 128f;
            d.E = 64f;
            d.F = 64f;
            p.UserName = "YANG";
            p.NickName = "NULL";
            p.Hp = 100;
            p.MaxHp = 100;
            p.Exp = 0;
            p.MaxExp = 50;
            p.Level = 1;
            p.MaxLevel = 10;
            p.PassWord = "12345";
            CreateNewPlayerObject(p.UserName, p, d);
            DEV_Install_SUB("CLS", 0, 1.368f);
            DEV_Install_SUB("HELP", 0, 1.368f);
            DEV_Install_SUB("FILE", 0, 1.368f);
            DEV_Install_SUB("INFO", 0, 1.368f);


            DEV_Uninstall_SUB("cls");
            DEV_Uninstall_SUB("info");
            DEV_Uninstall_SUB("file");
            DEV_Uninstall_SUB("help");

            Printer.Print("\n当前磁盘余量:\t\t", color:ConsoleColor.Green);
            DEV_INFO_DISK();
        }
        /// <summary>
        /// 安装子程序
        /// </summary>
        /// <param name="name"></param>
        /// <param name="id"></param>
        /// <param name="size"></param>
        public static void DEV_Install_SUB(string name, int id, float size)
        {
            SUB sub = new SUB();
            sub.Name = name;
            sub.Id = id;
            sub.Size = size;
            p.SubList.Add(name);
            d.C -= sub.Size;
            FILE.Create(path + p.UserName.ToUpper() + @"\" + sub.Path+sub.Name, sub);
            Printer.Print(">增加了子程序" + sub.Name + "\t", color: ConsoleColor.Green);
            DEV_INFO_DISK();
            DEV_LIST_PROGRAM();
        }
        /// <summary>
        /// 移除子程序
        /// </summary>
        /// <param name="name"></param>
        public static void DEV_Uninstall_SUB(string name)
        {
            SUB sub = new SUB();
            sub = (SUB)FILE.ReadObject(path+p.UserName.ToUpper() + @"\" + HEDS_DISK_C + name.ToUpper() + ".SUB");
            d.C += sub.Size;
            Printer.Print("\n>移除了子程序" + sub.Name + "归还了 "+sub.Size+" 存储单元\n", color: ConsoleColor.Green);
            p.SubList.Remove(name.ToUpper());
            FILE.Delete(p.UserName.ToUpper() + @"\" + HEDS_DISK_C + name.ToUpper() + ".SUB");
            DEV_INFO_DISK();
            DEV_LIST_PROGRAM();
        }
        public static void DEV_INFO_DISK()
        {
            Console.WriteLine("C:{0}\tE:{1}\tF:{2}",d.C, d.E, d.F);
        }

        /// <summary>
        /// 遍历子程序列表
        /// </summary>
        public static void DEV_LIST_PROGRAM()
        {
            Printer.Print("SUB LIST:\n");
            foreach (var data in p.SubList)
            {
                Printer.Print(data + "\n");
            }
        }
        #endregion
    }
}
