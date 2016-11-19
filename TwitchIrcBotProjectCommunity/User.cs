using System.Collections.Generic;

namespace IrcBot
{
    public class User
    {
        private string _nick, _host, _realname, _umodes;
        private int _hopCount;
        private List<Channel> _channels;

        // TODO: Implement this
        public static User [ ] GetUsers ( Irc irc )
        {
            List<User> lst = new List<User> ( );
            var code = ReplyCodes.ReplyCode.RplWhoreply;

            return null;
        }
    }
}