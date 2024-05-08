

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CRUD
{
    public class program
    {
        public static void Main(string[] args)
        {

            while (true) 
            {
                Console.WriteLine("Student Menu !! ");
                Console.WriteLine("1. Get All Student ");
                Console.WriteLine("2. Get Student By Id ");
                Console.WriteLine("3. Add Student ");
                Console.WriteLine("4. Update Student");
                Console.WriteLine("5. Delete Student");
                Console.WriteLine("6. Exit\n\n");

                Console.WriteLine("Enter the Option :");
                int op = Convert.ToInt32(Console.ReadLine());


                switch (op)
                {
                    case 1:
                        Console.WriteLine("\nAll student Details :\n");

                        StudentController.GetAllStudent();
                        break;

                    case 2:
                        Console.WriteLine("\nEnter Student Roll No");
                        int rNo = Convert.ToInt32(Console.ReadLine());

                        StudentController.GetStudentByRollNo(rNo);
                        break;

                    case 3:
                        Console.WriteLine("\nEnter Student Name");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter Student Roll Number");
                        int rollNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Student Date of Birth");
                        DateOnly dob = DateOnly.Parse(Console.ReadLine());

                        Student student = new Student();
                        student.name = name;
                        student.rollNo = rollNo;
                        student.dob = dob;
                        StudentController.AddStudent(student);
                        break;

                    case 4:
                        Console.WriteLine("Enter Student Roll Number");
                        int searchRollNo = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("\nUpdate Menu !! ");
                        Console.WriteLine("1. Update Name ");
                        Console.WriteLine("2. Update Roll Number ");
                        Console.WriteLine("3. Update Date of Birth\n ");
                        Console.WriteLine("Enter the Option :");
                        int option = Convert.ToInt32(Console.ReadLine());
                        Student std = new Student();

                        switch (option)
                        {
                            case 1:
                                Console.WriteLine("Enter Student Name");
                                string updateName = Console.ReadLine();
                                std.name = updateName;
                               StudentController.UpdateStudent(searchRollNo,new Student { name=updateName} ,1);
                                break;
                            case 2:
                                Console.WriteLine("Enter Student Roll Number");
                                int updateRollNo = Convert.ToInt32(Console.ReadLine());
                                std.rollNo = updateRollNo;
                                StudentController.UpdateStudent(searchRollNo, new Student { rollNo = updateRollNo }, 2);
                                break;
                            case 3:
                                Console.WriteLine("Enter Student Date of Birth(format:yyyy-mm-dd)");
                                DateOnly updateDob = DateOnly.Parse(Console.ReadLine());
                                std.dob = updateDob;
                                StudentController.UpdateStudent(searchRollNo, new Student { dob = updateDob }, 3);
                                break;
                            default:
                                Console.WriteLine("Wrong Input ");
                                break;
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter Student roll Number");
                        int deleteId = Convert.ToInt32(Console.ReadLine());
                        StudentController.DeleteStudent(deleteId);
                        break;
                    case 6:
                        System.Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Wrong Input ");
                        break;
                }
            }
        }
    }
}

