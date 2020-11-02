using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace DarkModeEnabler
{
    public class IconButton : Button
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        const int BM_SETIMAGE = 0x00F7;
        const int BS_ICON = 0x00000040;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), Obsolete("Does nothing", true)]
        public new FlatButtonAppearance FlatAppearance => null;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), Obsolete("Does nothing", true)]
        public new Image Image => null;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), Obsolete("Does nothing", true)]
        public new int ImageIndex => -1;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), Obsolete("Does nothing", true)]
        public new string ImageKey => null;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), Obsolete("Does nothing", true)]
        public new ImageList ImageList => null;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), Obsolete("Does nothing", true)]
        public new ContentAlignment ImageAlign => ContentAlignment.MiddleCenter;

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden), Bindable(false), Obsolete("Does nothing", true)]
        public new TextImageRelation TextImageRelation => TextImageRelation.Overlay;

        private Icon m_icon;
        [Category("Appearance"), Description("The icon to display on the icon")]
        public Icon Icon
        {
            get => m_icon;
            set => SetIcon(value);
        }

        private bool m_showicononly = false;
        [Category("Appearance"), Description("Hides the label and displays icon. Also displays icon when no text is set"), DefaultValue(false)]
        public bool ShowIconOnly
        {
            get => m_showicononly;
            set { m_showicononly = value; UpdateStyles(); }
        }

        public IconButton()
        {
            FlatStyle = FlatStyle.System;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cParams = base.CreateParams;
                if (ShowIconOnly)
                    cParams.Style |= BS_ICON;
                return cParams;
            }
        }

        private void SetIcon(Icon icon)
        {
            m_icon = icon;

            if (icon == null)
                return;

            SendMessage(Handle, BM_SETIMAGE, 1, (int)icon.Handle);
        }
    }
}
