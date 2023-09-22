//Adrian Rozsahegyi NET23

namespace Övning
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // do while loop to check if user chose to play again (Y/N)
            // needed to declare variables outside loop as default values
            string playAgain = "Y";
            int rounds = 1;
            do
            {


                //declare variables for random generation, guesses and number since most of them are used inside loops
                //and need to be declared outside.
                Random rnd = new Random();
                int number = 0;
                int userGuess;
                bool correctGuess = false;
                int guesses = 0;

                // Introduction
                // if first time playing (rounds == 1) send intro message, otherwise just say Round X and continue
                if (rounds == 1)
                {

                Console.WriteLine("Välkommen till *Guess a number*! ChasAcademy\'s populäraste gameshow! " +
                    "\nKan du gissa vilket nummer jag tänker på? ");
                }
                else
                {
                    Console.WriteLine($"\nRond: {rounds}! \nKan du gissa vilket nummer jag tänker på? ");
                }


                // Difficulty
                //chooses the difficulty i.e. the number of tries and the range of the number gen
                Console.Write(" \n 1: [Very Easy] \n 2: [Easy] \n 3: [Medium] \n 4: [Hard] \n 5: [BRUTAL] \n Hur svårt vill du ha det? [1-5]: ");
                int difficulty = int.Parse(Console.ReadLine());

                switch (difficulty)
                {
                    case 1:
                        guesses = 8;
                        number = rnd.Next(1, 20);
                        Console.WriteLine("\n[Very Easy] Du har 8 försök att gissa på ett nummer mellan 1-20.");
                        break;
                    case 2:
                        guesses = 6;
                        number = rnd.Next(1, 30);
                        Console.WriteLine("\n[Easy] Du har 6 försök att gissa på ett nummer mellan 1-30.");
                        break;
                    case 3:
                        guesses = 5;
                        number = rnd.Next(1, 50);
                        Console.WriteLine("\n[Medium] Du har 5 försök att gissa på ett nummer mellan 1-50.");
                        break;
                    case 4:
                        guesses = 3;
                        number = rnd.Next(1, 75);
                        Console.WriteLine("\n[Hard] Du har 3 försök att gissa på ett nummer mellan 1-75."); ;
                        break;
                    case 5:
                        guesses = 1;
                        number = rnd.Next(1, 100);
                        Console.WriteLine("\n[BRUTAL] Du har 1 försök att gissa på ett nummer mellan 1-100.");
                        break;
                }

                // Gameplay loop
                while (guesses > 0 && correctGuess != true)
                {
                    // tells user how many guesses they have left and takes new guess input
                    Console.Write($"\n{guesses} försök kvar: ");
                    userGuess = int.Parse(Console.ReadLine());

                    // sends the users guess and the number as well as the correctGuess check to the function
                    // checks if userGuess was correct, or the guess was higher or lower. Returns value if correctGuess was true or false
                    correctGuess = CheckGuess(userGuess, number, correctGuess, guesses);

                    //if guess was correct ask user to play again and take input as well as increase number of rounds
                    if (correctGuess == true)
                    {
                        Console.Write("\nVill du spela igen? [Y/N]: ");
                        playAgain = Console.ReadLine();
                        rounds++;
                    }

                    // if guesses = 1 the user didn't succeed with guessing ask user to play again
                    // and take input as well as increase number of rounds
                    if (guesses == 1)
                    {
                        Console.WriteLine("Tyvärr, du lyckades inte gissa talet!");
                        Console.WriteLine($"\nRätt svar var: {number}");
                        Console.Write("\nVill du spela igen? [Y/N]: ");
                        playAgain = Console.ReadLine();
                        rounds++;
                    }

                    // decreases guess by 1 each loop
                    guesses--;

                }
            }
            while (playAgain == "Y" || playAgain == "y");
        }

        // checks if users guess is correct or higher/lower than the specified number. 
        // returns if guess was correct or not
        static bool CheckGuess(int userGuess, int number, bool correctGuess, int guesses) 
        {
            // gets value of distance to correct guess
            int guessDistance = isGuessClose(userGuess, number);
            
            if (userGuess == number)
            {
                Console.WriteLine("Wohoo! Du gissade rätt! ");
                correctGuess = true;
            }
            // checks if guess was higher or lower. Doesn't run if guesses is less than 2 (to skip printing on the last guess)
            else if (guesses > 1)
            {
                // chooses a phrase depending on how close or far off the users guess was from the correct number
                PhraseSelector(guessDistance);
            }

            return correctGuess;
    
        }
        
        // returns the value of how far the users guess is from the correct number
        static int isGuessClose(int userGuess, int number)
        {
            
            int guessDistance = number - userGuess;

            // Since guessDistance can become negative we make it back to a positive number ex: (-18) - (-18) - (-18) = 18
            if (guessDistance < 0)
            {
                guessDistance = guessDistance - guessDistance - guessDistance;
            }

            return guessDistance;
        }

        // Prints out phrases depending on how close the guess was to the correct number
        static void PhraseSelector(int guessDistance)
        {
            if (guessDistance == 1)
            {
                Console.WriteLine("Oj, oj det är skogsbrands varning här!!!");
            }
            else if (guessDistance < 3)
            {
                Console.WriteLine("Det är riktigt, riktigt varmt här!!");
            }
            else if (guessDistance < 5)
            {
                Console.WriteLine("Lite rökdoft, det börjar närma sig!");
            }
            else if (guessDistance < 8)
            {
                Console.WriteLine("Känns lite kyligt i luften.");
            }
            else if (guessDistance < 12)
            {
                Console.WriteLine("Här var det kallt!");
            }
            else if (guessDistance < 15)
            {
                Console.WriteLine("Tycker jag ser is på vägarna!!");
            }
            else
            {
                Console.WriteLine("Rena rama istiden här borta!!!");
            }
        }
    }
}