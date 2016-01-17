using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2
{
   class trimString
    {
        public static void splitcomma(ref string str)
        {
            int length = str.Length;
            if (str[length - 1] == ',')
                str = str.Substring(0, length - 1);
        }
    }
}