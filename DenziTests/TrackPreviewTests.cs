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
    public class TrackPreviewTests
    {
        [TestMethod()]
        public void Button_previewTest()
        {
            MediaPlayer mediaPlayer = new MediaPlayer();
            List<string> paths = new List<string>();
            List<string> track = new List<string>()
            {
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Ёлка – Прованс.mp3",
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Dorozhka_4_ - _dlitelnost - 3.23.mp3",
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\samira_-_skazhi_mne_mam_muzati.net.mp3"
            };
            for (int i = 0; i < track.Count; i++)
            {
                if (track[i].EndsWith(".mp3"))
                {
                    paths.Add(track[i]);
                }
            }
            int x = 5;
            if (x > 0 && x < paths.Count)
            {
                mediaPlayer.Open(new Uri(paths[x]));
                mediaPlayer.Play();
                mediaPlayer.Open(new Uri(paths[x - 1]));
                mediaPlayer.Play();
                if (mediaPlayer.Source == new Uri(paths[x - 1]))
                {
                    Assert.IsTrue(true, "Играет предыдущий айдиофайл");
                }
                else
                {
                    Assert.Fail();
                }
            }
            else if (x == 0 )
            {
                mediaPlayer.Open(new Uri(paths[x]));
                mediaPlayer.Play();
                mediaPlayer.Open(new Uri(paths[paths.Count - 1]));
                mediaPlayer.Play();
                if (mediaPlayer.Source == new Uri(paths[paths.Count - 1]))
                {
                    Assert.IsTrue(true, "Играет предыдущий айдиофайл");
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.IsFalse(false);
            }
        }
    }
}