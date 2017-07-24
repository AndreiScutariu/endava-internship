﻿using System;
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

        private async void SubmitButtonOnClick(object sender, EventArgs e)
        {
            try
            {
                Log("start");

                submitButton.Enabled = false;

                var x = int.Parse(leftOperand.Text);
                var y = int.Parse(rightOperand.Text);

                var task = ComputeResultAsync(x, y);
                var result = await task;

                Log($"result {x} : {y}= " + result);

                Log("end. main thread is free now.");
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
                Log("finally executed");

                submitButton.Enabled = true;
                leftOperand.Text = string.Empty;
                rightOperand.Text = string.Empty;
            }
        }

        private Task<int> ComputeResultAsync(int x, int y)
        {
            return Task.Factory.StartNew(() =>
            {
                Log($"computing... ");

                Thread.Sleep(TimeSpan.FromSeconds(3));
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