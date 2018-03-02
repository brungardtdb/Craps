using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class Craps
    {

    // create random-number generator for use in method RollDice
    private static Random randomNumbers = new Random();

    // enumeration with constants that represent the game status
    private enum Status { Continue, Won, Lost}

    // enumeration with constants that repressent the common rolls of the dice
    private enum DiceNames

   
   
    {
        SnakeEyes = 2,
        Trey = 3,
        Seven = 7,
        YoLeven = 11,
        BoxCars = 12,
    }
    
    // plays one game of craps
    static void Main()
    {
        int balance = 1000;
        
        do
        {
            Console.WriteLine($"Please enter your wager: (balance is {balance})");
                       
                int wager = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"Your wager is {wager} dollars.");           


            if (wager <= balance)
            {

                // gameStatus can ontain Continue, Won, or Lost
                Status gameStatus = Status.Continue;
                int myPoint = 0; // point of no win or loss on first roll

                int sumOfDice = RollDice(); // first roll of dice

                // determine game status and point based on first roll
                switch ((DiceNames)sumOfDice)
                {
                    case DiceNames.Seven: // win with 7 on the first roll
                    case DiceNames.YoLeven: // win with 11 on the first roll
                        gameStatus = Status.Won;
                        break;
                    case DiceNames.SnakeEyes: // lose with 2 on the first roll
                    case DiceNames.Trey: // lose with 3 on the first roll
                    case DiceNames.BoxCars: // lose with 12 on the first roll
                        gameStatus = Status.Lost;
                        break;
                }

                // while game is not complete


                while (gameStatus == Status.Continue) // game not won or lost
                {
                    sumOfDice = RollDice(); // roll dice again

                    // determine game status
                    if (sumOfDice == myPoint) // win by making point
                    {
                        gameStatus = Status.Won;
                    }
                    else
                    {
                        //lose by rolling 7 before point
                        if (sumOfDice == (int)DiceNames.Seven)
                        {
                            gameStatus = Status.Lost;
                        }
                    }
                }

                // display won or lost message
                if (gameStatus == Status.Won)
                {
                    Console.WriteLine("Player Wins");
                    balance = balance + wager;
                    Console.WriteLine($"Your new balance is: {balance}\n");
                }
                else
                {
                    Console.WriteLine("Player Loses\n");
                    balance = balance - wager;
                    Console.WriteLine($"Your new balance is: {balance}\n");
                }
            }
            else
            {
                Console.WriteLine($"Wager exceeded balance, please enter a new wager\n");
            }

        } while (balance > 0);
    }

    // roll dice, calculate sum and display results
    static int RollDice()
    {
        // pick random die values
        int die1 = randomNumbers.Next(1, 7); // first die roll
        int die2 = randomNumbers.Next(1, 7); // second die roll

        int sum = die1 + die2; // sum of all die values

        // display results of this roll
        Console.WriteLine($"Player rolled {die1} + {die2} = {sum}");
        return sum; // return sum of the dice
    }

}
