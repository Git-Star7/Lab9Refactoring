using System;
using System.Collections.Generic;

namespace Lab9RefactoringTime
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> students = new List<string> { "Arya", "John Snow", "Sansa" };
            List<string> cities = new List<string> { "Bravos", "The Wall", "King's Landing" };
            List<string> language = new List<string> { "Java", "Old Tongue", "Valyrian" };
            List<string> zip = new List<string> { "12345", "48225", "88885" };
            List<string> phoneNum = new List<string> { "321-123-6543", "888-555-9966", "420-420-4200" };
            List<string> direWolf = new List<string> { "", "", "" };

            bool continueLoop = true;
            while (continueLoop == true)
            {
                if (OneOrTwo("Learn about a character : 1\nAdd a character: 2\n", "1", "2") == true)
                {
                    ListOutStringArray(students);
                    Console.WriteLine("Which character would you like to learn more about?");

                    int studentSelection = InputIsString(students, GetUserInput($"Enter a Name or a number (1-{students.Count}): "));
                    Console.WriteLine("");
                    Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Location", cities[studentSelection]));
                    Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Class Language", language[studentSelection]));
                    Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Zipcode", zip[studentSelection]));
                    Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Phone Number", phoneNum[studentSelection]));

                    if (direWolf[studentSelection] == "")
                    {
                        bool addNewWolfBool = OneOrTwo("Do they have a Dire Wolf? y/n : ", "y", "n");
                        if (addNewWolfBool == true)
                        {
                            direWolf[studentSelection] = GetUserInput("Enter the wolf's name: ");
                            Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Dire Wolf", direWolf[studentSelection]));
                        }
                    }
                    else
                    {
                        Console.WriteLine(string.Format("{0, -17}:{1, 17}", "Dire Wolf", direWolf[studentSelection]));
                    }
                    
                }
                else
                {
                    students.Add(GetUserInput("Enter a name for your new character: "));
                    cities.Add(GetUserInput($"What city is {students[students.Count - 1]} in?: "));
                    language.Add(GetUserInput($"What language does {students[students.Count - 1]} know?: "));
                    zip.Add(GetUserInput($"What is the zipcode of {cities[cities.Count - 1]}?: "));
                    phoneNum.Add(GetUserInput($"What is {students[students.Count - 1]}'s phone number?: "));
                    bool addNewWolfBool = OneOrTwo("Do they have a Dire Wolf? y/n : ", "y", "n");
                    if (addNewWolfBool == true)
                    {
                        direWolf.Add(GetUserInput("Enter the wolf's name: "));
                    }
                }

                continueLoop = OneOrTwo("\nWould you like to learn about another character or add one? y/n : ", "y", "n");
            }
        }

        //takes in user input
        public static string GetUserInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            if (input == "")
            {
                input = GetUserInput($"Invalid input\n{message}");
            }
            return input;
        }

        //continue while loop
        public static bool OneOrTwo(string message, string option1, string option2)
        {
            string userContinue = "";
            while (userContinue != option1 && userContinue != option2)
            {
                Console.Write(message);
                userContinue = Console.ReadLine().ToLower();

                if (userContinue == option2)
                {
                    Console.WriteLine("Okay!!");
                    return false;
                }
            }
            return true;
        }

        //if any string in inputarray matches, return an int based on that. else, go to int input method
        public static int InputIsString(List<string> name, string pick)
        {
            if (name.Contains(pick))
            {
                return name.IndexOf(pick);
            }
            else
            {
                return InputIsInt(name, pick);
            }
        }

        //if string input is valid, return int
        public static int InputIsInt(List<string> name, string pick)
        {
            try
            {
                int intPick = int.Parse(pick) - 1;
                string tryExceptionT = name[intPick];
                return intPick;
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Input out of range");
                return InputIsString(name, GetUserInput("Try again"));
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid name");
                return InputIsString(name, GetUserInput("Try again"));
            }
        }

        //list out everything in the array
        public static void ListOutStringArray(List<string> array)
        {
            Console.WriteLine("");
            for (int i = 0; i < array.Count; i++)
            {
                Console.WriteLine(string.Format("{0, -11}:{1, 3}", array[i], i + 1));
            }
            Console.WriteLine("");
        }
    }
}
