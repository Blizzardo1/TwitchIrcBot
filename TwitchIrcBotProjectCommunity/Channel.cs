namespace IrcBot
{
    public class Channel
    {
        private string _name, _key, _curModes, _topic;
        private Irc _irc;

        public string Name => _name;

        public Channel ( Irc irc, string name, string key )
        {
            _irc = irc;
            _name = name;
            _key = key;
        }

        public void Join ( )
        {
            // JOIN #channel [key]
            if ( _key.IsEmpty ( ) )
                _irc.Raw ( "JOIN", Irc.margs ( _name ) );
            else
                _irc.Raw ( "JOIN", Irc.margs ( _name, _key ) );
        }

        public void Part ( string reason = "I am leaving" )
        {
            // PART #channel :reason
            _irc.Raw ( "PART", Irc.margs ( _name ), reason );
        }

        public bool Kick ( string nick, string reason )
        {
            _irc.Raw ( "KICK", Irc.margs ( _name, nick ), reason );
            return false;
        }

        public bool ChangeTopic ( string newTopic )
        {
            _irc.Raw ( "TOPIC", Irc.margs ( _name ), newTopic );
            return false;
        }

        public bool Mode ( bool append, string modeSet, string[] nicks )
        {
            // MODE #channel +/-modes [nick,]
            char m = append ? '+' : '-';
            string mSet = $"{m}{modeSet}";
            if ( nicks != null )
                _irc.Raw ( "MODE", Irc.margs ( _name, mSet, nicks.Compile ( "," ) ) );
            else
                _irc.Raw ( "MODE", Irc.margs ( _name, mSet ) );

            return false;
        }
    }
}