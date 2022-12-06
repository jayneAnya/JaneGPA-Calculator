using JaneCalc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JaneCalc.UI
{
    public class Display
    {
        static readonly string[] column = new string[] { "Course & Code", "Course Unit", "Grade", "Grade-Unit", "Weight Point", "Remarks" };
        PrintTable printTable = new PrintTable(column);
        GPACalc gpaCalc = new GPACalc();
        readonly static string option = @"Option:
        Next: To calculate your GPA
        Print: Show all result
        Help: Show all option
        Exit: End the Application";



        string? courseCode;
        double score;
        int courseUnit;
        public void CalculateGPA()
        {
            while (true)
            {
                while (true)
                {
                    Console.WriteLine("Enter your Course code: ");
                    courseCode = Console.ReadLine();
                    bool checkCourseCode = CheckCourseCode(courseCode);
                    if (checkCourseCode)
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Please input the right format e.g MTH101");
                }

                while (true)
                {
                    Console.WriteLine("Enter Score: ");
                    score = double.Parse(Console.ReadLine());
                    if (CheckScore(score))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Input correct score e.g 0 - 100");
                }

                while (true)
                {
                    Console.WriteLine("Enter course unit: ");
                    courseUnit = Convert.ToInt32(Console.ReadLine());
                    if (CheckCourseUnit(courseUnit))
                    {
                        break;
                    }
                    Console.Clear();
                    Console.WriteLine("Input correct score e.g 0 - 5");
                }
                string[] response = gpaCalc.Calc(courseCode, courseUnit, score);
                printTable.AddRow(response);

                Console.Clear();
                Console.WriteLine("Do you want to enter other courses? Enter 1 to continue or any key to exit");
                if (Console.ReadLine().Trim() != "1")
                    break;
            }
            Console.Clear();
            Console.WriteLine(option);
        }
        public void PrintResult()
        {
            double gpa = Math.Round(gpaCalc.totalWeigthPoint / gpaCalc.totalCourseUnit, 2);
            int totalweigthPoint = (int)gpaCalc.totalWeigthPoint;
            int totalcourseUnitPassed = (int)gpaCalc.totalCourseUnitPassed;
            int totalcourseUnitRegistered = (int)gpaCalc.totalCourseUnit;
            printTable.Print();

            Console.WriteLine($"Total Course Registered is: {totalcourseUnitRegistered}");
            Console.WriteLine($"Total Course Unit Passed is: {totalcourseUnitPassed}");
            Console.WriteLine($"Total Weight is: {totalweigthPoint}");
            Console.WriteLine($"Your GPA is: {gpa}");

        }
        public void UserGuide()
        {
            Console.WriteLine(option);
        }
        private bool CheckCourseCode(string courseCode)
        {
            string stRegex = @"^[A-Z]{3}\d{3}$";
            Regex regex = new Regex(stRegex);
            bool ismatch = regex.IsMatch(courseCode);
            if (ismatch)
            {
                return true;
            }
            return false;
        }
        private bool CheckScore(double score)
        {
            if (score >= 0 && score <= 100)
            {
                return true;
            }
            return false;
        }

        private bool CheckCourseUnit(int courseUnit)
        {
            if (courseUnit >= 0 && courseUnit <= 5)
            {
                return true;
            }
            return false;
        }
    }
}
