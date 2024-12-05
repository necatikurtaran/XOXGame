using System;

namespace XOXGame
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = {
                { '.', '.', '.' },
                { '.', '.', '.' },
                { '.', '.', '.' }
            };

            char currentPlayer = 'X';
            bool gameWon = false;
            int moves = 0;

            while (!gameWon && moves < 9)
            {
                Console.Clear();
                PrintBoard(board);

                Console.WriteLine($"{currentPlayer}'in sırası. Satır ve sütun girin (0-2):");
                if (int.TryParse(Console.ReadLine(), out int row) && int.TryParse(Console.ReadLine(), out int col))
                {
                    if (IsMoveValid(board, row, col))
                    {
                        MakeMove(board, row, col, currentPlayer);
                        moves++;

                        if (CheckWinner(board, currentPlayer))
                        {
                            gameWon = true;
                            Console.Clear();
                            PrintBoard(board);
                            Console.WriteLine($"{currentPlayer} kazandı!");
                        }
                        else
                        {
                            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                        }
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz hamle. Tekrar deneyin.");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Geçersiz giriş. Lütfen sayısal değerler girin.");
                    Console.ReadKey();
                }
            }

            if (!gameWon)
            {
                Console.Clear();
                PrintBoard(board);
                Console.WriteLine("Oyun berabere bitti.");
            }
        }

        static void PrintBoard(char[,] board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool IsMoveValid(char[,] board, int row, int col)
        {
            return row >= 0 && row < 3 && col >= 0 && col < 3 && board[row, col] == '.';
        }

        static void MakeMove(char[,] board, int row, int col, char player)
        {
            board[row, col] = player;
        }

        static bool CheckWinner(char[,] board, char player)
        {
            // Satır ve sütun kontrolleri
            for (int i = 0; i < 3; i++)
            {
                if ((board[i, 0] == player && board[i, 1] == player && board[i, 2] == player) ||
                    (board[0, i] == player && board[1, i] == player && board[2, i] == player))
                {
                    return true;
                }
            }

            // Çapraz kontroller
            return (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player) ||
                   (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player);
        }
    }
}

