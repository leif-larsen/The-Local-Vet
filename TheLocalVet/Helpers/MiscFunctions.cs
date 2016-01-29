using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace TheLocalVet.Helpers
{
    public static class MiscFunctions
    {
        public static string UpperCaseFirst(string newText)
        {
			string text = ToPascalCase (newText);

			if (text == null) return string.Empty;
			if (text.Length < 2) return text.ToUpper();

			// Start with the first character.
			string result = text.Substring(0, 1).ToUpper();

			// Add the remaining characters.
			for (int i = 1; i < text.Length; i++)
			{
				if (char.IsUpper(text[i])) result += " ";
				result += text[i];
			}

			return result;
        }

		public static string ToPascalCase(this string the_string)
		{
			// If there are 0 or 1 characters, just return the string.
			if (the_string == null) return the_string;
			if (the_string.Length < 2) return the_string.ToUpper();

			// Split the string into words.
			string[] words = the_string.Split(	
				new char[] { },
				StringSplitOptions.RemoveEmptyEntries);

			// Combine the words.
			string result = "";
			foreach (string word in words)
			{
				result += word.Substring(0, 1).ToUpper() + word.Substring(1);
			}

			return result;
		}
    }
}
