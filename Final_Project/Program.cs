using System;
using System.Collections.Generic;

namespace Final_Project
{
    internal class Program
    {
        private const int ADD = 1;
        private const int DELETE = 2;
        private const int EDIT =3;
        private const int LIST =4;
        private const int EXIT = 5;
        
        //MENU SYSTEM FOR USER TO NAVIGATE APPLICATION
        static int GetMenuChoice()
        {
            Console.WriteLine("Student Club Management");
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Delete Student");
            Console.WriteLine("3. Edit Student");
            Console.WriteLine("4. List Students");
            Console.WriteLine("5. Exit");
            Console.Write("\nSelect an option: ");

            int menuChoice = Convert.ToInt32(Console.ReadLine());
            if (menuChoice > 5 || menuChoice <= 0)
            {
                Console.WriteLine("Invalid option, please choose between options 1-5.\n");
            }
            
            return menuChoice;
        }
        
        //method to add student to list
        static Student AddNewStudent()
        {
            Console.Write("Enter first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Student added successfully\n");

            //creates a new student object
            Student newStudent = new Student(firstName, lastName, email);

            return newStudent;
            
        }
        
        //method to delete student from list
        static void DeleteStudent(List<Student> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("There are no students on the list.\n");
            }
            else
            {
                //print list of students
                ListAllStudents(studentList);
                
                //which to delete?
                Console.Write("Enter # to delete: ");
                int deleteNumber = Convert.ToInt32(Console.ReadLine());

                if (deleteNumber > studentList.Count + 1 || deleteNumber < studentList.Count-(studentList.Count))
                {
                    Console.WriteLine("Student number does not exist, please choose valid number.");
                }
                else {
                //remove student from list
                studentList.RemoveAt(deleteNumber - 1);

                Console.WriteLine("Student deleted successfully\n");
                }
            }
        }
        
        //method to edit students
        static void EditStudent(List<Student> studentList)
        {
            if (studentList.Count == 0)
            {
                Console.WriteLine("There are no students on the list.\n");
            }
            else
            { 
                //print list of students
                ListAllStudents(studentList);
                
            
            //which to edit? 
            Console.Write("Enter # to edit: ");
            int editNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter new first name: ");
            studentList[editNumber - 1].FirstName = Console.ReadLine();
            Console.Write("Enter new last name: ");
            studentList[editNumber - 1].LastName = Console.ReadLine();
            Console.Write("Enter new email: ");
            studentList[editNumber - 1].Email = Console.ReadLine();
            Console.WriteLine("Student edited successfully\n");
            
            //edit student on list
            }
        }
        
        //print student list method 
        static void ListAllStudents(List<Student> allStudents)
        {
            if (allStudents.Count == 0)
            {
                Console.WriteLine("There are no students on the list.");
            }

            for (int i = 0; i < allStudents.Count; i++)
            {
                Student student = allStudents[i];
                Console.WriteLine($"{i + 1}. {student.ToString()}");
            }

            //this is just here to print an extra line to separate this method from the menu
            Console.WriteLine("");
        }
        
        
        

        public static void Main(string[] args)
        {
            //create a list to hold students
            var studentList = new List<Student>();
            
            //print menu
            int menuChoice = GetMenuChoice();

            while (menuChoice != EXIT)
            {
                switch (menuChoice)
                {
                    //if adding a student
                    case ADD:
                        Student newStudent = AddNewStudent();
                        studentList.Add(newStudent);
                        break;
                        
                    //if deleting a student
                    case DELETE:
                        DeleteStudent(studentList);
                        break;
                    
                    
                    //if editing a student
                    case EDIT:
                        EditStudent(studentList);
                        break;
                    
                    
                    //if listing students
                    case LIST:
                        ListAllStudents(studentList);
                        break;
                }

                menuChoice = GetMenuChoice();
            }

            Console.WriteLine("\nThank you for using the student list!");
        }
    }
}