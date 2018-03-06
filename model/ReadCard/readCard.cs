using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MODEL.ReadCard {
    public class readCard {

        int iPort;
        bool connected = false;

        public void Connect() {
            iPort = 0;
            for (iPort = 1001; iPort < 1017; iPort++) {
                if (readCardAPI.Syn_OpenPort(iPort) == 0) {
                    if (readCardAPI.Syn_GetSAMStatus(iPort, 0) == 0) {
                        readCardAPI.Syn_ClosePort(iPort);
                        //sText = "读卡器连接在" + iPort + "USB端口上";
                        connected = true;
                        return;
                    }
                }
                readCardAPI.Syn_ClosePort(iPort);
            }
            for (iPort = 1; iPort < 17; iPort++) {
                if (readCardAPI.Syn_OpenPort(iPort) == 0) {
                    if (readCardAPI.Syn_GetSAMStatus(iPort, 0) == 0) {
                        readCardAPI.Syn_ClosePort(iPort);
                        //sText = "读卡器连接在串口" + iPort + "上";
                        connected = true;
                        return;
                    }
                }
                readCardAPI.Syn_ClosePort(iPort);
            }
        }

        public void GetSecurityModuleID() {
            byte[] cSAMID = new byte[128];
            if (iPort == 0) {
                throw new Exception("没有连接读卡器");
            }
            if (readCardAPI.Syn_OpenPort(iPort) != 0) {
                throw new Exception("打开端口错误");
            }
            if (readCardAPI.Syn_GetSAMIDToStr(iPort, ref cSAMID[0], 0) == 0) {
                ASCIIEncoding encoding = new ASCIIEncoding();
                string constructedString = encoding.GetString(cSAMID);
                //sText = "安全模块ID:" + constructedString;
            } else {
                throw new Exception("获得安全模块ID错误");
            }
            readCardAPI.Syn_ClosePort(iPort);
        }

        public IDCardData Read() {
            byte[] pucIIN = new byte[4];
            byte[] pucSN = new byte[8];
            if (!connected) {
                Connect();
            }
            IDCardData CardMsg = new IDCardData();
            try {
                int nRet = readCardAPI.Syn_OpenPort(iPort);
                if (nRet == 0) {
                    nRet = readCardAPI.Syn_GetSAMStatus(iPort, 0);
                    nRet = readCardAPI.Syn_StartFindIDCard(iPort, ref pucIIN[0], 0);
                    nRet = readCardAPI.Syn_SelectIDCard(iPort, ref pucSN[0], 0);
                    if (readCardAPI.Syn_ReadMsg(iPort, 0, ref CardMsg) == 0) {
                        return CardMsg;
                    } else {                        
                        throw new Exception("读二代证信息错误");
                    }
                } else {
                    throw new Exception("打开端口错误");
                }
            } catch {
                connected = false;
                throw;
            } finally {
                readCardAPI.Syn_ClosePort(iPort);
            }
        }     
    }
}
