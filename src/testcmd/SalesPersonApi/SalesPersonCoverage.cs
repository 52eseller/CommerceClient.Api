using System;
using System.Collections.Generic;
using System.Text;
using CommerceClient.Api.Online;
using JetBrains.Annotations;

namespace CommerceClient.Api.Coverage.SalesPersonApi
{
    public class SalesPersonCoverage : BaseHandler
    {

        public void GetCustomersForCurrentSalesPerson([CanBeNull] string searchFor = null, int? page = null, int? pageSize = null)
        {
            _connection.CustomersForCurrentSalesPerson(_clientState,searchFor,page,pageSize);
        }
    }
}
