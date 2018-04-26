using System;
using System.Globalization;
/*Att göra:
 * Fylla i kommentarer.
 */ 

namespace Pension
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Hej och välkommen till detta programm som ska räkna ut hur långt du har kvar till pension.\nVargod fylle i ditt förnamn och sedan trycker du på Enter-knappen. ");
            string firstName = Console.ReadLine();
                      

            Console.WriteLine("\nOch nu " + firstName + ", fyller in ditt efternamn och sedan trycker du igen på Enter-knappen: ");
            string lastName = Console.ReadLine();
            

            DateTime bday = AskBirthday(firstName, lastName);

            DateTime today = DateTime.Today;
            int age = today.Year - bday.Year; // datum här
            int pension = 65;
            if (age >= pension)
            {
                Console.WriteLine("\nDu har redan fyllt 65 år.");
                Console.ReadLine();
                return;
            }
            else
            {
                Console.WriteLine("\nDu " + firstName + " " + lastName + ", har " + (pension - age) + "år kvar till pensions ålder.\nTack för du använda mitt program!");
                Console.ReadLine();
            }
        }

        public static DateTime AskBirthday(string firstName, string lastName)
        {

            string insertAge;
            DateTime bday = DateTime.Today;
            CultureInfo customCulture = new CultureInfo("en-US", true);

            customCulture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";

            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            System.Threading.Thread.CurrentThread.CurrentUICulture = customCulture;

            DateTime newDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

            bool hasBirthday = false;
            while (hasBirthday == false)
            {
                Console.Write("\n" + firstName + " " + lastName + ", vill du vara så vänlig att fylla in din födelsedag genom att skriva med siffror på följade sätt YYYY-MM-DD. \n(Till exempel 2010-01-30)\nProgrammet räkna sedan ut hur långt du har kvar till pension: \n");
                insertAge = Console.ReadLine();
                try
                {
                    bday = Convert.ToDateTime(insertAge);
                    hasBirthday = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Du har angivit födelsedag i fel format.\n");
                }
            }
            return bday;
        }
    }
}
    