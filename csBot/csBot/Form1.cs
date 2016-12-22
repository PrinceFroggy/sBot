using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace sBot
{
    public partial class Form1 : Form
    {
        #region Imports

        [DllImport("psapi.dll")]
        public static extern int EmptyWorkingSet(IntPtr hwProc);

        #endregion

        #region Form1 functions

        #region Variable

        BackgroundWorker Backgroundlist;

        #endregion

        public Form1()
        {
            InitializeComponent();
            InitializeBrowser();

            this.Size = new Size(334, 243);

            Backgroundlist = new System.ComponentModel.BackgroundWorker();
            Backgroundlist.DoWork += new DoWorkEventHandler(Backgroundlist_DoWork);
            Backgroundlist.RunWorkerAsync();
        }

        #endregion

        #region Initialize functions

        #region Variable
        
        public ChromiumWebBrowser Browser;
        
        #endregion

        private void InitializeBrowser()
        {
            Cef.Initialize(new CefSettings());
            Browser = new ChromiumWebBrowser("http://www.supremenewyork.com/");
            panel1.Controls.Add(Browser);
            Browser.Dock = DockStyle.Fill;
        }

        #region Variable

        private SupremeList List;

        #endregion

        private void InitializeList()
        {
            List = new SupremeList(0);
        }

        #endregion

        #region Background worker

        private void Backgroundlist_DoWork(object sender, DoWorkEventArgs e)
        {
            InitializeList();
        }

        #endregion

        #region Robot animation

        #region Delegate

        delegate void SetBotCallback(int i);

        #endregion

        public void Robotanimation(int i)
        {
            if (this.pictureBox6.InvokeRequired)
            {
                SetBotCallback p = new SetBotCallback(Robotanimation);
                this.Invoke(p, new object[] { i });
            }
            else
            {
                switch (i)
                {
                    case 0:
                        pictureBox6.Image = Properties.Resources.robot___hands_down;
                        pictureBox6.Refresh();

                        Bot.Stop();
                        break;

                    case 1:
                        pictureBox6.Image = Properties.Resources.robot___gif;
                        pictureBox6.Refresh();

                        Bot.Start();
                        break;

                    case 2:
                        pictureBox6.Image = Properties.Resources.robot___hands_up;
                        pictureBox6.Refresh();
                        break;
                }

                EmptyWorkingSet(Process.GetCurrentProcess().Handle);
            }
        }

        #endregion

        #region Execution

        public void Execution(int scene, int item)
        {
            switch(scene)
            {
                case 0:
                    Browser.ExecuteScriptAsync("document.getElementById('size').text=" + '\'' + Wishlist[item].Size + '\'');
                    break;
            }
        }

        #endregion

        #region Picturebox functions

        #region Variables

        private SupremeBot.SupremeInformation Bill;
        private SupremeBot.SupremeProposal Wishlist;

        private SupremeBot Bot;

        bool Lock;
        bool Lockswitch;

        #endregion

        private void pictureBox6_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Lock)
            {
                for (int i = 1; i <= 15; i++)
                {
                    switch (i)
                    {
                        case 1:
                            if (string.IsNullOrWhiteSpace(cueTextBox1.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 2:
                            if (string.IsNullOrWhiteSpace(cueTextBox2.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 3:
                            if (string.IsNullOrWhiteSpace(cueTextBox3.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 4:
                            if (string.IsNullOrWhiteSpace(cueTextBox4.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 5:
                            if (string.IsNullOrWhiteSpace(cueTextBox5.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 6:
                            if (string.IsNullOrWhiteSpace(cueTextBox6.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 7:
                            if (string.IsNullOrWhiteSpace(cueTextBox7.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 8:
                            if (string.IsNullOrWhiteSpace(cueTextBox8.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 9:
                            if (string.IsNullOrWhiteSpace(cueTextBox9.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 10:
                            if (string.IsNullOrWhiteSpace(cueTextBox10.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 11:
                            if (string.IsNullOrWhiteSpace(cueTextBox11.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 12:
                            if (string.IsNullOrWhiteSpace(cueTextBox12.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                        case 13:
                            if (string.IsNullOrWhiteSpace(cueTextBox13.Text))
                            {
                                Lockswitch = true;
                            }
                            break;
                    }

                    if (Lockswitch)
                    {
                        break;
                    }
                }

                if (!Lockswitch)
                {
                    Bill = new SupremeBot.SupremeInformation();
                    Bill.Add(cueTextBox1.Text, cueTextBox2.Text, cueTextBox3.Text, cueTextBox4.Text, cueTextBox5.Text, cueTextBox6.Text, cueTextBox7.Text, cueTextBox8.Text, cueTextBox9.Text, cueTextBox10.Text, cueTextBox11.Text, cueTextBox12.Text);

                    Wishlist = new SupremeBot.SupremeProposal();
                    Wishlist.Add(cueTextBox13.Text, cueTextBox14.Text, cueTextBox15.Text);

                    if (this.Wishlist.Count != 0 && this.Bill.Count != 0)
                    {
                        Bot = new SupremeBot(this, Wishlist, Bill);

                        if (Bot.Executed)
                        {
                            Robotanimation(1);
                        }

                        Lock = true;
                        Lockswitch = true;
                    }
                }
                else
                {
                    Lock = false;
                    Lockswitch = false;
                }
            }
            else
            {
                Robotanimation(0);

                Lock = false;
                Lockswitch = false;
            }
        }

        #endregion
    }
}
