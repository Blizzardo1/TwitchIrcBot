using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace IrcBot
{
    using System.Collections.Generic;
    using System.Text;
    using ReplyCodes;

    public class Irc
    {
        private const string ircregex = @"^(:(?<prefix>\S+) )?(?<command>\S+)( (?!:)(?<params>.+?))?( :(?<trail>.+))?$";

        private string _nick, _user, _realname, _server, _message,
        // Totally up to you
        _servpass, _nspass
        // </>
        ;

        private int _port;
        private ReplyCode _currentCode;
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;
        private int _cmode;

        private List<Channel> _channels;
        private StringBuilder _tmpUsrDB;
        private Dictionary<string, string> _serverParams;

        public Irc ( string nick ) : this ( nick, Resources.BotDefaultName, Resources.BotDefaultRealName, true )
        {
        }

        public Irc ( string nick, string user, string realname, bool invisible )
        {
            SetPort ( ref _port );
            _nick = nick;
            _user = user;
            _realname = realname;
            _currentCode = ReplyCode.RplUnknowncode;
            _cmode = invisible ? 8 : 0;
            _client = new TcpClient ( );
            _channels = new List<Channel> ( );
            _tmpUsrDB = new StringBuilder ( );
            _serverParams = new Dictionary<string, string> ( );
        }

        public static object [ ] margs ( params object [ ] args )
        {
            return args;
        }

        private void SetPort ( ref int port )
        {
            int tP = 6667;
            int.TryParse ( Resources.BotDefaultPort, out tP );
            port = tP;
        }

        public void Connect ( string host )
        {
            Connect ( host, _port );
        }

        public void Connect ( string host, int port )
        {
            IPAddress ip = Dns.GetHostAddresses ( host ).First ( );
            IPEndPoint iep = new IPEndPoint ( ip, port );
            _client.Connect ( host, port );
            var strm = _client.GetStream ( );
            _reader = new StreamReader ( strm );
            _writer = new StreamWriter ( strm );

            if ( _client.Connected )
                Listen ( );
        }

        private void Pong ( string message = "" )
        {
            Raw ( "PONG", null, message );
        }

        public Channel GetChannel(string name) {
            return _channels.First ( ch => ch.Name == name );
        }

        private void Listen ( )
        {
            string msg;

            Raw ( "NICK", margs ( _nick ) );
            Raw ( "USER", margs ( _user, _cmode, "*" ), _realname );

            while ( ( msg = _reader.ReadLine ( ) ) != null )
            {
                Debug.WriteLine ( msg, "Irc Debug" );
                string prefix, command, tail;
                string [ ] parms;
                if ( ParseReply ( msg, out prefix, out command, out parms, out tail ) )
                {
                    if ( command.IsNumber ( ) )
                    {
                        ReplyCode c = ( ReplyCode ) Enum.Parse ( typeof ( ReplyCode ), command );
                        switch ( c )
                        {
                            // A=b :Are supported by this server
                            case ReplyCode.RplBounce:
                                for(int i = 1; i < parms.Length; i++ ) {
                                    string mbrName = string.Empty;
                                    string val = string.Empty;
                                    if ( parms [ i ].Contains ( '=' ) )
                                    {
                                        var tmp = parms [ i ].Split ( '=' );
                                        mbrName = tmp [ 0 ];
                                        val = tmp [ 1 ];

                                    }
                                    else
                                    {
                                        mbrName = parms [ i ];
                                    }
                                    _serverParams.Add ( mbrName, val );
                                }
                            break;
                            case ReplyCode.RplMotdstart:
                                _server = _serverParams [ "NETWORK" ];
                                Console.WriteLine (tail.Substring(2));
                                break;

                            case ReplyCode.RplMotd:
                                Console.WriteLine (tail.Substring(2));
                                break;

                            case ReplyCode.RplEndofmotd:
                                Console.WriteLine (tail);
                                Channel ch = new Channel ( this, "#tmfksoft", null );
                                // Raw ( "JOIN", margs ( "#tmfksoft" ) );
                                ch.Join ( );
                                _channels.Add ( ch );
                                break;
                            case ReplyCode.RplEndOfNames:
                                Console.WriteLine ( $"-> {tail}" );
                                break;
                            case ReplyCode.RplNamesreply:
                                Channel cx = GetChannel ( parms [ 2 ] );
                                Console.WriteLine ( $"Names << {tail}" );
                                break;
                            default:
                                Console.WriteLine ( $"Code <{prefix}> {c} [{parms.Compile ( )}] >> {tail}" );
                                break;
                        }
                    }
                    else
                    {
                        switch ( command.ToLower ( ) )
                        {
                            case "notice":
                                if ( parms [ 0 ].ToLower ( ) == "auth" )
                                {
                                }
                                Console.WriteLine ( $"* <{prefix}> {tail}" );
                                break;
                            case "privmsg":
                                Console.WriteLine ($"[{_server} ({parms[0]})] {tail}");
                                break;
                            case "ping":
                                // PING :CODE HERE
                                Pong ( tail );
                                break;

                            default:
                                Console.WriteLine ($"Command <{prefix}> {command} [{parms.Compile()}] >> {tail}");
                                break;
                        }
                    }
                }
            }
        }

        public static bool ParseReply ( string input, out string prefix, out string command, out string [ ] parameters, out string tail )
        {
            string trailing = null;
            prefix = command = tail = string.Empty;
            parameters = new string [ ] { };
            Regex r = new Regex ( ircregex, RegexOptions.Compiled | RegexOptions.ExplicitCapture );
            Match match = r.Match ( input );

            if ( match.Success )
            {
                prefix = match.Groups [ "prefix" ].Value;
                command = match.Groups [ "command" ].Value;
                parameters = match.Groups [ "params" ].Value.Split ( ' ' );
                trailing = match.Groups [ "trail" ].Value;

                if ( !string.IsNullOrEmpty ( trailing ) )
                    tail = trailing;
                return true;
            }
            return false;
        }

        public void Raw ( string command, object [ ] args, string message = "" )
        {
            string parameters, so = string.Empty;
            if ( args != null )
            {
                parameters = string.Join ( " ", args );
                so = $"{command} {parameters}";

                if ( !string.IsNullOrEmpty ( message ) )
                    so = $"{command} {parameters} :{message}";
            }
            else
            {
                so = $"{command} :{message}";
            }
            Debug.WriteLine ( so, "Irc Bot Raw" );
            _writer.WriteLine ( so );

            _writer.Flush ( );
        }
    }
}