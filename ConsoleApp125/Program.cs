using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp125
{
    class craps
    {
        private static Random randomNumbers = new Random();

        private enum status { Continue, won, Lost }

        private enum DiceNames
        {
            SnakeEyes = 2,
            Trey = 3,
            Seven = 7,
            Yoleven = 11,
            BoxCars = 12,
        }
        
        static void Main(string[] args)
        {
            status gameStatus = status.Continue;
            int mypoint = 0;

            int sumOfDice = RollDice();

            switch ((DiceNames)sumOfDice)
            {
                case DiceNames.Seven:
                case DiceNames.Yoleven:
                    gameStatus = status.Lost;
                    break;
                case DiceNames.SnakeEyes:
                case DiceNames.Trey:
                case DiceNames.BoxCars:
                  

                default:
                    gameStatus = status.Continue;
                    mypoint = sumOfDice;
                    Console.WriteLine($"point is {mypoint}");
                    break;
                    

                    while (gameStatus == status.Continue)
                    {
                        sumOfDice = RollDice();

                        if (sumOfDice == mypoint)
                        {
                            gameStatus = status.won;
                        }
                        else
                        {
                            if (sumOfDice == (int)DiceNames.Seven)
                            {
                                gameStatus = status.Lost;
                            }
                        }
                    }

                    if (gameStatus == status.won)
                    {
                        Console.WriteLine("player win");
                    }
                    else
                    {
                        Console.WriteLine("player losses");
                    }
                    Console.ReadLine();

            }
        }



        static int RollDice()
        {

            int die1 = randomNumbers.Next(1, 7);
            int die2 = randomNumbers.Next(1, 7);

            int sum = die1 + die2;

            Console.WriteLine($"player rolled {die1}+{die2}={sum}");
            return sum;
           

        }
    }

}
