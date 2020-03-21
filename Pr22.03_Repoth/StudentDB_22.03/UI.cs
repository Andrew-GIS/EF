using DAL_22._3;
using DAL_22._3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentDB_22._03
{
    public class UI
    {
        static public UnitOfWork unitOfWork;
        public void LoadStartMenu()
        {
            bool workStatus = true;

            while (workStatus==true)
                {
                    Console.Clear();
                    Console.WriteLine("Welcome to University Database Maneger Application " +
                    "\n Load Main Menu? Y/N ");
                    string startAnwer = Console.ReadLine();
                    if (startAnwer == "Y" || startAnwer == "y" || startAnwer == "Н" || startAnwer == "н")
                    {
                        DisplayMenu();

                        string displayMenuResult = Console.ReadLine();

                        switch (displayMenuResult)
                        {
                            case "1":
                            {
                                DisplayStudentMenu();
                                break;
                            }
                            case "2":
                            {
                                DisplayCourseMenu();
                                break;
                            }
                            case "3":
                            {
                                DisplayDepatmentMenu();
                                break;
                            }
                            default:
                            {
                                throw new Exception("Wrong Option! Try again!");
                            }
                        }
                    }
                }
        }

        public static string mainChooseResult;

        public static void DisplayMenu()
        {
            Console.WriteLine("Please, choose the entity to display");
            Console.WriteLine("1 - Students");
            Console.WriteLine("2 - Courses");
            Console.WriteLine("3 - Departments");
            var mainChooseResalt = Console.ReadLine();
            Console.Clear();
            //return mainChooseResult;
        }

        public static void DisplayStudentMenu()
        {
            Console.WriteLine("What would you like to do with Student info");
            Console.WriteLine("1. Add New Student");
            Console.WriteLine("2. Delete Some Student");
            Console.WriteLine("3. Update Some Student Info");
            Console.WriteLine("4. Display All Students");
            Console.WriteLine("5. Back to Main Menu");

            string studentResult = Console.ReadLine();
            Console.Clear();

            switch (studentResult)
            {
                case "1":
                    {
                        StudentsMethods.AddStudent();
                    }
                    break;
                case "2":
                    {
                        StudentsMethods.DeleteStudent();
                    }
                    break;
                case "3":
                    {
                        StudentsMethods.UpdateStudent();
                    }
                    break;
                case "4":
                    {
                        StudentsMethods.DisplayAllStudents();
                    }
                    break;

                case "m":
                    {
                        UI.DisplayMenu();
                    }
                    break;
            }
        }

        public static void DisplayCourseMenu()
        {
            Console.WriteLine(" What would you like to do with Course info");
            Console.WriteLine("1. Add New Course");
            Console.WriteLine("2. Delete Some Course");
            Console.WriteLine("3. Update Some Course Info");
            Console.WriteLine("4. Display All Course");
            Console.WriteLine("5. Back to Main Menu");

            string courseResult = Console.ReadLine();
            Console.Clear();

            switch (courseResult)
            {
                case "1":
                    {
                        CourseMethods.AddCourse();
                    }
                    break;
                case "2":
                    {
                        CourseMethods.DeleteCourse();
                    }
                    break;
                case "3":
                    {
                        CourseMethods.UpdateCourse();
                    }
                    break;
                case "4":
                    {
                        CourseMethods.DisplayAllCourses();
                    }
                    break;

                case "m":
                    {
                        DisplayMenu();
                    }
                    break;
            }
        }

        public static void DisplayDepatmentMenu()
        {
            Console.WriteLine("What would you like to do with Department info");
            Console.WriteLine("1. Add New Department");
            Console.WriteLine("2. Delete Some Department");
            Console.WriteLine("3. Update Some Department Info");
            Console.WriteLine("4. Display All Department");
            Console.WriteLine("5. Back to Main Menu");

            string departmentResult = Console.ReadLine();
            Console.Clear();

            switch (departmentResult)
            {
                case "1":
                    {
                        DepartmentMethods.AddDepartment();
                    }
                    break;
                case "2":
                    {
                        DepartmentMethods.DeleteDepatment();
                    }
                    break;
                case "3":
                    {
                        DepartmentMethods.UpdateDepartment();
                    }
                    break;
                case "4":
                    {
                        DepartmentMethods.DisplayAllDepartments();
                    }
                    break;

                case "m":
                    {
                        DisplayMenu();
                    }
                    break;
            }
        }
    }
}