using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Denzi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;
            timer.Start();
        }
        //Сворачивание окна
        private void Button_minimized(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //Закрытие окна
        private void Button_close(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Перемещение окна
        private void WrapPanel_mouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        MediaPlayer mediaPlayer = new MediaPlayer();
        private bool mediaPlayerIsPlaying = false;
        private bool userIsDraggingSlider = false;
        List<string> paths = new List<string>();
        List<string> files = new List<string>();
        List<string> song_names = new List<string>();
        

        bool check = true;

        //Добавление файлов
        public void Button_open_file(object sender, RoutedEventArgs e)
        {
            if (check == true)
            {
                mediaPlayer.Stop();
                List_track.Items.Clear();
                song_names.Clear();
                files.Clear();
                paths.Clear();
                File_play.Text = "";
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                };
                bool? dialogOK = fileDialog.ShowDialog();
                if (dialogOK == true)
                {
                    for (int j = 0; j < fileDialog.FileNames.Length; j++)
                    {
                        if (fileDialog.FileNames[j].EndsWith(".mp3"))
                        {
                            files.Add(fileDialog.SafeFileNames[j]);
                            paths.Add(fileDialog.FileNames[j]);
                        }

                    }
                    files.Sort();
                    paths.Sort();
                    for (int j = 0; j < files.Count; j++)
                    {
                        List_track.Items.Add(files[j].Substring(0, files[j].Length - 4));
                        song_names.Add(files[j].Substring(0, files[j].Length - 4));

                    }
                    song_names.Sort();



                }
                check = false;
            }
            else
            {
                mediaPlayer.Stop();
                List_track.Items.Clear();
                song_names.Clear();
                files.Clear();
                paths.Clear();
                File_play.Text = "";
                OpenFileDialog fileDialog = new OpenFileDialog
                {
                    Multiselect = true,
                };
                bool? dialogOK = fileDialog.ShowDialog();
                if (dialogOK == true)
                {
                    for (int j = 0; j < fileDialog.FileNames.Length; j++)
                    {
                        if (fileDialog.FileNames[j].EndsWith(".mp3"))
                        {
                            files.Add(fileDialog.SafeFileNames[j]);
                            paths.Add(fileDialog.FileNames[j]);
                        }

                    }
                    files.Sort();
                    paths.Sort();
                    for (int j = 0; j < files.Count; j++)
                    {
                        List_track.Items.Add(files[j].Substring(0, files[j].Length - 4));
                        song_names.Add(files[j].Substring(0, files[j].Length - 4));

                    }
                    song_names.Sort();



                    check = true;
                }

            }
            
        }
        //Пауза
        public void Button_pause(object sender, RoutedEventArgs e)
        {
            if (List_track.Items != null && List_track.SelectedItem != null )
            {

                mediaPlayer.Pause();
            }
        }

        public void Timer_Tick(object? sender, EventArgs e)
        {
            if ((mediaPlayer.Source != null) && (mediaPlayer.NaturalDuration.HasTimeSpan) && (!userIsDraggingSlider))
            {
                sliProgress.Minimum = 0;
                sliProgress.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                sliProgress.Value = mediaPlayer.Position.TotalSeconds;
            }
        }

        //Воспроизведение при двойном клике
        public void List_track_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (List_track.Items.Count != 0)
            {
                if (List_track.SelectedItem != null)
                {
                    mediaPlayer.Open(new Uri(paths[List_track.SelectedIndex]));
                    mediaPlayer.MediaEnded += MediaEnded_next;
                    mediaPlayer.MediaOpened += MediaOpened_Slider;
                    File_play.Text = files[List_track.SelectedIndex].Substring(0, files[List_track.SelectedIndex].Length - 4);
                    mediaPlayer.Play();

                }
            }
            
        }

        public void MediaOpened_Slider(object sender, EventArgs e)
        {
            sliProgress.Minimum = 0;
            sliProgress.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
        }

        public void MediaEnded_next(object sender, EventArgs e)
        {
            mediaPlayer.Stop();
            if (List_track.SelectedIndex < List_track.Items.Count - 1)
            {
                List_track.SelectedIndex = List_track.SelectedIndex + 1;
                mediaPlayer.Open(new Uri(paths[List_track.SelectedIndex]));
                mediaPlayer.MediaOpened += MediaOpened_Slider;
                mediaPlayer.MediaEnded += MediaEnded_next;
                File_play.Text = files[List_track.SelectedIndex].Substring(0, files[List_track.SelectedIndex].Length - 4);
                mediaPlayer.Play();
            }
            else
            {
                List_track.SelectedIndex = 0;
                mediaPlayer.Open(new Uri(paths[List_track.SelectedIndex]));
                mediaPlayer.MediaOpened += MediaOpened_Slider;
                mediaPlayer.MediaEnded += MediaEnded_next;
                File_play.Text = files[List_track.SelectedIndex].Substring(0, files[List_track.SelectedIndex].Length - 4);
                mediaPlayer.Play();
            }

        }


        //Следующий трек
        public void Button_next(object sender, RoutedEventArgs e)
        {
            if (List_track.Items.Count != 0)
            {
                if (List_track.SelectedIndex < List_track.Items.Count - 1)
                {
                    List_track.SelectedIndex = List_track.SelectedIndex + 1;
                    mediaPlayer.Open(new Uri(paths[List_track.SelectedIndex]));
                    mediaPlayer.MediaOpened += MediaOpened_Slider;
                    mediaPlayer.MediaEnded += MediaEnded_next;
                    File_play.Text = files[List_track.SelectedIndex].Substring(0, files[List_track.SelectedIndex].Length - 4);
                    mediaPlayer.Play();
                }
                else
                {
                    List_track.SelectedIndex = 0;
                    mediaPlayer.Open(new Uri(paths[List_track.SelectedIndex]));
                    mediaPlayer.MediaOpened += MediaOpened_Slider;
                    mediaPlayer.MediaEnded += MediaEnded_next;
                    File_play.Text = files[List_track.SelectedIndex].Substring(0, files[List_track.SelectedIndex].Length - 4);
                    mediaPlayer.Play();
                }

            }

        }

        //Предыдущий трек
        public void Button_preview(object sender, RoutedEventArgs e)
        {

            if (List_track.Items.Count != 0)
            {
                

                if (List_track.SelectedIndex > 0)
                {
                    List_track.SelectedIndex = List_track.SelectedIndex - 1;
                    mediaPlayer.Open(new Uri(paths[List_track.SelectedIndex]));
                    mediaPlayer.MediaOpened += MediaOpened_Slider;
                    mediaPlayer.MediaEnded += MediaEnded_next;
                    File_play.Text = files[List_track.SelectedIndex].Substring(0, files[List_track.SelectedIndex].Length - 4);
                    mediaPlayer.Play();
                }
                else if (List_track.SelectedIndex < 1)
                {
                    List_track.SelectedIndex = List_track.Items.Count - 1;
                    mediaPlayer.Open(new Uri(paths[List_track.SelectedIndex]));
                    mediaPlayer.MediaOpened += MediaOpened_Slider;
                    mediaPlayer.MediaEnded += MediaEnded_next;
                    File_play.Text = files[List_track.SelectedIndex].Substring(0, files[List_track.SelectedIndex].Length - 4);
                    mediaPlayer.Play();
                }
            }
        }

        //Регулировка звука
        public void Slider_volume_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            mediaPlayer.Volume = (double)Slider_volume.Value;
        }

        //Регулировка шкалы воспроизведения
        public void Slider_position_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            TimeSpan time = new TimeSpan(0, 0, Convert.ToInt32(Math.Round(sliProgress.Value))); 
            mediaPlayer.Position = time; 
        }

        //Поиск
        public void Search_track_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (List_track == null)
            {
                return;
            }
            List_track.Items.Clear();
            song_names.ForEach(s =>
            {
                if (s == "")
                {
                    List_track.Items.Add(s);
                }
                else if (s.Contains(Search_track.Text))
                {
                    List_track.Items.Add(s);
                }
            });

        }


        //Добавление файла
        public void Buttom_add_track(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Multiselect = false,
            };
            bool? dialogOK = fileDialog.ShowDialog();
            if (dialogOK == true)
            {
                if (fileDialog.FileNames[0].EndsWith(".mp3"))
                {
                    files.Add(fileDialog.SafeFileNames[0]);
                    paths.Add(fileDialog.FileNames[0]);
                    
                }
                files.Sort();
                paths.Sort();
                List_track.Items.Clear();
                song_names.Clear();
                for (int i = 0; i < files.Count; i++)
                {
                    List_track.Items.Add(files[i].Substring(0, files[i].Length - 4));
                   song_names.Add(files[i].Substring(0, files[i].Length - 4));
                }

            }
        }

        //Удаление файла
        public void Button_delete_track(object sender, RoutedEventArgs e)
        {
            if (List_track.SelectedItem != null)
            {
                if (File_play.Text == List_track.SelectedItem.ToString())
                {
                    mediaPlayer.Stop();
                    File_play.Text = "";
                }
                files.RemoveAt(List_track.SelectedIndex);
                paths.RemoveAt(List_track.SelectedIndex);
                files.Sort();
                paths.Sort();
                List_track.Items.Clear();
                song_names.Clear();
                for (int i = 0; i < files.Count; i++)
                {
                    List_track.Items.Add(files[i].Substring(0, files[i].Length - 4));
                    song_names.Add(files[i].Substring(0, files[i].Length - 4));
                }                
            }


        }

        //Воспроизведение трека
        public void Button_play(object sender, RoutedEventArgs e)
        {
            if (List_track.Items != null && List_track.SelectedItem != null)
            {
                mediaPlayer.Play();
                mediaPlayer.MediaOpened += MediaOpened_Slider;
                mediaPlayer.MediaEnded += MediaEnded_next;
                mediaPlayerIsPlaying = true;
             
            }
        }

        bool check2 = true;

        //Смена темы
        public void Button_color(object sender, RoutedEventArgs e)
        {
            if (check2 == true)
            {
                var uri = new Uri(@"Resource/Black.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                check2 = false;
            }
            else
            {
                var uri2 = new Uri(@"Resource/Write.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary2 = Application.LoadComponent(uri2) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
                check2 = true;
            }
        }
        bool check3 = true;

        //Смена языка
        public void Button_language(object sender, RoutedEventArgs e)
        {
            if (check3 == true)
            {
                var uri2 = new Uri(@"Resource/English.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary2 = Application.LoadComponent(uri2) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary2);
                check3 = false;
            }
            else
            {
                var uri = new Uri(@"Resource/Russian.xaml", UriKind.Relative);
                ResourceDictionary resourceDictionary = Application.LoadComponent(uri) as ResourceDictionary;
                Application.Current.Resources.MergedDictionaries.Add(resourceDictionary);
                check3 = true;
            }
        }
        bool check4 = true;

        //Сортировка
        public void Button_sorting(object sender, RoutedEventArgs e)
        {
            if (files != null && paths != null)
            {
                if (check4 == true)
                {
                    List_track.Items.Clear();
                    song_names.Clear();
                    files.Reverse();
                    paths.Reverse();
                    for (int i = 0; i < files.Count; i++)
                    {
                        List_track.Items.Add(files[i]);
                        song_names.Add(files[i]);
                    }
                    check4 = false;
                }
                else
                {
                    List_track.Items.Clear();
                    song_names.Clear();
                    files.Reverse();
                    paths.Reverse();
                    for (int i = 0; i < files.Count; i++)
                    {
                        List_track.Items.Add(files[i]);
                        song_names.Add(files[i]);
                    }
                    check4 = true;
                }

            }
        }

        public void Grid_MouseWheel(object sender, MouseWheelEventArgs e)
        {
             mediaPlayer.Volume += (e.Delta > 0) ? 0.1 : -0.1;
        }
        public void sliProgress_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ((Slider)sender).SelectionEnd = e.NewValue;
            lblProgressStatus.Text = TimeSpan.FromSeconds(sliProgress.Value).ToString(@"hh\:mm\:ss");
        }
        public void sliProgress_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            userIsDraggingSlider = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(sliProgress.Value);
        }
        public void sliProgress_DragStarted(object sender, DragStartedEventArgs e)
        {
            userIsDraggingSlider = true;
        }
    }

}


