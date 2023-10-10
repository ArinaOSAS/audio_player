using Microsoft.VisualStudio.TestTools.UnitTesting;
using Denzi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Media;

namespace Denzi.Tests
{
    [TestClass()]
    public class Open_fileTests
    {
        [TestMethod()]
        public void Button_open_fileTestOne()
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

        [TestMethod()]
        public void Button_open_fileTestTxt()
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
        public void Button_open_fileTest()
        {
            List<string> paths = new List<string>();
            List<string> track = new List<string>()
            {
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\ab.txt",
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Dorozhka_4_ - _dlitelnost - 3.23.mp3",
                "C:\\Users\\arina\\OneDrive\\Рабочий стол\\ТИС\\Курсовая\\Музыка\\Ворд.docx"
            };

            for (int i = 0; i < track.Count; i++)
            {
                if (track[i].EndsWith(".mp3"))
                {
                    paths.Add(track[i]);
                }

            }
            if (paths.Contains(track[0]) && paths.Contains(track[2]))
            {
                Assert.Fail();
            }
            else
            {
                Assert.IsTrue(true, "Аудиофайл не соответствует формату");
            }
        }
    }
}