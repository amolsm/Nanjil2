using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
namespace Comman
{
    public class Comman
    {
        public static string msg { get; set; }
        public static bool IsDataSetEmpty(DataSet DS)
        {
            foreach (DataTable table in DS.Tables)
                if (table.Rows.Count != 0)
                    return false;

            return true;
        }        
        public static bool isValidEmail(string inputEmail)
        {


            string patternLenient = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            Regex reLenient = new Regex(patternLenient);
            string patternStrict = @"^(([^<>()[\]\\.,;:\s@\""]+"
               + @"(\.[^<>()[\]\\.,;:\s@\""]+)*)|(\"".+\""))@"
               + @"((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}"
               + @"\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+"
               + @"[a-zA-Z]{2,}))$";
            Regex reStrict = new Regex(patternStrict);

            //match the strict first, and then match the lenients
            if (reStrict.IsMatch(inputEmail))
                return true;
            else if (reLenient.IsMatch(inputEmail))
                return true;
            else
                return false;
        }
        public static bool IsInteger(string var)
        {
            try
            {
                double i = double.Parse(var);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool isValidMobile(string inputEmail)
        {


            string patternLenient = @"^\d{10}$";
            Regex reLenient = new Regex(patternLenient);

            if (reLenient.IsMatch(inputEmail))
                return true;
            else
                return false;
        }
        public static string CleanInputForDBQuery(string dirty)
        {
            string clean = null;
            if (!String.IsNullOrEmpty(dirty))
            {
                clean = Regex.Replace(dirty, @"'+", "''"); ;//stop single quote escapes for little Jonny Tables
                clean = Regex.Replace(clean, @"[^\w\.@\-']", " "); //replace any non-word character with ""
            }
            return clean;
        }
        public static bool ValiedDate(string datetime)
        {
            if (Regex.IsMatch(datetime, ""))
            {
                return true;

            }
            else
            {
                return false;
            }
        }
        public static bool IsValidInteger(string value)
        {

            double myInt = 0;
            return double.TryParse(value, out myInt);
        }

        public static string RandomString()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}