using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace sBot
{
    public partial class Form3 : Form
    {
        #region Imports

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("psapi.dll")]
        public static extern int EmptyWorkingSet(IntPtr hwProc);

        #endregion

        #region Form3

        public Form3(Form1 _form1)
        {
            InitializeComponent();

            this.Owner = _form1;
            contextMenuStrip1.Cursor = Cursors.Hand;

            Bill = new SupremeBot.SupremeInformation();
        }

        private void Form3_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void Form3_MouseHover(object sender, EventArgs e)
        {
            groupBox1.Focus();
        }

        #endregion

        #region Event Handler

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg == 0x0084)
            {
                switch ((int)m.Result)
                {
                    case 15:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                    case 16:
                    case 17:
                        m.Result = (IntPtr)1;
                        break;
                }
            }
        }

        #endregion

        #region GOD - Function 

        #region Variable

        public SupremeBot.SupremeInformation Bill;

        private bool Block;

        #endregion

        public bool WinstonWolf()
        {
            if (!Block && !string.IsNullOrWhiteSpace(cueTextBox1.Text) && !string.IsNullOrWhiteSpace(cueTextBox2.Text) && !string.IsNullOrWhiteSpace(cueTextBox3.Text) && !string.IsNullOrWhiteSpace(cueTextBox4.Text) && !string.IsNullOrWhiteSpace(cueTextBox5.Text) && !string.IsNullOrWhiteSpace(cueTextBox6.Text) && !string.IsNullOrWhiteSpace(cueTextBox7.Text) && !string.IsNullOrWhiteSpace(cueTextBox8.Text) && !string.IsNullOrWhiteSpace(cueTextBox9.Text) && !string.IsNullOrWhiteSpace(cueTextBox10.Text) && !string.IsNullOrWhiteSpace(cueTextBox11.Text) && !string.IsNullOrWhiteSpace(cueTextBox12.Text))
            {
                Bill.Add(cueTextBox1.Text, cueTextBox2.Text, cueTextBox3.Text, cueTextBox4.Text, cueTextBox5.Text, cueTextBox6.Text, cueTextBox7.Text, cueTextBox8.Text, cueTextBox9.Text, cueTextBox10.Text, cueTextBox11.Text, cueTextBox12.Text);
                Block = true;
            }

            return Block;
        }

        #endregion

        #region cueTextBoxes

        private void cueTextBox10_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Convert.ToChar(Keys.Space);
        }

        private void cueTextBox11_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete && e.KeyChar != Convert.ToChar(Keys.Space);
        }

        private void cueTextBox12_KeyPress(object sender, KeyPressEventArgs e)
        {
            const char Delete = (char)8;
            e.Handled = !Char.IsDigit(e.KeyChar) && e.KeyChar != Delete;
        }

        #endregion

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            groupBox1.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Bill.Clear();

            cueTextBox1.Clear();
            cueTextBox2.Clear();
            cueTextBox3.Clear();
            cueTextBox4.Clear();
            cueTextBox5.Clear();
            cueTextBox6.Clear();
            cueTextBox7.Clear();
            cueTextBox8.Clear();
            cueTextBox9.Clear();
            cueTextBox10.Clear();
            cueTextBox11.Clear();
            cueTextBox12.Clear();

            groupBox1.Focus();

            Block = false;

            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }
    }
}
