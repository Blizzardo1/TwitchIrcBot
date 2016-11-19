namespace IrcBot
{
    public class Program
    {
        public static void Main ( string [ ] args )
        {
            Irc i = new Irc ( "myNewBot" );
            i.Connect ( "irc.smallirc.in" );
        }
    }
}