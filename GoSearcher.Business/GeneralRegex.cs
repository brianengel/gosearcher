using System.Text.RegularExpressions;

namespace GoSearcher.Business
{
    public static class GeneralRegex
    {
        public static Regex NonNumbers = new Regex("[^0-9\\.]", RegexOptions.Compiled);
        public static Regex HexColor = new Regex("#[0-9A-Za-z]{6}", RegexOptions.Compiled);
        public static Regex SteamImageSize = new Regex("[0-9]+fx[0-9]+f", RegexOptions.Compiled);
    }
}
