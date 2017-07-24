using System;
using System.Threading;
using System.Windows.Forms;

namespace EndavaInternship.WindowsFormApp
{
    internal delegate void SetTextCallback(string text);

    public partial class EndavaInternshipForm : Form
    {
        private readonly FileUserDetailsProcessor _fileProcessor;

        public EndavaInternshipForm()
        {
            InitializeComponent();

            _fileProcessor = new FileUserDetailsProcessor(Log);
        }

        private void SubmitButtonOnClick(object sender, EventArgs e)
        {
            Log("start");
        }

        private void Log(string text)
        {
            var logText = DateTime.Now.ToLongTimeString() + ": " + text +
                          $"[T_ID: {Thread.CurrentThread.ManagedThreadId}]" + Environment.NewLine;

            logsBox.AppendText(logText);
        }
    }
}