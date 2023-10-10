using Microsoft.VisualStudio.TestTools.UnitTesting;
using Denzi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Denzi.Tests
{
    [TestClass()]
    public class PauseTests
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        bool IsPlay = false;
        bool IsPause = false;
        public void PlayerIsPlay()
        {
            mediaPlayer.Play();
            IsPlay = true;
        }
        public void PlayerIsPause()
        {
            mediaPlayer.Pause();
            IsPause = true;
        }
        [TestMethod()]
        public void Button_pauseTest()
        {
            List<string> paths = new List<string>();

            string track = "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Dorozhka_4_ - _dlitelnost - 3.23.mp3";
            if (track.EndsWith(".mp3"))
            {
                paths.Add(track);
                mediaPlayer.Open(new Uri(paths[0]));
                PlayerIsPlay();
            }
            if (IsPlay)
            {
                PlayerIsPause();
                if(IsPause)
                {
                    Assert.IsTrue(IsPlay, "Аудиофайл на паузе");
                }
                else
                {
                    Assert.IsFalse(IsPause);
                }
            }
            else
            {
                Assert.IsFalse(IsPlay);
            }
        }
    }
}