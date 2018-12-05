using NAudio.Wave;
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
using System.Windows.Shapes;
using System.Timers;
using System.Windows.Threading;

namespace MineSweeperWPF
{
    /// <summary>
    /// Interaction logic for GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        int[,] board;
        int qtdBombs = 10;
        int timerIncrement = 0;
        //SoundPlayer soundPlayer = new SoundPlayer();
        //SoundPlayer sfxOcean = new SoundPlayer();

        public GameWindow()
        {
            InitializeComponent();
            Grid.SetRow(cellGrid, 3);
            int numColumn = 8;
            int numRow = 8;
            int threeBVValue = 100;
            string playerName = "";
            int WINDOW_WIDTH = 360;
            




            //Setting the level of dificult
            GameLevel myGameLevel = new GameLevel(1);
            GameBoard gameBoard =  new GameBoard(myGameLevel);
            board = gameBoard.Board;

            //Adding the values of row, columns, and qtdBombs for the selected leval
            numColumn = myGameLevel.columns;
            numRow = myGameLevel.rows;
            qtdBombs = myGameLevel.qtdBombs;

            //Setting UI info
            NumberOfMines.Content = qtdBombs;
            timerIncrement = 0;

            //GameOverInfo
            GameOverLogo.Visibility = Visibility.Hidden;
          



            //Checking the 3BV value for the Easy level
            while (threeBVValue >= 25)
            {
                gameBoard = new GameBoard(myGameLevel);
                gameBoard.AdjacentBombCounter();

                ThreeBV threeBV = new ThreeBV(gameBoard.Board);
                threeBVValue = threeBV.Value();
            }

            


            for (var i = 0; i < numRow; i++)
            {
                // Define the Rows
                RowDefinition rowDef = new RowDefinition();
                rowDef.MinHeight = 32;
                cellGrid.RowDefinitions.Add(rowDef);
            }

            for (var i = 0; i < numColumn; i++)
            {
                // Define the Columns
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.MinWidth = 32 ;
                cellGrid.ColumnDefinitions.Add(colDef);
            }

            for (var row=0; row<numRow; row++)
            {
                for (var column=0; column<numColumn; column++) {
                   
                    Button cellButton = new Button();
                    Button cellButtonCoverage = new Button();
                   

                    if(gameBoard.Board[row, column] == 100)
                    {
                        cellButton.Content = new Image { Source = new BitmapImage(new Uri("C:\\Users\\Marcos\\source\\repos\\MineSweeperWPF\\MineSweeperWPF\\iconMine.png")) } ;
                        cellButton.Background = new SolidColorBrush(Color.FromArgb(120, 4, 52, 5));
                        cellButton.BorderBrush = new SolidColorBrush(Color.FromArgb(180, 16, 244, 16));
                    }
                    else if (gameBoard.Board[row, column] == 0)
                    {
                        cellButton.Content = "";
                        cellButton.Background = new SolidColorBrush(Color.FromArgb(120, 4, 52, 5));
                        cellButton.BorderBrush = new SolidColorBrush(Color.FromArgb(180, 16, 244, 16));
                    }
                    else
                    {
                        cellButton.Content = gameBoard.Board[row, column];
                        if (gameBoard.Board[row, column] == 1) {
                            cellButton.Foreground = new SolidColorBrush(Color.FromArgb(250, 170, 0, 0));
                        }
                        if (gameBoard.Board[row, column] == 2)
                        {
                            cellButton.Foreground = new SolidColorBrush(Color.FromArgb(250, 40, 40, 40));
                        }
                        if (gameBoard.Board[row, column] == 3)
                        {
                            cellButton.Foreground = new SolidColorBrush(Color.FromArgb(250, 63, 63, 115));
                        }

                        if (gameBoard.Board[row, column] == 4)
                        {
                            cellButton.Foreground = new SolidColorBrush(Color.FromArgb(250, 0, 01, 31));
                        }

                        if (gameBoard.Board[row, column] == 5)
                        {
                            cellButton.Foreground = new SolidColorBrush(Color.FromArgb(250, 0, 05, 38));
                        }

                        if (gameBoard.Board[row, column] == 6)
                        {
                            cellButton.Foreground = new SolidColorBrush(Color.FromArgb(250, 0, 10, 45));
                        }

                        if (gameBoard.Board[row, column] == 7)
                        {
                            cellButton.Foreground = new SolidColorBrush(Color.FromArgb(250, 0, 20, 47));
                        }

                        if (gameBoard.Board[row, column] == 8)
                        {
                            cellButton.Foreground = new SolidColorBrush(Color.FromArgb(250, 0, 30, 53));
                        }

                        cellButton.FontWeight = FontWeights.Bold;
                        cellButton.Background = new SolidColorBrush(Color.FromArgb(120, 16, 244, 16));
                        cellButton.BorderBrush = new SolidColorBrush(Color.FromArgb(180, 16, 244, 16));
                    }

                    cellButtonCoverage.Width = 30;
                    cellButtonCoverage.Height = 30;
                    cellButtonCoverage.HorizontalAlignment = HorizontalAlignment.Center;
                    cellButtonCoverage.VerticalAlignment = VerticalAlignment.Center;
                    cellButtonCoverage.Name = "cellButtonCoverage" + row + "" + column;
                    cellButtonCoverage.Content = "";
                    cellButtonCoverage.Click += new RoutedEventHandler(cellButtonCoverageClick);
                    cellButtonCoverage.MouseRightButtonUp += new MouseButtonEventHandler(cellButtonCoverageRightClickFlag);
                    RegisterName(cellButtonCoverage.Name, cellButtonCoverage);

                    cellButton.Width = 30;
                    cellButton.Height = 30 ;
                    cellButton.HorizontalAlignment = HorizontalAlignment.Center;
                    cellButton.VerticalAlignment = VerticalAlignment.Center;
                    cellButton.Name = "cellButton" + row + "" +column;
                    RegisterName(cellButton.Name, cellButton);
                    cellButton.Visibility = Visibility.Visible;

                    cellButtonCoverage.Background = new SolidColorBrush(Color.FromArgb(250, 1, 51, 2));
                    cellButtonCoverage.BorderBrush = new SolidColorBrush(Color.FromArgb(180, 16, 244, 16));
                    

                    Grid.SetRow(cellButtonCoverage, row);
                    Grid.SetColumn(cellButtonCoverage, column);
                    Grid.SetZIndex(cellButtonCoverage, 10);

                    Grid.SetRow(cellButton, row);
                    Grid.SetColumn(cellButton, column);
                    Grid.SetZIndex(cellButton, 5);

                    
                    cellGrid.Children.Add(cellButtonCoverage);
                    cellGrid.Children.Add(cellButton); 
                }
                
            }

            TimerCountUp();
        }

        void cellButtonCoverageClick(Object sender, RoutedEventArgs e)
        {
            char[] buttonNameArray;
            string buttonName;
            string row;
            string col;
            var isSoundPlayed = false;

            Button cellButtonCoverage = ((System.Windows.Controls.Button)sender);

            buttonName = cellButtonCoverage.Name;
            buttonNameArray = buttonName.ToCharArray();
            row = buttonNameArray[18].ToString();
            col = buttonNameArray[19].ToString();

            cellButtonCoverage.Visibility = Visibility.Hidden;

            Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" + row + col);
            

            if (cellButton.Content.ToString() == "")
            {
                IWavePlayer sfxRadarNegative = new WaveOut();
                AudioFileReader sfxOceanFileReader = new AudioFileReader(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\radarSoundNegative.mp3");

                sfxRadarNegative.Init(sfxOceanFileReader);
                sfxRadarNegative.Play();

                if (!isSoundPlayed)
                {

                    sfxRadarNegative.Init(sfxOceanFileReader);
                    sfxRadarNegative.Play();
                    isSoundPlayed = true;
                }

                if (isSoundPlayed)
                {
                    sfxRadarNegative.Stop();
                    sfxRadarNegative.Dispose();
                    isSoundPlayed = false;
                }
               

                RevealAdjacentCell(Convert.ToInt32(row), Convert.ToInt32(col));
            }

            else if (cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                || cellButton.Content.ToString() == "8")
            {
                IWavePlayer sfxRadar = new WaveOut();
                AudioFileReader sfxRadarFileReader = new AudioFileReader(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\radarSound.mp3");

                sfxRadar.Init(sfxRadarFileReader);
                sfxRadar.Play();

                if (!isSoundPlayed)
                {
                    sfxRadar.Init(sfxRadarFileReader);
                    sfxRadar.Play();
                    isSoundPlayed = true;
                }

                if (isSoundPlayed)
                {
                    sfxRadar.Stop();
                    sfxRadar.Dispose();
                    isSoundPlayed = false;
                }
            }

            else
            {
                IWavePlayer sfxBomb = new WaveOut();
                AudioFileReader sfxBombFileReader = new AudioFileReader(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\bombSound.mp3");

                sfxBomb.Init(sfxBombFileReader);
                sfxBomb.Play();

                if (!isSoundPlayed)
                {
                    sfxBomb.Init(sfxBombFileReader);
                    sfxBomb.Play();
                    isSoundPlayed = true;
                }

                if (isSoundPlayed)
                {
                    sfxBomb.Stop();
                    sfxBomb.Dispose();
                    isSoundPlayed = false;
                }

                GameOverScreen();
            }

        }
        void cellButtonCoverageRightClickFlag(Object sender, RoutedEventArgs e)
        {
            Button cellButtonCoverage = ((System.Windows.Controls.Button)sender);
            

            if (cellButtonCoverage.Visibility != Visibility.Hidden)
            {
                if(cellButtonCoverage.Content.ToString() == "")
                {
                    cellButtonCoverage.Content = new Image { Source = new BitmapImage(new Uri(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\iconFlag.png")) };
                    qtdBombs --;
                    NumberOfMines.Content = qtdBombs;
                }

            }

        }

        void TimerCountUp()
        {

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += TimerTicker;
            timer.Start();
           
        }

        void TimerTicker(Object sender, EventArgs e)
        {
            timerIncrement++;
            GameTimer.Content = timerIncrement.ToString();
        }

        void RevealAdjacentCell ( int row, int col)
        {


            //Check the right cell
            if (col + 1 <= board.GetUpperBound(1))
            {
                Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" + row + "" + (col + 1));
                Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" + row + "" + (col + 1));

                Console.Write(cellButton.Content);
                if ((cellButton.Content.ToString() == "" ) &&  cellButtonCoverage.Visibility == Visibility.Visible)
                {
                            cellButtonCoverage.Visibility = Visibility.Hidden;
                                RevealAdjacentCell(row, col + 1);
                }

                if (( cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                {
                    cellButtonCoverage.Visibility = Visibility.Hidden;
             
                }

            }

                //Check the left cell
                if (col - 1 >0)
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" + row + "" + (col - 1));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" + row + "" + (col - 1));
                    if ((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                            cellButtonCoverage.Visibility = Visibility.Hidden;
                            RevealAdjacentCell(row, col - 1);
                    }
                if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                    || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                    || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;

                    }
            }

                //Check the cell up
                if (row - 1 >= 0)
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" + (row - 1) + "" + (col));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" + (row - 1) + "" + (col));
                    if((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                            cellButtonCoverage.Visibility = Visibility.Hidden;
                            RevealAdjacentCell(row-1, col);
                    }
                if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                    || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                    || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                           cellButtonCoverage.Visibility = Visibility.Hidden;

                    }
            }

                //Check the cell down
                if (row + 1 <= board.GetUpperBound(0))
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" + (row + 1) + "" + (col));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" + (row + 1) + "" + (col));
               
                    if ((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                                cellButtonCoverage.Visibility = Visibility.Hidden;
                                RevealAdjacentCell(row + 1, col);
                    }
                if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                    || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                    || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;

                    }
            }

                //Check the adjacent cell up
                if (row -1 >= 0 && col + 1 <= board.GetUpperBound(1))
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" + (row - 1) + "" + (col + 1));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" + (row - 1) + "" + (col + 1));
                    if ((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                                cellButtonCoverage.Visibility = Visibility.Hidden;
                                RevealAdjacentCell(row - 1, col + 1);
                    }
                    if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                        || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                        || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;

                    }
            }

                //Check the adjacent cell down
                if (row + 1 <= board.GetUpperBound(0) && col - 1 >= 0)
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" + (row + 1) + "" + (col - 1));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" + (row + 1) + "" + (col - 1));
                    if ((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                                cellButtonCoverage.Visibility = Visibility.Hidden;
                                RevealAdjacentCell(row + 1, col - 1);
                     }
                    if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                        || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                        || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;

                    }
                }



        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
           
            this.Close();
            timerIncrement = 0;
            mainWindow.ShowDialog();
            
        }

        void GameOverScreen()
        {
            cellGrid.IsEnabled = false;
            
            GameOverLogo.Visibility = Visibility.Visible;
            GameTimer.Visibility = Visibility.Hidden;
            NumberOfMines.Visibility = Visibility.Hidden;
            StopButton.Content = "Back";

        }
    }
}
