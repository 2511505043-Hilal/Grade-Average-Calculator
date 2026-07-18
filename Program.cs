using System;
using System.Collections.Generic;

public class Course {
    public string Name { get; set; }
    public int Credits { get; set; }
    public int Midterm { get; set; }
    public int Final { get; set; }
    public double Average { get; set; }
    public string LetterGrade { get; set; }
    public string Status { get; set; }
}
public class Program {
                                                                                    //büyük küçük ayrımını görmezden gelmesini sağlar.
    public static Dictionary <string , double> GNO_LetterGrade = new Dictionary <string , double>(StringComparer.OrdinalIgnoreCase)
        {
          {"AA" , 4.0} , {"BA" , 3.5} , {"BB" , 3.0} , {"CB" , 2.5} , {"CC" , 2.0} , 
          {"DC" , 1.5} , {"DD" , 1.0} , {"FD" , 0.5} , {"FF" , 0}  
        }; 
    
    public static Dictionary <string , double> GPA_LetterGrade = new Dictionary <string , double>(StringComparer.OrdinalIgnoreCase)
        {
          {"A" , 4.0} , {"A-" , 3.7} , {"B+" , 3.3} , {"B" , 3.0} , {"B-" , 2.7} , {"C+" , 2.3} , 
          {"C" , 2.0} , {"C-" , 1.7} , {"D+" , 1.3} , {"D" , 1.0} , {"D-" , 0.7} , {"F" , 0.0}
        };
    public static List<Course> courses = new List<Course>();
    
    public static void Main(String[] args)
    {
        
        Console.WriteLine();
        bool ContinueProgram = true;
        while (ContinueProgram)
        {
            Console.WriteLine("----------GradeAverageCalculator----------");
            Console.WriteLine("1 - Add Course");
            Console.WriteLine("2 - Remove Course");
            Console.WriteLine("3 - Show Courses");
            Console.WriteLine("4 - Clear All Results");
            Console.WriteLine("5 - Statistics");
            Console.WriteLine("6 - Calculate GNO (AA / BA / BB / CB ...)");
            Console.WriteLine("7 - Calculate GPA (A / A- / B / B+ ...)");
            Console.WriteLine("8 - Exit");
            Console.WriteLine("------------------------------------------");
            Console.WriteLine("Note : You must add courses before calculating !!");
            Console.Write("Your Choice : ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
            switch (choice)
            {
                case 1:
                    Console.Write("How many courses would you like to add : ");
                    int number;
                    while(!int.TryParse(Console.ReadLine() , out number))
                    {
                        Console.WriteLine("Please enter a number !!");
                        Console.Write("How many courses would you like to add : ");
                    }
                    AddCourse(number);
                break;
                
                case 2:
                    RemoveCourse();
                break;
                
                case 3:
                    ShowCourses();
                break;
                
                case 4:
                    ClearAll();
                break;
                
                case 5:
                    Statistics();
                break;
                
                case 6:
                    CalculateGNO();
                break;
                
                case 7:
                    CalculateGPA();
                break;

                case 8:
                    ContinueProgram = false;
                break;
                
                default:
                Console.WriteLine("Please enter a number between 1 and 8 !!");
                break;
            }
            }
            else
            {
                Console.WriteLine("Please enter a valid number !!");
            }
        }
    }
       public static void AddCourse(int number)
    {
        for (int i = 1 ; i <= number ; i++)
        {
            Console.WriteLine("Course " + i);
            
            string name;
            do
            {
                Console.Write("Course Name : ");
                name = Console.ReadLine();
            }
            while (string.IsNullOrWhiteSpace(name));
            
            Console.Write("Credits : ");
            int credits;
            while(!int.TryParse(Console.ReadLine(), out credits) || credits <= 0)
            {
                Console.WriteLine("Credit must be greater than 0 !!");
                Console.Write("Credits : ");
            }

            Console.Write("Midterm Grade : ");
            int midterm;
            while(!int.TryParse(Console.ReadLine() , out midterm) || midterm < 0 || midterm > 100)
            {
                Console.WriteLine("Please enter a grade between 0 and 100 !!");
                Console.Write("Midterm Grade : ");
            }
            
            Console.Write("Final Grade : ");
            int final;
            while(!int.TryParse(Console.ReadLine() , out final) || final < 0 || final > 100)
            {
                Console.WriteLine("Please enter a grade between 0 and 100 !!");
                Console.Write("Final Grade : ");
            }
            double average = (midterm * 0.4) + (final * 0.6);
            string letter = "";
            string status = "";
           
            Console.WriteLine("Select the letter grading system :");
            Console.WriteLine("1 - (AA / BA / BB ..)");
            Console.WriteLine("2 - (A / A- / B+ ..)");
            Console.Write("Your Choice : ");
            int choice1;
            while(!int.TryParse(Console.ReadLine(), out choice1) || ( choice1 != 1 && choice1 != 2))
            {
                Console.WriteLine("Please choose 1 or 2 !!");
                Console.Write("Your Choice : ");
            }
            
            if (choice1 == 1)
            {
                letter = GetOneLetter(average , final);
            }
            else
            {
                letter = GetTwoLetter(average , final);
            }
            
            status = (letter == "FF" || letter == "F") ? "Failed" : "Passed";

            Course course = new Course();
            course.Name = name;
            course.Credits = credits;
            course.Midterm = midterm;
            course.Final = final;
            course.Average = average;
            course.LetterGrade = letter;
            course.Status = status;

            courses.Add(course);
            
            Console.WriteLine("Average : " + average.ToString("F2"));
            Console.WriteLine("Letter Grade : " + letter);
            Console.WriteLine("Status : " + status);
        }
    }
    public static string GetOneLetter(double average , int final)
    {
        if(final < 50) return "FF";
        if(average >= 90) return "AA";
        if(average >= 85) return "BA";
        if(average >= 80) return "BB";
        if(average >= 75) return "CB";
        if(average >= 70) return "CC";
        if(average >= 65) return "DC";
        if(average >= 50) return "DD";

        return "FF";
    }
    public static string GetTwoLetter(double average , int final)
    {
        if(final < 50) return "F";
        if(average >= 90) return "A";
        if(average >= 85) return "A-";
        if(average >= 80) return "B+";
        if(average >= 75) return "B";
        if(average >= 70) return "B-";
        if(average >= 65) return "C+";
        if(average >= 60) return "C";
        if(average >= 57) return "C-";
        if(average >= 54) return "D+";
        if(average >= 51) return "D";
        if(average == 50) return "D-";

        return "F";
    }
    public static void RemoveCourse()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("There are no courses to remove !!");
            return;
        }
        
        Console.WriteLine("-------- Courses --------");
        
        foreach (Course course2 in courses)
        {
            Console.WriteLine("Name     : " + course2.Name);
            Console.WriteLine("Credits  : " + course2.Credits);
            Console.WriteLine("Average  : " + course2.Average.ToString("F2"));
            Console.WriteLine("Letter   : " + course2.LetterGrade);
            Console.WriteLine("Status   : " + course2.Status);
            Console.WriteLine("-------------------------");
            Console.WriteLine("");
        }

        while(true)
        {
            Console.Write("Enter the course name to remove : ");
            string remove = Console.ReadLine();
        
            if (string.IsNullOrWhiteSpace(remove))
            {
                Console.WriteLine("Course name cannot be empty !!");
                continue;
            }
            bool found = false;
        
            for (int i = 0; i < courses.Count; i++)
            {
                if (courses[i].Name.Equals(remove, StringComparison.OrdinalIgnoreCase))
                {
                    courses.RemoveAt(i);
                    Console.WriteLine("Course removed successfully.");
                    found = true;
                    break;
                }
            }
            
            if (found)
            {
                break;
            }
            
            Console.WriteLine("Course not found. Please try again !!");
        }
    }
    public static void ShowCourses()
    {
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.White;
        
        Console.WriteLine("");
        Console.WriteLine("-------- Courses --------");
        
        if (courses.Count == 0)
        {
            Console.WriteLine("There are no courses to display !!");
            Console.ResetColor();
            return;
        }

        foreach (Course course2 in courses)
        {
            Console.WriteLine("Name     : " + course2.Name);
            Console.WriteLine("Credits  : " + course2.Credits);
            Console.WriteLine("Final    : " + course2.Final);
            Console.WriteLine("Midterm  : " + course2.Midterm);
            Console.WriteLine("Average  : " + course2.Average.ToString("F2"));
            Console.WriteLine("Letter   : " + course2.LetterGrade);
            Console.WriteLine("Status   : " + course2.Status);
            Console.WriteLine("-------------------------");
            Console.WriteLine("");

        }
        Console.ResetColor();
    }
    public static void ClearAll()
    {
        string answer;
        while (true)
        {
            if (courses.Count == 0)
            {
                Console.WriteLine("There are no results to clear .");
                return;
            }
            Console.Write("Are you sure you want to clear all results ? (Y / N) : ");
            answer = Console.ReadLine();

            if (answer == "Y" || answer == "y")
            {
                courses.Clear();
                Console.WriteLine("All results have been cleared successfully :D");
                return;
            }
            else if (answer == "N" || answer == "n")
            {
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please enter Y or N !!");
                Console.ResetColor();
            }
        }
    }
    public static void Statistics()
    {
        if (courses.Count == 0)
        {
            Console.WriteLine("There are no courses to analyze !!");
            return;
        }
        int passed = 0;
        int failed = 0;
        double highest = 0;
        double lowest = 100;
        string name1 = "";
        string name2 = "";
        string letter1 = "";
        string letter2 = "";        
        double total = 0;
        int credit = 0;

        foreach (Course PassFail in courses)
        {
            if (PassFail.Status == "Passed")
            {
                passed ++;
            }
            else if (PassFail.Status == "Failed")
            {
                failed ++;
            }
        }
        
        for (int i = 0 ; i < courses.Count ; i++)
        {
            total += courses[i].Average;
            credit += courses[i].Credits;

            if (courses[i].Average > highest)
            {
                highest = courses[i].Average;
                name1 = courses[i].Name;
                letter1 = courses[i].LetterGrade;
            }
            if (courses[i].Average < lowest)
            {
                lowest = courses[i].Average;
                name2 = courses[i].Name;
                letter2 = courses[i].LetterGrade;
            }
        }
        
        double average = total / courses.Count;
        double rate = (double)passed / (passed + failed) * 100;
        Console.WriteLine("");
        Console.WriteLine("-------- Statistics --------");
        Console.WriteLine("Total Courses         : " + courses.Count);
        Console.WriteLine("Passed Courses        : " + passed);
        Console.WriteLine("Failed Courses        : " + failed);
        Console.WriteLine("Success Rate          : %" + rate.ToString("F2") );
        Console.WriteLine("Average Score         : " + average.ToString("F2"));
        Console.WriteLine("Total Credits         : " + credit);
        Console.WriteLine("");
        Console.WriteLine("Highest Grade Course : " + name1);
        Console.WriteLine("Average              : " + highest.ToString("F2"));
        Console.WriteLine("Letter Grade         : " + letter1);
        Console.WriteLine("");
        Console.WriteLine("Lowest Grade Course  : " + name2);
        Console.WriteLine("Average              : " + lowest.ToString("F2"));
        Console.WriteLine("Letter Grade         : " + letter2);
        Console.WriteLine("----------------------------");
    }
    public static void CalculateGNO()
    {
        Console.Write("How many courses would you like to enter : ");
        int CourseCount;
        while(!int.TryParse(Console.ReadLine(), out CourseCount) || CourseCount > 28 || CourseCount <= 0)
        {
            Console.WriteLine("Please enter a number !!");
            Console.Write("How many courses would you like to enter : ");
        }
        
        int credit = 0;
        string letter = "";
        int totalCredit = 0;
        double total = 0;
        
        for (int i = 1; i <= CourseCount ; i++)
        {
            Console.WriteLine("Course " + i );
            Console.WriteLine("");
            
            do
            {
                Console.Write("Letter Grade : ");
                letter = Console.ReadLine();
            }while(string.IsNullOrWhiteSpace(letter));
            
            while (!GNO_LetterGrade.ContainsKey(letter))
            {
                Console.WriteLine("Invalid letter grade !!");
                Console.Write("Letter Grade : ");
                letter = Console.ReadLine();
            }
            
            Console.WriteLine("Credits : ");
            while(!int.TryParse(Console.ReadLine(), out credit) || credit <= 0)
            {
                Console.WriteLine("Please enter a number !!");
            }
            
            totalCredit += credit;
            total += GNO_LetterGrade[letter] * credit;
        }
        
        double gno = total / totalCredit;
        Console.WriteLine("Calculate GNO : " + gno.ToString("F2"));
    }  
    public static void CalculateGPA()
    {
        Console.Write("How many courses would you like to enter : ");
        int CourseCount;
        while(!int.TryParse(Console.ReadLine(), out CourseCount) || CourseCount > 28 || CourseCount <= 0)
        {
            Console.WriteLine("Please enter a number !!");
            Console.Write("How many courses would you like to enter : ");
        }
        int credit = 0;
        string letter = "";
        int totalCredit = 0;
        double total = 0;
        for (int i = 1; i <= CourseCount ; i++)
        {
            Console.WriteLine("Course " + i );
            Console.WriteLine("");
            
            do
            {
                Console.Write("Letter Grade : ");
                letter = Console.ReadLine();
            }while(string.IsNullOrWhiteSpace(letter));

            while (!GPA_LetterGrade.ContainsKey(letter))
            {
                Console.WriteLine("Invalid letter grade !!");
                Console.Write("Letter Grade : ");
                letter = Console.ReadLine();
            }

            Console.WriteLine("Credits : ");
            while(!int.TryParse(Console.ReadLine(), out credit) || credit <= 0)
            {
                Console.WriteLine("Please enter a number !!");
            }
            
            totalCredit += credit;
            total += GPA_LetterGrade[letter] * credit;
        }
        double gpa = total / totalCredit;
        Console.WriteLine("Calculate GPA : " + gpa.ToString("F2"));
    }     
}
