using System;
using System.Text.RegularExpressions;

namespace UserDefinedException
{
    public class MyInvalidException : Exception
    {
        public MyInvalidException(string message) : base(message)
        {
        }
    }

    class Program
    {
        static bool IsValidEmail(string str)
        {
            const String pattern =
            @"^([0-9a-zA-Z]" + //Start with a digit or alphabetical
            @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continuous or ending +-_. chars in email
            @")+" +
            @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
            // Return true if str is in valid e-mail format.

            return Regex.IsMatch(str, pattern);
        }
        static string CkeckEmail(out Exception eObj)
        {
            string addr;
            do
            {
                eObj = null;
                Console.WriteLine("Enter e-mail address: ");
                addr = Console.ReadLine();

                try
                {
                    if (!IsValidEmail(addr))
                    {
                        throw (new MyInvalidException("Invalid e-mail address!"));
                    }
                }
                catch (MyInvalidException e)
                {
                    Console.WriteLine("MyEmailException: {0}", e.Message);
                    eObj = e;
                }

            } while (eObj != null);

            return addr;
        }

        static bool IsValidName(string str)
        {
            //ToDo
            //process string str for a valid name input
            //You may use strings or regular expressions for completing it
            //return true if the name is valid, return false otherwise
            //change this return true statement, only return true when the name is valid.

            /*
            @"^([0-9a-zA-Z]" + //Start with a digit or alphabetical
            @"([\+\-_\.][0-9a-zA-Z]+)*" + // No continuous or ending +-_. chars in email
            @")+" +
            @"@(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]*\.)+[a-zA-Z0-9]{2,17})$";
            // Return true if str is in valid e-mail format.

             * */

            const String pattern =
            @"^([A-Z][a-z]*)(\s([A-z][a-z]*))*$|" +
            @"^([A-Z][a-z]*\s)+([A-Z][a-z]*)$|" +
            @"^([A-Z]\.\s)+([A-Z][a-z]*)$|" +
            @"^(Dr\.|Mr\.|Mrs\.|Ms\.)\s[A-Z][a-z]*$";

            return Regex.IsMatch(str, pattern);

            /*
             //Examples of valid Names:
            Mahbub Murshed
            Mahbub 
            Susan Harper
            Michael Jackson
            Sir Thomas Alva Edison
            Dr. Julius Hossain
            Mr. Smith
            A. K. M. Asadujjaman
             */

            /*
             //Examples of invalid Names:
            mahbub murshed    //first letter of every word must be a capital letter
            mahBub            //Middle letters must not be capital
            S.. Harper        //Two or more consecutive dots(.) not allowed
            M.Jackson         //A single Space must be there after a dot(.)
            . Name            //One or more characters are required before a dot(.)
            Sir_Thomas_Alva_Edison  //Only alphabet characters and dot(.) are allowed
            Julius Hoss@in        //Special characters are not allowed 
             */
        }

        static string CkeckName(out Exception eObj)
        {
            string addr;
            do
            {
                eObj = null;
                Console.WriteLine("Enter a name: ");
                addr = Console.ReadLine();

                try
                {
                    if (!IsValidName(addr))
                    {
                        throw (new MyInvalidException("Invalid Name!"));
                    }
                }
                catch (MyInvalidException e)
                {
                    Console.WriteLine("MyNameException: {0}", e.Message);
                    eObj = e;
                }
            } while (eObj != null);
            //eObj = null;
            /*
             Same as email eaxmple, collect name input in a infinity loop until the input is valid.
            Through an exception for invalid name input.
            Use the following expection message while throwing an exception:
               "Invalid Name! \nName must start with a Capital letter and no digits or symbols are allowed except dot(.)"
             
             */



            return addr;
        }

        static bool IsValidPhone(string str)
        {
            const String pattern = 
            @"^(\+[0-9]{1,4}[- ]?)?([0-9]{1,4}[- ]?)?[0-9]{3}[- ]?[0-9]{3}[- ]?[0-9]{4}$";
            //ToDo
            //process string str for a valid phone number string
            //You may use strings or regular expressions for completing it
            //return true if the phone number format is valid, return false otherwise
            //change this return true statement, only return true when the phone number is valid.
            return Regex.IsMatch(str, pattern);
            /*
             //Example of valid phones:
             +1 555-333-7777
             +880-765-543-1234
             987 543 1234
             1-999-123-1234
             88 123 123 1234
             +82-111-222-3333

            //Example of invalid phones:
            ++456-432-1234      //Two leading ‘+’ signs are not allowed
            123-123             //Must be at least a 10-digit number (Use more digits if the number has country code)
            1-1234-123-1236     //(optional ‘+’ symbol) (optional country code [length 1 to 4 digit length maximum]), 
                                //there will be exactly 3 digits then by 3 digits finally the last 4 digits except the country code.
            -1 403-333-1234      //First symbol before country code can be only ‘+’
            +12345-123-123-1234  //Country code must not be more than 4 digits


             */

        }
        static string CkeckPhone(out Exception eObj)
        {
            string addr;
            do
            {
                eObj = null;
                Console.WriteLine("Enter a phone number: ");
                addr = Console.ReadLine();

                try
                {
                    if (!IsValidPhone(addr))
                    {
                        throw (new MyInvalidException("Invalid phone number!"));
                    }
                }
                catch (MyInvalidException e)
                {
                    Console.WriteLine("MyPhoneException: {0}", e.Message);
                    eObj = e;
                }
            } while (eObj != null);
            //eObj = null;
            /*
             Same as email eaxmple, collect name input in a infinity loop until the input is valid.
            Through an exception for invalid name input.
            Use the following expection message while throwing an exception:
               "Invalid Name! \nName must start with a Capital letter and no digits or symbols are allowed except dot(.)"
             
             */



            return addr;
        }

        




        static void Main(string[] args)
        {
            Exception eObj;
            string Name = CkeckName(out eObj);
            string Phone = CkeckPhone(out eObj);
            string Email = CkeckEmail(out eObj);

            Console.WriteLine();
            Console.WriteLine("Your Name is : " + Name);
            Console.WriteLine("Your Phone Number is : " + Phone);
            Console.WriteLine("Your e-mail is : " + Email);  //Note: the e-mail address is already done for you.

            Console.ReadLine();
        }
    }
}
