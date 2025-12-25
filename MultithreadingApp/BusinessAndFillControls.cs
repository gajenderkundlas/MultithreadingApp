using MultithreadingApp.DbObject.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingApp
{
    internal class BusinessAndFillControls
    {
        /// <summary>
        /// Asynchronously populates the specified DataGridView with data retrieved from the data source.
        /// </summary>
        /// <remarks>This method must be called from a context where the DataGridView control is
        /// accessible. The data population is performed on the UI thread using the control's Invoke method to ensure
        /// thread safety.</remarks>
        /// <param name="dataGridView">The DataGridView control to be populated with data. Cannot be null.</param>
        internal async void FillGrid(DataGridView dataGridView)
        {
            DataAccessObject dataAccessObject=new DataAccessObject();
            DataTable dataTable=dataAccessObject.FillGrid();
            dataGridView.Invoke(() =>
            {
                dataGridView.DataSource = dataTable;
            }); 
        }   
    }
}
