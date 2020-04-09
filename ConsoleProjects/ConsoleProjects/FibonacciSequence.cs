using System;
using System.Collections.Generic;

namespace ConsoleProjects
{
    class FibonacciSequence
    {
        private bool restartProgramMethod(bool restartProgramVariable)
        {
            string restartProgramQuestion = "\nDo you want to restart the program? (Y)es or (N)o.";

            Console.WriteLine(restartProgramQuestion);
            string userAnswer = Console.ReadLine();

            if (userAnswer.Equals("y") || userAnswer.Equals("Y"))
                restartProgramVariable = true;
            else if (userAnswer.Equals("n") || userAnswer.Equals("N"))
                restartProgramVariable = false;

            return restartProgramVariable;
        }


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
            bool restartProgram = false;

            do
            {
                Console.Clear();

                Console.Write("Hello! Write how many Fibonacci Numbers you want to be shown: ");
                string userInputNumber = Console.ReadLine();

                bool checkUserInput = long.TryParse(userInputNumber, out long numAmount);

                if (checkUserInput)
                {
                    if (numAmount < 0)
                    {
                        Console.WriteLine("Only natural numbers please!");

                        restartProgram = restartProgramMethod(restartProgram);
                    }

                    if (numAmount == 0)
                    {
                        Console.WriteLine("Currently showing zero numbers!");

                        restartProgram = restartProgramMethod(restartProgram);
                    }
                    if (numAmount == 1)
                    {
                        Console.WriteLine("0");

                        restartProgram = restartProgramMethod(restartProgram);
                    }
                    if (numAmount == 2)
                    {
                        Console.WriteLine("0");
                        Console.WriteLine("1");

                        restartProgram = restartProgramMethod(restartProgram);
                    }

                    numAmount -= 2;

                    List<long> fibonacciList = new List<long>();
                    fibonacciList.Add(0);
                    fibonacciList.Add(1);

                    for (int i = 0; i < numAmount; i++)
                    {
                        long nextFibNumber = fibonacciList[i] + fibonacciList[i + 1];

                        fibonacciList.Add(nextFibNumber);
                    }

                    fibonacciList.ForEach(num => Console.WriteLine("{0}", num));

                    restartProgram = restartProgramMethod(restartProgram);
                }
                else
                {
                    Console.WriteLine("Only numbers can be used here!");

                    restartProgram = restartProgramMethod(restartProgram);
                }
            } while (restartProgram);

            System.Environment.Exit(0);
        }
    }
}
