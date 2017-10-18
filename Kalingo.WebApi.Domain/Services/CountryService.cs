using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kalingo.WebApi.Domain.Services
{
    public class CountryService
    {
        public static int GetCountry(string name)
        {
            switch (name)
            {
                case "UK": return 1;
                case "USA": return 2;
                case "India": return 3;
                case "Euro": return 4;
                case "Canada": return 5;
                default: return 1;
            }
        }
    }
}
