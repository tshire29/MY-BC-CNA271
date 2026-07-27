using System;
using System.Collections.Generic;

namespace CNA271
{
    internal class Program
    {
        enum MainMenu
        {
            Input_Results = 1,
            Qualifications,
            All_students,
            Exit,
        }

        static List<(int ID, string Name, int T1, int T2, int AS, int P, DateTime Now)> student_results =
            new List<(int ID, string Name, int T1, int T2, int AS, int P, DateTime Now)>();

        static void input_results()
        {
            bool add_more = true;

            while (add_more)
            {
                Console.Clear();

                int student_number;

                while (true)
                {
                    Console.Write("Enter student number: ");

                    if (int.TryParse(Console.ReadLine(), out student_number))
                        break;

                    Console.WriteLine("Invalid student number. Try again.");
                }

                Console.Write("Enter student name: ");
                string student_name = Console.ReadLine();

                int test_1;
                int test_2;
                int assignment;
                int project;

                while (true)
                {
                    Console.Write("Enter Test 1 mark (0 - 30): ");

                    if (int.TryParse(Console.ReadLine(), out test_1) &&
                        test_1 >= 0 && test_1 <= 30)
                        break;

                    Console.WriteLine("Invalid mark. Try again.");
                }

                while (true)
                {
                    Console.Write("Enter Test 2 mark (0 - 50): ");

                    if (int.TryParse(Console.ReadLine(), out test_2) &&
                        test_2 >= 0 && test_2 <= 50)
                        break;

                    Console.WriteLine("Invalid mark. Try again.");
                }

                while (true)
                {
                    Console.Write("Enter Assignment mark (0 - 10): ");

                    if (int.TryParse(Console.ReadLine(), out assignment) &&
                        assignment >= 0 && assignment <= 10)
                        break;

                    Console.WriteLine("Invalid mark. Try again.");
                }

                while (true)
                {
                    Console.Write("Enter Project mark (0 - 10): ");

                    if (int.TryParse(Console.ReadLine(), out project) &&
                        project >= 0 && project <= 10)
                        break;

                    Console.WriteLine("Invalid mark. Try again.");
                }

                student_results.Add
                (
                    (
                        student_number,
                        student_name,
                        test_1,
                        test_2,
                        assignment,
                        project,
                        DateTime.Now
                    )
                );

                Console.Write("\nDo you want to add another student? (Y/N): ");

                string choice = Console.ReadLine().ToUpper();

                if (choice == "N")
                {
                    add_more = false;
                }
            }
        }

        static void calculate()
        {
            bool search = true;

            while (search)
            {
                Console.Clear();

                int student_number;

                Console.Write("Enter student number: ");

                while (!int.TryParse(Console.ReadLine(), out student_number))
                {
                    Console.Write("Invalid student number. Enter again: ");
                }

                bool found = false;

                Console.WriteLine();
                Console.WriteLine($"{"ID",-8} {"Name",-20} {"Average",-10} {"Status",-15}");

                for (int i = 0; i < student_results.Count; i++)
                {
                    if (student_results[i].ID == student_number)
                    {
                        found = true;

                        double average =
                            (student_results[i].T1 * 0.30) +
                            (student_results[i].T2 * 0.50) +
                            (student_results[i].AS * 0.10) +
                            (student_results[i].P * 0.10);

                        string status;

                        if (average >= 50)
                        {
                            status = "Qualified";
                        }
                        else
                        {
                            status = "Not Qualified";
                        }

                        Console.WriteLine(
                            $"{student_results[i].ID,-8} " +
                            $"{student_results[i].Name,-20} " +
                            $"{average:F2,-10} " +
                            $"{status,-15}"
                        );

                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Student not found.");
                }

                Console.WriteLine();
                Console.Write("Search another student? (Y/N): ");

                string choice = Console.ReadLine().ToUpper();

                if (choice == "N")
                {
                    search = false;
                }
            }
        }
	        static void Show_All_Students()
        {
            Console.Clear();

            if (student_results.Count == 0)
            {
                Console.WriteLine("No students have been added yet.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }

            Console.WriteLine($"{"ID",-8} {"Name",-20} {"T1",-5} {"T2",-5} {"AS",-5} {"P",-5} {"Average",-10} {"Status",-15}");

            for (int i = 0; i < student_results.Count; i++)
            {
                double average =
                    (student_results[i].T1 * 0.30) +
                    (student_results[i].T2 * 0.50) +
                    (student_results[i].AS * 0.10) +
                    (student_results[i].P * 0.10);

                string status;

                if (average >= 50)
                {
                    status = "Qualified";
                }
                else
                {
                    status = "Not Qualified";
                }

                Console.WriteLine(
                    $"{student_results[i].ID,-8} " +
                    $"{student_results[i].Name,-20} " +
                    $"{student_results[i].T1,-5} " +
                    $"{student_results[i].T2,-5} " +
                    $"{student_results[i].AS,-5} " +
                    $"{student_results[i].P,-5} " +
                    $"{average:F2,-10} " +
                    $"{status,-15}"
                );
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            bool run = true;

            while (run)
            {
                Console.Clear();

                Console.WriteLine(" Student Qualification System");
                Console.WriteLine("1. Enter Student Results");
                Console.WriteLine("2. Search Student");
                Console.WriteLine("3. Show All Students");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option (1-4): ");

                int choiceInt;

                while (!int.TryParse(Console.ReadLine(), out choiceInt))
                {
                    Console.Write("Invalid choice. Enter a number between 1 and 4: ");
                }

                MainMenu choice = (MainMenu)choiceInt;

                switch (choice)
                {
                    case MainMenu.Input_Results:
                        input_results();
                        break;

                    case MainMenu.Qualifications:
                        calculate();
                        break;

                    case MainMenu.All_students:
                        Show_All_Students();
                        break;

                    case MainMenu.Exit:
                        Console.WriteLine("Thank you for using the Student Qualification System.");
                        run = false;
                        break;

                    default:
                        Console.WriteLine("Invalid option.");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}

