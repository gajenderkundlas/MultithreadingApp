using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingApp
{
    internal class DataAccessObject: IDataAccessObject
    {
        /// <summary>
        /// Asynchronously retrieves user data from the database.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token that can be used to cancel the asynchronous operation.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of user data
        /// transfer objects. Returns an empty collection if the operation is canceled.</returns>
        /// <exception cref="ApplicationException">Thrown when an error occurs while retrieving user data from the database.</exception>
       public async Task<IEnumerable<UserDto>> GetUserData(CancellationToken cancellationToken)
        {
            try
            {
                DataTable dataTable = new();
                using SqlCommand sqlCommand = new();
                var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Gajender Singh\source\repos\MultithreadingApp\MultithreadingApp\DbObject\MultiThread.mdf"";Integrated Security=True";
                sqlCommand.CommandText = "SELECT * FROM [User]";
                using SqlConnection sqlConnection = new(connectionString);
                sqlCommand.Connection = sqlConnection;
                if (sqlCommand.Connection.State == ConnectionState.Closed) { 
                  await sqlCommand.Connection.OpenAsync(cancellationToken).ConfigureAwait(false);
                }
                await using var reader= await sqlCommand.ExecuteReaderAsync(cancellationToken).ConfigureAwait(false);
              
                var ordFirstName = reader.GetOrdinal("FirstName");
                var ordLastName = reader.GetOrdinal("LastName");
                var ordEmail = reader.GetOrdinal("Email");
                var ordUserType = reader.GetOrdinal("UserType");
                var ordCreatedOn = reader.GetOrdinal("CreatedOn");
                List<UserDto> userList = new();
                while (await reader.ReadAsync(cancellationToken).ConfigureAwait(false)) { 
                    UserDto userDto = new() { 
                       FirstName= reader.IsDBNull(ordUserType) ? string.Empty : reader.GetString(ordFirstName),
                       LastName= reader.IsDBNull(ordUserType) ? string.Empty : reader.GetString(ordLastName),   
                       Email= reader.IsDBNull(ordUserType) ? string.Empty : reader.GetString(ordEmail),
                       UserType=reader.IsDBNull(ordUserType)?string.Empty:reader.GetString(ordUserType),
                       CreatedOn=!reader.IsDBNull(ordCreatedOn)? reader.GetDateTime(ordCreatedOn) : DateTime.MinValue,
                    };
                    userList.Add(userDto);  
                }
                return userList;    
            }
            catch (OperationCanceledException)
            {
                // Handle cancellation
                return Enumerable.Empty<UserDto>();
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log the error)
                throw new ApplicationException("An error occurred while retrieving user data.", ex);
            }
        }
    }
}
