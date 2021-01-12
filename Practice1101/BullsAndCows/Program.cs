using System;
using System.Collections.Generic;

namespace BullsAndCows
{
    class Program
    {
        static List<string> possibleAnswers = GetAllAnswers();
        static void Main(string[] args)
        {
            //try to resolve conflicts
            possibleAnswers = GetAllAnswers();

            StartGame();

            Console.ReadLine();
        }

        private static void StartGame()
        {
            string currentAnswer = GetOneAnswer(possibleAnswers);
            List<string> currentPossibleAnswers = possibleAnswers;

            Console.WriteLine($"Lets go. May be your number is {currentAnswer} ?");

            Console.Write("Enter bools: ");
            int bulls = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter cows: ");
            int cows = Convert.ToInt32(Console.ReadLine());

            if (bulls < 0 || bulls > 4 || cows < 0 || cows > 4)
            {
                Console.WriteLine("Your digit must be: 1<= digit <=4 ");
                return;
            }
            else if (bulls == 4 && cows == 0)
            {
                Console.WriteLine($"Game over! Your number is {currentAnswer}");
                return;
            }

            possibleAnswers = Sieve(currentAnswer, bulls, cows, currentPossibleAnswers);

            if (possibleAnswers.Count == 1)
            {
                Console.WriteLine($"Your number is {possibleAnswers[0]} !!! GameOver");
            }
            else
            {
                StartGame();
            }
        }

        private static List<string> Sieve(string currentAnswer, int bulls, int cows, List<string> currentPossibleAnswers)
        {
            List<string> newPossibleAnswers = new List<string>();
            for (int i = 0; i < currentPossibleAnswers.Count; i++)
            {
                var tuple = GetCountOfBullsAndCowsInTwoNumbers(currentAnswer, currentPossibleAnswers[i]);
                //equals bulls and cows
                if (bulls == tuple.Item1 && cows == tuple.Item2)
                {
                    newPossibleAnswers.Add(currentPossibleAnswers[i]);
                }
            }
            return newPossibleAnswers;
        }

        private static (int, int) GetCountOfBullsAndCowsInTwoNumbers(string currentAnswer, string answerFromPossibleMassive)
        {
            int[] current = GetIntMass(currentAnswer);
            int[] possible = GetIntMass(answerFromPossibleMassive);
            var tuple = (bulls: 0, cows: 0);

            //calculate bulls and cows in every string
            for (int i = 0; i < current.Length; i++)
            {
                //if digits at the same position are equal we add bull
                if (current[i] == possible[i])
                {
                    tuple.bulls++;
                }
                else
                {
                    //if digits at the different position are equal we add cow
                    for (int k = 0; k < possible.Length; k++)
                    {
                        if (current[i] == possible[k])
                        {
                            tuple.cows++;
                        }
                    }
                }
            }

            return tuple;
        }

        static int[] GetIntMass(string str)
        {
            //Convert string to int[]
            int[] massOfNumbers = new int[str.Length];

            //Convert string to int[]
            for (int i = 0; i < str.Length; i++)
            {
                massOfNumbers[i] = Convert.ToInt32(str[i]);
            }

            return massOfNumbers;
        }

        //Create list with all possible answers
        static List<string> GetAllAnswers()
        {
            List<string> answers = new List<string>();

            for (int i = 0; i < 10000; i++)
            {
                string fmd = "0000";
                string fmt = i.ToString(fmd);

                //character inequality check
                if (fmt[0] != fmt[1] && fmt[0] != fmt[2] && fmt[0] != fmt[3] && fmt[1] != fmt[2] && fmt[1] != fmt[3] && fmt[2] != fmt[3])
                {
                    answers.Add(i.ToString(fmd));
                }
            }

            return answers;
        }

        //get one answer from possible list
        static string GetOneAnswer(List<string> answers)
        {
            Random rnd = new Random();
            int random = rnd.Next(0, answers.Count);
            //get random variant and return it
            string answer = answers[random];
            return answer;
        }
    }
}
