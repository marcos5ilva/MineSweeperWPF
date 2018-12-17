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
        int gameLevelValue;
        GameLevel myGameLevel;
        int victoryCountDown;

        //public int GameLevelValue { get; set; }

        //SoundPlayer soundPlayer = new SoundPlayer();
        //SoundPlayer sfxOcean = new SoundPlayer();

        IWavePlayer finalTheme = new WaveOut();
        AudioFileReader finalTemeFileReader;

        public GameWindow(int gameLevelValue, int costumNumColumn, int costumNumRow, int costumNumMines)
        {
            InitializeComponent();
            Grid.SetRow(cellGrid, 3);
            int numColumn = costumNumColumn;
            int numRow = costumNumRow;
            int numMines = costumNumMines;
            int threeBVValue = 100;
            int threeBVLevel = 25;
            string playerName = "";
            int CELLGRID_WIDTH = 300;
            int CELLGRID_HEIGHT = 300;
            this.gameLevelValue = gameLevelValue;


            //Setting the level of dificult
            if (gameLevelValue <= 3)
            {
                myGameLevel = new GameLevel(gameLevelValue);
            }
            if(gameLevelValue == 4)
            {
                myGameLevel = new GameLevel(numRow, numColumn, numMines, "");
            }
            
            GameBoard gameBoard = new GameBoard(myGameLevel);
            board = gameBoard.Board;



            //Adding the values of row, columns, and qtdBombs for the selected level
            
                numColumn = myGameLevel.columns;
                numRow = myGameLevel.rows;
                qtdBombs = myGameLevel.qtdBombs;
                threeBVLevel = 25;

            //Setting Victory countdown
            victoryCountDown = (numRow * numColumn) - qtdBombs;
            

            //Setting UI info
            NumberOfMines.Content = qtdBombs;
            timerIncrement = 0;

            //GameOverInfo
            GameOverLogo.Visibility = Visibility.Hidden;
            GameTimer.Visibility = Visibility.Visible;
            NumberOfMines.Visibility = Visibility.Visible;
            GameTimerImg.Visibility = Visibility.Visible;
            NumberOfMinesImg.Visibility = Visibility.Visible;
            TimerLabel.Visibility = Visibility.Hidden;
            TimeScore.Visibility = Visibility.Hidden;

            //Win Msg Info
            WinMsgLogo.Visibility = Visibility.Hidden;


            if (gameLevelValue == 1)
            {
                threeBVLevel = 25;
            }
            else if( gameLevelValue == 2)
            {
                threeBVLevel = 32;
            }
            else if (gameLevelValue == 3)
            {
                threeBVLevel = 45;
            }
            else
            {
                threeBVLevel = 45;
            }

            //Checking the 3BV value for the Easy level
            while (threeBVValue >=threeBVLevel )
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
                rowDef.MinHeight = (int)(CELLGRID_WIDTH / numRow);
                cellGrid.RowDefinitions.Add(rowDef);
            }

            for (var i = 0; i < numColumn; i++)
            {
                // Define the Columns
                ColumnDefinition colDef = new ColumnDefinition();
                colDef.MinWidth = (int)(CELLGRID_WIDTH / numColumn);
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

                    cellButtonCoverage.Width = (int) (CELLGRID_WIDTH / numColumn);
                    cellButtonCoverage.Height = (int) (CELLGRID_WIDTH / numRow);
                    cellButtonCoverage.Margin = new Thickness(0) ;

                    cellButtonCoverage.HorizontalAlignment = HorizontalAlignment.Center;
                    cellButtonCoverage.VerticalAlignment = VerticalAlignment.Center;
                    cellButtonCoverage.Name = "cellButtonCoverage" +"R"+ row + "CL"+ column;
                    cellButtonCoverage.Content = "";
                    cellButtonCoverage.Click += new RoutedEventHandler(cellButtonCoverageClick);
                    cellButtonCoverage.MouseRightButtonUp += new MouseButtonEventHandler(cellButtonCoverageRightClickFlag);
                    RegisterName(cellButtonCoverage.Name, cellButtonCoverage);

                    cellButton.Width = (int)(CELLGRID_WIDTH / numColumn);
                    cellButton.Height = (int)(CELLGRID_WIDTH / numRow);
                    cellButton.Margin = new Thickness(0);


                    cellButton.HorizontalAlignment = HorizontalAlignment.Center;
                    cellButton.VerticalAlignment = VerticalAlignment.Center;
                    cellButton.Name = "cellButton" +"R"+ row + "CL" +column;
                    RegisterName(cellButton.Name, cellButton);
                    cellButton.Visibility = Visibility.Visible;

                    cellButtonCoverage.Background = new SolidColorBrush(Color.FromArgb(255, 1, 51, 2));
                    cellButtonCoverage.BorderBrush = new SolidColorBrush(Color.FromArgb(180, 16, 244, 16));
                    

                    Grid.SetRow(cellButtonCoverage, row);
                    Grid.SetRowSpan(cellButtonCoverage, 1);
                    Grid.SetColumn(cellButtonCoverage, column);
                    Grid.SetColumnSpan(cellButtonCoverage, 1);
                    Grid.SetZIndex(cellButtonCoverage, 10);

                    Grid.SetRow(cellButton, row);
                    Grid.SetRowSpan(cellButton, 1);
                    Grid.SetColumn(cellButton, column);
                    Grid.SetColumnSpan(cellButton, 1);
                    Grid.SetZIndex(cellButton, 5);


                    //cellGrid.ShowGridLines = true;
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
            String row1;
            string col;
            var isSoundPlayed = false;

            Button cellButtonCoverage = ((System.Windows.Controls.Button)sender);

            buttonName = cellButtonCoverage.Name;
            int quant = buttonName.Substring(buttonName.IndexOf("R") + 1).Length - buttonName.Substring(buttonName.IndexOf("CL")).Length;
            String rowIndex = buttonName.Substring(buttonName.IndexOf("R") + 1, quant);
            String columnIndex = buttonName.Substring(buttonName.IndexOf("CL") + 2);
            buttonNameArray = buttonName.ToCharArray();
           // row1 = buttonNameArray[rowIndex].ToString();
            //int rowIndex2 = row1.IndexOf("C");
            row = rowIndex;
            col = columnIndex;

            cellButtonCoverage.Visibility = Visibility.Hidden;
            victoryCountDown--;
            GameWinScreen(victoryCountDown);

            Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" +"R"+ row +"CL"+ col);
            

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

                GameOverScreen(board);
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

               else
                {
                    cellButtonCoverage.Content = "";
                    qtdBombs++;
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
                Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" +"R"+ row + "CL" + (col + 1));
                Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" +"R"+ row + "CL" + (col + 1));

                Console.Write(cellButton.Content);
                if ((cellButton.Content.ToString() == "" ) &&  cellButtonCoverage.Visibility == Visibility.Visible)
                {
                    cellButtonCoverage.Visibility = Visibility.Hidden;
                    victoryCountDown--;
                    GameWinScreen(victoryCountDown);
                    RevealAdjacentCell(row, col + 1);
                }

                if (( cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                {
                    cellButtonCoverage.Visibility = Visibility.Hidden;
                    victoryCountDown--;
                    GameWinScreen(victoryCountDown);

                }

            }

                //Check the left cell
                if (col - 1 >0)
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" +"R"+ row + "CL" + (col - 1));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" +"R"+ row + "CL" + (col - 1));
                    if ((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;
                        victoryCountDown--;
                        RevealAdjacentCell(row, col - 1);
                    }
                if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                    || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                    || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;
                        victoryCountDown--;
                        GameWinScreen(victoryCountDown);
                }
            }

                //Check the cell up
                if (row - 1 >= 0)
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" +"R"+ (row - 1) + "CL" + (col));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" +"R"+ (row - 1) + "CL" + (col));
                    if((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;
                        victoryCountDown--;
                        GameWinScreen(victoryCountDown);
                        RevealAdjacentCell(row-1, col);
                    }
                if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                    || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                    || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                           cellButtonCoverage.Visibility = Visibility.Hidden;
                           victoryCountDown--;
                    GameWinScreen(victoryCountDown);

                }
            }

                //Check the cell down
                if (row + 1 <= board.GetUpperBound(0))
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" +"R"+ (row + 1) + "CL" + (col));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" +"R"+ (row + 1) + "CL" + (col));
                   

                if ((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                                cellButtonCoverage.Visibility = Visibility.Hidden;
                                victoryCountDown--;
                                GameWinScreen(victoryCountDown);
                    RevealAdjacentCell(row + 1, col);
                    }
                if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                    || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                    || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;
                        victoryCountDown--;
                        GameWinScreen(victoryCountDown);

                }
            }

                //Check the adjacent cell up
                if (row -1 >= 0 && col + 1 <= board.GetUpperBound(1))
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" +"R"+ (row - 1) + "CL" + (col + 1));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" +"R"+ (row - 1) + "CL" + (col + 1));
                    if ((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                            cellButtonCoverage.Visibility = Visibility.Hidden;
                            victoryCountDown--;
                            GameWinScreen(victoryCountDown);
                            RevealAdjacentCell(row - 1, col + 1);
                    }
                    if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                        || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                        || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;
                        victoryCountDown--;
                        GameWinScreen(victoryCountDown);

                }
            }

                //Check the adjacent cell down
                if (row + 1 <= board.GetUpperBound(0) && col - 1 >= 0)
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" +"R"+ (row + 1) + "CL" + (col - 1));
                    Button cellButton = (System.Windows.Controls.Button)cellGrid.FindName("cellButton" +"R"+ (row + 1) + "CL" + (col - 1));
                    if ((cellButton.Content.ToString() == "") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                                cellButtonCoverage.Visibility = Visibility.Hidden;
                                victoryCountDown--;
                                RevealAdjacentCell(row + 1, col - 1);
                     }
                    if ((cellButton.Content.ToString() == "1" || cellButton.Content.ToString() == "2" || cellButton.Content.ToString() == "3" || cellButton.Content.ToString() == "4"
                        || cellButton.Content.ToString() == "5" || cellButton.Content.ToString() == "6" || cellButton.Content.ToString() == "7"
                        || cellButton.Content.ToString() == "8") && cellButtonCoverage.Visibility == Visibility.Visible)
                    {
                        cellButtonCoverage.Visibility = Visibility.Hidden;
                        victoryCountDown--;
                        GameWinScreen(victoryCountDown);

                }
                }



        }

        void RevealAll(int numRow, int numColumn)
        {
            for (var row = 0; row <= numRow; row++)
            {
                for (var column = 0; column <= numColumn; column++)
                {
                    Button cellButtonCoverage = (System.Windows.Controls.Button)cellGrid.FindName("cellButtonCoverage" + "R" + row + "CL" + column);
                    cellButtonCoverage.Visibility = Visibility.Hidden;
                }
            }
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            finalTheme.Stop();
            finalTheme.Dispose();
            this.Close();
            timerIncrement = 0;
            mainWindow.ShowDialog();
            
            
        }

        void GameOverScreen(int[,] board)
        {
            //cellGrid.IsEnabled = false;
            TimeScore.Content = GameTimer.Content;
            GameOverLogo.Visibility = Visibility.Visible;
            GameTimer.Visibility = Visibility.Hidden;
            NumberOfMines.Visibility = Visibility.Hidden;
            GameTimerImg.Visibility = Visibility.Hidden;
            NumberOfMinesImg.Visibility = Visibility.Hidden;
            TimerLabel.Visibility = Visibility.Visible;
            TimeScore.Visibility = Visibility.Visible;
            RevealAll(board.GetUpperBound(0), board.GetUpperBound(1));
            StopButton.Content = "Back";

            //Final Screen Song
            finalTheme = new WaveOut();
            finalTemeFileReader = new AudioFileReader(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\SadnessPianoTheme.mp3");
            finalTheme.Init(finalTemeFileReader);
            finalTheme.Play();

        }

        void GameWinScreen(int cellToReveal)
        {
            Console.WriteLine("victoryCountDown: " + cellToReveal);
            if(cellToReveal == 0)
            {
                TimeScore.Content = GameTimer.Content;
                GameTimer.Visibility = Visibility.Hidden;
                NumberOfMines.Visibility = Visibility.Hidden;
                GameTimerImg.Visibility = Visibility.Hidden;
                NumberOfMinesImg.Visibility = Visibility.Hidden;
                TimerLabel.Visibility = Visibility.Visible;
                TimeScore.Visibility = Visibility.Visible;
                WinMsgLogo.Visibility = Visibility.Visible;
                StopButton.Content = "Back";

                //Final Screen Song
                finalTheme = new WaveOut();
                finalTemeFileReader = new AudioFileReader(@"C:\Users\Marcos\source\repos\MineSweeperWPF\MineSweeperWPF\VictoryTheme.mp3");
                finalTheme.Init(finalTemeFileReader);
                finalTheme.Play();
            }
            
        }
    }
}
