using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleProjects
{
    //Fake credit card numbers form:
    //https://saijogeorge.com/dummy-credit-card-generator/

    class CreditCardValidator
    {
        /*Luhn Checksum Validation steps from Wikipedia:
            1. Double every second digit, starting from the rightmost.
            
            2. Sum all the individual digits.
   
            3. If there isn't a remainder when the sum is divided by 10, then the account 
            number is valid. 
            */


        //Helper functions start.
        private void doubleEverySecondNum(List<long> listToTakeNumFrom, List<long> listWhereEveryOtherNumIsDoubled)
        {

            bool isSecondNumber = false;
            for (int i = listToTakeNumFrom.Count - 1; i >= 0; i--)
            {

                if (isSecondNumber == true)
                {
                    long doubledDigit = listToTakeNumFrom[i] * 2;

                    if (doubledDigit > 9)
                    {
                        long digitSum = 0;

                        while (doubledDigit != 0)
                        {
                            digitSum += doubledDigit % 10;
                            doubledDigit /= 10;
                        }

                        doubledDigit = digitSum;
                    }
                    listWhereEveryOtherNumIsDoubled.Add(doubledDigit);
                }
                else
                {
                    listWhereEveryOtherNumIsDoubled.Add(listToTakeNumFrom[i]);
                }

                isSecondNumber = !isSecondNumber;
            }

            //The numbers are in the reverse order, so let's un-reverse the list.
            listWhereEveryOtherNumIsDoubled.Reverse();
        }


        //Helper functions end.




        public void StartValidation()
        {
            /*Luhn checksum, Manual Test:
            Card number: 79927398713 (from Wikipedia - Luhn Checksum validation - Description)


            1. Ask the user to write a text string which is between 10 and 14 in character length.

            2. Check if the character length is less than 10 or greater than 14.
                2.1. If the length is less than 10 or greater than 14, then repeat the above prompt.
                2.2. If the length is in the range of 10 to 14, then continue.

            3. Now, the text stirng is between 10 and 14 characters in length.
            Check if the inputed string is a number.
                3.1. If it isn't a number, then repeat the above prompt.
                3.2. If it is a number, then continue.
            
            4. The user input is now 100% a number.
            Create a new list and add the user number to that list.
            The list will be made since it is easier to do change it's indices than in an int.

            5. From the last index, add that one to the list and move backwards. This next index
            will be doubled. The new number will then be placed on the next position on the 
            new list. This will go on until index 0 is hit. At index 0, nothing will happen.
                5.1. If the doubled number is 10 or more, then add the two digits together 
                     and place that number into the new list.
                5.2. Else, just add it to the new list.

            6. Sum all of the digits and save the sum.

            7. Divide the sum by 10.
                7.1. If there is a remainder, then the card number is invalid!
                7.2. If there isn't a remainder, then the card number is valid!

            8. Whatever the result was, write this to the console so the user can see!
            */








            //Real code.
            bool restartProgram = false;

            do
            {
                string whatTheUserShouldDo = "Hello! Please write a number, it should be between 10 and 14 in character length.\nExample fake credit card number to copy and paste:\n5361294315582214, 5159797061836557, 5515141498775039, 5410510884350774, 5153544617592572, 5402632209029917";
                string textIfInputIsIncorrect = "The input is not correct. \nPlease enter a number with the character length between 10 and 14.";

                string validCreditCardNumber = "Your credit card is valid!";
                string invalidCreditCardNumber = "Your credit card is invalid!";

                string restartProgramQuestion = "Do you want to restart the program? (Y)es or (N)o.";



                Console.Clear();

                Console.WriteLine(whatTheUserShouldDo);
                Console.WriteLine();

                string userInput = Console.ReadLine();

                while (userInput.Length < 10 || userInput.Length > 20)
                {
                    Console.WriteLine(textIfInputIsIncorrect);
                    userInput = Console.ReadLine();
                }

                bool inputIsNumber = long.TryParse(userInput, out long userNumber);

                while (!inputIsNumber)
                {
                    Console.WriteLine(textIfInputIsIncorrect);
                    userInput = Console.ReadLine();

                    inputIsNumber = long.TryParse(userInput, out userNumber);
                }

                var userNumberList = new List<long>();

                //Code for adding the numbers to the List<long>.
                while (userNumber > 0)
                {
                    userNumberList.Add(userNumber % 10);
                    userNumber /= 10;
                }

                //The numbers are in the list! But they are reveresed, so the method below will
                //un-reverse the list.
                userNumberList.Reverse();

                var userNumberList_EveryOtherNumDoubled = new List<long>();

                //Parameters:("Numbers to double and add to the other list", "List where the all numbers will be placed")
                doubleEverySecondNum(userNumberList, userNumberList_EveryOtherNumDoubled);

                long sumOfUserNumbers = userNumberList_EveryOtherNumDoubled.Sum();



                //Modulo can be used to get the remainder instantly!
                if ((sumOfUserNumbers % 10) == 0)
                {
                    Console.WriteLine(validCreditCardNumber);
                    Console.WriteLine();

                    Console.WriteLine(restartProgramQuestion);
                    string yesOrNo = Console.ReadLine();

                    if (yesOrNo.Equals("y") || yesOrNo.Equals("Y"))
                        restartProgram = true;
                    else if (yesOrNo.Equals("n") || yesOrNo.Equals("N"))
                        restartProgram = false;
                }
                else
                {
                    Console.WriteLine(invalidCreditCardNumber);
                    Console.WriteLine();

                    Console.WriteLine(restartProgramQuestion);
                    string yesOrNo = Console.ReadLine();

                    if (yesOrNo.Equals("y") || yesOrNo.Equals("Y"))
                        restartProgram = true;
                    else if (yesOrNo.Equals("n") || yesOrNo.Equals("N"))
                        restartProgram = false;
                }

            } while(restartProgram == true);

            System.Environment.Exit(0);
        }
    }
}
