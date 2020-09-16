using System;
using System.Collections.Generic;
using System.Text;
using CommerceClient.Api.Model;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class CurrencyExtension
    {
        public static DataItemsResponse<Currency> GetCurrencies(
            this Connection conn,
            IClientState state )
        {
            var restRequest = conn.CreateRestRequestJson(
                Method.GET,
                "/services/v3/currencies"
            );

            var (_, response) = conn.Execute<DataItemsResponse<Currency>>(
                restRequest,
                state,
                Includes.Ticket
            );

            return response;
        }
    }
}
