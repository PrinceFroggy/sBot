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
using System.Management;

namespace sBot
{
    public partial class Form1 : Form
    {
        #region Imports

        [DllImport("psapi.dll")]
        public static extern int EmptyWorkingSet(IntPtr hwProc);

        #endregion

        #region Form1

        public Form1()
        {
            InitializeComponent();
            InitializeForms();

            Randomizer = new System.Threading.Timer(CallLogoRandomizer, null, 0, 3000);
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            form2.Location = new Point(this.Location.X + 250, this.Location.Y + 24);
            form3.Location = new Point(this.Location.X - 200, this.Location.Y - 114);
        }

        #endregion

        #region Functions

        #region Forms

        #region Variables

        Form2 form2;
        Form3 form3;

        #endregion

        private void InitializeForms()
        {
            form2 = new Form2(this);
            form3 = new Form3(this);
        }

        #endregion

        #region Logo - Invoke - Randomizer

        #region Delegate

        delegate void SetPictureCallback(Image logo);

        #endregion

        private void CallLogoRandomizer(Object state)
        {
            if (Block)
            {
                try
                {
                    this.LogoRandomizer((Image)Properties.Resources.ResourceManager.GetObject("supreme_box_logo___" + new Random().Next(2, Properties.Resources.ResourceManager.GetResourceSet(System.Globalization.CultureInfo.CurrentUICulture, true, true).Cast<Object>().Count() - 7).ToString()));
                }
                catch (Exception) { }
            }
        }
        
        private void LogoRandomizer(Image logo)
        {
            if (this.pictureBox1.InvokeRequired)
            {
                SetPictureCallback p = new SetPictureCallback(LogoRandomizer);
                this.Invoke(p, new object[] { logo });
            }
            else
            {
                this.pictureBox1.Image = logo;
            }

            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }

        #endregion

        #region Bot - Invoke

        #region Delegate

        delegate void SetBotCallback(int i);

        #endregion

        public void BotBuddha(int i)
        {
            if (this.pictureBox2.InvokeRequired)
            {
                SetBotCallback p = new SetBotCallback(BotBuddha);
                this.Invoke(p, new object[] { i });
            }
            else
            {
                switch (i)
                {
                    case 0:
                        try
                        {
                            pictureBox1.Image = Properties.Resources.supreme_box_logo___1;
                        }
                        catch (Exception) { }

                        pictureBox2.Image = Properties.Resources.robot_hands___down;

                        Bot.Stop();

                        Randomizer.Change(Timeout.Infinite, Timeout.Infinite);
                        Block = false;
                        break;

                    case 1:
                        pictureBox2.Image = Properties.Resources.robot_gif;

                        Bot.Start();

                        Randomizer.Change(0, 3000);
                        Block = true;
                        break;

                    case 2:
                        pictureBox2.Image = Properties.Resources.robot_hands___up;
                        break;

                    case 3:
                        pictureBox2.Image = Properties.Resources.robot_gif;
                        pictureBox2.Refresh();
                        break;
                }
            }

            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }

        #endregion

        #region HWID - Calculator - Verification

        #region Variable

        private static Mutex _mutex;

        #endregion

        static bool IsSingleInstance()
        {
            _mutex = new Mutex(false, "sBot");

            // keep the mutex reference alive until the normal 
            //termination of the program
            GC.KeepAlive(_mutex);

            try
            {
                return _mutex.WaitOne(0, false);
            }
            catch (AbandonedMutexException)
            {
                // if one thread acquires a Mutex object 
                //that another thread has abandoned 
                //by exiting without releasing it

                _mutex.ReleaseMutex();
                return _mutex.WaitOne(0, false);
            }
        }

        static bool CalculateVerifiedInstance(string id)
        {
            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create("http://jahpre.me/HWID.txt");

                System.Net.WebResponse response = request.GetResponse();

                System.IO.StreamReader reader = new System.IO.StreamReader(response.GetResponseStream());

                string HWIDLIST = reader.ReadToEnd();

                string CRYPT = HWID() + "|" + "sBot" + "|" + "26/02/2666";

                string ENCRYPTEDHWID = AESEncryption.Encrypt(CRYPT, "666", "Password2", "SHA1", 2, "16CHARSLONG12345", 128);

                Clipboard.SetText(ENCRYPTEDHWID);

                if (HWIDLIST.Contains(ENCRYPTEDHWID))
                {
                    string DECRYPTEDHWID = AESEncryption.Decrypt(ENCRYPTEDHWID, "666", "Password2", "SHA1", 2, "16CHARSLONG12345", 128);

                    string[] DETAILS = DECRYPTEDHWID.Split('|');

                    if (DETAILS[0] == HWID() & DETAILS[1] == "sBot")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        static string HWID()
        {
            string cpuInfo = string.Empty;
            ManagementClass mc = new ManagementClass("win32_processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == "")
                {
                    cpuInfo = mo.Properties["processorID"].Value.ToString();
                    break;
                }
            }
            return cpuInfo;
        }

        #endregion

        #endregion

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (IsSingleInstance())
            {
                //if (CalculateVerifiedInstance("sBot"))
                //{
                    button1.Visible = false;

                    pictureBox2.Image = Properties.Resources.robot_hands___down;

                    pictureBox2.Visible = true;

                    pictureBox1.Cursor = Cursors.Hand;
                //}
            }

            groupBox1.Focus();
        }

        #region pictureBox

        #region pictureBox1

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!button1.Visible)
            {
                if (!form2.Visible)
                {
                    form2.Visible = true;

                    form2.Location = new Point(this.Location.X + 250, this.Location.Y + 24);
                }
                else
                {
                    form2.Visible = false;
                }
            }
        }

        #endregion

        #region pictureBox2

        #region Variables

        SupremeBot Bot;

        System.Threading.Timer Randomizer;

        private bool Block;
        
        #endregion

        private void pictureBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (!form3.Visible)
                {
                    form3.Visible = true;

                    form3.Location = new Point(this.Location.X - 200, this.Location.Y - 114);
                }
                else
                {
                    form3.Visible = false;
                }
            }
            else if (!Block)
            {
                try
                {
                    System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 2");
                    System.Diagnostics.Process.Start("rundll32.exe", "InetCpl.cpl,ClearMyTracksByProcess 8");
                }
                catch (Exception) { }

                if (form2.WishList.Count != 0 && form3.WinstonWolf() && form3.Bill.Count != 0)
                {
                    Bot = new SupremeBot(this, form2.WishList, form3.Bill);

                    if (Bot.Executed)
                    {
                        BotBuddha(1);
                    }
                }
            }
            else
            {
                BotBuddha(0);
            }
        }

        #endregion

        #endregion

        #region webBrowser

        #region Variable

        public HtmlElement SupremeSize;
        public HtmlElement SupremeAddButton;
        public HtmlElement SupremeCart;
        public HtmlElement SupremeCartAddress;
        public HtmlElement SupremeState;
        public mshtml.HTMLSelectElement SupremeCountry;
        public HtmlElement SupremeCartCC;
        public HtmlElement SupremeType;
        public HtmlElement SupremeMonth;
        public HtmlElement SupremeYear;
        public HtmlElementCollection SupremeTerm;
        public HtmlElement SupremeProcessButton;

        #endregion

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            try
            {
                SupremeSize = webBrowser1.Document.GetElementById("size");
                SupremeAddButton = webBrowser1.Document.GetElementById("add-remove-buttons");
                SupremeCart = webBrowser1.Document.GetElementById("cart");
                SupremeCartAddress = webBrowser1.Document.GetElementById("cart-address");
                SupremeState = webBrowser1.Document.GetElementById("order_billing_state");
                SupremeCountry = (mshtml.HTMLSelectElement) webBrowser1.Document.GetElementById("order_billing_country").DomElement;
                SupremeCartCC = webBrowser1.Document.GetElementById("cart-cc");
                SupremeType = webBrowser1.Document.GetElementById("credit_card_type");
                SupremeMonth = webBrowser1.Document.GetElementById("credit_card_month");
                SupremeYear = webBrowser1.Document.GetElementById("credit_card_year");
                SupremeTerm = webBrowser1.Document.GetElementsByTagName("div");
                SupremeProcessButton = webBrowser1.Document.GetElementById("pay");
            }
            catch (Exception) { }
        }

        #endregion

        private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.Cursor = Cursors.Default;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (_mutex != null)
                {
                    _mutex.ReleaseMutex();
                }
            }
            catch (Exception) { }
        }
    }
}
