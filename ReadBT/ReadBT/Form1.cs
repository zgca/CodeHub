using System;
using System.Windows.Forms;
using TestEngineAPI;

namespace ReadBT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MessageBox.Show("1");
        }

        private uint csrHandle;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.csrHandle = TestEngine.openTestEngine(2, "\\\\.\\csr0", 0u, 0, 1000);
                this.textBox1.AppendText("CSR Open 成功！\r\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            uint num = 0u;
            byte b = 0;
            ushort num2 = 0;
            if (TestEngine.psReadBdAddr(this.csrHandle, out num, out b, out num2) == 1)
            {
                str = num2.ToString("X4") + b.ToString("X2") + num.ToString("X6");
            }
            this.textBox1.AppendText("Read CSR BT Addr : " + str + "\r\n");
        }
    }
}