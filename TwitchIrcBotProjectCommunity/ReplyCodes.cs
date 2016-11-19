/*‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾‾*\
|*  Copyright (C) 2014  Blizzeta Software                                   *|
|*                                                                          *|
|*  This program is free software: you can redistribute it and/or modify    *|
|*  it under the terms of the GNU General Public License as published by    *|
|*  the Free Software Foundation, either version 3 of the License, or       *|
|*  (at your option) any later version.                                     *|
|*                                                                          *|
|*  This program is distributed in the hope that it will be useful,         *|
|*  but WITHOUT ANY WARRANTY; without even the implied warranty of          *|
|*  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the           *|
|*  GNU General Public License for more details.                            *|
|*                                                                          *|
|*  You should have received a copy of the GNU General Public License       *|
|*  along with this program.  If not, see <http://www.gnu.org/licenses/>.   *|
\*__________________________________________________________________________*/

namespace IrcBot.ReplyCodes
{
    /// <summary>
    /// </summary>
    public enum Colors : int
    {
        /// <summary>
        ///     The color white
        /// </summary>
        White = 0,

        /// <summary>
        ///     The color black
        /// </summary>
        Black = 1,

        /// <summary>
        ///     The color blue
        /// </summary>
        Blue = 2,

        /// <summary>
        ///     The color green
        /// </summary>
        Green = 3,

        /// <summary>
        ///     The color red
        /// </summary>
        Red = 4,

        /// <summary>
        ///     The color maroon
        /// </summary>
        Maroon = 5,

        /// <summary>
        ///     The color purple
        /// </summary>
        Purple = 6,

        /// <summary>
        ///     The color orange
        /// </summary>
        Orange = 7,

        /// <summary>
        ///     The color yellow
        /// </summary>
        Yellow = 8,

        /// <summary>
        ///     The color light green
        /// </summary>
        LightGreen = 9,

        /// <summary>
        ///     The color dark cyan
        /// </summary>
        DarkCyan = 10,

        /// <summary>
        ///     The color cyan
        /// </summary>
        Cyan = 11,

        /// <summary>
        ///     The color royale blue
        /// </summary>
        Royale = 12,

        /// <summary>
        ///     The color magenta
        /// </summary>
        Magenta = 13,

        /// <summary>
        ///     The color gray
        /// </summary>
        Gray = 14,

        /// <summary>
        ///     The color light gray
        /// </summary>
        LightGray = 15,

        /// <summary>
        /// Color is overridden
        /// </summary>
        Overridden = -1
    };

    /// <summary>
    /// The Types of receive codes
    /// </summary>
    public enum ReceiveType : short
    {
        /// <summary>
        ///     Received an Unknown Code
        /// </summary>
        Unknown,

        /// <summary>
        ///     Received Login
        /// </summary>
        Login,

        /// <summary>
        ///     Received Information
        /// </summary>
        Info,

        /// <summary>
        ///     Received the Message of the Day
        /// </summary>
        Motd,

        /// <summary>
        ///     Received the name of a User
        /// </summary>
        Name,

        /// <summary>
        ///      Received a Who reply
        /// </summary>
        Who,

        /// <summary>
        ///     Received a Generic List
        /// </summary>
        List,

        /// <summary>
        ///     Received a Channel Ban List
        /// </summary>
        BanList,

        /// <summary>
        ///     Received a Topic
        /// </summary>
        Topic,

        /// <summary>
        ///     Received a Topic Change
        /// </summary>
        TopicChange,

        /// <summary>
        ///     Received a Whois reply
        /// </summary>
        WhoIs,

        /// <summary>
        ///     Received a WhoWas reply
        /// </summary>
        WhoWas,

        /// <summary>
        ///     Received a Nick Change
        /// </summary>
        NickChange,

        /// <summary>
        ///     Received a list of UserModes
        /// </summary>
        UserMode,

        /// <summary>
        ///     Received a list of Channel Modes
        /// </summary>
        ChannelMode,

        /// <summary>
        ///     Received a Channel Mode Change
        /// </summary>
        ChannelModeChange,

        /// <summary>
        ///     Received an Error Message
        /// </summary>
        ErrorMessage,

        /// <summary>
        ///     Received a Raw Error
        /// </summary>
        Error,

        /// <summary>
        ///     Received a CTCP Request
        /// </summary>
        CtcpRequest,

        /// <summary>
        ///     Received a CTCP reply
        /// </summary>
        CtcpReply,

        /// <summary>
        ///     Received an invite
        /// </summary>
        Invite,

        /// <summary>
        ///     Received a join
        /// </summary>
        Join,

        /// <summary>
        ///     Received a kick
        /// </summary>
        Kick,

        /// <summary>
        ///     Received a part
        /// </summary>
        Part,

        /// <summary>
        ///     Received a ping
        /// </summary>
        Ping,

        /// <summary>
        ///     Received a UserMode Change
        /// </summary>
        UserModeChange,

        /// <summary>
        ///     Received a quit
        /// </summary>
        Quit,

        /// <summary>
        ///     Received a Query message
        /// </summary>
        QueryMessage,

        /// <summary>
        ///     Received a Query notice
        /// </summary>
        QueryNotice,

        /// <summary>
        ///     Received a Query action
        /// </summary>
        QueryAction,

        /// <summary>
        ///     Received a Channel action
        /// </summary>
        ChannelAction,

        /// <summary>
        ///     Received a Channel notice
        /// </summary>
        ChannelNotice,

        /// <summary>
        ///     Received a Channel message
        /// </summary>
        ChannelMessage,

        /// <summary>
        ///     Received a Wallops Message
        /// </summary>
        Wallops,

        /// <summary>
        ///     Received a Reply Code (Raw)
        /// </summary>
        ReplyCode
    }

    /// <summary>
    ///     RFC1459 Reply Codes
    /// </summary>
    public enum ReplyCode : short
    {
        /// <summary>
        ///     An Unkown Error Code
        /// </summary>
        ErrUnknowncode = 000,

        /// <summary>
        ///     &lt;nickname&gt; :No such nick/channel
        /// </summary>
        ErrNosuchnick = 401, // "<nickname> :No such nick/channel"

        /// <summary>
        ///     &lt;server name&gt; :No such server
        /// </summary>
        ErrNosuchserver = 402, // "<server name> :No such server"

        /// <summary>
        ///     &lt;channel name> :No such channel
        /// </summary>
        ErrNosuchchannel = 403, // "<channel name> :No such channel"

        /// <summary>
        ///     &lt;channel name&gt; :Cannot send to channel
        /// </summary>
        ErrCannotsendtochan = 404, // "<channel name> :Cannot send to channel"

        /// <summary>
        ///     &lt;channel name&gt; :You have joined too many channels
        /// </summary>
        ErrToomanychannels = 405, // "<channel name> :You have joined too many channels"

        /// <summary>
        ///     &lt;nickname&gt; :There was no such nickname
        /// </summary>
        ErrWasnosuchnick = 406, // "<nickname> :There was no such nickname"

        /// <summary>
        ///     &lt;target&gt; :Duplicate recipients. No message delivered
        /// </summary>
        ErrToomanytargets = 407, // "<target> :Duplicate recipients. No message delivered"

        /// <summary>
        ///     :No origin specified
        /// </summary>
        ErrNoorigin = 409, // ":No origin specified"

        /// <summary>
        ///     :No recipient given (&lt;command&gt;)
        /// </summary>
        ErrNorecipient = 411, // ":No recipient given (<command>)"

        /// <summary>
        ///    :No text to send
        /// </summary>
        ErrNotexttosend = 412, // ":No text to send"

        /// <summary>
        ///     &lt;mask&gt; :No toplevel domain specified
        /// </summary>
        ErrNotoplevel = 413, // "<mask> :No toplevel domain specified"

        /// <summary>
        ///     &lt;mask&gt; :Wildcard in toplevel domain
        /// </summary>
        ErrWildtoplevel = 414, // "<mask> :Wildcard in toplevel domain"

        ErrBadMask = 415,

        /// <summary>
        ///     &lt;command&gt; :Unknown command
        /// </summary>
        ErrUnknownCommand = 421, // "<command> :Unknown command"

        /// <summary>
        ///     :MOTD File is missing
        /// </summary>
        ErrNoMotd = 422, // ":MOTD File is missing"

        /// <summary>
        ///    &lt;server&gt; :No administrative info available
        /// </summary>
        ErrNoAdminInfo = 423, // "<server> :No administrative info available"

        /// <summary>
        ///     :File error doing &lt;file op&gt; on &lt;file&gt;The error fileerror
        /// </summary>
        ErrFileError = 424, // ":File error doing <file op> on <file>"

        /// <summary>
        ///     :No nickname given
        /// </summary>
        ErrNoNickNameGiven = 431, // ":No nickname given"

        /// <summary>
        ///     &lt;nick&gt; :Erroneus nickname
        /// </summary>
        ErrErroneusNickname = 432, // "<nick> :Erroneus nickname"

        /// <summary>
        ///     &lt;nick&gt; :Nickname is already in use
        /// </summary>
        ErrNicknameInUse = 433, // "<nick> :Nickname is already in use"

        /// <summary>
        ///     &lt;nick&gt; :Nickname collision KILL
        /// </summary>
        ErrNickCollision = 436, // "<nick> :Nickname collision KILL"

        /// <summary>
        ///     &lt;nick&gt; &lt;channel&gt; :They aren't on that channel
        /// </summary>
        ErrUserNotInChannel = 441, // "<nick> <channel> :They aren't on that channel"

        /// <summary>
        ///     &lt;channel&gt; :You're not on that channel"
        /// </summary>
        ErrNotOnChannel = 442, // "<channel> :You're not on that channel"

        /// <summary>
        ///     &lt;user&gt; &lt;channel&gt; :is already on channel
        /// </summary>
        ErrUserOnChannel = 443, // "<user> <channel> :is already on channel"

        /// <summary>
        ///     &lt;user&gt; :User not logged in
        /// </summary>
        ErrNoLogin = 444, // "<user> :User not logged in"

        /// <summary>
        ///     :SUMMON has been disabled
        /// </summary>
        ErrSummonDisabled = 445, // ":SUMMON has been disabled"

        /// <summary>
        ///     :USERS has been disabled
        /// </summary>
        ErrUsersDisabled = 446, // ":USERS has been disabled"

        /// <summary>
        ///     :You have not registered
        /// </summary>
        ErrNotRegistered = 451, // ":You have not registered"

        /// <summary>
        ///     &lt;command&gt; :Not enough parameters
        /// </summary>
        ErrNeedMoreParams = 461, // "<command> :Not enough parameters"

        /// <summary>
        ///     :You may not reregister
        /// </summary>
        ErrAlreadyRegistered = 462, // ":You may not reregister"

        /// <summary>
        ///     :Your host isn't among the privileged
        /// </summary>
        ErrNoPermForHost = 463, // ":Your host isn't among the privileged"

        /// <summary>
        ///     :Password incorrect
        /// </summary>
        ErrPasswdMismatch = 464, // ":Password incorrect"

        /// <summary>
        ///    :You are banned from this server The error yourebannedcreep
        /// </summary>
        ErrYoureBannedCreep = 465, // ":You are banned from this server"

        /// <summary>
        ///     Sent by a server to a user to inform that access to the server will soon be denied
        /// </summary>
        ErrYouWillBeBanned = 466, // "Sent by a server to a user to inform that access to the server will soon be denied"

        /// <summary>
        ///     &lt;channel&gt; :Channel key already set
        /// </summary>
        ErrKeySet = 467, // "<channel> :Channel key already set"

        /// <summary>
        ///     &lt;channel&gt; :Cannot join channel (+l)
        /// </summary>
        ErrChannelIsFull = 471, // "<channel> :Cannot join channel (+l)"

        /// <summary>
        ///     &lt;char&gt; :is unknown mode char to me
        /// </summary>
        ErrUnknownMode = 472, // "<char> :is unknown mode char to me"

        /// <summary>
        ///     &lt;channel&gt; :Cannot join channel (+i)
        /// </summary>
        ErrInviteOnlyChan = 473, // "<channel> :Cannot join channel (+i)"

        /// <summary>
        ///     &lt;channel&gt; :Cannot join channel (+b)
        /// </summary>
        ErrBannedFromChan = 474, // "<channel> :Cannot join channel (+b)"

        /// <summary>
        ///     &lt;channel&gt; :Cannot join channel (+k)
        /// </summary>
        ErrBadChannelKey = 475, // "<channel> :Cannot join channel (+k)"

        ErrBadChannelMask = 476,

        ErrNoChannelModes = 477,

        ErrBanListFull = 478,

        /// <summary>
        ///     :Permission Denied- You're not an IRC operator
        /// </summary>
        ErrNoPrivileges = 481, // ":Permission Denied- You're not an IRC operator"

        /// <summary>
        ///     &lt;channel&gt; :You're not channel operator
        /// </summary>
        ErrChanOpPrivsNeeded = 482, // "<channel> :You're not channel operator"

        /// <summary>
        ///     :You cant kill a server!
        /// </summary>
        ErrCantKillServer = 483, // ":You cant kill a server!"

        /// <summary>
        ///     :Your connection is restricted!
        /// </summary>
        ErrRestricted = 484, // ":Your connection is restricted!" (umode +r)

        /// <summary>
        ///     :You're not the original channel operator
        /// </summary>
        /// <remarks>
        ///     Any MODE requiring "channel creator" privileges MUST
        ///     return this error if the client making the attempt is not
        ///     a chanop on the specified channel.
        /// </remarks>
        ErrUniqOpPrivIsNeeded = 485, // ":You're not the original channel operator"

        /// <summary>
        ///     :No O-lines for your host
        /// </summary>
        ErrNoOperHost = 491, // ":No O-lines for your host"

        /// <summary>
        ///     :Unknown MODE flag
        /// </summary>
        ErrUmodeUnknownFlag = 501, // ":Unknown MODE flag"

        /// <summary>
        ///    :Cant change mode for other users
        /// </summary>
        ErrUsersDontMatch = 502, // ":Cant change mode for other users"

        /// <summary>
        ///     Unknown Reply Code
        /// </summary>
        RplUnknowncode = 000,

        /// <summary>
        ///     Welcome to the Internet Relay Network &lt;nick&gt;!&lt;user&gt;@&lt;host&gt;
        /// </summary>
        RplWelcome = 001, // "Welcome to the Internet Relay Network <nick>!<user>@<host>"

        /// <summary>
        ///     Your host is &lt;servername&gt;, running version &lt;ver&gt;
        /// </summary>
        RplYourHost = 002, // "Your host is <servername>, running version <ver>"

        /// <summary>
        ///     This server was created &lt;date&gt;
        /// </summary>
        RplCreated = 003, // "This server was created <date>"

        /// <summary>
        ///     &lt;servername&gt; &lt;version&gt; &lt;available user modes&gt; &lt;available channel modes&gt;
        /// </summary>
        RplMyinfo = 004, // "<servername> <version> <available user modes> <available channel modes>"

        /// <summary>
        ///     Try server &lt;server name&gt;, port &lt;port number&gt;
        /// </summary>
        RplBounce = 005, // "Try server <server name>, port <port number>"

        /// <summary>
        ///     Link &lt;version & debug level&gt; &lt;destination&gt; &lt;next server&gt;
        /// </summary>
        RplTraceLink = 200, // "Link <version & debug level> <destination> <next server>"

        /// <summary>
        ///     Try. &lt;class&gt; &lt;server&gt;
        /// </summary>
        RplTraceConnecting = 201, // "Try. <class> <server>"

        /// <summary>
        ///     H.S. &lt;class&gt; &lt;server&gt;The RPL trace and shake
        /// </summary>
        RplTraceAndShake = 202, // "H.S. <class> <server>"

        /// <summary>
        ///     ???? &lt;class&gt; [&lt;client IP address in dot form&gt;]
        /// </summary>
        RplTraceUnknown = 203, // "???? <class> [<client IP address in dot form>]"

        /// <summary>
        ///     Oper &lt;class&gt; &lt;nick&gt;
        /// </summary>
        RplTraceOperator = 204, // "Oper <class> <nick>"

        /// <summary>
        ///     User &lt;class&gt; &lt;nick&gt;The RPL trace user
        /// </summary>
        RplTraceUser = 205, // "User <class> <nick>"

        /// <summary>
        ///     Serv &lt;class&gt; &lt;int&gt;S &lt;int&gt;C &lt;server&gt; &lt;nick!user|*!*&gt;@&lt;host|server&gt;The RPL trace server
        /// </summary>
        RplTraceServer = 206, // "Serv <class> <int>S <int>C <server> <nick!user|*!*>@<host|server>"

        RplTraceService = 207,

        /// <summary>
        ///     &lt;newtype&gt; 0 &lt;client name&gt;
        /// </summary>
        RplTraceNewType = 208, // "<newtype> 0 <client name>"

        RplTraceClass = 209,

        RplTraceReconnect = 210,

        /// <summary>
        ///     &lt;linkname&gt; &lt;sendq&gt; &lt;sent messages&gt; &lt;sent bytes&gt; &lt;received messages&gt; &lt;received bytes&gt; &lt;time open&gt;
        /// </summary>
        RplStatsLinkInfo = 211, // "<linkname> <sendq> <sent messages> <sent bytes> <received messages> <received bytes> <time open>"

        /// <summary>
        ///     &lt;command&gt; &lt;count&gt;
        /// </summary>
        RplStatsCommands = 212, // "<command> <count>"

        /// <summary>
        ///     C &lt;host&gt; * &lt;name&gt; &lt;port&gt; &lt;class&gt;
        /// </summary>
        RplStatsCline = 213, // "C &lt;host> * &lt;name> &lt;port> &lt;class>"

        /// <summary>
        ///     N &lt;host&gt; * &lt;name&gt; &lt;port&gt; &lt;class&gt;The RPL stats nline
        /// </summary>
        RplStatsNline = 214, // "N <host> * <name> <port> <class>"

        /// <summary>
        ///     I &lt;host&gt; * &lt;host&gt; &lt;port&gt; &lt;class&gt;The RPL stats iline
        /// </summary>
        RplStatsIline = 215, // "I <host> * <host> <port> <class>"

        /// <summary>
        ///     K &lt;host&gt; * &lt;username&gt; &lt;port&gt; &lt;class&gt;
        /// </summary>
        RplStatsKline = 216, // "K <host> * <username> <port> <class>"

        /// <summary>
        ///     Q &lt;nick&gt; &lt;duration&gt; &lt;timestamp&gt; &lt;host&gt; &lt;reason&gt;
        /// </summary>
        RplStatsQline = 217, // Q <nick> <duration> <timestamp> <host> <reason>

        /// <summary>
        ///     Y &lt;class&gt; &lt;ping frequency&gt; &lt;connect frequency&gt; &lt;max sendq&gt;
        /// </summary>
        RplStatsYline = 218, // "Y <class> <ping frequency> <connect frequency> <max sendq>"

        /// <summary>
        ///     &lt;stats letter&gt; :End of /STATS reportThe RPL endof stats
        /// </summary>
        RplEndofStats = 219, // "<stats letter> :End of /STATS report"

        /// <summary>
        ///    &lt;user mode string&gt;
        /// </summary>
        RplUmodeIs = 221, // "<user mode string>"

        RplServiceList = 234,

        RplServiceListEnd = 235,

        /// <summary>
        ///     L &lt;hostmask&gt; * &lt;servername&gt; &lt;maxdepth&gt;
        /// </summary>
        RplStatsLline = 241, // "L <hostmask> * <servername> <maxdepth>"

        /// <summary>
        ///     :Server Up %d days %d:%02d:%02d
        /// </summary>
        RplStatsUptime = 242, // ":Server Up %d days %d:%02d:%02d"

        /// <summary>
        ///     O &lt;hostmask&gt; * &lt;name&gt;
        /// </summary>
        RplStatsOline = 243, // "O <hostmask> * <name>"

        /// <summary>
        ///     H &lt;hostmask&gt; * &lt;servername&gt;
        /// </summary>
        RplStatsHline = 244, // "H <hostmask> * <servername>"

        /// <summary>
        ///     :There are &lt;integer&gt; users and &lt;integer&gt; invisible on &lt;integer&gt; servers
        /// </summary>
        RplLUserClient = 251, // ":There are <integer> users and <integer> invisible on <integer> servers"

        /// <summary>
        ///     &lt;integer&gt; :operator(s) online
        /// </summary>
        RplLUserOp = 252, // "<integer> :operator(s) online"

        /// <summary>
        ///     &lt;integer&gt; :unknown connection(s)
        /// </summary>
        RplLUserUnknown = 253, // "<integer> :unknown connection(s)"

        /// <summary>
        ///     &lt;integer&gt; :channels formed
        /// </summary>
        RplLUserChannels = 254, // "<integer> :channels formed"

        /// <summary>
        ///     :I have &lt;integer&gt; clients and &lt;integer&gt; servers
        /// </summary>
        RplLUserMe = 255, // ":I have <integer> clients and <integer> servers"

        /// <summary>
        ///     &lt;server&gt; :Administrative info
        /// </summary>
        RplAdminMe = 256, // "<server> :Administrative info"

        /// <summary>
        ///     :&lt;admin info&gt;
        /// </summary>
        RplAdminLoc1 = 257, // ":<admin info>"

        /// <summary>
        ///     :&lt;admin info&gt;
        /// </summary>
        RplAdminLoc2 = 258, // ":<admin info>"

        /// <summary>
        ///     :&lt;admin info&gt;
        /// </summary>
        RplAdminEmail = 259, // ":<admin info>"

        /// <summary>
        ///     File &lt;logfile&gt; &lt;debug level&gt;The RPL trace log
        /// </summary>
        RplTraceLog = 261, // "File <logfile> <debug level>"

        RplTraceEnd = 262,

        RplTryAgain = 263,

        /// <summary>
        ///
        /// </summary>
        RplLocalUsers = 265,

        /// <summary>
        ///
        /// </summary>
        RplGlobalUsers = 266,

        /// <summary>
        ///     &lt;nick&gt; :&lt;away message&gt;
        /// </summary>
        RplAway = 301, // "<nick> :<away message>"

        /// <summary>
        ///     :[&lt;reply&gt;{&lt;space&gt;&lt;reply&gt;}]
        /// </summary>
        RplUserhost = 302, // ":[<reply>{<space><reply>}]"

        /// <summary>
        ///     :[&lt;nick&gt; {&lt;space&gt;&lt;nick&gt;}]
        /// </summary>
        RplIson = 303, // ":[<nick> {<space><nick>}]"

        /// <summary>
        ///     Text Reply?
        /// </summary>
        RplText = 304,

        /// <summary>
        ///     :You are no longer marked as being away
        /// </summary>
        RplUnaway = 305, // ":You are no longer marked as being away"

        /// <summary>
        ///     :You have been marked as being away
        /// </summary>
        RplNowaway = 306, // ":You have been marked as being away"

        /// <summary>
        ///     &lt;nick&gt; &lt;user&gt; &lt;host&gt; * :&lt;real name&gt;
        /// </summary>
        RplWhoisuser = 311, // "<nick> <user> <host> * :<real name>"

        /// <summary>
        ///     &lt;nick&gt; &lt;server&gt; :&lt;server info&gt;
        /// </summary>
        RplWhoisserver = 312, // "<nick> <server> :<server info>"

        /// <summary>
        ///     &lt;nick&gt; :is an IRC operator
        /// </summary>
        RplWhoisoperator = 313, // "<nick> :is an IRC operator"

        /// <summary>
        ///     T&lt;nick&gt; &lt;user&gt; &lt;host&gt; * :&lt;real name&gt;
        /// </summary>
        RplWhowasuser = 314, // "<nick> <user> <host> * :<real name>"

        /// <summary>
        ///     &lt;name&gt; :End of /WHO list
        /// </summary>
        RplEndofwho = 315, // "<name> :End of /WHO list"

        /// <summary>
        ///     nick&gt; &lt;integer&gt; :seconds idle
        /// </summary>
        RplWhoisidle = 317, // "<nick> <integer> :seconds idle"

        /// <summary>
        ///     &lt;nick&gt; :End of /WHOIS list
        /// </summary>
        RplEndofwhois = 318, // "<nick> :End of /WHOIS list"

        /// <summary>
        ///     &lt;nick&gt; :{[@|+]&lt;channel&gt;&lt;space&gt;}
        /// </summary>
        RplWhoischannels = 319, // "<nick> :{[@|+]<channel><space>}"

        /// <summary>
        ///     Channel :Users  Name
        /// </summary>
        RplListstart = 321, // "Channel :Users  Name"

        /// <summary>
        ///     &lt;channel&gt; &lt;# visible&gt; :&lt;topic&gt;
        /// </summary>
        RplList = 322, // "<channel> <# visible> :<topic>"

        /// <summary>
        ///     :End of /LIST
        /// </summary>
        RplListend = 323, // ":End of /LIST"

        /// <summary>
        ///     &lt;channel&gt; &lt;mode&gt; &lt;mode params&gt;
        /// </summary>
        RplChannelmodeis = 324, // "<channel> <mode> <mode params>"

        RplUniqueOpIs = 325,

        /// <summary>
        ///     &lt;channel&gt; :No topic is set
        /// </summary>
        RplNoTopic = 331, // "<channel> :No topic is set"

        /// <summary>
        ///     &lt;channel&gt; :&lt;topic&gt;
        /// </summary>
        RplTopic = 332, // "<channel> :<topic>"

        /// <summary>
        /// &lt;channel&gt; &lt;topicEditor&gt; &lt;timestamp&gt;
        /// </summary>
        RplTopicWhoTime = 333,

        /// <summary>
        ///     &lt;channel&gt; &lt;nick&gt;
        /// </summary>
        RplInviting = 341, // "<channel> <nick>"

        /// <summary>
        ///     &lt;user&gt; :Summoning user to IRC
        /// </summary>
        RplSummoning = 342, // "<user> :Summoning user to IRC"

        RplInviteList = 346,

        RplEndOfInviteList = 347,

        RplExceptionList = 348,

        RplEndOfExceptionList = 349,

        /// <summary>
        ///     &lt;version&gt;.&lt;debuglevel&gt; &lt;server&gt; :&lt;comments&gt;
        /// </summary>
        RplVersion = 351, // "<version>.<debuglevel> <server> :<comments>"

        /// <summary>
        ///     &lt;channel&gt; &lt;user&gt; &lt;host&gt; &lt;server&gt; &lt;nick&gt; &lt;H|G&gt;[*][@|+] :&lt;hopcount&gt; &lt;real name&gt;
        /// </summary>
        RplWhoreply = 352, // "<channel> <user> <host> <server> <nick> <H|G>[*][@|+] :<hopcount> <real name>"

        /// <summary>
        ///     &lt;nick&gt; &lt;accessType&gt; &lt;channel&gt; :[[@|+]&lt;nick&gt; [[@|+]&lt;nick&gt; [...]]]
        /// </summary>
        RplNamesreply = 353, // "<nick> <accessType> <channel> :[[@|+]<nick> [[@|+]<nick> [...]]]"

        /// <summary>
        ///     &lt;mask&gt; &lt;server&gt; :&lt;hopcount&gt; &lt;server info&gt;
        /// </summary>
        RplLinks = 364, // "<mask> <server> :<hopcount> <server info>"

        /// <summary>
        ///     &lt;mask&gt; :End of /LINKS list
        /// </summary>
        RplEndoflinks = 365, // "<mask> :End of /LINKS list"

        /// <summary>
        ///     &lt;channel&gt; :End of /NAMES list
        /// </summary>
        RplEndOfNames = 366, // "<channel> :End of /NAMES list"

        /// <summary>
        ///     &lt;channel&gt; &lt;banid&gt;
        /// </summary>
        RplBanList = 367, // "<channel> <banid>"

        /// <summary>
        ///     &lt;channel&gt; :End of channel ban list
        /// </summary>
        RplEndOfBanList = 368, // "<channel> :End of channel ban list"

        /// <summary>
        ///     &lt;nick&gt; :End of WHOWAS
        /// </summary>
        RplEndOfWhoWas = 369, // "<nick> :End of WHOWAS"

        /// <summary>
        ///     :&lt;string&gt;
        /// </summary>
        RplInfo = 371, // ":<string>"

        /// <summary>
        ///     :- &lt;text&gt;
        /// </summary>
        RplMotd = 372, // ":- <text>"

        /// <summary>
        ///     :End of /INFO list
        /// </summary>
        RplEndofinfo = 374, // ":End of /INFO list"

        /// <summary>
        ///     :- &lt;server&gt; Message of the day -
        /// </summary>
        RplMotdstart = 375, // ":- <server> Message of the day - "

        /// <summary>
        ///     :End of /MOTD
        /// </summary>
        RplEndofmotd = 376, // ":End of /MOTD command"

        /// <summary>
        ///     :You are now an IRC operator
        /// </summary>
        RplYoureoper = 381, // ":You are now an IRC operator"

        /// <summary>
        ///     &lt;config file&gt; :Rehashing
        /// </summary>
        RplRehashing = 382, // "<config file> :Rehashing"

        RplYouAreService = 383,

        /// <summary>
        ///    &lt;server&gt; :&lt;string showing server's local time&gt;
        /// </summary>
        RplTime = 391, // "<server> :<string showing server's local time>"

        /// <summary>
        ///     :UserID Terminal Host
        /// </summary>
        RplUsersstart = 392, // ":UserID Terminal Host"

        /// <summary>
        ///     :%-8s %-9s %-8s
        /// </summary>
        RplUsers = 393, // ":%-8s %-9s %-8s"

        /// <summary>
        ///     :End of users
        /// </summary>
        RplEndofusers = 394, // ":End of users"

        /// <summary>
        ///     :Nobody logged in
        /// </summary>
        RplNousers = 395, // ":Nobody logged in"

        /// <summary>
        ///     Host Hidden Reply?
        /// </summary>
        RplHostHidden = 396
    }

    /// <summary>
    /// </summary>
    public class Constants
    {
        /// <summary>
        ///     Bold
        /// </summary>
        public const char Bold = '\x2';

        /// <summary>
        ///     Colors
        /// </summary>
        public const char Color = '\x3';

        /// <summary>
        ///     CTCP character
        /// </summary>
        public const char CtcpChar = '\x1';

        /// <summary>
        ///     CTCP quote character
        /// </summary>
        public const char CtcpQuoteChar = '\x20';

        /// <summary>
        ///     Italics character
        /// </summary>
        public const char Italic = '\x1d';

        /// <summary>
        ///     Cancel/Normal
        /// </summary>
        public const char Normal = '\xf';

        /// <summary>
        ///     Reverse
        /// </summary>
        public const char Reverse = '\x16';

        /// <summary>
        ///     Underline
        /// </summary>
        public const char Underline = '\x1f';
    }
}