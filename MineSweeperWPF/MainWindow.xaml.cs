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

            GameWindow gameWindow = new GameWindow();
            this.Close();
            gameWindow.ShowDialog();
            


        }

        private void Normal_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Hard_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
