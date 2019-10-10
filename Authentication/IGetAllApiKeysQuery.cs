using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airport.API.Authentication
{
    public interface IGetAllApiKeysQuery
    {
        Task<IReadOnlyDictionary<string, ApiKey>> ExecuteAsync();
    }
}
