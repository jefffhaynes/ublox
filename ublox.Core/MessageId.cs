namespace ublox.Core
{
    public enum MessageId : ushort
    {
        /// <summary>
        /// NAV-POSECEF message
        /// </summary>
        NAV_POSECEF = 0x0101,

        /// <summary>
        /// NAV-POSLLH message
        /// </summary>
        NAV_POSLLH = 0x0102,

        /// <summary>
        /// NAV-STATUS message
        /// </summary>
        NAV_STATUS = 0x0103,

        /// <summary>
        /// NAV-DOP message
        /// </summary>
        NAV_DOP = 0x0104,

        /// <summary>
        /// NAV-SOL message
        /// </summary>
        NAV_SOL = 0x0106,

        /// <summary>
        /// NAV-PVT message
        /// </summary>
        NAV_PVT = 0x0107,

        /// <summary>
        /// NAV-ODO message
        /// </summary>
        NAV_ODO = 0x0109,

        /// <summary>
        /// NAV-RESETODO message
        /// </summary>
        NAV_RESETODO = 0x0110,

        /// <summary>
        /// NAV-VELECEF message
        /// </summary>
        NAV_VELECEF = 0x0111,

        /// <summary>
        /// NAV-VELNED message
        /// </summary>
        NAV_VELNED = 0x0112,

        /// <summary>
        /// NAV-TIMEGPS message
        /// </summary>
        NAV_TIMEGPS = 0x0120,

        /// <summary>
        /// NAV-TIMEUTC message
        /// </summary>
        NAV_TIMEUTC = 0x0121,

        /// <summary>
        /// NAV-CLOCK message
        /// </summary>
        NAV_CLOCK = 0x0122,

        /// <summary>
        /// NAV-TIMEGLO message
        /// </summary>
        NAV_TIMEGLO = 0x0123,

        /// <summary>
        /// NAV-TIMEBDS message
        /// </summary>
        NAV_TIMEBDS = 0x0124,

        /// <summary>
        /// NAV-TIMEGAL message
        /// </summary>
        NAV_TIMEGAL = 0x0125,

        /// <summary>
        /// NAV-TIMELS message
        /// </summary>
        NAV_TIMELS = 0x0126,

        /// <summary>
        /// NAV-SVINFO message
        /// </summary>
        NAV_SVINFO = 0x0130,

        /// <summary>
        /// NAV-DGPS message
        /// </summary>
        NAV_DGPS = 0x0131,

        /// <summary>
        /// NAV-SBAS message
        /// </summary>
        NAV_SBAS = 0x0132,

        /// <summary>
        /// NAV-ORB message
        /// </summary>
        NAV_ORB = 0x0134,

        /// <summary>
        /// NAV-SAT message
        /// </summary>
        NAV_SAT = 0x0135,

        /// <summary>
        /// NAV-GEOFENCE message
        /// </summary>
        NAV_GEOFENCE = 0x0139,

        /// <summary>
        /// NAV-EKFSTATUS message
        /// </summary>
        NAV_EKFSTATUS = 0x0140,

        /// <summary>
        /// NAV-AOPSTATUS message
        /// </summary>
        NAV_AOPSTATUS = 0x0160,

        /// <summary>
        /// NAV-EOE message
        /// </summary>
        NAV_EOE = 0x0161,

        /// <summary>
        /// RXM-RAW message
        /// </summary>
        RXM_RAW = 0x0210,

        /// <summary>
        /// RXM-SFRB message
        /// </summary>
        RXM_SFRB = 0x0211,

        /// <summary>
        /// RXM-SFRBX message
        /// </summary>
        RXM_SFRBX = 0x0213,

        /// <summary>
        /// RXM-MEASX message
        /// </summary>
        RXM_MEASX = 0x0214,

        /// <summary>
        /// RXM-RAWX message
        /// </summary>
        RXM_RAWX = 0x0215,

        /// <summary>
        /// RXM-SVSI message
        /// </summary>
        RXM_SVSI = 0x0220,

        /// <summary>
        /// RXM-ALM message
        /// </summary>
        RXM_ALM = 0x0230,

        /// <summary>
        /// RXM-EPH message
        /// </summary>
        RXM_EPH = 0x0231,

        /// <summary>
        /// RXM-PMREQ message
        /// </summary>
        RXM_PMREQ = 0x0241,

        /// <summary>
        /// RXM-RLM message
        /// </summary>
        RXM_RLM = 0x0259,

        /// <summary>
        /// RXM-IMES message
        /// </summary>
        RXM_IMES = 0x0261,

        /// <summary>
        /// RXM-ERROR message
        /// </summary>
        INF_ERROR = 0x0400,

        /// <summary>
        /// INF-WARNING message
        /// </summary>
        INF_WARNING = 0x0401,

        /// <summary>
        /// INF-NOTICE message
        /// </summary>
        INF_NOTICE = 0x0402,

        /// <summary>
        /// INF-TEST message
        /// </summary>
        INF_TEST = 0x0403,

        /// <summary>
        /// INF-DEBUG message
        /// </summary>
        INF_DEBUG = 0x0404,

        /// <summary>
        /// ACK-NACK message
        /// </summary>
        ACK_NAK = 0x0500,

        /// <summary>
        /// ACK-ACK message
        /// </summary>
        ACK_ACK = 0x0501,

        /// <summary>
        /// CFG-PRT message
        /// </summary>
        CFG_PRT = 0x0600,

        /// <summary>
        /// CFG-MSG message
        /// </summary>
        CFG_MSG = 0x0601,

        /// <summary>
        /// CFG-INF message
        /// </summary>
        CFG_INF = 0x0602,

        /// <summary>
        /// CFG-RST message
        /// </summary>
        CFG_RST = 0x0604,

        /// <summary>
        /// CFG-DAT message
        /// </summary>
        CFG_DAT = 0x0606,

        /// <summary>
        /// CFG-TP message
        /// </summary>
        CFG_TP = 0x0607,

        /// <summary>
        /// CFG-RATE message
        /// </summary>
        CFG_RATE = 0x0608,

        /// <summary>
        /// CFG-CFG message
        /// </summary>
        CFG_CFG = 0x0609,

        /// <summary>
        /// CFG-FXN message
        /// </summary>
        CFG_FXN = 0x060E,

        /// <summary>
        /// CFG-RXM message
        /// </summary>
        CFG_RXM = 0x0611,

        /// <summary>
        /// CFG-EKF message
        /// </summary>
        CFG_EKF = 0x0612,

        /// <summary>
        /// CFG-ANT message
        /// </summary>
        CFG_ANT = 0x0613,

        /// <summary>
        /// CFG-SBAS message
        /// </summary>
        CFG_SBAS = 0x0616,

        /// <summary>
        /// CFG-NMEA message
        /// </summary>
        CFG_NMEA = 0x0617,

        /// <summary>
        /// CFG-USB message
        /// </summary>
        CFG_USB = 0x061b,

        /// <summary>
        /// CFG-TMODE message
        /// </summary>
        CFG_TMODE = 0x061d,

        /// <summary>
        /// CFG-ODO message
        /// </summary>
        CFG_ODO = 0x061e,

        /// <summary>
        /// CFG-NVS message
        /// </summary>
        CFG_NVS = 0x0622,

        /// <summary>
        /// CFG-NAVX5 message
        /// </summary>
        CFG_NAVX5 = 0x0623,

        /// <summary>
        /// CFG-NAV5 message
        /// </summary>
        CFG_NAV5 = 0x0624,

        /// <summary>
        /// CFG-ESFGWT message
        /// </summary>
        CFG_ESFGWT = 0x0629,

        /// <summary>
        /// CFG-TP5 message
        /// </summary>
        CFG_TP5 = 0x0631,

        /// <summary>
        /// CFG-PM message
        /// </summary>
        CFG_PM = 0x0632,

        /// <summary>
        /// CFG-RINV message
        /// </summary>
        CFG_RINV = 0x0634,

        /// <summary>
        /// CFG-ITFM message
        /// </summary>
        CFG_ITFM = 0x0639,

        /// <summary>
        /// CFG-PM2 message
        /// </summary>
        CFG_PM2 = 0x063b,

        /// <summary>
        /// CFG-TMODE2 message
        /// </summary>
        CFG_TMODE2 = 0x063d,

        /// <summary>
        /// CFG-GNSS message
        /// </summary>
        CFG_GNSS = 0x063e,

        /// <summary>
        /// CFG-LOGFILTER message
        /// </summary>
        CFG_LOGFILTER = 0x0647,

        /// <summary>
        /// CFG-TXSLOT message
        /// </summary>
        CFG_TXSLOT = 0x0653,

        /// <summary>
        /// CFG-HNR message
        /// </summary>
        CFG_HNR = 0x0655,

        /// <summary>
        /// CFG-PWR message
        /// </summary>
        CFG_PWR = 0x0657,

        /// <summary>
        /// CFG-ESRC message
        /// </summary>
        CFG_ESRC = 0x0660,

        /// <summary>
        /// CFG-DOSC message
        /// </summary>
        CFG_DOSC = 0x0661,

        /// <summary>
        /// CFG-SMGR message
        /// </summary>
        CFG_SMGR = 0x0662,

        /// <summary>
        /// CFG-GEOFENCE message
        /// </summary>
        CFG_GEOFENCE = 0x0669,

        /// <summary>
        /// CFG-FIXSEED message
        /// </summary>
        CFG_FIXSEED = 0x0684,

        /// <summary>
        /// CFG-DYNSEED message
        /// </summary>
        CFG_DYNSEED = 0x0685,

        /// <summary>
        /// CFG-PMS message
        /// </summary>
        CFG_PMS = 0x0686,

        /// <summary>
        /// UPD-SOS message
        /// </summary>
        UPD_SOS = 0x0914,

        /// <summary>
        /// MON-IO message
        /// </summary>
        MON_IO = 0x0a02,

        /// <summary>
        /// MON-VER message
        /// </summary>
        MON_VER = 0x0a04,

        /// <summary>
        /// MON-MSGPP message
        /// </summary>
        MON_MSGPP = 0x0a06,

        /// <summary>
        /// MON-RXBUF message
        /// </summary>
        MON_RXBUF = 0x0a07,

        /// <summary>
        /// MON-TXBUF message
        /// </summary>
        MON_TXBUF = 0x0a08,

        /// <summary>
        /// MON-HW message
        /// </summary>
        MON_HW = 0x0a09,

        /// <summary>
        /// MON-HW2 message
        /// </summary>
        MON_HW2 = 0x0a0b,

        /// <summary>
        /// MON-RXR message
        /// </summary>
        MON_RXR = 0x0a21,

        /// <summary>
        /// MON-PATCH message
        /// </summary>
        MON_PATCH = 0x0a27,

        /// <summary>
        /// MON-GNSS message
        /// </summary>
        MON_GNSS = 0x0a28,

        /// <summary>
        /// MON-SMGR message
        /// </summary>
        MON_SMGR = 0x0a2e,

        /// <summary>
        /// AID-REQ message
        /// </summary>
        AID_REQ = 0x0b00,

        /// <summary>
        /// AID-INI message
        /// </summary>
        AID_INI = 0x0b01,

        /// <summary>
        /// AID-HUI message
        /// </summary>
        AID_HUI = 0x0b02,

        /// <summary>
        /// AID-DATA message
        /// </summary>
        AID_DATA = 0x0b10,

        /// <summary>
        /// AID-ALM message
        /// </summary>
        AID_ALM = 0x0b30,

        /// <summary>
        /// AID-EPH message
        /// </summary>
        AID_EPH = 0x0b31,

        /// <summary>
        /// AID-ALPSRV message
        /// </summary>
        AID_ALPSRV = 0x0b32,

        /// <summary>
        /// AID-AOP message
        /// </summary>
        AID_AOP = 0x0b33,

        /// <summary>
        /// AID-ALP message
        /// </summary>
        AID_ALP = 0x0b50,

        /// <summary>
        /// TIM-TP message
        /// </summary>
        TIM_TP = 0x0d01,

        /// <summary>
        /// TIM-TM2 message
        /// </summary>
        TIM_TM2 = 0x0d03,

        /// <summary>
        /// TIM-SVIN message
        /// </summary>
        TIM_SVIN = 0x0d04,

        /// <summary>
        /// TIM-VRFY message
        /// </summary>
        TIM_VRFY = 0x0d06,

        /// <summary>
        /// TIM-DOSC message
        /// </summary>
        TIM_DOSC = 0x0d11,

        /// <summary>
        /// TIM-TOS message
        /// </summary>
        TIM_TOS = 0x0d12,

        /// <summary>
        /// TIM-SMEAS message
        /// </summary>
        TIM_SMEAS = 0x0d13,

        /// <summary>
        /// TIM-VCOCAL message
        /// </summary>
        TIM_VCOCAL = 0x0d15,

        /// <summary>
        /// TIM-FCHG message
        /// </summary>
        TIM_FCHG = 0x0d16,

        /// <summary>
        /// TIM-HOC message
        /// </summary>
        TIM_HOC = 0x0d17,

        /// <summary>
        /// ESF-STATUS message
        /// </summary>
        ESF_STATUS = 0x1010,

        /// <summary>
        /// MGA-GPS message
        /// </summary>
        MGA_GPS = 0x1300,

        /// <summary>
        /// MGA-GAL message
        /// </summary>
        MGA_GAL = 0x1302,

        /// <summary>
        /// MGA-BDS message
        /// </summary>
        MGA_BDS = 0x1303,

        /// <summary>
        /// MGA-QZSS message
        /// </summary>
        MGA_QZSS = 0x1305,

        /// <summary>
        /// MGA-GLO message
        /// </summary>
        MGA_GLO = 0x1306,

        /// <summary>
        /// MGA-ANO message
        /// </summary>
        MGA_ANO = 0x1320,

        /// <summary>
        /// MGA-FLASH message
        /// </summary>
        MGA_FLASH = 0x1321,

        /// <summary>
        /// MGA-INI message
        /// </summary>
        MGA_INI = 0x1340,

        /// <summary>
        /// MGA-ACK message
        /// </summary>
        MGA_ACK = 0x1360,

        /// <summary>
        /// MGA-DBD message
        /// </summary>
        MGA_DBD = 0x1380,

        /// <summary>
        /// LOG-ERASE message
        /// </summary>
        LOG_ERASE = 0x2103,

        /// <summary>
        /// LOG-STRING message
        /// </summary>
        LOG_STRING = 0x2104,

        /// <summary>
        /// LOG-CREATE message
        /// </summary>
        LOG_CREATE = 0x2107,

        /// <summary>
        /// LOG-INFO message
        /// </summary>
        LOG_INFO = 0x2108,

        /// <summary>
        /// LOG-RETRIEVE message
        /// </summary>
        LOG_RETRIEVE = 0x2109,

        /// <summary>
        /// LOG-RETRIEVEPOS message
        /// </summary>
        LOG_RETRIEVEPOS = 0x210b,

        /// <summary>
        /// LOG-RETRIEVESTRING message
        /// </summary>
        LOG_RETRIEVESTRING = 0x210d,

        /// <summary>
        /// LOG-FINDTIME message
        /// </summary>
        LOG_FINDTIME = 0x210e,

        /// <summary>
        /// LOG-RETRIEVEPOSEXTRA message
        /// </summary>
        LOG_RETRIEVEPOSEXTRA = 0x210f,

        /// <summary>
        /// SEC-SIGN message
        /// </summary>
        SEC_SIGN = 0x2701,

        /// <summary>
        /// SEC-UNIQID message
        /// </summary>
        SEC_UNIQID = 0x2703,

        /// <summary>
        /// HNR-PVT message
        /// </summary>
        HNR_PVT = 0x2800
    }
}
