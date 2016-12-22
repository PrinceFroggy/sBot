using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sBot
{
    public class CueTextBox : TextBox
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        private static extern IntPtr SendMessage(HandleRef hWnd, uint Msg, IntPtr wParam, String lParam);

        private static uint ECM_FIRST = 0x1500;
        private static uint EM_SETCUEBANNER = ECM_FIRST + 1;

        private string _cueText = String.Empty;

        public event EventHandler CueTextChanged;

        private bool _showCueTextWithFocus = false;

        public event EventHandler ShowCueTextWithFocusChanged;

        [Description("The text value to be displayed as a cue to the user.")]
        [Category("Appearance")]
        [DefaultValue("")]
        [Localizable(true)]
        public string CueText
        {
            get
            {
                return _cueText;
            }
            set
            {
                if (value == null)
                {
                    value = String.Empty;
                }

                if (!_cueText.Equals(value, StringComparison.CurrentCulture))
                {
                    _cueText = value;
                    UpdateCue();
                    OnCueTextChanged(EventArgs.Empty);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnCueTextChanged(EventArgs e)
        {
            EventHandler handler = CueTextChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        [Description("Indicates whether the CueText will be displayed even when the control has focus.")]
        [Category("Appearance")]
        [DefaultValue(false)]
        [Localizable(true)]
        public bool ShowCueTextWithFocus
        {
            get
            {
                return _showCueTextWithFocus;
            }
            set
            {
                if (_showCueTextWithFocus != value)
                {
                    _showCueTextWithFocus = value;
                    UpdateCue();
                    OnShowCueTextWithFocusChanged(EventArgs.Empty);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnShowCueTextWithFocusChanged(EventArgs e)
        {
            EventHandler handler = ShowCueTextWithFocusChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            UpdateCue();

            base.OnHandleCreated(e);
        }

        private void UpdateCue()
        {
            if (this.IsHandleCreated)
            {
                SendMessage(new HandleRef(this, this.Handle), EM_SETCUEBANNER, (_showCueTextWithFocus) ? new IntPtr(1) : IntPtr.Zero, _cueText);
            }
        }
    }
}
