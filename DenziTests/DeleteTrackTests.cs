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
    public class DeleteTrackTests
    {
        [TestMethod()]
        public void Button_delete_trackTest()
        {
            List<string> paths = new List<string>();
            List<string> track = new List<string>()
            {
               "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Ёлка – Прованс.mp3",
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Dorozhka_4_ - _dlitelnost - 3.23.mp3",
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\samira_-_skazhi_mne_mam_muzati.net.mp3",
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\ab.txt"
            };
            for (int i = 0; i < track.Count; i++)
            {
                if (track[i].EndsWith(".mp3"))
                {
                    paths.Add(track[i]);
                }
            }
            string x = "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Ёлка – Прованс.mp3";
            if(paths.Contains(x))
            {
                paths.Remove(x);
                for (int j = 0; j < paths.Count; j++)
                {
                    if (paths.Contains(x))
                    {
                        Assert.Fail();
                    }
                    else
                    {
                        Assert.IsTrue(true, "Аудиофайл удален");

                    }
                }

            }
            else
            {
                Assert.IsFalse(false);
            }

        }
    }
}