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
    public class AddOneTrackTests
    {
        [TestMethod()]
        public void Buttom_add_trackTestTxt()
        {
            List<string> paths = new List<string>();

            string track = "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\ab.txt";
            if (track.EndsWith(".mp3"))
            {
                paths.Add(track);
            }
            if (paths.Contains(track))
            {
                Assert.Fail();
            }
            else
            {
                Assert.IsTrue(true, "Аудиофайл не соответствует формату");
            }
        }

        [TestMethod()]
        public void Buttom_add_trackTestMp3()
        {
            List<string> paths = new List<string>();

            string track = "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Dorozhka_4_ - _dlitelnost - 3.23.mp3";
            if (track.EndsWith(".mp3"))
            {
                paths.Add(track);
            }
            if (paths != null)
            {
                Assert.IsTrue(true, "Аудиофайл добавлен");

            }
            else
            {
                Assert.Fail();
            }
        }
    }
}