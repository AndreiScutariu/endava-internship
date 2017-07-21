using System;
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

                var result = x / y;

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
                Log("end");

                leftOperand.Text = string.Empty;
                rightOperand.Text = string.Empty;
            }
        }

        private void Log(string text)
        {
            logsBox.AppendText(DateTime.Now.ToLongTimeString() + ": " + text + Environment.NewLine);
        }
    }
}