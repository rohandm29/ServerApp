using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.WebApi.Domain.Data.Repository;

namespace Kalingo.WebApi.Domain.Services
{
    public class CountryService
    {
        private readonly CountryRepository _countryRepository;
        private static IEnumerable<CountryResponse> _countryResponses;

        public CountryService(CountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public async Task<IEnumerable<CountryResponse>> GetCounties()
        {
            return _countryResponses ?? (_countryResponses = await _countryRepository.GetCountries());
        }

        public static int GetCountryId(string name)
        {
            return _countryResponses.First(x => x.Name == name).Id;
        }
    }
}
