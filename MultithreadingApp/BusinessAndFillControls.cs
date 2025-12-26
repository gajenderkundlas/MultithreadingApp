
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
        protected internal IDataAccessObject dataAccessObject;
        public BusinessAndFillControls() { 
            dataAccessObject = new DataAccessObject();
        }    
        internal async Task<IEnumerable<UserDto>> GetUserData(CancellationToken cancellationToken)
        {
            return await dataAccessObject.GetUserData(cancellationToken);
        }   
    }
}
