using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EndavaInternship.WindowsFormApp
{
    public partial class EndavaInternshipForm : Form
    {
        public EndavaInternshipForm()
        {
            InitializeComponent();
        }

        private void SubmitButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Log("start");

                submitButton.Enabled = false;

                var x = int.Parse(leftOperand.Text);
                var y = int.Parse(rightOperand.Text);

                var task = ComputeResult(x, y);

                task.ContinueWith(t =>
                        {
                            if (t.IsFaulted)
                            {
                                t.Exception?.Handle(ex =>
                                {
                                    Log($"ex in task {ex.Message}");
                                    return true;
                                });

                                return;
                            }

                            Log($"result {x} : {y}= " + t.Result);
                        })
                    .ContinueWith(t =>
                        {
                            Log("end. main thread is free now.");

                            submitButton.Enabled = true;
                            leftOperand.Text = string.Empty;
                            rightOperand.Text = string.Empty;
                        }, TaskScheduler.FromCurrentSynchronizationContext());
            }
            catch (FormatException ex)
            {
                Log("exception: " + ex.GetType());
            }
            catch (DivideByZeroException ex)
            {
                Log("exception: " + ex.GetType());
            }
            catch (AggregateException ex)
            {
                Log("exception: " + ex.GetType());
            }
            finally
            {
                Log("finally executed");
            }
        }

        private static Task<int> ComputeResult(int x, int y)
        {
            return Task.Factory.StartNew(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                return x/y;
            });
        }

        private void Log(string text)
        {
            logsBox.AppendText(DateTime.Now.ToLongTimeString() + ": " + text +
                               $" [thread_id: {Thread.CurrentThread.ManagedThreadId}]" + Environment.NewLine);
        }
    }
}