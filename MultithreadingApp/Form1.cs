using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MultithreadingApp
{
    public partial class Form1 : Form
    {
        // Cancellation token source to manage task cancellation
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        BusinessAndFillControls businessAndFillControls = new BusinessAndFillControls();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        ///  Start button click event handler to initiate the background task
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void button1_Click(object sender, EventArgs e)
        {
            tokenSource = new CancellationTokenSource();
            writelabel("Its start");
            await Task.Run(() =>
            {
                AddSubTask();
            }, tokenSource.Token).ConfigureAwait(false);
        }
        /// <summary>
        /// Background Task method that performs work and checks for cancellation
        /// </summary>
        private void AddSubTask()
        {
            for (int i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                if (tokenSource.IsCancellationRequested)
                {
                    writelabel($"Its cancelled on {i.ToString()}");
                    return;
                }
                writelabel($"Its executed for {i.ToString()}");
            }

        }
        /// <summary>
        /// Sets the text of the label control to the specified string in a thread-safe manner.
        /// </summary>
        /// <remarks>This method ensures that the label's text is updated on the UI thread. Use this
        /// method when updating the label from a background thread to avoid cross-thread operation
        /// exceptions.</remarks>
        /// <param name="s">The text to display in the label control. Can be null or empty to clear the label.</param>
        private void writelabel(string s)
        {
            lblStatus.Invoke(() =>
            {
                lblStatus.Text = s;
            });
        }


        /// <summary>
        /// Handles the Click event of the Get Data button by asynchronously loading data into the grid.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Get Data button.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private async void btnGetData_Click(object sender, EventArgs e)
        {
            await Task.Run(() =>
            {
                businessAndFillControls.FillGrid(dgvUser);
            }).ConfigureAwait(false);
        }
        /// <summary>
        /// Handles the Click event of the Cancel button to request cancellation of the current operation.
        /// </summary>
        /// <remarks>This method signals cancellation by invoking the Cancel method on the associated
        /// CancellationTokenSource. Any ongoing operations that observe the corresponding cancellation token may
        /// respond by terminating early.</remarks>
        /// <param name="sender">The source of the event, typically the Cancel button.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private void btnStop_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
            lblStatus.Text = string.Empty;
            dgvUser.DataSource = null;
        }
    }
}
