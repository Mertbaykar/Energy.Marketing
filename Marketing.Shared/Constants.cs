﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Shared
{
    public class Constants
    {
        public const string RootUrl = "https://seffaflik.epias.com.tr";

        #region Partials
        private const string MarginalPricePartialUrl = "/transparency/service/market/smp";
        private const string PTFAndSMFPartialUrl = "/transparency/service/market/mcp-smp";
        private const string GIPAOFPartialUrl = "/transparency/service/market/intra-day-aof-average";
        private const string IDMIncomePartialUrl = "/transparency/service/market/intra-day-income";
        #endregion

        public const string MarginalPriceUrl = RootUrl + MarginalPricePartialUrl;
        public const string PTFAndSMFUrl = RootUrl + PTFAndSMFPartialUrl;
        public const string GIPAOFUrl = RootUrl + GIPAOFPartialUrl;
        public const string IDMIncome = RootUrl + IDMIncomePartialUrl;
    }
}
