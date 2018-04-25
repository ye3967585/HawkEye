using HawkTools.Edit;
using HawkTools.IO.Data;
using HawkTools.IO.File;
using HawkTools.IO.Text;
using HawkEye.UserData;
using System;
using System.Threading;
using System.IO;
using HawkEye.HEDS.Files;
using HawkEye.EvenManger;
using System.Runtime.Serialization.Formatters.Binary;

namespace HawkEye.HEDS.Mail
{
    /// <summary>
    /// 邮件的基本结构
    /// </summary>
    [Serializable]
    public struct Mail
    {
        public string Title;       //标题
        public string Sender;      //发件人
        public string Content;     //内容
        public string Abstract;    //摘要
        public string Date;        //日期
        public string Time;        //时间
        public bool isEnclosure;   //是否带有附件
        public bool isUrgent;      //是否是紧急邮件
    }

    class MailSystem
    {
        bool isBreak;                                                               //是否结束了输入
        string Input;                                                               //接受用户输入
        string Name = File.ReadAllText("Game\\Save\\QuickLoadData.hawksav");        //获取玩家名
        string path;

        FormColum formColum;
        TEXT text;
        FILE file;
        DATA data;
        Even even;
        Mail mail;

        public MailSystem(string Name)
        {
            path = "Game\\Save\\" + Name + "\\HEDS\\Mail\\";
            even = new Even(Name);
            isBreak = false;
            text = new TEXT();
            file = new FILE();
            data = new DATA();
            formColum = new FormColum();
        }

        public void Command()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            while (!isBreak)
            {
                Console.Write("  {0}>SYSTEM\\MAIL\\{1}@hawk.com>", Name, Name);
                Input = Console.ReadLine();
                if (Input.Contains("list"))
                {
                    GetInboxList(Input);
                }
                else if (Input.Contains("read"))
                {
                    Input = data.CutString(Input, 4);
                    ReadMail(Input);
                }
                else if (Input.Contains("del"))
                {
                    Input = data.CutString(Input, 3);
                    file.DelFile(path, Input);
                }
                else if (Input == "exit")
                {
                    break;
                }
            }
        }

        /// <summary>
        /// 列出收件箱
        /// </summary>
        /// <param name="Input"></param>
        void GetInboxList(string Input)
        {
            if (Input.Contains("list"))
            {
                Console.WriteLine("\n  INBOX");//
                Console.WriteLine("\n  DATE\t\tTIME\t\tSENDER\t\tTITLE");
                string[] Index = file.GetFileIndex(path);
                for (int i = 0; i < Index.Length; i++)
                {
                    Thread.Sleep(30);
                    mail = (Mail)file.GetObjectData(path, Index[i].Substring(25));
                    if (mail.isUrgent)
                    {
                        text.OutPutColorText("  " + File.GetCreationTime(Index[i]).AddYears(-30).ToString("yyyy.M.d") + "\t" + File.GetCreationTime(Index[i]).ToString("HH:mm:ss") + "\t" + mail.Sender + "\t\t" + Index[i].Substring(25) + "\t", ConsoleColor.Red, ConsoleColor.Black, 1);
                    }
                    else if (mail.isEnclosure)
                    {
                        text.OutPutColorText("  " + File.GetCreationTime(Index[i]).AddYears(-30).ToString("yyyy.M.d") + "\t" + File.GetCreationTime(Index[i]).ToString("HH:mm:ss") + "\t" + mail.Sender + "\t\t" + Index[i].Substring(25) + "\t", ConsoleColor.Yellow, ConsoleColor.Black, 1);
                    }
                    else
                    {
                        text.OutPutColorText("  " + File.GetCreationTime(Index[i]).AddYears(-30).ToString("yyyy.M.d") + "\t" + File.GetCreationTime(Index[i]).ToString("HH:mm:ss") + "\t" + mail.Sender + "\t\t" + Index[i].Substring(25) + "\t", ConsoleColor.Green, ConsoleColor.Black, 1);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ERROR: 错误的参数或操作");
                Console.ForegroundColor = ConsoleColor.Green;
            }

        }

        /// <summary>
        /// 阅读邮件
        /// </summary>
        /// <param name="Input"></param>
        void ReadMail(string Input)
        {
            if (File.Exists(path + Input))
            {
                mail = (Mail)file.GetObjectData(path, Input);
                Console.WriteLine("\n  标题:\t\t{0}\n  发件人:\t{1}\n  内容:\n  {2}", mail.Title, mail.Sender, mail.Content);
                Console.WriteLine("\n\n  接收于:\t\t{0}/{1}", mail.Date, mail.Time);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("  ERROR: 不存在的邮件");
                Console.ForegroundColor = ConsoleColor.Green;
            }
        }

    }
}
