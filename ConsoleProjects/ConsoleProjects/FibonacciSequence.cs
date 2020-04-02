using System;
using System.Collections.Generic;

namespace ConsoleProjects
{
    class FibonacciSequence
    {
        /*Descripion:
         The Fibonacci sequence:
         "0, 1, 1, 2, 3, 5, 8, 13, 21, 34"*/

        public void StartSequence()
        {
            /*Step-by-step solution:
            1. output "Hello! Write how many Fibonacci Numbers you want to be shown!"
            2. Let the user write an input.
            3. Check that the input is an integer.
            4. If it's not an integer, output "Only integers work." and show step 1 again.
            5. If a "0" is inputed, then output "Zero numbers are showed!".
            6. If a "1" is inputed, then output "0".
            7. If a "2" is inputed, then output "0, 1".
            8. Else, just add the two previous numbers to make a third number.
            9. Then add the two previous number again.
            10. Show the numbers on the console.
            11. This will be done untill the number amount becomes 0.
            12. The program is done!
            13. output "Program done!" 
            */

            /*Pseudocode:
            say "Hello! Write how many Fibonacci Numbers you want to be shown!": 
            string userInputNumber = Console.ReadLine() 

            int numAmount = 0;
            bool checkUserInput = Int32.TryParse(userInputNumber, out numAmount)

            if(checkUserInput) {
                if(numAmount < 0) say "Only natural numbers please!"

                if(numAmount == 0) say "Currently showing zero numbers!"
                if(numAmount == 1) say "0"
                if(numAmount == 2) say "0 1"

                var fibonacciList = new List<int>()
                fibonacciList.Add(0)
                fibonacciList.Add(1)

                for(int i = numAmount; i >= 0; i--) {
                    Console.Write($"{fibonacciList[i - 2]} + {fibonacciList[i - 1]} ")
                }
                
            }*/



            //Real code:
            Console.Write("Hello! Write how many Fibonacci Numbers you want to be shown: ");
            string userInputNumber = Console.ReadLine();

            bool checkUserInput = int.TryParse(userInputNumber, out int numAmount);

            if (checkUserInput)
            {
                if (numAmount < 0)
                {
                    Console.WriteLine("Only natural numbers please!");

                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

                if (numAmount == 0)
                {
                    Console.WriteLine("Currently showing zero numbers!");

                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                if (numAmount == 1)
                {
                    Console.WriteLine("0");

                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                if (numAmount == 2)
                {
                    Console.WriteLine("0 1");

                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

                numAmount -= 2;

                var fibonacciList = new List<int>();
                fibonacciList.Add(0);
                fibonacciList.Add(1);

                for (int i = 0; i < numAmount; i++)
                {
                    int nextFibNumber = fibonacciList[i] + fibonacciList[i + 1];

                    fibonacciList.Add(nextFibNumber);
                }

                fibonacciList.ForEach(num => Console.Write("{0} ", num));

                Console.ReadKey();
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Only number can be used here!");

                Console.ReadKey();
                System.Environment.Exit(0);
            }

        }
    }
}
