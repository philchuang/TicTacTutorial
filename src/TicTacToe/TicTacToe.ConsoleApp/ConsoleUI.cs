using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Com.PhilChuang.Apps.TicTacToe.ConsoleApp
{
    public class ConsoleUI
    {
        public int GamesPlayed { get; private set; }

        public Game CurrentGame { get; private set; }

        private readonly GameManager _gameManager;

        public ConsoleUI()
        {
            _gameManager = new GameManager(new RandomProvider());
        }

        public void Run()
        {
            var player1Name = "Player 1";
            var player2Name = "Player 2";

            do
            {
                this.CurrentGame = _gameManager.CreateNewRandom(player1Name, player2Name);

                do
                {
                    DrawGameBoard();
                    ReceiveInput();
                } while (!this.CurrentGame.IsFinished);
                DisplayGameEnd();
                this.GamesPlayed++;
            } while (AskContinue());
        }

        private void DrawGameBoard()
        {
            for (var row = 0; row < 3; row++)
            {
                for (var col = 0; col < 3; col++)
                {
                    if (col > 0) Console.Write(" | ");
                    var square = row * 3 + col + 1;
                    Console.Write(this.CurrentGame.Board[square]?.ToString() ?? square.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("---------");
            }
        }

        private void ReceiveInput()
        {
            Console.Write($"{this.CurrentGame.PlayerTurn.Name} [{this.CurrentGame.PlayerTurn.Mark}], your move - choose square: ");
            do
            {
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.KeyChar < '1' || key.KeyChar > '9')
                {
                    Console.Write("Please enter a number 1-9: ");
                    continue;
                }
                var square = int.Parse(key.KeyChar.ToString());
                if (this.CurrentGame.Board[square] != null)
                {
                    Console.Write($"Square {square} is already taken, pick another one: ");
                    continue;
                }
                this.CurrentGame.MakeMove(square);

                Console.WriteLine();
                break;
            } while (true);
        }

        private void DisplayGameEnd()
        {
            if (this.CurrentGame.Winner == null)
            {
                Console.WriteLine("It's a draw!");
            }
            else
            {
                Console.WriteLine($"Congratulations {this.CurrentGame.Winner.Name}, you won!");
            }
        }

        private bool AskContinue()
        {
            do
            {
                Console.Write("Play again? [y/n]: ");
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key != ConsoleKey.Y &&
                    key.Key != ConsoleKey.N)
                    continue;

                Console.WriteLine();
                return key.Key == ConsoleKey.Y;
            } while (true);
        }
    }
}
