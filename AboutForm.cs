using System;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Windows.Forms;

namespace DarkModeEnabler
{
    partial class AboutForm : Form
    {
        public AboutForm()
        {
            var dt = DateTime.ParseExact(Properties.Resources.builddate, "yyyyMMddhhmmss", CultureInfo.CurrentCulture);
            var builddate = string.Format(dt.ToString(@"MMMM d\{\0\}, yyyy"), (dt.Day % 10 == 1 && dt.Day != 11) ? "st"
                                                                           : (dt.Day % 10 == 2 && dt.Day != 12) ? "nd"
                                                                           : (dt.Day % 10 == 3 && dt.Day != 13) ? "rd"
                                                                           : "th");

            InitializeComponent();
            Text = string.Format("About {0}", AssemblyTitle);
            labelProductName.Text = AssemblyProduct;
            labelVersion.Text = string.Format("Version {0}", AssemblyVersion);
            labelCopyright.Text = AssemblyCopyright;
            labelCompanyName.Text = AssemblyCompany;
            labelBuildDate.Text = string.Format("Compiled {0}", builddate);
            textBoxDescription.Text = AssemblyDescription;

            aboutIcon.Image = MainForm.GetSystemIcon(MainForm.SHSTOCKICONID.SIID_INFO, IconSize.Unspecified).ToBitmap();
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void websiteLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            websiteLinkLabel.LinkVisited = true;
            Process.Start("https://jonaskohl.de/");
        }

        private void licenseButton_Click(object sender, EventArgs e)
        {
            using (var f = new LicenseForm())
                f.ShowDialog(this);
        }
    }
}
