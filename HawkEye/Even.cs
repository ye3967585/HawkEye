using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HawkEngine.IO;
using HawkEngine.Edit;
using System.IO;

namespace HawkEye.EvenManger
{
    /// <summary>
    /// 事件
    /// </summary>
    public class Even
    {
        TEXT text = new TEXT();
        ProgressBar progressBar = new ProgressBar();
        FormColum formColum = new FormColum();

        /// <summary>
        /// 注册新账户
        /// </summary>
        public void SignUpUser()
        {
            text.OutPutText("\n\n 接下来，将创建一份属于你的雇员档案，并上传至H.E.N.I.S.C.中央托管数据库中。",15,true);
        }
    }
}
