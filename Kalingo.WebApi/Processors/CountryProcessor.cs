﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kalingo.Games.Contract.Entity;
using Kalingo.Games.Contract.Entity.Voucher;
using Kalingo.WebApi.Domain.Data.Repository;
using Kalingo.WebApi.Domain.Services;

namespace Kalingo.WebApi.Processors
{
    public class CountryProcessor
    {
        private readonly CountryService _countryService;

        public CountryProcessor(CountryService countryService)
        {
            _countryService = countryService;
        }

        public async Task<IEnumerable<CountryResponse>> GetVouchers()
        {
            try
            {
                return await _countryService.GetCounties();
            }
            catch (Exception)
            {
                return new List<CountryResponse>();
            }
        }
    }
}