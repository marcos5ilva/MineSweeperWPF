using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MineSweeperWPF;

namespace MineSweeperTests
{
    public class MinesweeperGameTets
    {
        [Fact]
        public void AddRandom_ShouldReturnRightNumBoms()
        {
            //Arrange
            int numberOfBombs = 10;
            int gridRows = 8;
            int gridColumns = 8;
            int[,] finalBombArray;
            Bombs myBombs = new Bombs();
            int expected = 10;
            int response = 0;

            //Act
            finalBombArray = myBombs.AddRandom(gridRows, gridColumns, numberOfBombs);

            foreach (int position in finalBombArray)
            {
                if (position == 100)
                {
                    response++;
                }
            }

            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        public void GameBoardShouldReturnTheRightAmountofRows()
        {
            //Arrange
            int numberOfBombs = 4;
            int gridRows = 10;
            int gridColumns = 6;
            string playerName = "Tester";

            GameLevel myGameLevel = new GameLevel(gridRows, gridColumns, numberOfBombs, playerName);
            GameBoard gameBoard = new GameBoard(myGameLevel);
            int expected = 10;
            int response = 0;

            //Act
            response = gameBoard.Board.GetUpperBound(0) + 1;

            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        public void GameBoardShouldReturnTheRightAmountofColumns()
        {
            //Arrange
            int numberOfBombs = 4;
            int gridRows = 10;
            int gridColumns = 6;
            string playerName = "Tester";

            GameLevel myGameLevel = new GameLevel(gridRows, gridColumns, numberOfBombs, playerName);
            GameBoard gameBoard = new GameBoard(myGameLevel);
            int expected = 6;
            int response = 0;

            //Act
            response = gameBoard.Board.GetUpperBound(1) + 1;

            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        public void ThreeBVShouldReturnRightValue()
        {
            //Arrange
            int[,] board = new int[8,8] {
                {0,0,1,1,1,0,1,1 },
                {0,0,1,100,1,0,1,100},
                {0,1,2,2,1,0,1,1},
                {0,1,100,1,0,0,0,0},
                {1,2,3,2,1,0,1,1},
                {1,100,2,100,1,0,1,100},
                {1,1,2,1,1,0,1,1},
                {0,0,0,0,0,0,0,0 }
            };
           
            ThreeBV myThreeBV = new ThreeBV(board);
            int expected = 7;
            int response = 0;
            //Act
            response = myThreeBV.Value();
            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        void GameLevelOneShouldReturnRightNumberOfBombs()
        {
            //Arrange
            int gameLevelValue = 1;
            GameLevel myGameLevel = new GameLevel(gameLevelValue);
            int expected = 6;
            int response = 0;
            //Act
            response = myGameLevel.qtdBombs;
            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        void GameLevelOneShouldReturnRightNumberOfRows()
        {
            //Arrange
            int gameLevelValue = 1;
            GameLevel myGameLevel = new GameLevel(gameLevelValue);
            int expected = 8;
            int response = 0;
            //Act
            response = myGameLevel.rows;
            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        void GameLevelOneShouldReturnRightNumberOfColumns()
        {
            //Arrange
            int gameLevelValue = 1;
            GameLevel myGameLevel = new GameLevel(gameLevelValue);
            int expected = 8;
            int response = 0;
            //Act
            response = myGameLevel.columns;
            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        void GameLevelTwoShouldReturnRightNumberOfBombs()
        {
            //Arrange
            int gameLevelValue = 2;
            GameLevel myGameLevel = new GameLevel(gameLevelValue);
            int expected = 10;
            int response = 0;
            //Act
            response = myGameLevel.qtdBombs;
            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        void GameLevelTwoShouldReturnRightNumberOfRows()
        {
            //Arrange
            int gameLevelValue = 2;
            GameLevel myGameLevel = new GameLevel(gameLevelValue);
            int expected = 8;
            int response = 0;
            //Act
            response = myGameLevel.rows;
            //Assert
            Assert.Equal(expected, response);
        }

        [Fact]
        void GameLevelTwoShouldReturnRightNumberOfColumns()
        {
            //Arrange
            int gameLevelValue = 2;
            GameLevel myGameLevel = new GameLevel(gameLevelValue);
            int expected = 8;
            int response = 0;
            //Act
            response = myGameLevel.columns;
            //Assert
            Assert.Equal(expected, response);
        }
    }
}
