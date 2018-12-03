using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperWPF
{
    public class Game

    {
        int rows = 8;
        int cols = 8;
        int qtdBombs = 10;
        string playerName = " ";
         GameBoard Board;

        public Game(int row, int cols, int qtdBombs)
        {
            this.rows = row;
            this.cols = cols;
            this.qtdBombs = qtdBombs;
        }

        private void Start()
        {

            


            /*
            Console.WriteLine("Enter number of rows: ");
            rows = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of columns: ");
            cols = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter number of Bombs: ");
            qtdBombs = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Your Name : ");
            playerName = Console.ReadLine();

            Console.WriteLine("Let's play " + playerName + "!");

            Console.Clear();*/


            //creating  a array to store the game board
            GameLevel myGameLevel = new GameLevel(this.rows, this.cols, this.qtdBombs, this.playerName);
            Board = new GameBoard(myGameLevel);
        

            //storing the random gameboard result
            // myBoard = myBombs.Add();

            //drawing header
            //gameBoard.DrawHeader();
            Board.AdjacentBombCounter();

            //drawing the gameboard
            Board.DrawBorad();
        }
    }
}
