using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperWPF
{
    public class GameBoard
    {
        //Implements all the game board functionalities
        private Bombs myBombs;
        public int[,] Board { get; }
        private readonly int bombCell = 100;
        private readonly int emptyCell = 0;
        public int qtdBombs { get; }

        private string playerName = "";


        //constructor
        public GameBoard(GameLevel gameLevel)
        {
            int gameBoardRows = gameLevel.rows;
            int gameBoardColumns = gameLevel.columns;
            qtdBombs = gameLevel.qtdBombs;
            playerName = gameLevel.playerName;
            myBombs = new Bombs();
            Board = myBombs.AddRandom(gameBoardRows, gameBoardColumns, qtdBombs);

        }

        public void CleanBoard()
        {
            //Reestart the game board state
        }

        //Check for adjacent bombs
        public void AdjacentBombCounter()
        {
            for (int row = 0; row <= Board.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= Board.GetUpperBound(1); col++)
                {
                    if (Board[row, col] == 100)
                    {

                        /*//Add adjacent bomb count on the right cell
                        if (row >= 0 && row <= board.GetUpperBound(0) && col + 1 >= 0 && col + 1 <= board.GetUpperBound(1) && board[row, col + 1] != 100) { board[row, col + 1]++; }

                        //Add adjacent bomb count on the lef cell
                        if (row >= 0 && row <= board.GetUpperBound(0) && col - 1 >= 0 && col - 1 <= board.GetUpperBound(1) && board[row, col - 1] != 100) { board[row, col - 1]++; }

                        //Add adjacent bomb count in the upper cell
                        if (row - 1 >= 0 && board[row - 1, col] != 100) { board[row - 1, col]++; }

                        // Add adjacent bomb count in the right cell bellow
                        if (row + 1 >= 0 && row + 1 <= board.GetUpperBound(1) && col + 1 >= 0 && col + 1 <= board.GetUpperBound(0) && board[row + 1, col + 1] != 100) { board[row + 1, col + 1]++; }

                        // Add adjacent bomb count in the right cell upper
                        if (row - 1 >= 0 && row - 1 <= board.GetUpperBound(1) && col + 1 >= 0 && col + 1 <= board.GetUpperBound(0) && board[row - 1, col + 1] != 100) { board[row - 1, col + 1]++; }

                        // Add adjacent bomb count in the left cell bellow
                        if (row + 1 >= 0 && row + 1 <= board.GetUpperBound(1) && col + 1 >= 0 && col + 1 <= board.GetUpperBound(0) && board[row + 1, col + 1] != 100) { board[row + 1, col + 1]++; }

                        // Add adjacent bomb count in the left cell upper
                        if (row - 1 >= 0 && row - 1 <= board.GetUpperBound(1) && col - 1 >= 0 && col - 1 <= board.GetUpperBound(0) && board[row - 1, col - 1] != 100) { board[row - 1, col - 1]++; }*/

                        //Add adjacent bomb count on the right cell
                        try
                        {
                            if (Board[row, col + 1] != 100) { Board[row, col + 1]++; }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }

                        try
                        {
                            //Add adjacent bomb count on the left cell
                            if (Board[row, col - 1] != 100) { Board[row, col - 1]++; }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }

                        try
                        {
                            //Add adjacent bomb count in the upper cell
                            if (Board[row - 1, col] != 100) { Board[row - 1, col]++; }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }

                        try
                        {
                            //Add adjacent bomb count in the cell bellow
                            if (Board[row + 1, col] != 100) { Board[row + 1, col]++; }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }

                        try
                        {
                            // Add adjacent bomb count in the left cell upper
                            if (Board[row - 1, col - 1] != 100) { Board[row - 1, col - 1]++; }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }
                        try
                        {
                            // Add adjacent bomb count in the left cell down
                            if (Board[row + 1, col - 1] != 100) { Board[row + 1, col - 1]++; }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }
                        try
                        {
                            // Add adjacent bomb count in the right cell bellow
                            if (Board[row - 1, col + 1] != 100) { Board[row - 1, col + 1]++; }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }
                        try
                        {
                            // Add adjacent bomb count in the right cell upper
                            if (Board[row + 1, col + 1] != 100) { Board[row + 1, col + 1]++; }
                        }
                        catch (IndexOutOfRangeException e)
                        {

                        }



                    }

                }
            }

        }

       

        public void DrawBorad()
        {
            
        }

    }
    public struct GameLevel
    {
        public int rows;
        public int columns;
        public int qtdBombs;
        public string playerName;
        //public int threeBV;

        public GameLevel(int rows, int columns, int qtdBombs, string playerName)
        {
            this.rows = rows;
            this.columns = columns;
            this.qtdBombs = qtdBombs;
            //this.threeBV = threeBV;
            this.playerName = playerName;
        }

        public GameLevel(int level)
        {
            if (level == 1)
            {
                this.rows = 8;
                this.columns = 8;
                this.qtdBombs = 6;
                this.playerName = "";
                //this.threeBV = 24;
            }
            else if (level == 2)
            {
                this.rows = 10;
                this.columns = 10;
                this.qtdBombs = 8;
                this.playerName = "";
                //this.threeBV = 30;
            }
            else if (level == 3)
            {
                this.rows = 12;
                this.columns = 12;
                this.qtdBombs = 10;
                this.playerName = "";
                //this.threeBV = 40;
            }
            else
            {
                this.rows = 8;
                this.columns = 8;
                this.qtdBombs = 6;
                this.playerName = "";
                //this.threeBV = 24;
            }

        }

    }
}
