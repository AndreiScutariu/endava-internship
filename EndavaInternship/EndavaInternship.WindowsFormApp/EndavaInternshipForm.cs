using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndavaInternship.WindowsFormApp
{
    internal delegate void SetTextCallback(string text);

    public partial class EndavaInternshipForm : Form
    {
        private readonly FileUserDetailsProcessor _fileProcessor;
        private readonly CancellationTokenSource _cancellationTokenSource;

        public EndavaInternshipForm()
        {
            InitializeComponent();

            _cancellationTokenSource = new CancellationTokenSource();
            _fileProcessor = new FileUserDetailsProcessor(Log, _cancellationTokenSource);
        }

        private async void SubmitButtonOnClick(object sender, EventArgs e)
        {
            Log("start...");
            var path = directoryPathInput.Text;

            try
            {
                submitButton.Enabled = false;

                await Task.WhenAll(_fileProcessor.Proces(path));

                Log("end...");
            }
            catch (Exception ex)
            {
                Log("Exception: " + ex.GetType());
            }
            finally
            {
                Log("finally...");
                submitButton.Enabled = true;
                directoryPathInput.Text = string.Empty;
            }
        }

        private void Log(string text)
        {
            var logText = DateTime.Now.ToLongTimeString() + ": " + text +
                          $"[T_ID: {Thread.CurrentThread.ManagedThreadId}]" + Environment.NewLine;

            logsBox.AppendText(logText);
        }

        private void stopOperation_Click(object sender, EventArgs e)
        {
            _cancellationTokenSource.Cancel();
        }

        private void countButton_Click(object sender, EventArgs e)
        {
            var path = directoryPathInput.Text;

            _fileProcessor.Count(path);
        }
    }
}