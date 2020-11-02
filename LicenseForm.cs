using System.Windows.Forms;

namespace DarkModeEnabler
{
    public partial class LicenseForm : Form
    {
        public LicenseForm()
        {
            InitializeComponent();

            licenseTextBox.Text = Properties.Resources.LICENSE;
            licenseTextBox.SelectionStart = 0;
            licenseTextBox.SelectionLength = 0;
        }
    }
}
