using System;

namespace Logic
{
    public class XoGame
    {
        bool?[,] gameXo = new bool?[4,3];
        string winnerName = "";
        int count = 0;

        public String SendTurn(bool xTurnBtn, int row, int col)
        {
            gameXo[row, col] = xTurnBtn;
            count++;
            return CheckWins();   
        }

        private string CheckWins()
        {
            //at the end of a turn, use this is method
            for (int i = 0; i < gameXo.GetLength(0) && count > 4 ; i++)
            {
                for (int j = 0; j < gameXo.GetLength(1); j++)
                {  //check row
                    if (gameXo[i, j] == null ) continue;
                    else if (j==0 &&(gameXo[i, j] == gameXo[i, j + 1]) && gameXo[i, j] == gameXo[i, j + 2])
                       return winnerName = CheckNameWinner(i, j);
                    //check col
                    else if (i== 0 && (gameXo[i, j] == gameXo[i + 1, j]) && gameXo[i, j] == gameXo[i + 2, j])
                       return winnerName = CheckNameWinner(i, j);
                    //אלכסון ראשי 
                    else if (i == j && i == 0 && gameXo[i, j] == gameXo[i + 1, j + 1] && gameXo[i, j] == gameXo[i + 2, j + 2])
                       return winnerName = CheckNameWinner(i, j);
                    //אלכסון משני
                    else if (i==0 && i + j == gameXo.GetLength(0) - 2 && gameXo[i, j] == gameXo[i + 1, j - 1] && gameXo[i, j] == gameXo[i + 2, j - 2])
                       return winnerName = CheckNameWinner(i, j);
                    else if (count == 9 && i == 2 && j == 2 && winnerName != "X" && winnerName != "O") return "Tie";

                }
            }
            return null;
        }

        private string CheckNameWinner(int i, int j)
        {
            if (gameXo[i, j] == true) return "X";
            return "O";
        }

      
    }
}
