using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperWPF
{
    public class ThreeBV
    {
        string[,] ThreeBVBoard;
        int[,] board;
        private readonly string bombCell = "100";
        private readonly string emptyCell = "0";

        public ThreeBV(int[,] board)
        {
            this.board = board;
            ThreeBVBoard = new string[board.GetUpperBound(0)+1, board.GetUpperBound(1)+1];
            Console.WriteLine("board.GetUpperBound(0): " + board.GetUpperBound(0));
            Console.WriteLine("board.GetUpperBound(1): " + board.GetUpperBound(1));

            //Converting the game board info to string
            for (int row = 0; row <= board.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= board.GetUpperBound(1); col++)
                {
                   
                        ThreeBVBoard[row, col] = Convert.ToString(board[row, col]);
                    
                   
                }
            }
        }

        public int Value()
        {
           
            int ThreeBVCount = 0;

            for (int row = 0; row <= ThreeBVBoard.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= ThreeBVBoard.GetUpperBound(1); col++)
                {
                    if (ThreeBVBoard[row, col] == "0" && ThreeBVBoard[row, col] != "M")
                    {
                        ThreeBVBoard[row, col] = "F";
                       // ThreeBVCount++;

                        MarkNeighbor(row, col);
                    }
                    else if (ThreeBVBoard[row, col] != "M" && ThreeBVBoard[row, col] != "100")
                    {
                       // ThreeBVCount++;
                    }
                }
            }

            for (int row = 0; row <= ThreeBVBoard.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= ThreeBVBoard.GetUpperBound(1); col++)
                {
                    if (ThreeBVBoard[row, col] != "M" && ThreeBVBoard[row, col] != "100")
                    {
                         ThreeBVCount++;

                       
                    }
                }
            }

                    Console.WriteLine("3BV: " + ThreeBVCount);

            DrawBoard();

            return ThreeBVCount;
        }

        private void MarkNeighbor(int row, int col)
        {
            //Add adjacent bomb count on the right cell

            /*try
            { 
                if (ThreeBVBoard[row, col + 1] != "M" && ThreeBVBoard[row, col + 1] != "100" && ThreeBVBoard[row, col + 1] != "0" && ThreeBVBoard[row, col + 1] != "F") { ThreeBVBoard[row, col + 1] = "M"; }
                if (ThreeBVBoard[row, col + 1] == "0") { ThreeBVBoard[row, col + 1] = "M"; MarkNeighbor(row, col + 1 ); }
            }
            catch (IndexOutOfRangeException e)
            {

            }

            try
            {
                //Add adjacent bomb count on the left cell
                if (ThreeBVBoard[row, col - 1] != "M" && ThreeBVBoard[row, col - 1] != "100" && ThreeBVBoard[row, col - 1] != "0" && ThreeBVBoard[row, col - 1] != "F") { ThreeBVBoard[row, col - 1] = "M"; }
                if (ThreeBVBoard[row, col - 1] == "0") { ThreeBVBoard[row, col - 1] = "M";  MarkNeighbor(row, col - 1); }
            }
            catch (IndexOutOfRangeException e)
            {

            }

            try
            {
                //Add adjacent bomb count in the upper cell
                if (ThreeBVBoard[row - 1, col] != "M" && ThreeBVBoard[row -1, col] != "100" && ThreeBVBoard[row - 1, col] != "0" && ThreeBVBoard[row - 1, col] != "F") { ThreeBVBoard[row - 1, col] = "M"; }
                if (ThreeBVBoard[row - 1, col] == "0") { ThreeBVBoard[row - 1, col] = "M";  MarkNeighbor(row - 1, col); }
            }
            catch (IndexOutOfRangeException e)
            {

            }

            try
            {
                //Add adjacent bomb count in the cell bellow
                if (ThreeBVBoard[row + 1, col] != "M" && ThreeBVBoard[row + 1 , col] != "100" && ThreeBVBoard[row + 1, col] != "0" && ThreeBVBoard[row + 1, col] != "F") { ThreeBVBoard[row + 1, col] = "M"; }
                if (ThreeBVBoard[row + 1, col] == "0") { ThreeBVBoard[row + 1, col] = "M"; MarkNeighbor(row + 1, col);}
            }
            catch (IndexOutOfRangeException e)
            {

            }

            try
            {
                // Add adjacent bomb count in the left cell upper
                if (ThreeBVBoard[row - 1, col - 1] != "M" && ThreeBVBoard[row - 1, col - 1] != "100" && ThreeBVBoard[row - 1, col - 1] != "0" && ThreeBVBoard[row - 1, col - 1] != "F") { ThreeBVBoard[row - 1, col - 1] = "M"; }
                if (ThreeBVBoard[row -1, col - 1] == "0") { ThreeBVBoard[row - 1, col - 1] = "M"; MarkNeighbor(row -1, col - 1); }
            }
            catch (IndexOutOfRangeException e)
            {

            }
            try
            {
                // Add adjacent bomb count in the left cell down
                if (ThreeBVBoard[row + 1, col - 1] != "M" && ThreeBVBoard[row + 1, col - 1] != "100" && ThreeBVBoard[row + 1, col - 1] != "0" && ThreeBVBoard[row + 1, col - 1] != "F") { ThreeBVBoard[row + 1, col - 1] = "M"; }
                if (ThreeBVBoard[row + 1, col - 1] == "0") { ThreeBVBoard[row + 1, col - 1] = "M"; MarkNeighbor(row + 1, col - 1); }
            }
            catch (IndexOutOfRangeException e)
            {

            }
            try
            {
                // Add adjacent bomb count in the right cell bellow
                if (ThreeBVBoard[row - 1, col + 1] != "M" && ThreeBVBoard[row - 1, col + 1] != "100" && ThreeBVBoard[row - 1, col + 1] != "0" && ThreeBVBoard[row - 1, col + 1] != "F") { ThreeBVBoard[row - 1, col + 1] = "M"; }
                if (ThreeBVBoard[row - 1, col + 1] == "0") { ThreeBVBoard[row - 1, col + 1] = "M"; MarkNeighbor(row - 1, col + 1); }
            }
            catch (IndexOutOfRangeException e)
            {

            }
            try
            {
                // Add adjacent bomb count in the right cell upper
                if (ThreeBVBoard[row + 1, col + 1] != "M" && ThreeBVBoard[row + 1, col + 1] != "100" && ThreeBVBoard[row + 1, col + 1] != "0" && ThreeBVBoard[row + 1, col + 1] != "F") { ThreeBVBoard[row + 1, col + 1] = "M"; }
                if (ThreeBVBoard[row + 1, col + 1] == "0") { ThreeBVBoard[row + 1, col + 1] = "M"; MarkNeighbor(row + 1, col + 1); }
            }
            catch (IndexOutOfRangeException e)
            {

            }*/

            //Add adjacent bomb count on the right cell
            if (col + 1 <= ThreeBVBoard.GetUpperBound(1))
            { 
                if (ThreeBVBoard[row, col + 1] != "M" && ThreeBVBoard[row, col + 1] != "100" && ThreeBVBoard[row, col + 1] != "0" && ThreeBVBoard[row, col + 1] != "F") { ThreeBVBoard[row, col + 1] = "M"; }
                if (ThreeBVBoard[row, col + 1] == "0") { ThreeBVBoard[row, col + 1] = "M"; MarkNeighbor(row, col + 1 ); }
            }

            //Add adjacent bomb count on the left cell
            if (col - 1 > 0)
            {
                if (ThreeBVBoard[row, col - 1] != "M" && ThreeBVBoard[row, col - 1] != "100" && ThreeBVBoard[row, col - 1] != "0" && ThreeBVBoard[row, col - 1] != "F") { ThreeBVBoard[row, col - 1] = "M"; }
                if (ThreeBVBoard[row, col - 1] == "0") { ThreeBVBoard[row, col - 1] = "M";  MarkNeighbor(row, col - 1); }
            }


            //Add adjacent bomb count in the upper cell
            if (row - 1 >= 0)
            {
                if (ThreeBVBoard[row - 1, col] != "M" && ThreeBVBoard[row -1, col] != "100" && ThreeBVBoard[row - 1, col] != "0" && ThreeBVBoard[row - 1, col] != "F") { ThreeBVBoard[row - 1, col] = "M"; }
                if (ThreeBVBoard[row - 1, col] == "0") { ThreeBVBoard[row - 1, col] = "M";  MarkNeighbor(row - 1, col); }
            }

            //Add adjacent bomb count in the cell bellow
            if (row + 1 <= ThreeBVBoard.GetUpperBound(0))
            {
                
                if (ThreeBVBoard[row + 1, col] != "M" && ThreeBVBoard[row + 1 , col] != "100" && ThreeBVBoard[row + 1, col] != "0" && ThreeBVBoard[row + 1, col] != "F") { ThreeBVBoard[row + 1, col] = "M"; }
                if (ThreeBVBoard[row + 1, col] == "0") { ThreeBVBoard[row + 1, col] = "M"; MarkNeighbor(row + 1, col);}
            }

            // Add adjacent bomb count in the left cell upper
            if (row - 1 >= 0 && col - 1 >= 0)
            {
                if (ThreeBVBoard[row - 1, col - 1] != "M" && ThreeBVBoard[row - 1, col - 1] != "100" && ThreeBVBoard[row - 1, col - 1] != "0" && ThreeBVBoard[row - 1, col - 1] != "F") { ThreeBVBoard[row - 1, col - 1] = "M"; }
                if (ThreeBVBoard[row -1, col - 1] == "0") { ThreeBVBoard[row - 1, col - 1] = "M"; MarkNeighbor(row -1, col - 1); }
            }

            // Add adjacent bomb count in the left cell down
            if (row + 1 <= ThreeBVBoard.GetUpperBound(0) && col - 1 >= 0)
            {
                if (ThreeBVBoard[row + 1, col - 1] != "M" && ThreeBVBoard[row + 1, col - 1] != "100" && ThreeBVBoard[row + 1, col - 1] != "0" && ThreeBVBoard[row + 1, col - 1] != "F") { ThreeBVBoard[row + 1, col - 1] = "M"; }
                if (ThreeBVBoard[row + 1, col - 1] == "0") { ThreeBVBoard[row + 1, col - 1] = "M"; MarkNeighbor(row + 1, col - 1); }
            }

            // Add adjacent bomb count in the right cell bellow
            if(row + 1 <= ThreeBVBoard.GetUpperBound(0) && col + 1 <= ThreeBVBoard.GetUpperBound(1))
            {
                if (ThreeBVBoard[row + 1, col + 1] != "M" && ThreeBVBoard[row + 1, col + 1] != "100" && ThreeBVBoard[row + 1, col + 1] != "0" && ThreeBVBoard[row + 1, col + 1] != "F") { ThreeBVBoard[row + 1, col + 1] = "M"; }
                if (ThreeBVBoard[row + 1, col + 1] == "0") { ThreeBVBoard[row + 1, col + 1] = "M"; MarkNeighbor(row + 1, col + 1); }
            }

            // Add adjacent bomb count in the right cell upper
            if (row - 1 >= 0 && col + 1 <= ThreeBVBoard.GetUpperBound(1))
            {
                if (ThreeBVBoard[row - 1, col + 1] != "M" && ThreeBVBoard[row - 1, col + 1] != "100" && ThreeBVBoard[row - 1, col + 1] != "0" && ThreeBVBoard[row - 1, col + 1] != "F") { ThreeBVBoard[row - 1, col + 1] = "M"; }
                if (ThreeBVBoard[row - 1, col + 1] == "0") { ThreeBVBoard[row - 1, col + 1] = "M"; MarkNeighbor(row - 1, col + 1); }
            }
         
        }

        public void DrawBoard()
        {
            string boardLine = "";

            //Drawing the array
            for (int row = 0; row <= ThreeBVBoard.GetUpperBound(0); row++)
            {
                for (int col = 0; col <= ThreeBVBoard.GetUpperBound(1); col++)
                {
                    if (ThreeBVBoard[row, col] == bombCell)
                    {
                        boardLine += "[Ó]";
                    }

                    else if ((ThreeBVBoard[row, col] != bombCell) && (ThreeBVBoard[row, col] != emptyCell))
                    {
                        boardLine += "[" + ThreeBVBoard[row, col].ToString() + "]";
                    }
                    else if ((ThreeBVBoard[row, col] != bombCell) && (ThreeBVBoard[row, col] == "M"))
                    {
                        boardLine += "M";
                    }
                    else
                    {
                        boardLine += "[ ]";
                    }
                }


                Console.WriteLine(boardLine);
                boardLine = "";
            }

          
        }
    }
}
