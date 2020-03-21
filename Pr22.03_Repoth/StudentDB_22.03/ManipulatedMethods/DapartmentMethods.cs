using DAL_22._3;
using DAL_22._3.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentDB_22._03
{
    public class DepartmentMethods
    {
        static private UnitOfWork unitOfWork;
        public static void AddDepartment()
        {
            Console.WriteLine("You chose (1) Add.");
            Console.WriteLine("Please, enter department Name:");
            var departmentName = Console.ReadLine();
            Console.Clear();

            Console.WriteLine("Would you like to add?");
            Console.WriteLine($"Name - {departmentName}");

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        var newDepartment = new Department()
                        {
                            Name = departmentName,
                        };

                        unitOfWork.DepartmantRepository.Insert(newDepartment);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nDepartment is added.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            UI.DisplayDepatmentMenu();
                        }
                        break;
                    }
                case "n":
                    UI.DisplayDepatmentMenu();
                    break;
            }
        }

        public static void DeleteDepatment()
        {

            Console.WriteLine("You chose (2) Delete.");
            Console.WriteLine("Please, enter DepartmentID:");
            var departmentId = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Would you like to delete?");
            var departmentToDelete = unitOfWork.DepartmantRepository.GetByID(departmentId);
            Console.WriteLine(departmentToDelete);

            Console.WriteLine("\nPress Y or N:");
            var decision = Console.ReadLine();
            switch (decision)
            {
                case "y":
                    {
                        unitOfWork.DepartmantRepository.Delete(departmentToDelete);
                        unitOfWork.Save();
                        unitOfWork.Dispose();

                        Console.Clear();
                        Console.WriteLine("\nDepartment is deleted.");

                        Console.WriteLine("\nPress M to back");
                        var result = Console.ReadLine();
                        if (result == "m")
                        {
                            UI.DisplayDepatmentMenu();
                        }
                        break;

                    }
                case "n":
                    UI.DisplayDepatmentMenu();
                    break;
            }
        }

        public static void UpdateDepartment()
        {
            unitOfWork = new UnitOfWork();

            Console.WriteLine("You chose (3) Update.");
            Console.WriteLine("Please, enter DepartmentID:");
            var departmentId = Int32.Parse(Console.ReadLine());
            var selectedDepartment = unitOfWork.DepartmantRepository.GetByID(departmentId);

            Console.Clear();

            Console.WriteLine("You chose department:");
            Console.WriteLine(selectedDepartment);

            Console.WriteLine("\nPlease, choose attribute which you want to update:");

            Console.WriteLine("1 - Name");
            Console.WriteLine("m - Back to menu");

            var attributeResult = Console.ReadLine();

            Console.Clear();

            UpdateDepartmentAttributeMenu(selectedDepartment, attributeResult);
        }

        public static void DisplayAllDepartments()
        {
            unitOfWork = new UnitOfWork();

            var departments = unitOfWork.DepartmantRepository.Get();

            Console.WriteLine("Here is all courses:");
            foreach (var department in departments)
            {
                Console.WriteLine(department);
            }

            Console.WriteLine("\nPress M to back");
            var decision = Console.ReadLine();
            if (decision == "m")
            {
                UI.DisplayDepatmentMenu();
            }
        }

        public static void UpdateDepartmentAttributeMenu(Department department, string attributeResult)
        {
            switch (attributeResult)
            {
                case "1":
                    {
                        Console.WriteLine($"You want to change Name - {department.Name}");
                        Console.WriteLine("Please, enter a new one:");
                        var departmentName = Console.ReadLine();

                        Console.WriteLine("Press Y or N to save:");
                        var decision = Console.ReadLine();
                        switch (decision)
                        {
                            case "y":
                                {
                                    department.Name = departmentName;
                                    unitOfWork.DepartmantRepository.Update(department);
                                    unitOfWork.Save();
                                    unitOfWork.Dispose();

                                    Console.Clear();
                                    Console.WriteLine("Department's name is updated.");

                                    Console.WriteLine("\nPress M to back");
                                    var result = Console.ReadLine();
                                    if (result == "m")
                                    {
                                        UI.DisplayDepatmentMenu();
                                    }
                                    break;
                                }
                            case "n":
                                UpdateDepartment();
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