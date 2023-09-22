// Adrian Rozsahegyi NET23

namespace Chessboard
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Unicode to show the squares, and setting a unicode standard output
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Take user input for prefered symbols/characters and size
            Console.Write("Choose size for the board: ");
            int size = int.Parse(Console.ReadLine());

            Console.Write("Choose character for black: ");
            string blackSquare = Console.ReadLine();

            Console.Write("Choose character for white: ");
            string whiteSquare = Console.ReadLine();

            Console.Write("Choose a special character: ");
            string specialSquare = Console.ReadLine();

            Console.Write("Choose a place on board ex: E7: ");
            string location = Console.ReadLine();

            // Splits up loacation into 2 separate variables to be able to compare them in the nested loops below.
            int char1 = (location[0]);
            int char2 = (location[1]);

            //Converts chars to numbers t.ex E (65) - 65 = 4 (E) & 7 (55) - 48 = 7. 
            char1 -= 65;
            char2 -= 48;


            // Created an array in an array to get a "grid" to make up the structure of the chessboard the size th user put in.
            string[,] chessBoard = new string[size, size];

            // Nested loop to iterate over each row and column of the array. 
            // Checks if current positions is divadable with 2 to see if it's an even or odd number.
            // to be able to assign white or black squares every other position
            for (int i = 0; i < size; i++)
            {   
                for (int j = 0; j < size; j++)
                {
                    if (i == char2 && j == char1) 
                    {
                        chessBoard[i, j] = specialSquare;
                    }     
                    else if ((i + j) % 2 == 0)
                    {
                        chessBoard[i, j] = blackSquare; // Black squares

                    }
                    else
                    {
                        chessBoard[i, j] = whiteSquare; // White squares
                    }
                }   
                
            }

            // This loops also iterates all over the chessboard but prints out what's stored on each position.
            for (int i = 0; i < size; i++)
            {
                for(int j = 0; j < size; j++)
                {
                    Console.Write(chessBoard[i, j]);
                }
                Console.WriteLine();
            }

        }
    }
}
