using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MQLib;
using static MQText;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MQTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void MQCount_Click(object sender, EventArgs e)
        {
            // 1.宣告MQ物件
            MQWay GM = new MQWay(MQIP.Text.Trim(), MQPort.Text.Trim(), MQChannel.Text.Trim());

            //2. 算出數量
            MQCNT.Text = GM.GetQueueCount(MQManage.Text.Trim(), MQName.Text.Trim()).ToString();

        }

        private void PutQ_Click(object sender, EventArgs e)
        {
            // 1.宣告MQ物件
            MQWay GM = new MQWay(MQIP.Text.Trim(), MQPort.Text.Trim(), MQChannel.Text.Trim());

            //2.將資料序列化 (假設物件為Member)
            string data;
            Member mem = new Member();
            mem.Id = "25867890";
            mem.Name = "GSS";
            mem.Tel = "78902586";
            mem.Address = "台北市中山區德惠街";

            using (MemoryStream ms = new MemoryStream())
            {
                //以二進位做序列化 為何要用MemoryStream去使用記憶體做存取?
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(ms, mem); //將men的資料序列化到ms的資料流之中
                ms.Seek(0, 0); //將目前資料流中的位置設定為指定的數值

                byte[] ASCIIbytes = ms.ToArray();
                //seriealization
                data = Encoding.ASCII.GetString(ASCIIbytes);
            }
            bool ex = GM.PutQueue(MQManage.Text.Trim(), MQName.Text.Trim(), PutItem.Text);

            if (ex == true) MessageBox.Show("新增成功");
            else MessageBox.Show("新增失敗");

        }

        private void GetQ_Click(object sender, EventArgs e)
        {
            //1.宣告MQ物件
            MQWay GM = new MQWay(MQIP.Text.Trim(), MQPort.Text.Trim(), MQChannel.Text.Trim());

            //2.取得資料 (目前是序列化的資料)
            GetItem.Text = GM.GetQueue(MQManage.Text.Trim(), MQName.Text.Trim());
            MessageBox.Show(GetItem.Text);

        }
    }
}
