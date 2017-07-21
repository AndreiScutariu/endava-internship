using System;
using System.Threading;
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

                var x = int.Parse(leftOperand.Text);
                var y = int.Parse(rightOperand.Text);

                var result = ComputeResult(x, y);

                Log("result: " + result);
            }
            catch (FormatException ex)
            {
                Log("exception: " + ex.GetType());
            }
            catch (DivideByZeroException ex)
            {
                Log("exception: " + ex.GetType());
            }
            finally
            {
                Log("end. clear the inputs.");

                leftOperand.Text = string.Empty;
                rightOperand.Text = string.Empty;
            }
        }

        private static int ComputeResult(int x, int y)
        {
            //Do something ...
            Thread.Sleep(TimeSpan.FromSeconds(5));

            return x / y;
        }

        private void Log(string text)
        {
            logsBox.AppendText(DateTime.Now.ToLongTimeString() + ": " + text + Environment.NewLine);
        }
    }
}