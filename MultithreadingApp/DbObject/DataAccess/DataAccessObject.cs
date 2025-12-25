using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingApp.DbObject.DataAccess
{
    internal class DataAccessObject
    {
        /// <summary>
        /// Populates the user data grid with records retrieved from the database.
        /// </summary>
        /// <remarks>This method retrieves all user records from the database and updates the data source
        /// of the user data grid. The update is performed on the UI thread to ensure thread safety. This method should
        /// be called when the displayed user data needs to be refreshed.</remarks>
        internal DataTable FillGrid()
        {
            try
            {
                var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Gajender Singh\source\repos\MultithreadingApp\MultithreadingApp\DbObject\MultiThread.mdf"";Integrated Security=True";
                var query = "SELECT * FROM [User]";

                using (var connection = new SqlConnection(connectionString))
                using (var adapter = new SqlDataAdapter(query, connection))
                {
                    var dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    return dataTable;
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                throw new ApplicationException("An error occurred while retrieving user data.", ex);
            }
        }
    }
}
