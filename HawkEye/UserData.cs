using System;

namespace HawkEye.UserData
{
    /// <summary>
    /// 是否结束
    /// </summary>
    enum State_isLive
    {
        Live, Death
    }

    /// <summary>
    /// 等级
    /// </summary>
    enum State_LeveName
    {
        A, B, C, D
    }

    /// <summary>
    /// 玩家信息
    /// </summary>
    [Serializable]
    public class PlayerData
    {
       
        /// <summary>
        /// Player Data
        /// </summary>
        public string Name;
        public string IP;
        public string LevelName;
        public string Password;
        public int Health;
        public int Level;
        public int MaxLevel;
        public int Exp;
        public int MaxExp;
    }

    /// <summary>
    /// 磁盘信息
    /// </summary>
    [Serializable]
    public class DiskInfo
    {
        /// <summary>
        /// Disk Info
        /// </summary>
        public int DISK_C;
        public int DISK_E;
        public int DISK_F;
        public string DiskCode;
    }
}
