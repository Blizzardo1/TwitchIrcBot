namespace IrcBot
{
    public static class Extensions
    {
        public static bool IsNumber ( this string s )
        {
            int dummy;

            return int.TryParse ( s, out dummy );
        }

        public static string Compile ( this string [ ] s, string delm = " " )
        {
            return string.Join ( delm, s );
        }

        public static bool IsEmpty ( this string s )
        {
            return string.IsNullOrEmpty ( s ) || string.IsNullOrWhiteSpace ( s );
        }
    }
}