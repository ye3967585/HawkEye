
/*********************************************************************************************************
 * Hawk Enginer - IO 文件操作与管理系统 V0.01  
 * By ChihHuCheYeh
 * 基于.net对文件的操作基础上根据个人需求进行改进和修改，对文件的增删，访问提供了多种途径和更为
 * 简单明瞭的的解决方案。
 *********************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace HawkEnginer.IO
{
    /// <summary>
    /// 文件的操作与管理。
    /// </summary>
    public class FILE
    {
        DirectoryInfo dir;
        Text text = new Text();
        string Log;  //日志

        /*********************** 添加与删除 ************************/
        /// <summary>
        /// 根据输入名称创建新的路径，如果已经存在相同的路径，则会自动覆盖
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="Name">名称</param>
        public void CreateDir(string Path, string Name)
        {
            /************ 创建文件夹 ************/
            dir = new DirectoryInfo(Path);         //指定路径
            dir.CreateSubdirectory(Name);          //创建玩家档案文件夹
            /************ 添加信息至日志 ************/
            Log += DateTime.Now + "---创建路径 : " + Path + "\\" + Name + "\n";
        }
        /// <summary>
        /// 创建文本文件,并输出到指定路径,如果文件已经存在，则会自动覆盖。
        /// </summary>
        /// <param name="Text">文本</param>
        /// <param name="Path">路径</param>
        /// <param name="FileName">文件名</param>
        public void CreateTextData(string Text, string Path, string FileName)
        {
            StreamWriter TextData = new StreamWriter(Path + FileName);
            TextData.WriteLine(Text);
            TextData.Close();
        }
        /// <summary>
        /// 创建能保存对象实例数据的加密文件,并输出到指定路径,如果文件已经存在，则会自动覆盖。
        /// </summary>
        /// <param name="Object">保存的对象</param>
        /// <param name="Path">路径</param>
        /// <param name="FileName">文件名</param>
        public void CreateObjectData(object Object, string Path, string FileName)
        {
            /************ 创建文件流 ************/
            FileStream Stream = new FileStream(Path + FileName, FileMode.Create);
            /************ 序列化对象数据至文件流中 ************/
            BinaryFormatter PlauerDataBFormatter = new BinaryFormatter();
            PlauerDataBFormatter.Serialize(Stream, Object);
            Stream.Close();
        }
        /// <summary>
        /// 删除路径，包含此路径下的所有文件。
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="Name">名称</param>
        public bool DelDir(string Path, string Name)
        {
            /************ 删除路径 ************/
            if (File.Exists(Path + Name)) //如果路径存在，则删除。
            {
                File.Delete(Path + Name);
                return true;  //向外界返回 true。
            }
            else
            {
                return false; //否则返回 false。
            }
        }
        /// <summary>
        /// 删除文件，随后向外界告知文件是否被删除。
        /// </summary>
        /// <param name="Path">文件名</param>
        /// <param name="FileName">路径</param>
        public bool DelFile(string Path, string FileName)
        {
            /************ 删除文件 ************/
            if (File.Exists(Path + FileName)) //如果文件存在，则删除。
            {
                File.Delete(Path + FileName);
                return true;  //向外界返回 true。
            }
            else
            {
                return false; //否则返回 false。
            }
        }

        /*********************** 获取与访问 ************************/
        /// <summary>
        /// 获取文本文件中的文本。
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="FileName">文件名</param>
        /// <returns>文件内容</returns>
        public string GetTextData(string Path, string FileName)
        {
            /************ 创建文件读取流 ************/
            StreamReader TextData = new StreamReader(Path + FileName);
            string Text = TextData.ReadLine();  //获取文本文件内容
            TextData.Close();
            return Text;  //向外界返回
        }
        /// <summary>
        /// 通过索引号获取文本文件中的文本。
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Index"></param>
        /// <param name="PID"></param>
        /// <returns>指定文本</returns>
        public string GetTextDataIndexPID(string[] Index, int PID, string Path = null)
        {
            //Index[]已经储存了所有的文件列表，访问它的元素即可获取单独的文件名
            string Text = GetTextData(Path, Index[PID]);//如果存在，获取文件文本。
            return Text; //返回外界
        }
        /// <summary>
        /// 获取保存对象数据文件中的对象。
        /// </summary>
        /// <param name="Path">路径</param>
        /// <param name="FileName">文件名</param>
        /// <returns>文件内容</returns>
        public object GetObjectData(string Path, string FileName)
        {
            object _Object;   //用于接收对象数据的变量
            /************ 创建文件流 ************/
            FileStream Stream = new FileStream(Path + FileName, FileMode.Open);
            /************ 从文件流中反序列化 ************/
            BinaryFormatter bFormat = new BinaryFormatter();
            _Object = bFormat.Deserialize(Stream); //接收对象数据
            Stream.Close();
            return _Object;  //向外界返回
        }
        /// <summary>
        /// 获取路径索引目录。
        /// </summary>
        /// <param name="Path">路径</param>
        /// <returns>文件索引目录表</returns>
        public string[] GetDirIndex(string Path)
        {
            string[] Index;  //用于接收索引的字符串数组
            if (Directory.Exists(Path)) //判断路径是否存在
            {
                Index = Directory.GetDirectories(Path); //如果存在，获取索引。
                return Index; //返回外界
            }
            else
            {
                return null; //否则返回null。
            }
        }
        /// <summary>
        /// 通过索引号获取路径。
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Index"></param>
        /// <param name="PID"></param>
        /// <returns>路径索引目录表</returns>
        public string[] GetDirIndexPID(string[] Index, int PID)
        {
            Index = Directory.GetDirectories(Index[PID] + "\\"); //如果存在，获取索引。
            return Index; //返回外界
        }
        /// <summary>
        /// 获取文件索引目录。
        /// </summary>
        /// <param name="Path"></param>
        /// <returns>文件索引目录表</returns>
        public string[] GetFileIndex(string Path)
        {
            string[] Index;  //用于接收索引的字符串数组
            if (Directory.Exists(Path)) //判断路径是否存在
            {

                Index = Directory.GetFiles(Path); //如果存在，获取索引。
                return Index; //返回外界
            }
            else
            {
                return null; //否则返回null。
            }
        }
        /// <summary>
        /// 通过索引号获取文件。
        /// </summary>
        /// <param name="Index"></param>
        /// <param name="PID"></param>
        /// <returns>文件索引目录表</returns>
        public string[] GetFileIndexPID(string[] Index, int PID)
        {
            //Index[]已经储存了所有的文件列表，访问它的元素即可获取单独的文件名
            Index = Directory.GetFiles(Index[PID] + "\\"); //如果存在，获取索引。
            return Index; //返回外界
        }


        /*********************** 移动与复制 ************************/
        /// <summary>
        /// 移动文件至目标路径，随后向外界告知文件是否被移动。
        /// </summary>
        /// <param name="SourePath">原路径</param>
        /// <param name="FileName">文件名</param>
        /// <param name="ObjectPath">目标路径</param>
        /// <returns></returns>
        public bool MoveFile(string SourePath, string FileName, string ObjectPath)
        {
            /************ 移动文件 ************/
            if (File.Exists(SourePath + FileName)) //如果文件存在，则删除。
            {
                File.Move(SourePath + FileName, ObjectPath + FileName);
                return true;  //向外界返回 true。
            }
            else
            {
                return false; //否则返回 false。
            }

        }
        /// <summary>
        /// 复制文件副本至指定路径，如果目标路径下文件已经存在，则会自动覆盖，随后向外界告知文件是否被复制。
        /// </summary>
        /// <param name="SourePath">原路径</param>
        /// <param name="FileName">文件名</param>
        /// <param name="ObjectPath">目标路径</param>
        /// <returns></returns>
        public bool CopyFile(string SourePath, string FileName, string ObjectPath)
        {
            /************ 复制文件 ************/
            if (File.Exists(SourePath + FileName)) //如果文件存在，则删除。
            {
                File.Copy(SourePath + FileName, ObjectPath + FileName, true);
                return true;  //向外界返回 true。
            }
            else
            {
                return false; //否则返回 false。
            }

        }
    }
}
