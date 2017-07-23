using System;
using System.Runtime.InteropServices;
using System.Text;

namespace TestEngineAPI
{
    public class TestEngine
    {
        private const CharSet charset = CharSet.Ansi;

        private const CallingConvention calling_convention = CallingConvention.StdCall;

        private const string dllPath = "TestEngine.dll";

        public static bool GetAdcVoltage(uint csrHandle, ushort adc, ref double volt, ref string msg)
        {
            double num = 0.0013196480938416422;
            bool flag = adc <= 4;
            double num4;
            if (flag)
            {
                ushort num2 = 0;
                ushort num3 = 0;
                bool flag2 = TestEngine.bccmdGetVrefConstant(csrHandle, out num3) != 1;
                if (flag2)
                {
                    msg = "Get Vref Constant";
                    return false;
                }
                byte b;
                bool flag3 = TestEngine.bccmdGetVrefAdc(csrHandle, out num2, out b) != 1;
                if (flag3)
                {
                    msg = "Get Vref Adc";
                    return false;
                }
                num4 = (double)num3 / (double)(num2 * 1000);
            }
            else
            {
                num4 = num;
            }
            ushort num5;
            bool flag4 = TestEngine.bccmdGetAdc(csrHandle, adc, out num5) != 1;
            bool result;
            if (flag4)
            {
                msg = "Get Adc";
                result = false;
            }
            else
            {
                volt = (double)num5 * num4;
                result = true;
            }
            return result;
        }

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int teGetVersion(StringBuilder versionStr);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int teGetVersion(byte[] versionStr);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint openTestEngine(int transport, string transportDevice, uint dataRate, int retryTimeOut, int usbTimeOut);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint openTestEngine(int transport, byte[] transportDevice, uint dataRate, int retryTimeOut, int usbTimeOut);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint openTestEngineSpi(int port, int multi, int transport);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint openTestEngineSpiTrans(string trans, int multi);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint openTestEngineSpiTrans(byte[] trans, int multi);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int closeTestEngine(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern uint teGetLastError(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetColdReset(uint handle, int usbTimeout);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetWarmReset(uint handle, int usbTimeout);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPause(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestDeepSleep(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmExtLb(uint handle, ushort pcm_mode);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmExtLbIf(uint handle, ushort pcm_mode, ushort pcm_if);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmLb(uint handle, ushort pcm_mode);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmLbIf(uint handle, ushort pcm_mode, ushort pcm_if);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmTimingIn(uint handle, ushort pio_out, ushort pcm_in);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmTimingInIf(uint handle, ushort pio_out, ushort pcm_in, ushort pcm_if);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmTone(uint handle, ushort freq, ushort ampl, ushort dc);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmToneIf(uint handle, ushort freq, ushort ampl, ushort dc, ushort pcm_if);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestPcmToneStereo(uint handle, ushort freq, ushort ampl, ushort dc, ushort channel);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCtsRtsLb(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestRadioStatus(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hqGetRadioStatus(uint handle, ushort[] r, int timeout);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestRadioStatusArray(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hqGetRadioStatusArray(uint handle, ushort[] r, int timeout);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdMemoryGet(uint handle, ushort baseAddr, ushort dataLength, ushort[] data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdMemorySet(uint handle, ushort baseAddr, ushort dataLength, ushort[] data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetBuildId(uint handle, out ushort buildid);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBuildName(uint handle, StringBuilder name, ushort max_len, out ushort length);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBuildName(uint handle, byte[] name, ushort max_len, out ushort length);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetChipVersion(uint handle, out ushort chipver);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetChipRevision(uint handle, out ushort chiprev);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetChipAnaVer(uint handle, out byte major, out byte minor, out byte vari);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdRouteClock(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdRssiAcl(uint handle, ushort connectionHandle, out short rssi);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetPio(uint handle, ushort mask, ushort port);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetPio(uint handle, out ushort mask, out ushort port);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdMapPio32(uint handle, uint mask, uint pios, out uint errLines);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetPio32(uint handle, uint mask, uint direction, uint value, out uint errLines);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetPio32(uint handle, out uint direction, out uint value);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetAdc(uint handle, ushort adc, out ushort result);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetAio(uint handle, ushort aio, out ushort result, out byte numBits);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBC5MMGetBatteryVoltage(uint handle, out ushort voltage);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetFirmwareCheckMask(uint handle, out ushort mask);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetFirmwareCheck(uint handle, out ushort check);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetExternalClockPeriod(uint handle, out ushort period);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdEnableDeviceConnect(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdEnableDeviceUnderTestMode(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestStereoCodecLB(uint handle, ushort sampleRate, ushort reroute);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestTxstart(uint handle, ushort frequency, ushort intPA, ushort extPA, short modulation);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestTxdata1(uint handle, ushort frequency, ushort intPA, ushort extPA);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestTxdata2(uint handle, ushort countrycode, ushort intPA, ushort extPA);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestTxdata3(uint handle, ushort frequency, ushort intPA, ushort extPA);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestTxdata4(uint handle, ushort frequency, ushort intPA, ushort extPA);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgTxPower(uint handle, short power);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestRxstart1(uint handle, ushort frequency, byte hiside, ushort rx_attenuation);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestRxstart2(uint handle, ushort frequency, byte hiside, ushort rx_attenuation, ushort sample_size);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hqGetRssi(uint handle, int timeout, ushort max_size, ushort[] r);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestBer1(uint handle, ushort frequency, byte hiside, ushort rx_attenuation, uint sampleSize);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestBer2(uint handle, ushort country_code, byte hiside, ushort rx_attenuation, uint sampleSize);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestBerLoopback(uint handle, ushort frequency, ushort intPA, ushort extPA, uint sampleSize);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestRxLoopback(uint handle, ushort frequency, ushort intPA, ushort extPA);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestLoopback(uint handle, ushort frequency, ushort intPA, ushort extPA);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hqGetBer(uint handle, int timeout, uint[] r);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestRxdata1(uint handle, ushort frequency, byte hiside, ushort rx_attenuation);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestRxdata2(uint handle, ushort countrycode, byte hiside, ushort rx_attenuation);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hqGetRxdata(uint handle, int timeout, ushort[] r);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgFreq(uint handle, ushort txrxinterval, ushort loopback, ushort report);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgFreqMs(uint handle, ushort txrxinterval, ushort loopback, ushort report);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgPkt(uint handle, ushort aType, ushort size);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgBitError(uint handle, uint sampleSize, byte reset);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgTxPaAtten(uint handle, ushort atten);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgXtalFtrim(uint handle, ushort ftrim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCalcXtalOffset(double nominalFreqMhz, double actualFreqMhz, out short offset);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgUapLap(uint handle, ushort uap, uint lap);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgIqTrim(uint handle, ushort trim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgTxIf(uint handle, short offset);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgTxTrim(uint handle, ushort am_addr);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgLoLvl(uint handle, ushort lo_lvl);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestCfgHoppingSeq(uint handle, ushort[] channels);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestSettle(uint handle, ushort start, ushort aEnd);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hqGetSettle(uint handle, ushort[] r);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int get_freq_offset(uint handle, out double offset, int sample_size);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetEeprom(uint handle, ushort log2bytes, ushort addrMask);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadBdAddr(uint handle, out uint lap, out byte uap, out ushort nap);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psRead(uint handle, ushort psKey, ushort store, ushort arrayLen, ushort[] data, out ushort aLen);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psClear(uint handle, ushort psKey, ushort store);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psClearAll(uint handle, ushort store);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psFactorySet(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psFactoryRestoreAll(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psFactoryRestore(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psSize(uint handle, ushort psKey, ushort store, out ushort size);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWrite(uint handle, ushort psKey, ushort store, ushort length, ushort[] data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteVerify(uint handle, ushort psKey, ushort store, ushort length, ushort[] data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteBdAddr(uint handle, uint lap, uint uap, uint nap);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadModuleId(uint handle, out uint moduleId);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadXtalFtrim(uint handle, out ushort fTrim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteXtalFtrim(uint handle, ushort fTrim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadXtalOffset(uint handle, out short offset);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteXtalOffset(uint handle, short offset);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteModuleSecurityCode(uint handle, ushort[] code);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteModuleId(uint handle, uint moduleId);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteBaudrate(uint handle, ushort value);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteRadiotestFirstTrimTime(uint handle, uint time);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadRadiotestFirstTrimTime(uint handle, out uint time);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteRadiotestLoLvlTrimEnable(uint handle, ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadRadiotestLoLvlTrimEnable(uint handle, out ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteRadiotestSubsequentTrimTime(uint handle, uint time);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadRadiotestSubsequentTrimTime(uint handle, out uint time);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteHostInterface(uint handle, ushort transport);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadHostInterface(uint handle, out ushort transport);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteUsbAttributes(uint handle, ushort bmAttributes);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteDPlusPullup(uint handle, ushort pioPin);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteUsbMaxPower(uint handle, ushort maxPower);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWritePioProtectMask(uint handle, ushort mask);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadPioProtectMask(uint handle, out ushort mask);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteTxOffsetHalfMhz(uint handle, short offset);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadTxOffsetHalfMhz(uint handle, out short offset);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteUsrValue(uint handle, ushort userNo, ushort length, ushort[] data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadUsrValue(uint handle, ushort userNo, ushort maxLen, out ushort length, ushort[] data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWritePowerTable(uint handle, ushort numEntries, byte intPA, byte[] extPA, int[] power);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadPowerTable(uint handle, int maxSize, out int numEntries, byte[] intPA, byte[] extPA, int[] power);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psWriteVmDisable(uint handle, byte vmDisable);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psReadVmDisable(uint handle, out byte vmDisable);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psMergeFromFile(uint handle, string filePath);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int psMergeFromFile(uint handle, byte[] filePath);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSlave(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSetAfhHostChannelClass(uint handle, byte[] cClass);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciReadAfhChannelMap(uint handle, ushort aclHandle, out byte mode, byte[] cMap);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSetEventFilterAutoacceptConnection(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWriteInquiryScanActivity(uint handle, ushort inquiryscan_interval, ushort inquiryscan_window);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWritePageScanActivity(uint handle, ushort pagescan_interval, ushort pagescan_window);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWriteScanEnable(uint handle, byte scan_enable);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciInquiry(uint handle, byte inquiryLength, byte numResponses, uint lap);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciGetInquiryResults(uint handle, uint[] lap, byte[] uap, ushort[] nap, ushort[] clockOffset, uint maxLen, out uint aLen);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciInquiryCancel(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciCreateConnection(uint handle, uint lap, byte uap, ushort nap, ushort pkt_type, out ushort connectionHandle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciCreateConnectionNoInquiry(uint handle, uint lap, byte uap, ushort nap, ushort pkt_type, byte page_scan_rep_mode, byte page_scan_mode, ushort clock_offset, byte allow_role_switch, out ushort connectionHandle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciCreateScoConnection(uint handle, ushort aclConnectionHandle, ushort pkt_type, out ushort scoConnectionHandle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSetupScoConnection(uint handle, ushort aclConnectionHandle, uint txBandwidth, uint rxBandwidth, ushort maxLatency, ushort voiceSetting, byte retransEffort, ushort pktType, out ushort scoConnectionHandle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciReadVoiceSetting(uint handle, out ushort voiceSetting);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWriteVoiceSetting(uint handle, ushort voiceSetting);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWriteLinkPolicySettings(uint handle, ushort connection_handle, ushort link_policy_settings);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSendAclFile(uint handle, ushort connHandle, string fileName);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSendAclFile(uint handle, ushort connHandle, byte[] fileName);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSendAclData(uint handle, ushort connHandle, byte[] data, ushort length);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciGetAclData(uint handle, byte[] data, out uint numBytes);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciGetAclBytesRead(uint handle, out uint numBytes);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciGetAclFileName(uint handle, StringBuilder fileName, out uint length);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciGetAclFileName(uint handle, byte[] fileName, out uint length);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciGetAclState(uint handle, out int state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciResetAclState(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciReset(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetAnaXtalFtrim(uint handle, out ushort ftrim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetAnaXtalFtrim(uint handle, ushort ftrim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSniffMode(uint handle, ushort connection_handle, ushort sniff_max_interval, ushort sniff_min_interval, ushort sniff_attempt, ushort sniff_timeout);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciExitSniff(uint handle, ushort connection_handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciDisconnect(uint handle, ushort connection_handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciGetConnectionHandle(uint handle, uint lap, byte uap, ushort nap, out ushort connectionHandle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciConnectionStatus(uint handle, ushort connection_handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciEnableDeviceUnderTestMode(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciGetLinkQuality(uint handle, ushort connection_handle, out byte quality);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciReadRemoteVersionInformation(uint handle, ushort connection_handle, uint[] r);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciReadRemoteNameRequest(uint handle, uint lap, byte uap, ushort nap, byte page_scan_repetition_mode, byte page_scan_offset, ushort clock_offset, StringBuilder r);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciReadRemoteNameRequest(uint handle, uint lap, byte uap, ushort nap, byte page_scan_repetition_mode, byte page_scan_offset, ushort clock_offset, byte[] r);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int dmRegisterReq(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int dmSlave(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int dmEnableDeviceUnderTestMode(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int dmWritePageScanActivity(uint handle, ushort pagescan_interval, ushort pagescan_window);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int dmWriteInquiryScanActivity(uint handle, ushort inquiryscan_interval, ushort inquiryscan_window);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int dmWriteScanEnable(uint handle, byte scan_enable);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int dmSetEventFilterAutoacceptConnection(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBc3PsuTrim(uint handle, ushort data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdChargerPsuTrim(uint handle, ushort trim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBc3BuckReg(uint handle, ushort data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdPsuSmpsEnable(uint handle, ushort reg);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBc3MicEn(uint handle, ushort data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdPsuHvLinearEnable(uint handle, ushort reg);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBc3Led0(uint handle, ushort data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdLedEnable(uint handle, ushort led, ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdLed0Enable(uint handle, ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBc3Led1(uint handle, ushort data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdLed1Enable(uint handle, ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdChargerStatus(uint handle, out ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdChargerDisable(uint handle, ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdChargerSuppressLed0(uint handle, ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciCreateConnectionNoWait(uint handle, uint lap, byte uap, ushort nap, ushort pktType, byte pageScanRepMode, byte pageScanMode, ushort clockOffset, byte allowRoleSwitch);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWriteAuthenticationEnable(uint handle, byte enable);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciLinkKeyRequestNegativeReply(uint handle, uint lap, byte uap, ushort nap);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWaitForConnectionComplete(uint handle, out ushort connHandle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWaitForLinkKeyRequest(uint handle, out uint lap, out byte uap, out ushort nap);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWaitForPinCodeRequest(uint handle, out uint lap, out byte uap, out ushort nap);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciWaitForEncryptionChange(uint handle, out byte enable);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciPinCodeRequestReply(uint handle, uint lap, byte uap, ushort nap, byte pinCodeLength, byte[] pinCode);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hciSetConnectionEncryption(uint handle, ushort connHandle, byte enable);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int vmWrite(uint handle, ushort[] data);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int vmRead(uint handle, ushort[] data, ushort timeout);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetSingleChan(uint handle, ushort channel);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetHoppingOn(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmSwitchPower(uint handle, byte powerOn);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmSetFreq(uint handle, uint freqKHz);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmGetRssi(uint handle, out sbyte rssi);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmGetSnr(uint handle, out short snr);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmGetIfOffset(uint handle, out short offset);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmGetStatus(uint handle, out byte status);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmSetupAudio(uint handle, byte route, byte gain, byte channel);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmVerifyRDSPi(uint handle, ushort pi, ushort timeoutMs, out byte matched);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmTxSwitchPower(uint handle, byte powerOn);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmTxSetFreq(uint handle, uint freqKHz);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmTxSetPowerLevel(uint handle, short powerLevel);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdFmTxSetupAudio(uint handle, byte route, ushort audioGain);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdDisconnectAudio(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdDirectChargerPsuTrim(uint handle, ushort trim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int teSupportsHq(uint handle, out byte hqSupported);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetAuxDac(uint handle, byte enable, byte level);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetMicBiasIf(uint handle, byte instance, byte enable, byte voltage);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetMicBias(uint handle, byte enable, byte voltage, byte current, byte enableLowPowerMode);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int teGetAvailableSpiPorts(out ushort maxLen, StringBuilder ports, StringBuilder trans, out ushort count);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int teGetAvailableSpiPorts(out ushort maxLen, byte[] ports, byte[] trans, out ushort count);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdProvokeFault(uint handle, ushort faultCode);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hqGetFaultReports(uint handle, ushort maxReports, ushort[] codes, uint[] timestamps, ushort[] repeats, out ushort numReports, int timeout);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int teGetFaultDesc(uint handle, ushort faultCode, StringBuilder desc);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int teGetFaultDesc(uint handle, ushort faultCode, byte[] desc);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetMapScoPcm(uint handle, byte enable);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetVrefConstant(uint handle, out ushort vref);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetVrefAdc(uint handle, out ushort result, out byte numBits);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdBC5FMGetI2CState(uint handle, out byte sda, out byte scl);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int refEpGetRssiDbm(uint handle, ushort freqMHz, double rssiChip, out double rssiDbm);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int refEpGetPaLevel(uint handle, ushort freqMHz, double targetPowerDbm, out ushort intPa, out double powerDbm);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int refEpWriteCalDataFile(uint handle, string filePath);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int refEpWriteCalDataFile(uint handle, byte[] filePath);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int refEpLoadCalDataFile(uint handle, string filePath);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int refEpLoadCalDataFile(uint handle, byte[] filePath);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetVmStatus(uint handle, out ushort status, out ushort exitCode);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdI2CTransfer(uint handle, ushort slaveAddr, ushort txOctets, ushort rxOctets, byte restart, byte[] data, out ushort octets);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int radiotestBle(uint handle, ushort command, byte channel, byte txLength, byte txPayload);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int hqGetBleRxPktCount(uint handle, int timeout, out ushort pktCount);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetChargerTrims(uint handle, out ushort chgRefTrim, out ushort hVrefTrim, out ushort rTrim, out ushort iTrim, out ushort iExtTrim, out ushort iTermTrim, out ushort vFastTrim, out ushort hystTrim);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdCapSenseRead(uint handle, ushort mask, ushort[] values);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSetSpiLockCustomerKey(uint handle, uint[] custKey);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdGetSpiLockStatus(uint handle, out ushort status);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi)]
        public static extern int bccmdSpiLockInitiateLock(uint handle);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "bccmdPsuSmpsEnable")]
        public static extern int bccmdPsuBuckReg(uint handle, ushort reg);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "bccmdPsuHvLinearEnable")]
        public static extern int bccmdPsuMicEn(uint handle, ushort reg);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "bccmdLed0Enable")]
        public static extern int bccmdLed0(uint handle, ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "bccmdLed1Enable")]
        public static extern int bccmdLed1(uint handle, ushort state);

        [DllImport("TestEngine.dll", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Ansi, EntryPoint = "bccmdChargerSuppressLed0")]
        public static extern int bccmdChargerSupressLed0(uint handle, ushort state);
    }
}
