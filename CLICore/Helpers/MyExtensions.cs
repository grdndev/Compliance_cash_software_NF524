using System;
using System.Text;
using System.Text.RegularExpressions;

namespace CLICore.Helpers
{
    public static class MyExtensions
    {
        public static string Truncate(this string s, int length, string truncatedsymbol="...")
        {
            if (s.Length > length)
            {
                if (length> truncatedsymbol.Length)
                {
                    return $"{s.Substring(0, length - truncatedsymbol.Length)}{truncatedsymbol}";
                }

                return $"{s.Substring(0, length)})";
            }
                
            return s;
        }

        public static string RemoveSpecialCharacters(this string str)
        {
            StringBuilder sb = new StringBuilder();
            foreach (char c in str)
            {
                if ((c >= '0' && c <= '9') || (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || c == '.' || c == '_')
                {
                    sb.Append(c);
                }
            }

           return sb.ToString();
        }

        public static string RemoveUnicodeCharacters(this string str)
        {
            string output = str.Replace("\u0002", string.Empty).Replace("\u001f",string.Empty).Replace("\u001e",string.Empty);


            
            return output;
        }
    
    //create an extension method to remove all <script> tags and inside content from a string
    public static string RemoveScriptTags(this string str)
    {
        Regex regex = new Regex(@"<script\b[^<]*(?:(?!<\/script>)<[^<]*)*<\/script>", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        return regex.Replace(str, string.Empty);
    }



        

    }
}

