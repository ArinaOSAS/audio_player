using Microsoft.VisualStudio.TestTools.UnitTesting;
using Denzi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Denzi.Tests
{
    [TestClass()]
    public class SearchTrackTests
    {
        [TestMethod()]
        public void Search_track_TextChangedTest()
        {
            List<string> paths = new List<string>();
            string path = "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка";
            List<string> track = new List<string>()
            {
                path + "\\" + "Ёлка – Прованс.mp3",
                path + "\\" + "Dorozhka_4_ - _dlitelnost - 3.23.mp3",
                path + "\\" + "samira_-_skazhi_mne_mam_muzati.net.mp3",
                path + "\\" + "ab.txt"
            };
            List<string> search = new List<string>()
            {
                "Ёлка",
                "ghdgfhtjkdl;s",
                "dlitelnost",
                "3.23"
            };

            for (int i = 0; i < track.Count; i++)
            {
                if (track[i].EndsWith(".mp3"))
                {
                    paths.Add(track[i]); 
                }
            }

            for (int j = 0; j < paths.Count; j++)
            {
                for (int a = 0; a < search.Count; a++)
                {
                    if(paths[j].Contains(search[a]))
                    {
                        Assert.IsTrue(true);
                        break;
                    }
                    else
                    {
                        Assert.IsFalse(false);
                    }
                }
            }
        }
    }
}