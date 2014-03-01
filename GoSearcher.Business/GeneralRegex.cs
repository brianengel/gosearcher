using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GoSearcher.Business
{
    public static class GeneralRegex
    {
        public static Regex NonNumbers = new Regex("[^0-9\\.]", RegexOptions.Compiled);
    }
}
