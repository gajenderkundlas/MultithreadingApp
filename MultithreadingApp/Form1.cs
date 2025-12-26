using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace MultithreadingApp
{
    public partial class frmMultiThread : Form
    {
        // Cancellation token source to manage task cancellation
        CancellationTokenSource tokenSource = new CancellationTokenSource();
        BusinessAndFillControls businessAndFillControls = new BusinessAndFillControls();
        public frmMultiThread()
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
            tokenSource?.Dispose();
            tokenSource = new CancellationTokenSource();
            WriteLabel("Its start");
            try
            {
                await AddSubTaskAsync();
                WriteLabel("Completed");
            }
            catch (OperationCanceledException ex)
            {
                WriteLabel(ex.Message);
            }
            catch (Exception ex) {
                WriteLabel($"Error: {ex.Message}");
            }
          
        }
        /// <summary>
        /// Background Task method that performs work and checks for cancellation
        /// </summary>
        private async Task AddSubTaskAsync()
        {
            for (int i = 0; i < 1000; i++)
            {
                if (tokenSource.IsCancellationRequested) throw new Exception($"Cancelled on {i.ToString()}");
                await Task.Delay(1000);
                WriteLabel($"Count: {i + 1}");  
               
            }

        }
        /// <summary>
        /// Sets the text of the label control to the specified string in a thread-safe manner.
        /// </summary>
        /// <remarks>This method ensures that the label's text is updated on the UI thread. Use this
        /// method when updating the label from a background thread to avoid cross-thread operation
        /// exceptions.</remarks>
        /// <param name="s">The text to display in the label control. Can be null or empty to clear the label.</param>
        private void WriteLabel(string s)
        {
            if (lblStatus.InvokeRequired)
            {
                lblStatus.Invoke(() =>
                {
                    lblStatus.Text = s;
                });
            }
            else {
                lblStatus.Text = s;
            }
        }


        /// <summary>
        /// Handles the Click event of the Get Data button by asynchronously loading data into the grid.
        /// </summary>
        /// <param name="sender">The source of the event, typically the Get Data button.</param>
        /// <param name="e">An EventArgs object that contains the event data.</param>
        private async void btnGetData_Click(object sender, EventArgs e)
        {

            IEnumerable<UserDto> userData = await businessAndFillControls.GetUserData(tokenSource.Token);
            if (dgvUser.InvokeRequired)
            {
                this.Invoke(() =>
                {
                    dgvUser.DataSource = userData.ToList();
                });
            }
            else
            {
                dgvUser.DataSource = userData.ToList();
            }
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
            tokenSource?.Cancel();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            tokenSource?.Cancel();
            lblStatus.Text = string.Empty;
            dgvUser.DataSource = new List<UserDto>();
        }
    }
}
