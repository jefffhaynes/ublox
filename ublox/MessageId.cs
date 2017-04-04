namespace ublox
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
        INF_ERROR = 0x0400, ///< ID of RXM-ERROR message
        INF_WARNING = 0x0401, ///< ID of INF-WARNING message
        INF_NOTICE = 0x0402, ///< ID of INF-NOTICE message
        INF_TEST = 0x0403, ///< ID of INF-TEST message
        INF_DEBUG = 0x0404, ///< ID of INF-DEBUG message
        ACK_NAK = 0x0500, ///< ID of ACK-NACK message
        ACK_ACK = 0x0501, ///< ID of ACK-ACK message
        CFG_PRT = 0x0600, ///< ID of CFG-PRT message
        CFG_MSG = 0x0601, ///< ID of CFG-MSG message
        CFG_INF = 0x0602, ///< ID of CFG-INF message
        CFG_RST = 0x0604, ///< ID of CFG-RST message
        CFG_DAT = 0x0606, ///< ID of CFG-DAT message
        CFG_TP = 0x0607, ///< ID of CFG-TP message
        CFG_RATE = 0x0608, ///< ID of CFG-RATE message
        CFG_CFG = 0x0609, ///< ID of CFG-CFG message
        CFG_FXN = 0x060E, ///< ID of CFG-FXN message
        CFG_RXM = 0x0611, ///< ID of CFG-RXM message
        CFG_EKF = 0x0612, ///< ID of CFG-EKF message
        CFG_ANT = 0x0613, ///< ID of CFG-ANT message
        CFG_SBAS = 0x0616, ///< ID of CFG-SBAS message
        CFG_NMEA = 0x0617, ///< ID of CFG-NMEA message
        CFG_USB = 0x061b, ///< ID of CFG-USB message
        CFG_TMODE = 0x061d, ///< ID of CFG-TMODE message
        CFG_ODO = 0x061e, ///< ID of CFG-ODO message
        CFG_NVS = 0x0622, ///< ID of CFG-NVS message
        CFG_NAVX5 = 0x0623, ///< ID of CFG-NAVX5 message
        CFG_NAV5 = 0x0624, ///< ID of CFG-NAV5 message
        CFG_ESFGWT = 0x0629, ///< ID of CFG-ESFGWT message
        CFG_TP5 = 0x0631, ///< ID of CFG-TP5 message
        CFG_PM = 0x0632, ///< ID of CFG-PM message
        CFG_RINV = 0x0634, ///< ID of CFG-RINV message
        CFG_ITFM = 0x0639, ///< ID of CFG-ITFM message
        CFG_PM2 = 0x063b, ///< ID of CFG-PM2 message
        CFG_TMODE2 = 0x063d, ///< ID of CFG-TMODE2 message
        CFG_GNSS = 0x063e, ///< ID of CFG-GNSS message
        CFG_LOGFILTER = 0x0647, ///< ID of CFG-LOGFILTER message
        CFG_TXSLOT = 0x0653, ///< ID of CFG-TXSLOT message
        CFG_PWR = 0x0657, ///< ID of CFG-PWR message
        CFG_ESRC = 0x0660, ///< ID of CFG-ESRC message
        CFG_DOSC = 0x0661, ///< ID of CFG-DOSC message
        CFG_SMGR = 0x0662, ///< ID of CFG-SMGR message
        CFG_GEOFENCE = 0x0669, ///< ID of CFG-GEOFENCE message
        CFG_FIXSEED = 0x0684, ///< ID of CFG-FIXSEED message
        CFG_DYNSEED = 0x0685, ///< ID of CFG-DYNSEED message
        CFG_PMS = 0x0686, ///< ID of CFG-PMS message
        UPD_SOS = 0x0914, ///< ID of UPD-SOS message
        MON_IO = 0x0a02, ///< ID of MON-IO message
        MON_VER = 0x0a04, ///< ID of MON-VER message
        MON_MSGPP = 0x0a06, ///< ID of MON-MSGPP message
        MON_RXBUF = 0x0a07, ///< ID of MON-RXBUF message
        MON_TXBUF = 0x0a08, ///< ID of MON-TXBUF message
        MON_HW = 0x0a09, ///< ID of MON-HW message
        MON_HW2 = 0x0a0b, ///< ID of MON-HW2 message
        MON_RXR = 0x0a21, ///< ID of MON-RXR message
        MON_PATCH = 0x0a27, ///< ID of MON-PATCH message
        MON_GNSS = 0x0a28, ///< ID of MON-GNSS message
        MON_SMGR = 0x0a2e, ///< ID of MON-SMGR message
        AID_REQ = 0x0b00, ///< ID of AID-REQ message
        AID_INI = 0x0b01, ///< ID of AID-INI message
        AID_HUI = 0x0b02, ///< ID of AID-HUI message
        AID_DATA = 0x0b10, ///< ID of AID-DATA message
        AID_ALM = 0x0b30, ///< ID of AID-ALM message
        AID_EPH = 0x0b31, ///< ID of AID-EPH message
        AID_ALPSRV = 0x0b32, ///< ID of AID-ALPSRV message
        AID_AOP = 0x0b33, ///< ID of AID-AOP message
        AID_ALP = 0x0b50, ///< ID of AID-ALP message
        TIM_TP = 0x0d01, ///< ID of TIM-TP message
        TIM_TM2 = 0x0d03, ///< ID of TIM-TM2 message
        TIM_SVIN = 0x0d04, ///< ID of TIM-SVIN message
        TIM_VRFY = 0x0d06, ///< ID of TIM-VRFY message
        TIM_DOSC = 0x0d11, ///< ID of TIM-DOSC message
        TIM_TOS = 0x0d12, ///< ID of TIM-TOS message
        TIM_SMEAS = 0x0d13, ///< ID of TIM-SMEAS message
        TIM_VCOCAL = 0x0d15, ///< ID of TIM-VCOCAL message
        TIM_FCHG = 0x0d16, ///< ID of TIM-FCHG message
        TIM_HOC = 0x0d17, ///< ID of TIM-HOC message
        ESF_STATUS = 0x1010, ///< ID of ESF-STATUS message
        MGA_GPS = 0x1300, ///< ID of MGA-GPS message
        MGA_GAL = 0x1302, ///< ID of MGA-GAL message
        MGA_BDS = 0x1303, ///< ID of MGA-BDS message
        MGA_QZSS = 0x1305, ///< ID of MGA-QZSS message
        MGA_GLO = 0x1306, ///< ID of MGA-GLO message
        MGA_ANO = 0x1320, ///< ID of MGA-ANO message
        MGA_FLASH = 0x1321, ///< ID of MGA-FLASH message
        MGA_INI = 0x1340, ///< ID of MGA-INI message
        MGA_ACK = 0x1360, ///< ID of MGA-ACK message
        MGA_DBD = 0x1380, ///< ID of MGA-DBD message
        LOG_ERASE = 0x2103, ///< ID of LOG-ERASE message
        LOG_STRING = 0x2104, ///< ID of LOG-STRING message
        LOG_CREATE = 0x2107, ///< ID of LOG-CREATE message
        LOG_INFO = 0x2108, ///< ID of LOG-INFO message
        LOG_RETRIEVE = 0x2109, ///< ID of LOG-RETRIEVE message
        LOG_RETRIEVEPOS = 0x210b, ///< ID of LOG-RETRIEVEPOS message
        LOG_RETRIEVESTRING = 0x210d, ///< ID of LOG-RETRIEVESTRING message
        LOG_FINDTIME = 0x210e, ///< ID of LOG-FINDTIME message
        LOG_RETRIEVEPOSEXTRA = 0x210f, ///< ID of LOG-RETRIEVEPOSEXTRA message
        SEC_SIGN = 0x2701, ///< ID of SEC-SIGN message
        SEC_UNIQID = 0x2703 ///< ID of SEC-UNIQID message
    }
}
