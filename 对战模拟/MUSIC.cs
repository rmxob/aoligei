using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;
using System.Runtime.InteropServices;
using System.Threading;

namespace 对战模拟
{
 public class MUSIC
    {
        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        [DllImport("winmm.dll")]
        public static extern uint mciSendString(string lpstrCommand, string lpstrReturnString, uint uReturnLength, uint hWndCallback);

        public void PlayMusic()
        {
            try
            {
                mciSendString(@"close temp_music", " ", 0, 0);
                //mciSendString(@"open " + p_FileName + " alias temp_music", " ", 0, 0);
                mciSendString(@"open """ + "音乐.mp3" + @""" alias temp_music", null, 0, 0);
                mciSendString(@"play temp_music", " ", 0, 0);
            }
            catch
            { }
        }
        public void PlayMusic1()
        {
            try
            {
                mciSendString(@"close temp_music", " ", 0, 0);
                //mciSendString(@"open " + p_FileName + " alias temp_music", " ", 0, 0);
                mciSendString(@"open """ + "音乐2.mp3" + @""" alias temp_music", null, 0, 0);
                mciSendString(@"play temp_music", " ", 0, 0);
            }
            catch
            { }
        }

        /// <summary>
        /// 停止当前音乐播放
        /// </summary>
        /// <param name="p_FileName">音乐文件名称</param>
        public void StopMusic(string p_FileName)
        {
            try
            {
                mciSendString(@"close " + p_FileName, " ", 0, 0);
            }
            catch { }
        }



    }
}
