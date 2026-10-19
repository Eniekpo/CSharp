using System;

namespace StudentGradebook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Student Gradebook and GPA Calculator ===");
            
            Console.Write("Enter the student's full name: ");
            string studentName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(studentName))
            {
                studentName = "Unknown Student";
            }

            string[] subjects = { "Mathematics", "Computer Science", "English", "Physics", "Statistics" };
            int[] scores = new int[subjects.Length];
            string[] letterGrades = new string[subjects.Length];
            int[] gradePoints = new int[subjects.Length];

            Console.WriteLine("\nEnter a score from 0 to 100 for each subject:");

            for (int i = 0; i < subjects.Length; i++)
            {
                scores[i] = GetValidScore(subjects[i]);
                letterGrades[i] = GetLetterGrade(scores[i]);
                gradePoints[i] = GetGradePoints(scores[i]);
            }

            double finalGpa = CalculateGpa(gradePoints);
            string academicStanding = finalGpa >= 1.0 ? "Pass" : "Fail";

            Console.WriteLine("\n============================================");
            Console.WriteLine($"Grade Report for: {studentName}");
            Console.WriteLine("============================================");
            Console.WriteLine($"{"Subject",-20} {"Score",-8} {"Grade",-8} {"Points",-6}");
            Console.WriteLine("--------------------------------------------");

            for (int i = 0; i < subjects.Length; i++)
            {
                Console.WriteLine($"{subjects[i],-20} {scores[i],-8} {letterGrades[i],-8} {gradePoints[i],-6}");
            }

            Console.WriteLine("--------------------------------------------");
            Console.WriteLine($"Final GPA: {finalGpa:F2} / 5.00 ({academicStanding})");
            Console.WriteLine("============================================");
        }

        static int GetValidScore(string subjectName)
        {
            while (true)
            {
                Console.Write($"{subjectName}: ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int score) && score >= 0 && score <= 100)
                {
                    return score;
                }

                Console.WriteLine("Invalid input. Please enter a whole number between 0 and 100.");
            }
        }

        static string GetLetterGrade(int score)
        {
            if (score >= 70) return "A";
            else if (score >= 60) return "B";
            else if (score >= 50) return "C";
            else if (score >= 45) return "D";
            else if (score >= 40) return "E";
            else return "F";
        }

        static int GetGradePoints(int score)
        {
            if (score >= 70) return 5;
            else if (score >= 60) return 4;
            else if (score >= 50) return 3;
            else if (score >= 45) return 2;
            else if (score >= 40) return 1;
            else return 0;
        }

        static double CalculateGpa(int[] points)
        {
            int totalPoints = 0;

            for (int i = 0; i < points.Length; i++)
            {
                totalPoints += points[i];
            }

            return (double)totalPoints / points.Length;
        }
    }
}