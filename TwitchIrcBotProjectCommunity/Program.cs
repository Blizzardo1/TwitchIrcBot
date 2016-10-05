using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IrcBot
{
    using ReplyCodes;
    public class Program
    {
        
        public static void Main ( string [ ] args )
        {
            Irc i = new Irc ( "myNewBot" );
            i.Connect ( "irc.smallirc.in" );
        }
    }
}
