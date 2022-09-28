using System;

namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)

        {
            int isGameOver = 0;
            int currentPlayer = -1;
            char[] Markers = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };

            do
            {
                Console.Clear();

                currentPlayer = GetNextPlayer(currentPlayer);

                GameIntro(currentPlayer);
                DrawGameboard(Markers);

                GameEngine(Markers, currentPlayer);


                isGameOver = CheckWinner(Markers);

            } while (isGameOver.Equals(0));

            Console.Clear();
            GameIntro(currentPlayer);
            DrawGameboard(Markers);

            if (isGameOver.Equals(1))
            {
                Console.WriteLine($"Player {currentPlayer} is the winner!");
            }

            if (isGameOver.Equals(2))
            {
                Console.WriteLine($"The game is a draw!");
            }
        }

        private static int CheckWinner(char[] Markers)
        {
            if (IsGameWinner(Markers))
            {
                return 1;
            }

            if (IsGameDraw(Markers))
            {
                return 2;
            }

            return 0;
        }

        private static bool IsGameDraw(char[] Markers)
        {
            return Markers[0] != '1' &&
                   Markers[1] != '2' &&
                   Markers[2] != '3' &&
                   Markers[3] != '4' &&
                   Markers[4] != '5' &&
                   Markers[5] != '6' &&
                   Markers[6] != '7' &&
                   Markers[7] != '8' &&
                   Markers[8] != '9';
        }

        private static bool IsGameWinner(char[] Markers)
        {
            if (areMarkersTheSame(Markers, 0, 1, 2))
            {
                return true;
            }

            if (areMarkersTheSame(Markers, 3, 4, 5))
            {
                return true;
            }

            if (areMarkersTheSame(Markers, 6, 7, 8))
            {
                return true;
            }

            if (areMarkersTheSame(Markers, 0, 3, 6))
            {
                return true;
            }

            if (areMarkersTheSame(Markers, 1, 4, 7))
            {
                return true;
            }

            if (areMarkersTheSame(Markers, 2, 5, 8))
            {
                return true;
            }

            if (areMarkersTheSame(Markers, 0, 4, 8))
            {
                return true;
            }

            if (areMarkersTheSame(Markers, 2, 4, 6))
            {
                return true;
            }

            return false;
        }

        private static bool areMarkersTheSame(char[] testMarkers, int pos1, int pos2, int pos3)
        {
            return testMarkers[pos1].Equals(testMarkers[pos2]) && testMarkers[pos2].Equals(testMarkers[pos3]);
        }

        private static void GameEngine(char[] Markers, int currentPlayer)
        {
            bool notValidMove = true;

            do
            {
                string userInput = Console.ReadLine();

                if (!string.IsNullOrEmpty(userInput) &&
                    (userInput.Equals("1") ||
                    userInput.Equals("2") ||
                    userInput.Equals("3") ||
                    userInput.Equals("4") ||
                    userInput.Equals("5") ||
                    userInput.Equals("6") ||
                    userInput.Equals("7") ||
                    userInput.Equals("8") ||
                    userInput.Equals("9")))
                {

                    int.TryParse(userInput, out var gamePlacementMarker);

                    char currentMarker = Markers[gamePlacementMarker - 1];

                    if (currentMarker.Equals('X') || currentMarker.Equals('O'))
                    {
                        Console.WriteLine("Placement has already a marker please select anotyher placement.");
                    }
                    else
                    {
                        Markers[gamePlacementMarker - 1] = GetPlayerMarker(currentPlayer);

                        notValidMove = false;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid value please select anotyher placement.");
                }
            } while (notValidMove);
        }

        private static char GetPlayerMarker(int player)
        {
            if (player % 2 == 0)
            {
                return 'O';
            }

            return 'X';
        }

        static void GameIntro(int PlayerNumber)
        {
            Console.WriteLine("Welcome to the Super Duper Tic Tac Toe Game!");

            Console.WriteLine("Player 1: X");
            Console.WriteLine("Player 2: O");
            Console.WriteLine();

            Console.WriteLine($"Player {PlayerNumber} to move, select 1 thorugh 9 from the game board.");
            Console.WriteLine();
        }

        static void DrawGameboard(char[] Markers)
        {
            Console.WriteLine($"{Markers[0]}|{Markers[1]}|{Markers[2]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{Markers[3]}|{Markers[4]}|{Markers[5]}");
            Console.WriteLine("-+-+-");
            Console.WriteLine($"{Markers[6]}|{Markers[7]}|{Markers[8]}");
        }

        static int GetNextPlayer(int player)
        {
            if (player.Equals(1))
            {
                return 2;
            }

            return 1;
        }
    }
}