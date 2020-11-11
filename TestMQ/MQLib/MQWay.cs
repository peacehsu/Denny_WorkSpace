using IBM.WMQ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MQLib
{
    public class MQWay
    {
        private string _MQServer, _MQChannel, _QueueManager, _RequestingQueue, _ReplyingQueue, _UserID, _UserPWD;
        private int _MQPort;
        private int _MQMessageExpiry = 3;           //MQ Server回應時間間隔，單位秒，預設3秒
        private int _MQMessageTimeOut = 500;        //MQ Server最大等待回應時間，單位秒，預設500秒

        private string _MQMessageFormat = MQC.MQFMT_NONE;
        private int _MQMessageCharacterSet = 950;     //BIG5
        private byte[] _MessageID = new byte[24];
        private byte[] _CorrelationID = new byte[24];

        private string Hostname;
        private string Port;
        private string Channel;

        public MQWay(string strHostname, string strPort, string strChannel)
        {
            this.Hostname = strHostname.Trim();
            this.Port = strPort.Trim();
            this.Channel = strChannel.Trim();
        }

        /// <summary>
        /// 將資料放至MQ的佇列中
        /// </summary>
        /// <param name="vstrQueueManagerName">佇列管理程式名稱</param>
        /// <param name="vstrRequestQueueName">佇列名稱</param>
        /// <param name="vstrRequestContent">要放入的資料</param>
        /// <returns>成功或失敗</returns>
        public bool PutQueue(string vstrQueueManagerName, string vstrRequestQueueName, string vstrRequestContent)
        {
            MQQueueManager mqQMgr;
            MQQueue requestQueue;

            MQText MQText = new MQText();
            MQMessage requestMessage;

            //step0

            MQEnvironment.Hostname = this.Hostname;
            MQEnvironment.Port = Convert.ToInt32(this.Port);
            MQEnvironment.Channel = this.Channel;

            //Step 1. Create Queue Manager Object. This will also CONNECT the Queue Manager
            try
            {
                mqQMgr = new MQQueueManager(vstrQueueManagerName);

            }
            catch (MQException mqe)
            {
                string strError = MQText.getMQText(mqe.Reason);
                throw new Exception("PutQueue Create Queue Manager Object 發生錯誤. Error:  code   " + mqe.Reason + ",  " + mqe.Message + ", Details: " + strError);

            }

            //Step 2. Open Request Queue for reading/ getting the request
            try
            {
                requestQueue = mqQMgr.AccessQueue(vstrRequestQueueName, MQC.MQOO_OUTPUT);
            }
            catch (MQException mqe)
            {
                if (mqQMgr.IsConnected)
                    mqQMgr.Disconnect();

                string strError = MQText.getMQText(mqe.Reason);
                throw new Exception("PutQueue open Request Queue 發生錯誤. Error:   code   " + mqe.Reason + ",  " + mqe.Message + ", Details: " + strError);

            }

            //step3. put content to MQ
            //建立MQMessage
            requestMessage = new MQMessage();
            requestMessage.Format = this._MQMessageFormat;
            requestMessage.CharacterSet = this._MQMessageCharacterSet;
            requestMessage.Persistence = MQC.MQPER_PERSISTENCE_AS_Q_DEF;
            requestMessage.Expiry = MQC.MQEI_UNLIMITED;

            //寫入Message內容
            //File.AppendAllText(@"D:\MQTest", vstrRequestContent);
            requestMessage.WriteString(vstrRequestContent);
            //File.AppendAllText(@"D:\MQTest", "====test====");

            //送出Message
            requestQueue.Put(requestMessage, new MQPutMessageOptions());

            //Step 4. Close Request, Response Queues and Disconnect Manager.
            try
            {

                if (requestQueue.OpenStatus)
                    requestQueue.Close();
                if (mqQMgr.IsConnected) 
                    mqQMgr.Disconnect();

                return true;
            }
            catch (MQException mqe)
            {
                string strError = MQText.getMQText(mqe.Reason);

                if (requestQueue.OpenStatus)
                    requestQueue.Close();

                if (mqQMgr.IsConnected)
                    mqQMgr.Disconnect();

                throw new Exception("PutQueue send Reply 發生錯誤. Error:  code   " + mqe.Reason + ",   " + mqe.Message + ", Details: " + strError);

            }
        }

        /// <summary>
        /// 由MQ的佇列取得資料
        /// </summary>
        /// <param name="vstrQueueManagerName">佇列管理程式名稱</param>
        /// <param name="vstrRequestQueueName">佇列名稱</param>
        /// <returns>序列化的資料</returns>
        public string GetQueue(string vstrQueueManagerName, string vstrRequestQueueName)
        {

            MQQueueManager mqQMgr;
            MQQueue requestQueue;

            MQText MQText = new MQText();
            MQMessage requestMessage;


            //step0

            MQEnvironment.Hostname = this.Hostname;
            MQEnvironment.Port = Convert.ToInt32(this.Port);
            MQEnvironment.Channel = this.Channel;

            //Step 1. Create Queue Manager Object. This will also CONNECT the Queue Manager
            try
            {
                mqQMgr = new MQQueueManager(vstrQueueManagerName);

            }
            catch (MQException mqe)
            {
                string strError = MQText.getMQText(mqe.Reason);
                throw new Exception("GetQueue create Queue Manager Object 發生錯誤. Error:  code   " + mqe.Reason + ",   " + mqe.Message + ", Details: " + strError);

            }

            //Step 2. Open Request Queue for reading/ getting the request
            try
            {

                requestQueue = mqQMgr.AccessQueue(vstrRequestQueueName, MQC.MQOO_INPUT_SHARED);

            }
            catch (MQException mqe)
            {

                if (mqQMgr.IsConnected) //if( mqQMgr.ConnectionStatus )
                    mqQMgr.Disconnect();

                string strError = MQText.getMQText(mqe.Reason);

                throw new Exception("GetQueue open Request Queue for reading 發生錯誤. Error:  code   " + mqe.Reason + ",   " + mqe.Message + ", Details: " + strError);

            }


            //step3. put content to MQ
            //建立MQMessage
            requestMessage = new MQMessage();
            requestMessage.Format = this._MQMessageFormat;
            requestMessage.CharacterSet = this._MQMessageCharacterSet;
            requestMessage.Expiry = this._MQMessageExpiry;

            MQGetMessageOptions MQGetMessageOptions = new MQGetMessageOptions();
            MQGetMessageOptions.WaitInterval = this._MQMessageTimeOut;
            MQGetMessageOptions.Options = MQC.MQGMO_WAIT;


            try
            {
                //讀取Replying Queue內的message
                requestQueue.Get(requestMessage, MQGetMessageOptions);
                string ReplyingMessage = requestMessage.ReadString(requestMessage.MessageLength);

                if (requestQueue.OpenStatus)
                    requestQueue.Close();
                if (mqQMgr.IsConnected) //if( mqQMgr.ConnectionStatus )
                    mqQMgr.Disconnect();

                return ReplyingMessage;

                //if (vGetMessageID == true)
                //{
                //    MQMessage.MessageId.CopyTo(_MessageID, 0);
                //}

                //if (vGetCorrelationID == true)
                //{
                //    MQMessage.CorrelationId.CopyTo(_CorrelationID, 0);
                //}
            }
            catch (MQException MQEx)
            {
                if (requestQueue.OpenStatus)
                    requestQueue.Close();
                if (mqQMgr.IsConnected) //if ( mqQMgr.ConnectionStatus )
                    mqQMgr.Disconnect();

                string strError = MQText.getMQText(MQEx.Reason);

                throw new Exception("GetQueue send Reply 發生錯誤. Error:  code   " + MQEx.Reason + ",   " + MQEx.Message + ", Details: " + strError);

            }


        }

        /// <summary>
        /// 取得佇列的目前數量
        /// </summary>
        /// <param name="vstrQueueManagerName"></param>
        /// <param name="vstrRequestQueueName"></param>
        /// <returns>目前數量</returns>
        public int GetQueueCount(string vstrQueueManagerName, string vstrRequestQueueName)
        {
            MQQueueManager mqQMgr;
            MQQueue requestQueue;

            MQText mqrcText = new MQText();

            //step0

            MQEnvironment.Hostname = this.Hostname;
            MQEnvironment.Port = Convert.ToInt32(this.Port);
            MQEnvironment.Channel = this.Channel;

            //Step 1. Create Queue Manager Object. This will also CONNECT the Queue Manager
            try
            {
                mqQMgr = new MQQueueManager(vstrQueueManagerName);

            }
            catch (MQException mqe)
            {
                string strError = mqrcText.getMQText(mqe.Reason);

                throw new Exception("GetQueueCount create Queue Manager Object. Error:   code   " + mqe.Reason + ",  " + mqe.Message + ", Details: " + strError);
            }

            //Step 2. Open Request Queue for reading/ getting the request
            try
            {
                requestQueue = mqQMgr.AccessQueue(vstrRequestQueueName, MQC.MQOO_INQUIRE);

            }
            catch (MQException mqe)
            {
                string strError = mqrcText.getMQText(mqe.Reason);

                if (mqQMgr.IsConnected) //if( mqQMgr.ConnectionStatus )
                    mqQMgr.Disconnect();

                throw new Exception("GetQueueCount open Request Queue for reading. Error:  code   " + mqe.Reason + ",   " + mqe.Message + ", Details: " + strError);


            }

            //inquire on a queue
            int[] selectors = new int[1];
            int[] intAttrs = new int[1];
            byte[] charAttrs = new byte[1];
            selectors[0] = MQC.MQIA_CURRENT_Q_DEPTH;
            requestQueue.Inquire(selectors, intAttrs, charAttrs);
            ASCIIEncoding enc = new ASCIIEncoding();
            String s1 = "";
            s1 = enc.GetString(charAttrs);
            int s2 = intAttrs[0];

            if (requestQueue.OpenStatus)
                requestQueue.Close();
            if (mqQMgr.IsConnected) //if( mqQMgr.ConnectionStatus )
                mqQMgr.Disconnect();

            return s2;
            //-------------------------------------------------------

        }

    }
}
