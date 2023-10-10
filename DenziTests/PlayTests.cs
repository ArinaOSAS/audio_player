using Denzi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace Denzi.Tests
{
    [TestClass()]
    public class PlayTests
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        bool IsPlay = false;
        public void PlayerIsPlay()
        {
            mediaPlayer.Play();
            IsPlay = true;
        }
        [TestMethod()]
        public void Button_playTest()
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
                Assert.IsTrue(IsPlay, "Аудиофайл играет");
            }
            else
            {
                Assert.IsFalse(IsPlay);
            }
        }
    }
}
