using DAL_22._3;
using DAL_22._3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentDB_22._03
{
    public class StudentsMethods
    {
        static private UnitOfWork unitOfWork;
        static private StudentRepository studentRepository;

        public static void AddStudent()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (1) Add.");
            Console.WriteLine("Please, enter First Name:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Please, enter Last Name:");
            var lastName = Console.ReadLine();

            Console.WriteLine("Please, enter CourseID:");
            var course = Int32.Parse(Console.ReadLine());
            Console.Clear();

            Console.WriteLine("Would you like to add?");
            Console.WriteLine($"{firstName} {lastName}, Course - {course}");

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        var newStudent = new Student()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Course = unitOfWork.CourseRepository.GetByID(course)
                        };

                        unitOfWork.StudentRepository.Insert(newStudent);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nStudent is added.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayStudentsMenu();
                        }
                        break;
                    }
                case "n":
                    DisplayStudentsMenu();
                    break;
            }
        }

        public static void DeleteStudent()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (2) Delete.");
            Console.WriteLine("Please, enter StudentID:");
            var studentId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to delete?");
            var studentToDelete = unitOfWork.StudentRepository.GetByID(studentId);
            Console.WriteLine(studentToDelete);

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        unitOfWork.StudentRepository.Delete(studentToDelete);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nStudent is deleted.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayStudentsMenu();
                        }
                        break;
                    }
                case "n":
                    DisplayStudentsMenu();
                    break;
            }
        }

        public static void UpdateStudent()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (3) Update.");
            Console.WriteLine("Please, enter StudentID:");
            var studentID = Int32.Parse(Console.ReadLine());
            var selectedStudent = unitOfWork.StudentRepository.GetByID(studentID);

            Console.Clear();

            Console.WriteLine("You chose student:");
            Console.WriteLine(selectedStudent);

            Console.WriteLine("\nPlease, choose attribute which you want to update:");

            Console.WriteLine("1 - First name");
            Console.WriteLine("2 -Last name");
            Console.WriteLine("3 - Course ID");
            Console.WriteLine("m - Back to menu");

            var attributeResult = Console.ReadLine();

            Console.Clear();

            UpdateStudentAttributeMenu(selectedStudent, attributeResult);
        }

        public static void DisplayAllStudents()
        {
            unitOfWork = new UnitOfWork();

            var students = unitOfWork.StudentRepository.Get();

            Console.WriteLine("Here is all students:");
            foreach (var student in students)
            {
                Console.WriteLine(student);
            }

            Console.WriteLine("\nPress M to back");
            var decision = Console.ReadLine();
            if (decision == "m")
            {
                DisplayStudentsMenu();
            }
        }

        private static void DisplayStudentsMenu()
        {
            Console.Clear();

            Console.WriteLine("You chose (1) Students.");
            Console.WriteLine("Choose option:");
            Console.WriteLine("1 - Add");
            Console.WriteLine("2 - Delete");
            Console.WriteLine("3 - Update");
            Console.WriteLine("4 - Display all students");
            Console.WriteLine("m - Back to menu");

            string studentResult = Console.ReadLine();
            Console.Clear();

            switch (studentResult)
            {
                case "1":
                    {
                        AddStudent();
                    }
                    break;
                case "2":
                    {
                        DeleteStudent();
                    }
                    break;
                case "3":
                    {
                        UpdateStudent();
                    }
                    break;
                case "4":
                    {
                        DisplayAllStudents();
                    }
                    break;

                case "m":
                    {
                        UI.DisplayMenu();
                    }
                    break;
            }
        }

        public static void UpdateStudentAttributeMenu(Student student, string attributeResult)
        {
            switch (attributeResult)
            {
                case "1":
                    {
                        Console.WriteLine($"You want to change First name - {student.FirstName}");
                        Console.WriteLine("Please, enter a new one:");
                        var firstName = Console.ReadLine();

                        Console.WriteLine("Press Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    student.FirstName = firstName;
                                    unitOfWork.StudentRepository.Update(student);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("Student's first name is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        DisplayStudentsMenu();
                                    }
                                    break;
                                }
                                case "n":
                                UpdateStudent();
                                break;
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine($"You want to change Last name - {student.LastName}");
                        Console.WriteLine("Please, enter a new one:");
                        var lastName = Console.ReadLine();

                        Console.WriteLine("Press Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    student.LastName = lastName;
                                    unitOfWork.StudentRepository.Update(student);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("\nStudent's last name is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        DisplayStudentsMenu();
                                    }
                                    break;
                                }
                            case "n":
                                UpdateStudent();
                                break;
                        }
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("You want to change Course");
                        Console.WriteLine("Please, enter a new one:");
                        var course = Int32.Parse(Console.ReadLine());

                        student.Course = unitOfWork.CourseRepository.GetByID(course);
                        unitOfWork.StudentRepository.Update(student);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nStudent's course is updated.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            DisplayStudentsMenu();
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