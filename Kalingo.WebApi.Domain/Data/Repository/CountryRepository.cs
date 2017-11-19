using System.Collections.Generic;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.WebApi.Domain.Data.DatabaseQuery;

namespace Kalingo.WebApi.Domain.Data.Repository
{
    public class CountryRepository
    {
        private readonly GetCountriesQuery _getCountriesQuery;

        public CountryRepository(GetCountriesQuery getCountriesQuery)
        {
            _getCountriesQuery = getCountriesQuery;
        }

        public async Task<IEnumerable<CountryResponse>> GetCountries()
        {
            return await _getCountriesQuery.Execute();
        }
    }
}