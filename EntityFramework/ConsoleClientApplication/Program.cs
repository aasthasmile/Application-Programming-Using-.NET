using Mm.DataAccessLayer;
using Mm.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mm.ConsoleClientApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            IBusinessLayer businessLayer = new BuinessLayer();

            //Table Standard
            //Create, update, and delete-Update by seaching standard id or standard name
            if (!businessLayer.GetAllStandards().Any())
            {
                Console.WriteLine("Currently there are no standards in the database.");
                Console.WriteLine("Please create a standard by entering a Standard Name:");
                Standard create = new Standard() { StandardName = Console.ReadLine() };
                businessLayer.AddStandard(create);
            }

            CUDStandard(businessLayer);
            CUDStudent(businessLayer);
            DisplayStudentsForStandardID(businessLayer);
            Console.ReadLine();
            DisplayAllStandards(businessLayer);
            Console.ReadLine();
            DisplayAllStudents(businessLayer);
            Console.ReadLine();
        }

        private static void DisplayAllStudents(IBusinessLayer businessLayer)
        {
            List<Student> studentList = businessLayer.GetAllStudents().ToList();
            Console.WriteLine("All Students are as follows:");
            foreach (Student student in studentList)
            {
                Console.WriteLine("Student Name: {0}\nStudent ID: {1}", student.StudentName, student.StudentID);
            }
        }

        private static void DisplayAllStandards(IBusinessLayer businessLayer)
        {
            List<Standard> standardList = businessLayer.GetAllStandards().ToList();
            Console.WriteLine("All Standards are as follows:");
            foreach (Standard standard in standardList)
            {
                Console.WriteLine("Standard Name: {0}\nStandard ID: {1}\nStandard Description: {2}", standard.StandardName, standard.StandardId, standard.Description);
            }
        }

        private static void DisplayStudentsForStandardID(IBusinessLayer businessLayer)
        {
            Console.WriteLine("Enter Standard ID for displaying related students:");
            List<Student> studentList = businessLayer.GetStudentsByStandardId(int.Parse(Console.ReadLine())).ToList();
            Console.WriteLine("Students related to standard ID are as follows:");
            foreach (Student student in studentList)
            {
                Console.WriteLine("Student Name: {0}\nStudent ID: {1}", student.StudentName, student.StudentID);
            }
        }

        private static void CUDStudent(IBusinessLayer businessLayer)
        {
            Console.WriteLine("Press 1 to create new student:\nPress 2 to update existing student:\nPress 3 to delete a student:\nPress 4 to skip:");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("Please enter Student Name:");
                        Student create = new Student() { StudentName = Console.ReadLine()};
                        Console.WriteLine("Do you want to associate student with standard?(y/n)");
                        if (Console.ReadLine()=="y")
                        {
                            Console.WriteLine("Please enter standard ID for the Student:");
                            create.StandardId = int.Parse(Console.ReadLine());
                        }
                        businessLayer.AddStudent(create);
                        Console.WriteLine("The created Student is as follows:\nStudent Name: {0}\nStudent ID: {1}",
                            create.StudentName, create.StudentID);
                        if (create.StandardId!=null)
                        {
                            Console.WriteLine("Student belongs to standard with ID: {0}", create.StandardId);
                        }
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("To update Student, Press 1 to update by searching Student ID or press 2 to update by searching Student Name:");
                        Student selectedStudent = new Student();
                        switch (Console.ReadLine())
                        {
                            case "1":
                                {
                                    selectedStudent = SearchStudentID(businessLayer);
                                    break;
                                }
                            case "2":
                                {
                                    selectedStudent = SearchStudentName(businessLayer);
                                    break;
                                }
                            default:
                                break;
                        }
                        Console.WriteLine("Selected Student has the following properties:\nStudent Name: {0}\nStudent ID: {1}",
                                        selectedStudent.StudentName, selectedStudent.StudentID);
                        if (selectedStudent.StandardId!=null)
                        {
                            Console.WriteLine("Student Standard ID: {0}", selectedStudent.StandardId);
                        }
                        Console.WriteLine("Press 1 to update Student Name or press 2 to update Student's Standard ID:");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                {
                                    Console.WriteLine("Enter new name for the Student:");
                                    selectedStudent.StudentName = Console.ReadLine();
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Enter new Standard ID for the Student:");
                                    selectedStudent.StandardId = int.Parse(Console.ReadLine());
                                    break;
                                }
                            default:
                                break;
                        }
                        businessLayer.UpdateStudent(selectedStudent);
                        Console.WriteLine("The updated Student is as follows:\nStudent Name: {0}\nStudent ID: {1}",
                            selectedStudent.StudentName, selectedStudent.StudentID);
                        if (selectedStudent.StandardId!=null)
                        {
                            Console.WriteLine("Student Standard ID: {0}", selectedStudent.StandardId);
                        }
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("To delete a Student, Press 1 to delete by searching Student ID or press 2 to delete by searching Student name:");
                        Student selectedStudent = new Student();
                        switch (Console.ReadLine())
                        {
                            case "1":
                                {
                                    selectedStudent = SearchStudentID(businessLayer);
                                    break;
                                }
                            case "2":
                                {
                                    selectedStudent = SearchStudentName(businessLayer);
                                    break;
                                }
                            default:
                                break;
                        }
                        businessLayer.RemoveStudent(selectedStudent);
                        Console.WriteLine("Requested Student removed:");
                        break;
                    }
                default:
                    break;
            }
            Console.WriteLine("Do you want to repeat?(y/n)");
            if (Console.ReadLine() == "y")
            {
                CUDStudent(businessLayer);
            }
        }

        private static Student SearchStudentName(IBusinessLayer businessLayer)
        {
            Student selectedStudent;
            Console.WriteLine("Please enter Student Name to search:");
            selectedStudent = businessLayer.GetStudentByName(Console.ReadLine());
            if (selectedStudent == null)
            {
                Console.WriteLine("The requested student does not exist");
            }

            return selectedStudent;
        }

        private static Student SearchStudentID(IBusinessLayer businessLayer)
        {
            Student selectedStudent;
            Console.WriteLine("Please enter Student ID to search:");
            selectedStudent = businessLayer.GetStudentByID(int.Parse(Console.ReadLine()));
            if (selectedStudent == null)
            {
                Console.WriteLine("The requested student does not exist");
            }

            return selectedStudent;
        }

        private static void CUDStandard(IBusinessLayer businessLayer)
        {
            Console.WriteLine("Press 1 to create new standard:\nPress 2 to update existing standard:\nPress 3 to delete a standard:\nPress 4 to skip:");
            switch (Console.ReadLine())
            {
                case "1":
                    {
                        Console.WriteLine("Please enter Standard Name:");
                        Standard create = new Standard() { StandardName = Console.ReadLine(), StandardId = businessLayer.GetAllStandards().Count };
                        Console.WriteLine("Please enter description for the Standard:");
                        create.Description = Console.ReadLine();
                        businessLayer.AddStandard(create);
                        Console.WriteLine("The created standard is as follows:\nStandard Name: {0}\nStandard ID: {1}\nStandard Description: {2}",
                            create.StandardName, create.StandardId, create.Description);
                        break;
                    }
                case "2":
                    {
                        Console.WriteLine("To update standard, Press 1 to update by searching standard ID or press 2 to update by searching standard name:");
                        Standard selectedStandard = new Standard();
                        switch (Console.ReadLine())
                        {
                            case "1":
                                {
                                    selectedStandard = SearchStandardID(businessLayer);
                                    break;
                                }
                            case "2":
                                {
                                    selectedStandard = SearchStandardName(businessLayer);
                                    break;
                                }
                            default:
                                break;
                        }
                        Console.WriteLine("Selected Standard has the following properties:\nStandard Name: {0}\nStandard ID: {1}\nStandard Description: {2}",
                                        selectedStandard.StandardName, selectedStandard.StandardId, selectedStandard.Description);
                        Console.WriteLine("Press 1 to update Standard Name or press 2 to update Standard description:");
                        switch (Console.ReadLine())
                        {
                            case "1":
                                {
                                    Console.WriteLine("Enter new name for the standard:");
                                    selectedStandard.StandardName = Console.ReadLine();
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("Enter new description for the standard:");
                                    selectedStandard.Description = Console.ReadLine();
                                    break;
                                }
                            default:
                                break;
                        }
                        businessLayer.UpdateStandard(selectedStandard);
                        Console.WriteLine("The updated standard is as follows:\nStandard Name: {0}\nStandard ID: {1}\nStandard Descripption: {2}",
                            selectedStandard.StandardName, selectedStandard.StandardId, selectedStandard.Description);
                        break;
                    }
                case "3":
                    {
                        Console.WriteLine("To delete a standard, Press 1 to delete by searching standard ID or press 2 to delete by searching standard name:");
                        Standard selectedStandard = new Standard();
                        switch (Console.ReadLine())
                        {
                            case "1":
                                {
                                    selectedStandard = SearchStandardID(businessLayer);
                                    break;
                                }
                            case "2":
                                {
                                    selectedStandard = SearchStandardName(businessLayer);
                                    break;
                                }
                            default:
                                break;
                        }
                        businessLayer.RemoveStandard(selectedStandard);
                        Console.WriteLine("Requested standard removed:");
                        break;
                    }
                default:
                    break;
            }
            Console.WriteLine("Do you want to repeat?(y/n)");
            if (Console.ReadLine()=="y")
            {
                CUDStandard(businessLayer);
            }
        }

        private static Standard SearchStandardName(IBusinessLayer businessLayer)
        {
            Standard selectedStandard;
            Console.WriteLine("Please enter Standard name to search:");
            selectedStandard = businessLayer.GetStandardByName(Console.ReadLine());
            if (selectedStandard == null)
            {
                Console.WriteLine("The requested standard does not exist");
            }

            return selectedStandard;
        }

        private static Standard SearchStandardID(IBusinessLayer businessLayer)
        {
            Standard selectedStandard;
            Console.WriteLine("Please enter Standard ID to search:");
            selectedStandard = businessLayer.GetStandardByID(int.Parse(Console.ReadLine()));
            if (selectedStandard == null)
            {
                Console.WriteLine("The requested standard does not exist");
            }

            return selectedStandard;
        }
    }
}
