namespace TicTacToe.ComputerMinMax
{
    using System;
    using System.Collections.Generic;
    using ComputerImplementation.Enums;

    /// <summary>
    /// Tic Tac Toe Minimax Algorithm Written by Stefano Fiumara and Zachary Kaspar, edited by me.
    /// </summary>
    public class MinMaxComputerImplementation
    {
        private CellValue[,] Board { get; set; }

        public MinMaxComputerImplementation(CellValue[,] gameBoardState)
        {
            this.Board = new CellValue[3, 3];
            this.Board = gameBoardState;
        }
        
        public int[] MiniMax(int depth, CellValue player, int alpha, int beta)
        {
            var nextMoves = this.GenerateAvailableMoves();

            int score;
            int bestRow = -1;
            int bestCol = -1;

            if (nextMoves.Count == 0 || depth == 0)
            {
                score = this.Evaluate();

                return new int[] { score, bestRow, bestCol };
            }

            foreach (int move in nextMoves)
            {
                int row, col;

                this.ConvertPositionToRowCol(move, out row, out col);

                this.Board[row, col] = player;

                if (player == CellValue.O)
                {
                    score = this.MiniMax(depth - 1, CellValue.X, alpha, beta)[0];

                    if (score > alpha)
                    {
                        alpha = score;
                        bestRow = row;
                        bestCol = col;
                    }
                }
                else
                {
                    score = this.MiniMax(depth - 1, CellValue.O, alpha, beta)[0];

                    if (score < beta)
                    {
                        beta = score;
                        bestRow = row;
                        bestCol = col;
                    }
                }

                this.Board[row, col] = CellValue.BLANK;

                if (alpha >= beta)
                {
                    break;
                }
            }

            return new int[] { player == CellValue.O ? alpha : beta, bestRow, bestCol };
        }

        private CellValue ValueAt(int row, int col)
        {
            return this.Board[row, col];
        }

        private void ConvertPositionToRowCol(int position, out int row, out int col)
        {
            switch (position)
            {
                case 1:
                    row = 0;
                    col = 0;
                    break;
                case 2:
                    row = 0;
                    col = 1;
                    break;
                case 3:
                    row = 0;
                    col = 2;
                    break;
                case 4:
                    row = 1;
                    col = 0;
                    break;
                case 5:
                    row = 1;
                    col = 1;
                    break;
                case 6:
                    row = 1;
                    col = 2;
                    break;
                case 7:
                    row = 2;
                    col = 0;
                    break;
                case 8:
                    row = 2;
                    col = 1;
                    break;
                case 9:
                    row = 2;
                    col = 2;
                    break;
                default:
                    throw new ArgumentException("Invalid Argument to ConvertPosition");
            }
        }

        private CellValue CheckForWinner()
        {
            for (int row = 0; row < 3; row++)
            {
                if (this.Board[row, 0] == this.Board[row, 1] && this.Board[row, 1] == this.Board[row, 2] && this.Board[row, 0] != CellValue.BLANK)
                {
                    return this.Board[row, 0];
                }
            }

            for (int col = 0; col < 3; col++)
            {
                if (this.Board[0, col] == this.Board[1, col] && this.Board[1, col] == this.Board[2, col] && this.Board[0, col] != CellValue.BLANK)
                {
                    return this.Board[0, col];
                }
            }

            if (this.Board[0, 0] == this.Board[1, 1] && this.Board[1, 1] == this.Board[2, 2] && this.Board[0, 0] != CellValue.BLANK)
            {
                return this.Board[0, 0];
            }

            if (this.Board[2, 0] == this.Board[1, 1] && this.Board[1, 1] == this.Board[0, 2] && this.Board[1, 1] != CellValue.BLANK)
            {
                return Board[1, 1];
            }

            return CellValue.BLANK;
        }

        private bool MakeAIMove()
        {
            int[] bestMove = MiniMax(8, CellValue.O, int.MinValue, int.MaxValue);

            if (bestMove[1] < 0 || bestMove[2] < 0)
            {
                return false;
            }

            this.Board[bestMove[1], bestMove[2]] = CellValue.O;

            return true;
        }

        private List<int> GenerateAvailableMoves()
        {
            var nextMoves = new List<int>();

            if (this.CheckForWinner() != CellValue.BLANK)
            {
                return nextMoves;
            }

            for (int position = 1; position <= 9; position++)
            {
                int row, col;

                this.ConvertPositionToRowCol(position, out row, out col);

                if (this.Board[row, col] == CellValue.BLANK)
                {
                    nextMoves.Add(position);
                }
            }

            return nextMoves;
        }

        private int Evaluate()
        {
            int score = 0;
            score += this.EvaluateLine(0, 0, 0, 1, 0, 2);  // row 0
            score += this.EvaluateLine(1, 0, 1, 1, 1, 2);  // row 1
            score += this.EvaluateLine(2, 0, 2, 1, 2, 2);  // row 2
            score += this.EvaluateLine(0, 0, 1, 0, 2, 0);  // col 0
            score += this.EvaluateLine(0, 1, 1, 1, 2, 1);  // col 1
            score += this.EvaluateLine(0, 2, 1, 2, 2, 2);  // col 2
            score += this.EvaluateLine(0, 0, 1, 1, 2, 2);  // diagonal
            score += this.EvaluateLine(0, 2, 1, 1, 2, 0);  // alternate diagonal

            return score;
        }

        private int EvaluateLine(int row1, int col1, int row2, int col2, int row3, int col3)
        {
            int score = 0;

            if (this.Board[row1, col1] == CellValue.O)
            {
                score = 1;
            }
            else if (this.Board[row1, col1] == CellValue.X)
            {
                score = -1;
            }

            if (this.Board[row2, col2] == CellValue.O)
            {
                if (score == 1)
                {
                    score = 10;
                }
                else if (score == -1)
                {
                    return 0;
                }
                else
                {
                    score = 1;
                }
            }
            else if (this.Board[row2, col2] == CellValue.X)
            {
                if (score == -1)
                {
                    score = -10;
                }
                else if (score == 1)
                {
                    return 0;
                }
                else
                {
                    score = -1;
                }
            }

            if (this.Board[row3, col3] == CellValue.O)
            {
                if (score > 0)
                {
                    score *= 10;
                }
                else if (score < 0)
                {
                    return 0;
                }
                else
                {
                    score = 1;
                }
            }
            else if (this.Board[row3, col3] == CellValue.X)
            {
                if (score < 0)
                {
                    score *= 10;
                }
                else if (score > 1)
                {
                    return 0;
                }
                else
                {
                    score = -1;
                }
            }

            return score;
        }
    }
}