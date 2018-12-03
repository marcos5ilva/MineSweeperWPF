using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweeperWPF
{
   public class Bombs
    {
        private readonly int emptyCell = 0;
        private readonly int bombCell = 100;

        public Bombs()
        {

        }


        public int[,] AddRandom(int gameBoardRows, int gameBoardColumns, int numberOfBombs)
        {
            //Randomly place the bombs in the game board


            int[,] boardArray = new int[gameBoardRows, gameBoardColumns];

            //0 = empty and 1= bomb
            //Populating array with 0 (empty spaces)
            for (int i = 0; i < gameBoardRows; i++)
            {
                for (int j = 0; j < gameBoardColumns; j++)
                {
                    boardArray[i, j] = emptyCell;
                }
            }

            //Generate random positions in the array for the bombs
            Random rnd = new Random();
            while (numberOfBombs > 0)
            {
                int randRow = rnd.Next(0, gameBoardRows);
                int randCol = rnd.Next(0, gameBoardColumns);
                if (boardArray[randRow, randCol] != bombCell)
                {
                    boardArray[randRow, randCol] = bombCell;
                    numberOfBombs--;
                }
            }

            return boardArray;
        }
    }
}

