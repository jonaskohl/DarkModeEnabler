using System;
using System.Text;
using System.Windows.Forms;

namespace DarkModeEnabler
{
    public partial class LogForm : Form
    {
        StringBuilder buffer = new StringBuilder();

        public LogForm()
        {
            InitializeComponent();
        }

        public void LogMessage(string message, string suffix)
        {
            buffer.Append(message + suffix);
            Flush();
        }

        public void LogMessageNoFlush(string message, string suffix)
        {
            buffer.Append(message + suffix);
            if (buffer.Length > short.MaxValue)
            {
                Flush();
            }
        }

        public void Flush()
        {
            logTextBox.AppendText(buffer.ToString());
            logTextBox.SelectionStart = logTextBox.TextLength;
            logTextBox.SelectionLength = 0;
            logTextBox.ScrollToCaret();
            buffer.Clear();
        }

        public void LogMessage(string format, params object[] args)
        {
            LogMessage(string.Format(format, args), Environment.NewLine);
            Flush();
        }

        public void LogMessageNoFlush(string format, params object[] args)
        {
            LogMessageNoFlush(string.Format(format, args), Environment.NewLine);
        }

        public void LogMessageNoFlush(string message)
        {
            LogMessage(message, Environment.NewLine);
        }

        public void LogMessage(string message)
        {
            LogMessage(message, Environment.NewLine);
            Flush();
        }

        private void LogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                e.Cancel = true;
        }
    }
}
