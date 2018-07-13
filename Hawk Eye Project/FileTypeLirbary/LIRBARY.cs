using System;

namespace FileTypeLirbary
{
    /// <summary>
    /// 所有文件的基本属性
    /// </summary>
    [Serializable]
    public class BASIC
    {
        private string name;
        private string extensionName;
        private string info;
        private float size;
        private DateTime time;

        /// <summary>
        /// 文件名
        /// </summary>
        public string Name { get => name.ToUpper() + ExtensionName.ToUpper(); set => name = value.ToUpper(); }
        /// <summary>
        /// 文件扩展名
        /// </summary>
        public string ExtensionName { get => extensionName.ToUpper(); protected set => extensionName = value.ToUpper(); }
        /// <summary>
        /// 文件类型描述
        /// </summary>
        public string Info { get => info.ToUpper(); protected set => info = value.ToUpper(); }
        /// <summary>
        /// 文件大小
        /// </summary>
        public float Size { get => size; set => size = value; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime Time { get => time; protected set => time = value; }

    }

    /// <summary>
    /// 文本文件
    /// </summary>
    [Serializable]
    public class TEXT : BASIC
    {
        public TEXT()
        {
            ExtensionName = ".TEXT";
            Time = DateTime.Now;
            Info = "TEXT FILE";
        }
        private string body;

        /// <summary>
        /// 内容
        /// </summary>
        public string Body { get => body.ToUpper(); set => body = value.ToUpper(); }
    }

    /// <summary>
    /// 邮件文件
    /// </summary>
    [Serializable]
    public class MAIL : BASIC
    {
        public MAIL()
        {
            ExtensionName = ".MAIL";
            Time = DateTime.Now;
            Info = "MAIL FILE";
        }

        private string title;
        private string body;
        private string address;

        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get => title.ToUpper(); set => title = value; }
        /// <summary>
        /// 内容
        /// </summary>
        public string Body { get => body.ToUpper(); set => body = value; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get => address.ToUpper(); set => address = value; }
    }

    /// <summary>
    /// 图形文件
    /// </summary>
    [Serializable]
    public class IMAGE : BASIC
    {
        public IMAGE()
        {
            ExtensionName = ".IMAGE";
            Time = DateTime.Now;
            Info = "MAIL FILE";
        }

        private string source;
        private int hight;
        private int width;

        /// <summary>
        /// 源文件
        /// </summary>
        public string Source { get => source; set => source = value; }
        /// <summary>
        /// 高度
        /// </summary>
        public int Hight { get => hight; set => hight = value; }
        /// <summary>
        /// 宽度
        /// </summary>
        public int Width { get => width; set => width = value; }
    }

    /// <summary>
    /// 子程序
    /// </summary>
    [Serializable]
    public class SUB : BASIC
    {
        private string subName;
        private int id;
        private const string path = @"HEDS\DISK\C\";


        public SUB()
        {
            ExtensionName = ".SUB";
            Time = DateTime.Now;
            Info = "PROGRAM";
        }

        /// <summary>
        /// 子程序名称
        /// </summary>
        public string SubName { get => subName; set => subName = value; }
        /// <summary>
        /// 子程序ID
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// 子程序固定位置
        /// </summary>
        public string Path => path;
    }
}
