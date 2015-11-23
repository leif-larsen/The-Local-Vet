using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLocalVet.Helpers
{
    public static class MiscFunctions
    {
        public static string UpperCaseFirst(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return char.ToUpper(text[0]) + text.Substring(1);
        }
    }
}
