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
                _irc.Raw ( "JOIN", Irc.Margs ( _name ) );
            else
                _irc.Raw ( "JOIN", Irc.Margs ( _name, _key ) );
        }

        public void Part ( string reason = "I am leaving" )
        {
            // PART #channel :reason
            _irc.Raw ( "PART", Irc.Margs ( _name ), reason );
        }

        public bool Kick ( string nick, string reason )
        {
            _irc.Raw ( "KICK", Irc.Margs ( _name, nick ), reason );
            return false;
        }

        public bool ChangeTopic ( string newTopic )
        {
            _irc.Raw ( "TOPIC", Irc.Margs ( _name ), newTopic );
            return false;
        }

        public bool Mode ( bool append, string modeSet, string [ ] nicks )
        {
            // MODE #channel +/-modes [nick,]
            char m = append ? '+' : '-';
            string mSet = $"{m}{modeSet}";
            if ( nicks != null )
                _irc.Raw ( "MODE", Irc.Margs ( _name, mSet, nicks.Compile ( "," ) ) );
            else
                _irc.Raw ( "MODE", Irc.Margs ( _name, mSet ) );

            return false;
        }
    }
}