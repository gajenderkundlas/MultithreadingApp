using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingApp
{
    public interface IDataAccessObject
    {
       Task<IEnumerable<UserDto>> GetUserData(CancellationToken cancellationToken);
    }
}
