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
    public partial class Form2 : Form
    {
        #region Imports

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("psapi.dll")]
        public static extern int EmptyWorkingSet(IntPtr hwProc);

        #endregion

        #region Form2

        #region Variable

        System.Threading.Timer Retriever;

        #endregion

        public Form2(Form1 _form1)
        {
            InitializeComponent();

            this.Owner = _form1;
            Block = true;

            contextMenuStrip1.Cursor = Cursors.Hand;

            pictureBox1.Visible = false;
            groupBox1.Visible = true;

            WishList = new SupremeBot.SupremeProposal();
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if (Retriever == null)
            {
                Retriever = new System.Threading.Timer(CallPictureBoxRetriever, null, 0, 300000);

                RegisterHotKey(this.Handle, 1, 0, Convert.ToUInt32(Keys.Left));
                RegisterHotKey(this.Handle, 2, 0, Convert.ToUInt32(Keys.Right));
                RegisterHotKey(this.Handle, 3, 0, Convert.ToUInt32(Keys.Up));
                RegisterHotKey(this.Handle, 4, 0, Convert.ToUInt32(Keys.Down));
                RegisterHotKey(this.Handle, 5, 0, Convert.ToUInt32(Keys.Insert));
            }
        }

        private void Form2_MouseHover(object sender, EventArgs e)
        {
            if (!groupBox1.Visible)
            {
                pictureBox1.Focus();
            }
            else
            {
                groupBox1.Focus();
            }
        }

        #endregion

        #region Overrided Event Handler

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
            else if (m.Msg == 0x0312 && this.Visible)
            {
                HotkeyHandler(m.WParam.ToInt32());
            }
        }

        #endregion

        #region Functions

        #region PictureBox - Hotkeys

        #region Delegate

        delegate void SetHotkeyCallback(int i);

        #endregion

        #region Variable

        private bool Block;

        #endregion

        private void HotkeyHandler(int i)
        {
            switch (i)
            {
                case 1:
                    if (Images != null)
                    {
                        GeneratePictureBoxImage(List, 0);
                    }
                    break;

                case 2:
                    if (Images != null)
                    {
                        GeneratePictureBoxImage(List, 1);
                    }
                    break;

                case 3:
                    if (Type != 0 && !Block)
                    {
                        Block = true;
                        Type = 0;

                        toolTip1.SetToolTip(pictureBox1, null);

                        pictureBox1.Image = sBot.Properties.Resources.loader;
                        pictureBox1.Cursor = Cursors.Default;
                        pictureBox1.Refresh();

                        Retriever.Change(0, 300000);
                    }
                    break;

                case 4:
                    if (Type != 1 && !Block)
                    {
                        Block = true;
                        Type = 1;

                        toolTip1.SetToolTip(pictureBox1, null);

                        pictureBox1.Image = sBot.Properties.Resources.loader;
                        pictureBox1.Cursor = Cursors.Default;
                        pictureBox1.Refresh();

                        Retriever.Change(0, 300000);
                    }
                    break;

                case 5:
                    if (!groupBox1.Visible)
                    {
                        pictureBox1.Visible = false;
                        groupBox1.Visible = true;
                    }
                    else
                    {
                        pictureBox1.Visible = true;
                        groupBox1.Visible = false;
                    }
                    break;
            }
        }

        #endregion

        #region PictureBox - Retriever

        #region Variable

        private int Type;

        #endregion

        private void CallPictureBoxRetriever(Object state)
        {
            switch (ListGenerator(Type))
            {
                case 0:
                    if (PopulateImageList(List))
                    {
                        GeneratePictureBoxImage(List, -1);
                    }
                    break;

                case 1:
                    GeneratePictureBoxImage(List, -1);
                    break;
            };
        }

        #endregion

        #region List - Generation

        #region Variable

        SupremeList List;

        #endregion

        private int ListGenerator(int i)
        {
            int ret = -1;

            if (List == null)
            {
                List = new SupremeList(i);

                if (List.Executed)
                {
                    ret = default(int);
                }
                else
                {
                    List = null;
                }
            }
            else
            {
                SupremeList Tmp = new SupremeList(i);

                if (Tmp.Executed)
                {
                    if (List.Count() != Tmp.Count())
                    {
                        List = Tmp;

                        ret = default(int);
                    }
                    else if (!List.SequenceEqual(Tmp, new SupremeComparer()))
                    {
                        List = Tmp;

                        ret = 1;
                    }
                }
                else
                {
                    Tmp = null;
                }
            }

            return ret;
        }

        #endregion

        #region Image Processor

        private Image LoadImage(string url)
        {
            Bitmap Bmp = null;

            try
            {
                System.Net.WebRequest request = System.Net.WebRequest.Create(url);

                System.Net.WebResponse response = request.GetResponse();

                System.IO.Stream responseStream = response.GetResponseStream();

                Bmp = new Bitmap(responseStream);

                responseStream.Dispose();
            }
            catch (Exception)
            {
                Bmp = null;
            }

            return Bmp;
        }

        #endregion

        #region ImageList - Generation

        #region Variable

        ImageList Images;

        #endregion

        private bool PopulateImageList(SupremeList _list)
        {
            if (Images == null)
            {
                Images = new ImageList();
                Images.ImageSize = new Size(120, 120);
            }
            else
            {
                Images.Images.Clear();
            }

            foreach (SupremeItem item in _list)
            {
                try
                {
                    Images.Images.Add(LoadImage("http:" + item.Product));
                }
                catch (Exception)
                {
                    Images.Images.Add(Properties.Resources.error);
                }
            }

            return true;
        }

        #endregion

        #region PictureBox - Invoke - Generation

        #region Delegate

        delegate void SetPictureBoxCallback(SupremeList _list, int i);

        #endregion

        #region Variable

        private int Navigation;

        #endregion

        private void GeneratePictureBoxImage(SupremeList _list, int i)
        {
            if (this.pictureBox1.InvokeRequired)
            {
                SetPictureBoxCallback p = new SetPictureBoxCallback(GeneratePictureBoxImage);
                this.Invoke(p, new object[] { _list, i });
            }
            else
            {
                switch (i)
                {
                    case 0:
                        if (!Block)
                        {
                            if (Navigation != 0)
                            {
                                Navigation--;
                            }

                            pictureBox1.Image = Images.Images[Navigation];
                        }
                        break;

                    case 1:
                        if (!Block)
                        {
                            if (Navigation != _list.Count() - 1)
                            {
                                Navigation++;
                            }

                            pictureBox1.Image = Images.Images[Navigation];
                        }
                        break;

                    default:
                        Navigation = default(int);

                        pictureBox1.Image = Images.Images[Navigation];

                        if (Type != 0)
                        {
                            pictureBox1.Cursor = Cursors.Hand;
                        }
                        else
                        {
                            pictureBox1.Cursor = Cursors.Help;
                        }

                        Block = false;
                        break;
                }

                if (!Block)
                {
                    if (_list[Navigation].Sold)
                    {
                        toolTip1.SetToolTip(pictureBox1, _list[Navigation].Name + " : SOLD OUT");
                    }
                    else
                    {
                        toolTip1.SetToolTip(pictureBox1, _list[Navigation].Name);
                    }
                }

                EmptyWorkingSet(Process.GetCurrentProcess().Handle);
            }
        }

        #endregion

        #endregion

        #region PictureBox MouseClick

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!Block && Type != 0)
            {
                cueTextBox1.Text = toolTip1.GetToolTip(pictureBox1);
            }
        }

        #endregion

        #region Label MouseClick

        #region Variable

        public SupremeBot.SupremeProposal WishList;

        #endregion

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cueTextBox1.Text) && string.IsNullOrWhiteSpace(cueTextBox2.Text) && string.IsNullOrWhiteSpace(cueTextBox3.Text))
            {
                WishList.Add(cueTextBox1.Text);
            }
            else if (!string.IsNullOrWhiteSpace(cueTextBox1.Text) && !string.IsNullOrWhiteSpace(cueTextBox2.Text) && string.IsNullOrWhiteSpace(cueTextBox3.Text))
            {
                WishList.Add(cueTextBox1.Text, cueTextBox2.Text);
            }
            else if (!string.IsNullOrWhiteSpace(cueTextBox1.Text) && !string.IsNullOrWhiteSpace(cueTextBox2.Text) && !string.IsNullOrWhiteSpace(cueTextBox3.Text))
            {
                WishList.Add(cueTextBox1.Text, cueTextBox2.Text, cueTextBox3.Text);
            }

            cueTextBox1.Clear();
            cueTextBox2.Clear();
            cueTextBox3.Clear();

            groupBox1.Focus();

            if (WishList.Count != 0)
            {
                toolTip1.SetToolTip(label1, "enumeration : " + WishList.Count());
            }

            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }

        #endregion

        private void groupBox1_MouseHover(object sender, EventArgs e)
        {
            groupBox1.Focus();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            WishList.Clear();

            cueTextBox1.Clear();
            cueTextBox2.Clear();
            cueTextBox3.Clear();

            groupBox1.Focus();

            toolTip1.SetToolTip(label1, "enumeration");

            EmptyWorkingSet(Process.GetCurrentProcess().Handle);
        }
    }
}
