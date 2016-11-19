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
        private const string Ircregex = @"^(:(?<prefix>\S+) )?(?<command>\S+)( (?!:)(?<params>.+?))?( :(?<trail>.+))?$";

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

        public static object [ ] Margs ( params object [ ] args )
        {
            return args;
        }

        private void SetPort ( ref int port )
        {
            if ( port <= 0 )
                throw new ArgumentOutOfRangeException ( nameof ( port ) );
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

        public Channel GetChannel ( string name )
        {
            return _channels.First ( ch => ch.Name == name );
        }

        private void Listen ( )
        {
            string msg;

            Raw ( "NICK", Margs ( _nick ) );
            Raw ( "USER", Margs ( _user, _cmode, "*" ), _realname );

            while ( ( msg = _reader.ReadLine ( ) ) != null )
            {
                Debug.WriteLine ( msg, "Irc Debug" );
                string prefix, command, tail;
                string [ ] parms;
                if ( !ParseReply ( msg, out prefix, out command, out parms, out tail ) )
                    continue;
                if ( command.IsNumber ( ) )
                {
                    var c = ( ReplyCode ) Enum.Parse ( typeof ( ReplyCode ), command );
                    switch ( c )
                    {
                        // A=b :Are supported by this server
                        case ReplyCode.RplBounce:
                            for ( int i = 1; i < parms.Length; i++ )
                            {
                                string mbrName;
                                string val = string.Empty;
                                if ( parms [ i ].Contains ( '=' ) )
                                {
                                    string [ ] tmp = parms [ i ].Split ( '=' );
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
                            Console.WriteLine ( tail.Substring ( 2 ) );
                            break;

                        case ReplyCode.RplMotd:
                            Console.WriteLine ( tail.Substring ( 2 ) );
                            break;

                        case ReplyCode.RplEndofmotd:
                            Console.WriteLine ( tail );
                            Channel ch = new Channel ( this, "#tmfksoft", null );
                            // Raw ( "JOIN", margs ( "#tmfksoft" ) );
                            ch.Join ( );
                            _channels.Add ( ch );
                            break;

                        case ReplyCode.RplEndOfNames:
                            Console.WriteLine ( $@"-> {tail}" );
                            break;

                        case ReplyCode.RplNamesreply:
                            Channel cx = GetChannel ( parms [ 2 ] );
                            Console.WriteLine ( $@"Names << {tail}" );
                            break;

                        case ReplyCode.ErrUnknowncode:
                            break;

                        case ReplyCode.ErrNosuchnick:
                            break;

                        case ReplyCode.ErrNosuchserver:
                            break;

                        case ReplyCode.ErrNosuchchannel:
                            break;

                        case ReplyCode.ErrCannotsendtochan:
                            break;

                        case ReplyCode.ErrToomanychannels:
                            break;

                        case ReplyCode.ErrWasnosuchnick:
                            break;

                        case ReplyCode.ErrToomanytargets:
                            break;

                        case ReplyCode.ErrNoorigin:
                            break;

                        case ReplyCode.ErrNorecipient:
                            break;

                        case ReplyCode.ErrNotexttosend:
                            break;

                        case ReplyCode.ErrNotoplevel:
                            break;

                        case ReplyCode.ErrWildtoplevel:
                            break;

                        case ReplyCode.ErrBadMask:
                            break;

                        case ReplyCode.ErrUnknownCommand:
                            break;

                        case ReplyCode.ErrNoMotd:
                            break;

                        case ReplyCode.ErrNoAdminInfo:
                            break;

                        case ReplyCode.ErrFileError:
                            break;

                        case ReplyCode.ErrNoNickNameGiven:
                            break;

                        case ReplyCode.ErrErroneusNickname:
                            break;

                        case ReplyCode.ErrNicknameInUse:
                            break;

                        case ReplyCode.ErrNickCollision:
                            break;

                        case ReplyCode.ErrUserNotInChannel:
                            break;

                        case ReplyCode.ErrNotOnChannel:
                            break;

                        case ReplyCode.ErrUserOnChannel:
                            break;

                        case ReplyCode.ErrNoLogin:
                            break;

                        case ReplyCode.ErrSummonDisabled:
                            break;

                        case ReplyCode.ErrUsersDisabled:
                            break;

                        case ReplyCode.ErrNotRegistered:
                            break;

                        case ReplyCode.ErrNeedMoreParams:
                            break;

                        case ReplyCode.ErrAlreadyRegistered:
                            break;

                        case ReplyCode.ErrNoPermForHost:
                            break;

                        case ReplyCode.ErrPasswdMismatch:
                            break;

                        case ReplyCode.ErrYoureBannedCreep:
                            break;

                        case ReplyCode.ErrYouWillBeBanned:
                            break;

                        case ReplyCode.ErrKeySet:
                            break;

                        case ReplyCode.ErrChannelIsFull:
                            break;

                        case ReplyCode.ErrUnknownMode:
                            break;

                        case ReplyCode.ErrInviteOnlyChan:
                            break;

                        case ReplyCode.ErrBannedFromChan:
                            break;

                        case ReplyCode.ErrBadChannelKey:
                            break;

                        case ReplyCode.ErrBadChannelMask:
                            break;

                        case ReplyCode.ErrNoChannelModes:
                            break;

                        case ReplyCode.ErrBanListFull:
                            break;

                        case ReplyCode.ErrNoPrivileges:
                            break;

                        case ReplyCode.ErrChanOpPrivsNeeded:
                            break;

                        case ReplyCode.ErrCantKillServer:
                            break;

                        case ReplyCode.ErrRestricted:
                            break;

                        case ReplyCode.ErrUniqOpPrivIsNeeded:
                            break;

                        case ReplyCode.ErrNoOperHost:
                            break;

                        case ReplyCode.ErrUmodeUnknownFlag:
                            break;

                        case ReplyCode.ErrUsersDontMatch:
                            break;

                        case ReplyCode.RplWelcome:
                            break;

                        case ReplyCode.RplYourHost:
                            break;

                        case ReplyCode.RplCreated:
                            break;

                        case ReplyCode.RplMyinfo:
                            break;

                        case ReplyCode.RplTraceLink:
                            break;

                        case ReplyCode.RplTraceConnecting:
                            break;

                        case ReplyCode.RplTraceAndShake:
                            break;

                        case ReplyCode.RplTraceUnknown:
                            break;

                        case ReplyCode.RplTraceOperator:
                            break;

                        case ReplyCode.RplTraceUser:
                            break;

                        case ReplyCode.RplTraceServer:
                            break;

                        case ReplyCode.RplTraceService:
                            break;

                        case ReplyCode.RplTraceNewType:
                            break;

                        case ReplyCode.RplTraceClass:
                            break;

                        case ReplyCode.RplTraceReconnect:
                            break;

                        case ReplyCode.RplStatsLinkInfo:
                            break;

                        case ReplyCode.RplStatsCommands:
                            break;

                        case ReplyCode.RplStatsCline:
                            break;

                        case ReplyCode.RplStatsNline:
                            break;

                        case ReplyCode.RplStatsIline:
                            break;

                        case ReplyCode.RplStatsKline:
                            break;

                        case ReplyCode.RplStatsQline:
                            break;

                        case ReplyCode.RplStatsYline:
                            break;

                        case ReplyCode.RplEndofStats:
                            break;

                        case ReplyCode.RplUmodeIs:
                            break;

                        case ReplyCode.RplServiceList:
                            break;

                        case ReplyCode.RplServiceListEnd:
                            break;

                        case ReplyCode.RplStatsLline:
                            break;

                        case ReplyCode.RplStatsUptime:
                            break;

                        case ReplyCode.RplStatsOline:
                            break;

                        case ReplyCode.RplStatsHline:
                            break;

                        case ReplyCode.RplLUserClient:
                            break;

                        case ReplyCode.RplLUserOp:
                            break;

                        case ReplyCode.RplLUserUnknown:
                            break;

                        case ReplyCode.RplLUserChannels:
                            break;

                        case ReplyCode.RplLUserMe:
                            break;

                        case ReplyCode.RplAdminMe:
                            break;

                        case ReplyCode.RplAdminLoc1:
                            break;

                        case ReplyCode.RplAdminLoc2:
                            break;

                        case ReplyCode.RplAdminEmail:
                            break;

                        case ReplyCode.RplTraceLog:
                            break;

                        case ReplyCode.RplTraceEnd:
                            break;

                        case ReplyCode.RplTryAgain:
                            break;

                        case ReplyCode.RplLocalUsers:
                            break;

                        case ReplyCode.RplGlobalUsers:
                            break;

                        case ReplyCode.RplAway:
                            break;

                        case ReplyCode.RplUserhost:
                            break;

                        case ReplyCode.RplIson:
                            break;

                        case ReplyCode.RplText:
                            break;

                        case ReplyCode.RplUnaway:
                            break;

                        case ReplyCode.RplNowaway:
                            break;

                        case ReplyCode.RplWhoisuser:
                            break;

                        case ReplyCode.RplWhoisserver:
                            break;

                        case ReplyCode.RplWhoisoperator:
                            break;

                        case ReplyCode.RplWhowasuser:
                            break;

                        case ReplyCode.RplEndofwho:
                            break;

                        case ReplyCode.RplWhoisidle:
                            break;

                        case ReplyCode.RplEndofwhois:
                            break;

                        case ReplyCode.RplWhoischannels:
                            break;

                        case ReplyCode.RplListstart:
                            break;

                        case ReplyCode.RplList:
                            break;

                        case ReplyCode.RplListend:
                            break;

                        case ReplyCode.RplChannelmodeis:
                            break;

                        case ReplyCode.RplUniqueOpIs:
                            break;

                        case ReplyCode.RplNoTopic:
                            break;

                        case ReplyCode.RplTopic:
                            break;

                        case ReplyCode.RplTopicWhoTime:
                            break;

                        case ReplyCode.RplInviting:
                            break;

                        case ReplyCode.RplSummoning:
                            break;

                        case ReplyCode.RplInviteList:
                            break;

                        case ReplyCode.RplEndOfInviteList:
                            break;

                        case ReplyCode.RplExceptionList:
                            break;

                        case ReplyCode.RplEndOfExceptionList:
                            break;

                        case ReplyCode.RplVersion:
                            break;

                        case ReplyCode.RplWhoreply:
                            break;

                        case ReplyCode.RplLinks:
                            break;

                        case ReplyCode.RplEndoflinks:
                            break;

                        case ReplyCode.RplBanList:
                            break;

                        case ReplyCode.RplEndOfBanList:
                            break;

                        case ReplyCode.RplEndOfWhoWas:
                            break;

                        case ReplyCode.RplInfo:
                            break;

                        case ReplyCode.RplEndofinfo:
                            break;

                        case ReplyCode.RplYoureoper:
                            break;

                        case ReplyCode.RplRehashing:
                            break;

                        case ReplyCode.RplYouAreService:
                            break;

                        case ReplyCode.RplTime:
                            break;

                        case ReplyCode.RplUsersstart:
                            break;

                        case ReplyCode.RplUsers:
                            break;

                        case ReplyCode.RplEndofusers:
                            break;

                        case ReplyCode.RplNousers:
                            break;

                        case ReplyCode.RplHostHidden:
                            break;

                        default:
                            Console.WriteLine ( $@"Code <{prefix}> {c} [{parms.Compile ( )}] >> {tail}" );
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
                            Console.WriteLine ( $@"* <{prefix}> {tail}" );
                            break;

                        case "privmsg":
                            Console.WriteLine ( $@"[{_server} ({parms [ 0 ]})] {tail}" );
                            break;

                        case "ping":
                            // PING :CODE HERE
                            Pong ( tail );
                            break;

                        default:
                            Console.WriteLine ( $@"Command <{prefix}> {command} [{parms.Compile ( )}] >> {tail}" );
                            break;
                    }
                }
            }
        }

        public static bool ParseReply ( string input, out string prefix, out string command, out string [ ] parameters, out string tail )
        {
            prefix = command = tail = string.Empty;
            parameters = new string [ ] { };
            var r = new Regex ( Ircregex, RegexOptions.Compiled | RegexOptions.ExplicitCapture );
            Match match = r.Match ( input );

            if ( !match.Success )
                return false;
            prefix = match.Groups [ "prefix" ].Value;
            command = match.Groups [ "command" ].Value;
            parameters = match.Groups [ "params" ].Value.Split ( ' ' );
            string trailing = match.Groups [ "trail" ].Value;

            if ( !string.IsNullOrEmpty ( trailing ) )
                tail = trailing;
            return true;
        }

        public void Raw ( string command, object [ ] args, string message = "" )
        {
            string so;
            if ( args != null )
            {
                string parameters = string.Join ( " ", args );
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