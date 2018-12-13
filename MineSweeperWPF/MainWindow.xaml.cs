using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NAudio;
using NAudio.Wave;



namespace MineSweeperWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer soundPlayer = new SoundPlayer();
     
        /*IWavePlayer waveOutDevice = new WaveOut();
        IWavePlayer waveOutDevice2 = new WaveOut();
        AudioFileReader audioFileReader = new AudioFileReader(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\Modern_Warriors.mp3");
        AudioFileReader audioFileReader2 = new AudioFileReader(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\oceanSound.wav");*/

        public MainWindow()
        {
            InitializeComponent();

            
            soundPlayer.Stream = File.OpenRead(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\Modern_Warriors.wav");
            soundPlayer.PlayLooping();

        }

        /*private void Start_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.ShowDialog();
        }*/

        private void Easy_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Stop();
            //waveOutDevice.Stop();
            //audioFileReader.Dispose();
            //waveOutDevice.Dispose();
            int gameLevelValue = 1;
            GameWindow gameWindow = new GameWindow(gameLevelValue, 0, 0, 0);
            this.Close();
            gameWindow.ShowDialog();
            
        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Stop();
            int gameLevelValue = 2;
            GameWindow gameWindow = new GameWindow(gameLevelValue, 0, 0, 0);
            
            this.Close();
            gameWindow.ShowDialog();

        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Stop();
            int gameLevelValue = 3;
            GameWindow gameWindow = new GameWindow(gameLevelValue, 0, 0, 0);
            this.Close();
            gameWindow.ShowDialog();

        }

        private void Custom_Click(object sender, RoutedEventArgs e)
        {
            soundPlayer.Stop();
            CustomWindow customWindow = new CustomWindow();
            //Easy.IsEnabled = false;
            //Normal.IsEnabled = false;
            //Hard.IsEnabled = false;
            this.Close();
            customWindow.ShowDialog();
           
          
        }
    }
}
