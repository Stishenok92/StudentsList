using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace StudentsListLibrary
{
    public class StudentsList
    {
        private const int MIN_SIZE_GROUP = 1;
        private const int MIN_SIZE_NAME = 1;
        private const int MIN_MARK = 0;
        private const int MAX_MARK = 10;
        private const int NUMBER_OF_ROUND_DIGIT = 2;

        private static int GetInt(string msg)
        {
            Console.Write(msg);
            return int.Parse(Console.ReadLine());
        }

        private static string GetString(string msg)
        {
            Console.Write(msg);
            return Console.ReadLine();
        }

        private static bool ValidationSizeGroup(int size)
        {
            return size >= MIN_SIZE_GROUP;
        }

        private static bool ValidationName(string name)
        {
            return name.Length >= MIN_SIZE_NAME;
        }

        private static bool ValidationMark(int mark)
        {
            return mark >= MIN_MARK && mark <= MAX_MARK;
        }

        public static int GetSizeGroup(string msg)
        {
            int size = GetInt(msg);

            if (!ValidationSizeGroup(size))
            {
                throw new ValidationException();
            }

            return size;
        }

        private static string GetName(string msg)
        {
            string name = GetString(msg);

            if (!ValidationName(name))
            {
                throw new ValidationException();
            }

            return name;
        }

        private static int GetMark(string msg)
        {
            int mark = GetInt(msg);

            if (!ValidationMark(mark))
            {
                throw new ValidationException();
            }

            return mark;
        }

        public static string[] GetArrayStudents(string msg, int size)
        {
            string[] temp = new string[size];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = GetName("[" + (i + 1) + "] " + msg);
            }

            return temp;
        }

        public static int[] GetArrayMarks(string msg, int size)
        {
            int[] temp = new int[size];

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = GetMark("[" + (i + 1) + "] " + msg);
            }

            return temp;
        }

        private static void PrintStudent(int number, string[] students, int[] marks)
        {
            Console.WriteLine("Name: " + students[number] + "\t\tMark: " + marks[number]);
        }

        private static void PrintStudentsWithMark(string[] students, int[] marks, int mark)
        {
            if (!ValidationMark(mark))
            {
                throw new ValidationException();
            }

            Console.WriteLine("\nStudents and marks: ");
            bool flag = false;

            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] == mark)
                {
                    flag = true;
                    PrintStudent(i, students, marks);
                }
            }

            if (flag == false)
            {
                Console.WriteLine("No students found!");
            }
        }

        private static void PrintStudentsWithParameters(string[] students, int[] marks, int mark)
        {
            Sort(ref students, ref marks);

            if (!ValidationMark(mark))
            {
                throw new ValidationException();
            }

            Console.WriteLine("\nStudents and marks: ");
            bool flag = false;

            for (int i = 0; i < marks.Length; i++)
            {
                if (marks[i] >= mark)
                {
                    flag = true;
                    PrintStudent(i, students, marks);
                }
            }

            if (flag == false)
            {
                Console.WriteLine("No students found!");
            }
        }

        private static double CalculateAveragePerformance(int[] marks)
        {
            return Math.Round((marks.Sum() * 1.0 / marks.Length), NUMBER_OF_ROUND_DIGIT);
        }

        private static void Sort(ref string[] students, ref int[] marks)
        {
            bool flag = true;

            while (flag)
            {
                int choose = GetInt("\nOperation:\n"
                                    + "1. Print by name (ascending)\n"
                                    + "2. Print by name (descending)\n"
                                    + "3. Print by mark (ascending)\n"
                                    + "4. Print by mark (descending)\n"
                                    + "\nEnter number operation: ");

                switch (choose)
                {
                    case 1:
                        Array.Sort(students, marks);
                        flag = false;
                        break;
                    case 2:
                        Array.Sort(students, marks);
                        Array.Reverse(students);
                        Array.Reverse(marks);
                        flag = false;
                        break;
                    case 3:
                        Array.Sort(marks, students);
                        flag = false;
                        break;
                    case 4:
                        Array.Sort(marks, students);
                        Array.Reverse(marks);
                        Array.Reverse(students);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter correct operation number!");
                        break;
                }
            }
        }

        public static void Interface(string[] students, int[] marks)
        {
            bool flag = true;

            while (flag)
            {
                int choose = GetInt("\nOperation:\n"
                                    + "1. Print students with max mark\n"
                                    + "2. Print students with min mark\n"
                                    + "3. Print average performance students\n"
                                    + "4. Print students with parameters\n"
                                    + "0. Exit\n"
                                    + "\nEnter number operation: ");

                switch (choose)
                {
                    case 0:
                        flag = false;
                        break;
                    case 1:
                        PrintStudentsWithMark(students, marks, MAX_MARK);
                        flag = false;
                        break;
                    case 2:
                        PrintStudentsWithMark(students, marks, MIN_MARK);
                        flag = false;
                        break;
                    case 3:
                        Console.WriteLine("Average performance students: " + CalculateAveragePerformance(marks));
                        flag = false;
                        break;
                    case 4:
                        int mark = GetMark("\nEnter parameter mark: ");
                        PrintStudentsWithParameters(students, marks, mark);
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("\nPlease enter correct operation number!");
                        break;
                }
            }
        }
    }
}