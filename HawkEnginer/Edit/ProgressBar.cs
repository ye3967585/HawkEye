
/*********************************************************************************************************
 * Hawk Enginer - Edit 进度条 V0.01  
 * By ChihHuCheYeh
 * 此类继承于HawkEnginer.IO中的Text类，可以定制长度，色彩，填充物的进度条。
 *********************************************************************************************************/

using HawkEnginer.IO;
using System;

namespace HawkEnginer.Edit
{
    /// <summary>
    /// 进度条
    /// </summary>
    public class ProgressBar : Text
    {
        /// <summary>
        /// 绘制进度条
        /// </summary>
        /// <param name="Conut">进度条长度</param>
        /// <param name="Speed">进度条速度</param>
        /// <param name="Color">进度条颜色</param>
        /// <param name="ShowDraw">显示填充图形</param>
        /// <param name="Draw">填充图形样式</param>
        /// <param name="ForegroundColor">填充图形颜色</param>
        public void ShowProgressBar(int Count, int Speed, ConsoleColor Color, bool ShowDraw = false, string Draw = "■", ConsoleColor DrawColor = ConsoleColor.White)
        {

            if (ShowDraw)
            {
                for (int i = 0; i <= Count; i++)
                {
                    OutPutColorText(Draw, DrawColor, Color, Speed);
                }
            }
            else
            {
                for (int i = 0; i <= Count; i++)
                {
                    OutPutColorText("  ", DrawColor, Color, Speed);
                }
            }


        }
    }
}
