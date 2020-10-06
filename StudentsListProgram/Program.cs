using System;
using System.ComponentModel.DataAnnotations;
using static StudentsListLibrary.StudentsList;

namespace StudentsListProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Task \"Student list\"\n");

            try
            {
                int sizeGroup = GetSizeGroup("Enter amount students: ");
                Console.WriteLine();
                string[] students = GetArrayStudents("Enter name student: ", sizeGroup);
                Console.WriteLine();
                int[] marks = GetArrayMarks("Enter mark student: ", sizeGroup);
                Interface(students, marks);
            }
            catch (ValidationException)
            {
                Console.WriteLine("\nError: ValidationException");
            }
            catch (FormatException)
            {
                Console.WriteLine("\nError: FormatException");
            }
        }
    }
} 