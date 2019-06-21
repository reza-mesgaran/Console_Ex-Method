using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Note (Ex-Method )
  1. Should defines in static class 
  2. Should define as a static method
  3. Can & Can't have a return value 
  4. Despite Ex-Method is Static but is accessible from instance of its target class (not directly from its class)
 */
namespace Console_Ex_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter something here:");
            string strInput = (Console.ReadLine().Trim());  
            strInput.WordCounter();                           // Using Ex-Method for Native Class (string class) -- word counter
            Console.WriteLine(EX_Method.Tavan2(12));          // Using Ex-Method for Native Class (int class)  -- calculate x*x

            Person p1 = new Person() { Id = 0, Fname = "Reza", Lname = "Mesgaran",Sex="Man"}; 
            Console.WriteLine(p1.FullName(p1.Fname, p1.Lname, p1.Sex));    // Using Ex-Method for user-defined Class (person class)  -- add prefix 
            Console.ReadKey();
        }
    }
    public static class EX_Method
    {
        public static void WordCounter(this string str)
        {
            char[] ch = str.ToCharArray();
            int digit = 0;
            int letter = 0;

            foreach (char c in ch)
            {
                if (!char.IsWhiteSpace(c))
                {
                    if (char.IsDigit(c))
                        digit++;
                    else if (char.IsLetter(c))
                        letter++;
                }
            }
            Console.WriteLine("Your entery has {0} letters and {1} digit ", letter, digit);
        }   // Ex-Method for Native Classes - Without Return

        public static int Tavan2(this int n)                 // Ex-Method for Native Classes- With Return
        {
            return (n * n);
        }

        public static string FullName(this Person person, string Fname, string Lname ,string Sex)  // Ex-Method for User-Defined Classes 
        {
            if (Sex == "Man")           //First value of Enum
                return "Mr. " + Fname + Lname;
            else if (Sex=="Woman")        //Second value of Enum
                return "Mrs. "   +Fname + Lname;
            return null;           // Never Happen
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Sex { get; set; }

    }
}