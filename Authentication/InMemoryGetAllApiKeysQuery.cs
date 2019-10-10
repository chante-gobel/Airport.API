using Airport.API.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.API.Authentication
{
    public class InMemoryGetAllApiKeysQuery : IGetAllApiKeysQuery
    {
        public Task<IReadOnlyDictionary<string, ApiKey>> ExecuteAsync()
        {
            var apiKeys = new List<ApiKey>
        {
            new ApiKey(1, "Authenticated User", "FA872702-6396-45DC-89F0-FC1BE900591B", new DateTime(2019, 06, 01),
                    new List<string>
                    {
                        Roles.ThirdParty
                    })
        };

            IReadOnlyDictionary<string, ApiKey> readonlyDictionary = apiKeys.ToDictionary(x => x.Key, x => x);
            return Task.FromResult(readonlyDictionary);
        }
    }
}
