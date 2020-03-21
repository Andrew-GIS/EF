using DAL_22._3;
using DAL_22._3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentDB_22._03
{
    public class CourseMethods
    {
        static private UnitOfWork unitOfWork;
        public static void AddCourse()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (1) Add.");
            Console.WriteLine("Please, enter course Name:");
            var courseName = Console.ReadLine();

            Console.WriteLine("Please, enter DepartmnetID:");
            var department = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Would you like to add?");
            Console.WriteLine($"Name - {courseName}, Department - {department}");

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        var newCourse = new Course()
                        {
                            Name = courseName,
                            Department = unitOfWork.DepartmantRepository.GetByID(department),
                        };

                        unitOfWork.CourseRepository.Insert(newCourse);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nCourse is added.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            UI.DisplayCourseMenu();
                        }
                        break;
                    }
                case "n":
                    UI.DisplayCourseMenu();
                    break;
            }

        }

        public static void DeleteCourse()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (2) Delete.");
            Console.WriteLine("Please, enter CourseID:");
            var courseId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to delete?");
            var courseToDelete = unitOfWork.CourseRepository.GetByID(courseId);
            Console.WriteLine(courseToDelete);

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        unitOfWork.CourseRepository.Delete(courseToDelete);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nCourse is deleted.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            UI.DisplayCourseMenu();
                        }
                        break;
                    }
                case "n":
                    UI.DisplayCourseMenu();
                    break;
            }
        }

        public static void UpdateCourse()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (3) Update.");
            Console.WriteLine("Please, enter CourseID:");
            var courseId = Int32.Parse(Console.ReadLine());
            var selectedCourse = unitOfWork.CourseRepository.GetByID(courseId);

            Console.Clear();

            Console.WriteLine("You chose course:");
            Console.WriteLine(selectedCourse);

            Console.WriteLine("\nPlease, choose attribute which you want to update:");

            Console.WriteLine("1 - Name");
            Console.WriteLine("2 - Department ID");
            Console.WriteLine("m - Back to menu");

            var attributeResult = Console.ReadLine();

            Console.Clear();

            UpdateCourseAttributeMenu(selectedCourse, attributeResult);
        }

        public static void DisplayAllCourses()
        {
            unitOfWork = new UnitOfWork();

            var courses = unitOfWork.CourseRepository.Get();

            Console.WriteLine("Here is all courses:");
            foreach (var course in courses)
            {
                Console.WriteLine(course);
            }

            Console.WriteLine("\nPress M to back");
            var decision = Console.ReadLine();
            if (decision == "m")
            {
                UI.DisplayCourseMenu();
            }
        }

        public static void UpdateCourseAttributeMenu(Course course, string attributeResult)
        {
            switch (attributeResult)
            {
                case "1":
                    {
                        Console.WriteLine($"You want to change Name - {course.Name}");
                        Console.WriteLine("Please, enter a new one:");
                        var courseName = Console.ReadLine();

                        Console.WriteLine("Press Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    course.Name = courseName;
                                    unitOfWork.CourseRepository.Update(course);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("Course's name is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();


                                    if (result == "m")
                                    {
                                        UI.DisplayCourseMenu();
                                    }
                                    break;
                                }
                            case "n":
                                CourseMethods.UpdateCourse();
                                break;
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("You want to change Department");
                        Console.WriteLine("Please, enter a new one:");
                        var department = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("\nPress Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    course.Department = unitOfWork.DepartmantRepository.GetByID(department);
                                    unitOfWork.CourseRepository.Update(course);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("\nCourse's department is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        UI.DisplayCourseMenu();
                                    }
                                    break;
                                }
                            case "n":
                                UpdateCourse();
                                break;
                        }
                        break;
                    }
                case "m":
                    {
                        UI.DisplayMenu();
                        break;
                    }
            }
        }
    }
}