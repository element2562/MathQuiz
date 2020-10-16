using System;
using System.Collections.Generic;
using System.Timers;

namespace MathQuiz
{
    class Program
    {
        private static bool Failed;
        private static Timer timer;
        static void Main(string[] args)
        {
            MathProblems();
        }

        static void MathProblems()
        {
            Console.WriteLine("Welcome to the math quiz! You will have 5 seconds to complete each question. If you answer the question wrong or run out of time, you lose.");
            timer = new Timer(5000);
            timer.Elapsed += OnTimedEvent;
            MathProblem problem1 = new MathProblem { Question = "What is 10 + 10?", Answer = 20, AlreadyAnswered = false };
            MathProblem problem2 = new MathProblem { Question = "What is 5 x 8?", Answer = 40, AlreadyAnswered = false };
            MathProblem problem3 = new MathProblem { Question = "What is 400 / 20?", Answer = 20, AlreadyAnswered = false };
            List<MathProblem> Problems = new List<MathProblem> 
            {
                problem1,
                problem2,
                problem3
            };
            foreach (MathProblem i in Problems)
            {
                timer.Start();
                Console.WriteLine(i.Question);
                if (Int32.TryParse(Console.ReadLine(), out int answer) && !Failed)
                {
                    if (answer == i.Answer)
                    {
                        timer.Stop();
                        i.AlreadyAnswered = true;
                        continue;
                    }
                    else Failed = true;
                }
                else
                {
                    Failed = true;
                    break;
                }
            };
            if(!Failed)
            {
                Console.WriteLine("Nice job, you won!");
            }
            else
            {
                Console.WriteLine("Sorry, you lost, better luck next time!");
            }
        }
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            Failed = true;
            timer.Enabled = false;
            Console.WriteLine("Your time is up! Press enter to continue");
        }
    }
}
