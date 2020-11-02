using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DarkModeEnabler
{
    public partial class MainForm : Form
    {
        const int DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 = 19;
        const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
        const int MAX_PATH = 256;

        [DllImport("Shell32.dll", SetLastError = false)]
        static extern int SHGetStockIconInfo(SHSTOCKICONID siid, SHGSI uFlags, ref SHSTOCKICONINFO psii);

        [DllImport("dwmapi.dll")]
        static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

        [DllImport("user32.dll")]
        static extern bool SetWindowCompositionAttribute(IntPtr hwnd, ref WindowCompositionAttributeData data);

        [DllImport("uxtheme.dll", EntryPoint = "#133")]
        static extern bool AllowDarkModeForWindow(IntPtr hWnd, bool allow);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        public enum SHSTOCKICONID : uint
        {
            SIID_DOCNOASSOC = 0,
            SIID_DOCASSOC = 1,
            SIID_APPLICATION = 2,
            SIID_FOLDER = 3,
            SIID_FOLDEROPEN = 4,
            SIID_DRIVE525 = 5,
            SIID_DRIVE35 = 6,
            SIID_DRIVEREMOVE = 7,
            SIID_DRIVEFIXED = 8,
            SIID_DRIVENET = 9,
            SIID_DRIVENETDISABLED = 10,
            SIID_DRIVECD = 11,
            SIID_DRIVERAM = 12,
            SIID_WORLD = 13,
            SIID_SERVER = 15,
            SIID_PRINTER = 16,
            SIID_MYNETWORK = 17,
            SIID_FIND = 22,
            SIID_HELP = 23,
            SIID_SHARE = 28,
            SIID_LINK = 29,
            SIID_SLOWFILE = 30,
            SIID_RECYCLER = 31,
            SIID_RECYCLERFULL = 32,
            SIID_MEDIACDAUDIO = 40,
            SIID_LOCK = 47,
            SIID_AUTOLIST = 49,
            SIID_PRINTERNET = 50,
            SIID_SERVERSHARE = 51,
            SIID_PRINTERFAX = 52,
            SIID_PRINTERFAXNET = 53,
            SIID_PRINTERFILE = 54,
            SIID_STACK = 55,
            SIID_MEDIASVCD = 56,
            SIID_STUFFEDFOLDER = 57,
            SIID_DRIVEUNKNOWN = 58,
            SIID_DRIVEDVD = 59,
            SIID_MEDIADVD = 60,
            SIID_MEDIADVDRAM = 61,
            SIID_MEDIADVDRW = 62,
            SIID_MEDIADVDR = 63,
            SIID_MEDIADVDROM = 64,
            SIID_MEDIACDAUDIOPLUS = 65,
            SIID_MEDIACDRW = 66,
            SIID_MEDIACDR = 67,
            SIID_MEDIACDBURN = 68,
            SIID_MEDIABLANKCD = 69,
            SIID_MEDIACDROM = 70,
            SIID_AUDIOFILES = 71,
            SIID_IMAGEFILES = 72,
            SIID_VIDEOFILES = 73,
            SIID_MIXEDFILES = 74,
            SIID_FOLDERBACK = 75,
            SIID_FOLDERFRONT = 76,
            SIID_SHIELD = 77,
            SIID_WARNING = 78,
            SIID_INFO = 79,
            SIID_ERROR = 80,
            SIID_KEY = 81,
            SIID_SOFTWARE = 82,
            SIID_RENAME = 83,
            SIID_DELETE = 84,
            SIID_MEDIAAUDIODVD = 85,
            SIID_MEDIAMOVIEDVD = 86,
            SIID_MEDIAENHANCEDCD = 87,
            SIID_MEDIAENHANCEDDVD = 88,
            SIID_MEDIAHDDVD = 89,
            SIID_MEDIABLURAY = 90,
            SIID_MEDIAVCD = 91,
            SIID_MEDIADVDPLUSR = 92,
            SIID_MEDIADVDPLUSRW = 93,
            SIID_DESKTOPPC = 94,
            SIID_MOBILEPC = 95,
            SIID_USERS = 96,
            SIID_MEDIASMARTMEDIA = 97,
            SIID_MEDIACOMPACTFLASH = 98,
            SIID_DEVICECELLPHONE = 99,
            SIID_DEVICECAMERA = 100,
            SIID_DEVICEVIDEOCAMERA = 101,
            SIID_DEVICEAUDIOPLAYER = 102,
            SIID_NETWORKCONNECT = 103,
            SIID_INTERNET = 104,
            SIID_ZIPFILE = 105,
            SIID_SETTINGS = 106,
            SIID_DRIVEHDDVD = 132,
            SIID_DRIVEBD = 133,
            SIID_MEDIAHDDVDROM = 134,
            SIID_MEDIAHDDVDR = 135,
            SIID_MEDIAHDDVDRAM = 136,
            SIID_MEDIABDROM = 137,
            SIID_MEDIABDR = 138,
            SIID_MEDIABDRE = 139,
            SIID_CLUSTEREDDRIVE = 140,
            SIID_MAX_ICONS = 175
        }

        [Flags]
        public enum SHGSI : uint
        {
            SHGSI_ICONLOCATION = 0,
            SHGSI_ICON = 0x000000100,
            SHGSI_SYSICONINDEX = 0x000004000,
            SHGSI_LINKOVERLAY = 0x000008000,
            SHGSI_SELECTED = 0x000010000,
            SHGSI_LARGEICON = 0x000000000,
            SHGSI_SMALLICON = 0x000000001,
            SHGSI_SHELLICONSIZE = 0x000000004
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct SHSTOCKICONINFO
        {
            public uint cbSize;
            public IntPtr hIcon;
            public long iSysIconIndex;
            public long iIcon;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szPath;
        }

        [StructLayout(LayoutKind.Sequential)]
        struct WindowCompositionAttributeData
        {
            public WindowCompositionAttribute Attribute;
            public IntPtr Data;
            public int SizeOfData;
        }

        enum WindowCompositionAttribute
        {
            WCA_ACCENT_POLICY = 19,
            WCA_USEDARKMODECOLORS = 26
        }

        IDictionary<IntPtr, string> queryResult;
        LogForm logForm;

        public static Icon GetSystemIcon(SHSTOCKICONID icon, IconSize size = IconSize.Unspecified)
        {
            var info = new SHSTOCKICONINFO();
            info.cbSize = (uint)unchecked(Marshal.SizeOf(info));
            var flags = SHGSI.SHGSI_ICON;
            if (size == IconSize.Small)
                flags |= SHGSI.SHGSI_SMALLICON;
            else if (size == IconSize.Large)
                flags |= SHGSI.SHGSI_LARGEICON;

            var r = SHGetStockIconInfo(icon, flags, ref info);
            if (r != 0)
                return null;

            return Icon.FromHandle(info.hIcon);
        }

        public MainForm()
        {
            InitializeComponent();
            logForm = new LogForm();
            Load += MainForm_Load;
            Shown += MainForm_Shown;

            Icon = GetSystemIcon(SHSTOCKICONID.SIID_DESKTOPPC, IconSize.Small);

            windowsListBox.SelectedIndexChanged += windowsListBox_SelectedIndexChanged;

            aboutButton.Icon = GetSystemIcon(SHSTOCKICONID.SIID_INFO, IconSize.Small);
            aboutButton.ShowIconOnly = true;
        }

        private void windowsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setButton.Enabled = unsetButton.Enabled =
                windowsListBox.SelectedIndex >= 0;
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Shown -= MainForm_Shown;

            logForm.Show(this);
            logForm.Left = Width + Left;
            logForm.Top = Top;
            Focus();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version.Major < 10)
            {
                if (MessageBox.Show("You are running a version of Windows prior to Windows 10. Immersive dark mode is not available for older versions of Windows and using this application may result in unexpected behavior. Click \"OK\" to continue anyway, click \"Cancel\" to exit.", Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) != DialogResult.OK)
                    Close();
            }

            QueryAndPopulate();
        }

        private void queryButton_Click(object sender, EventArgs e)
        {
            QueryAndPopulate();
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            SetDark(true);
        }

        private void unsetButton_Click(object sender, EventArgs e)
        {
            SetDark(false);
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            using (var a = new AboutForm())
                a.ShowDialog(this);
        }

        private void toggleLogButton_Click(object sender, EventArgs e)
        {
            if (logForm.Visible)
            {
                logForm.Hide();
                toggleLogButton.Text = "Show &log";
            }
            else
            {
                logForm.Show(this);
                logForm.Left = Width + Left;
                logForm.Top = Top;
                Focus();
                toggleLogButton.Text = "Hide &log";
            }
        }

        public IDictionary<IntPtr, string> GetOpenWindows()
        {
            IntPtr shellWindow = GetShellWindow();
            Dictionary<IntPtr, string> windows = new Dictionary<IntPtr, string>();

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
#if DEBUG
                logForm.LogMessageNoFlush("Found window 0x{0} (LPARAM = {1})", hWnd.ToInt64().ToString("X16"), lParam.ToString("X8"));
#endif
                if (hWnd == shellWindow) return true;
                if (!IsWindowVisible(hWnd)) return true;

                int length = GetWindowTextLength(hWnd);
                if (length == 0) return true;

                StringBuilder builder = new StringBuilder(length);
                GetWindowText(hWnd, builder, length + 1);

                windows[hWnd] = builder.ToString();
                return true;

            }, 0);

            return windows;
        }

        private void QueryAndPopulate()
        {
            logForm.LogMessage("Querying windows...");
            queryResult = GetOpenWindows();
            PopulateList();
        }

        private void PopulateList()
        {
            logForm.LogMessage("Populating list...");
            windowsListBox.BeginUpdate();
            windowsListBox.Items.Clear();
            foreach (var p in queryResult)
                windowsListBox.Items.Add(p.Value);
            windowsListBox.EndUpdate();
            setButton.Enabled = unsetButton.Enabled =
                windowsListBox.SelectedIndex >= 0;
        }

        private void SetDark(bool v)
        {
            if (windowsListBox.SelectedIndex < 0)
            {
                logForm.LogMessage("No window selected, doing nothing");
                return;
            }

            var elem = queryResult.ElementAt(windowsListBox.SelectedIndex);
            var handle = elem.Key;

            logForm.LogMessage("Attempting to set dark mode for window 0x{0} ({1}) to {2}", handle.ToInt64().ToString("X16"), elem.Value, v);

            var res2 = false;
            var res3 = false;

            logForm.LogMessage("Trying method 1 (SetWindowCompositionAttribute)... ", "");
            var res1 = UseImmersiveDarkModeColors(handle, v);
            logForm.LogMessage(res1 ? "success" : "failure");

            if (!res1)
            {
                logForm.LogMessage("Trying method 2 (DwmSetWindowAttribute)... ", "");
                res2 = UseImmersiveDarkMode(handle, v);
                logForm.LogMessage(res2 ? "success" : "failure");
            }

            if (!res1 && !res2)
            {
                logForm.LogMessage("Trying method 3 (AllowDarkModeForWindow)... ", "");
                res3 = AllowDarkMode(handle, v);
                logForm.LogMessage(res3 ? "success" : "failure");
            }

            var status = (res1 || res2 || res3) ? "Success" : "Failure";
            logForm.LogMessage("Attempted to set dark mode for window 0x{0} ({1}) to {2}: {3}", handle.ToInt64().ToString("X16"), elem.Value, v, status);
            MessageBox.Show(status, "", MessageBoxButtons.OK, (res1 || res2 || res3) ? MessageBoxIcon.Information : MessageBoxIcon.Exclamation);
        }

        public static bool UseImmersiveDarkModeColors(IntPtr handle, bool dark)
        {
            var size = Marshal.SizeOf(typeof(int));
            IntPtr pBool = Marshal.AllocHGlobal(size);
            Marshal.WriteInt32(pBool, 0, dark ? 1 : 0);
            var data = new WindowCompositionAttributeData()
            {
                Attribute = WindowCompositionAttribute.WCA_USEDARKMODECOLORS,
                Data = pBool,
                SizeOfData = size
            };
            var res = SetWindowCompositionAttribute(handle, ref data);

            Marshal.FreeHGlobal(pBool);

            return res;
        }

        public bool UseImmersiveDarkMode(IntPtr handle, bool enabled)
        {
            if (IsWindows10OrGreater(17763))
            {

                var attribute = DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1;
                if (IsWindows10OrGreater(18985))
                {
                    logForm.LogMessage("[OS is build 18965 or newer, using DWMWA_USE_IMMERSIVE_DARK_MODE (" + DWMWA_USE_IMMERSIVE_DARK_MODE_BEFORE_20H1 + ")]", " ");

                    attribute = DWMWA_USE_IMMERSIVE_DARK_MODE;
                }
                else
                    logForm.LogMessage("[OS is build 17763 or newer, using DWMWA_USE_IMMERSIVE_DARK_MODE_20H1 (" + DWMWA_USE_IMMERSIVE_DARK_MODE + ")]", " ");

                int useImmersiveDarkMode = enabled ? 1 : 0;
                return DwmSetWindowAttribute(handle, attribute, ref useImmersiveDarkMode, sizeof(int)) == 0;
            }

            logForm.LogMessage("[Cannot set DWM Window attribute: OS version unsupported]", " ");

            return false;
        }

        public bool IsWindows10OrGreater(int build = -1)
        {
            return Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= build;
        }

        private bool AllowDarkMode(IntPtr handle, bool v)
        {
            return AllowDarkModeForWindow(handle, v);
        }
    }

    public enum IconSize
    {
        Unspecified,
        Small,
        Large
    }
}
