using System;
using System.Collections.Generic;
using CommerceClient.Api.Model;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class SalePersonExtension
    {
        public static DataResponse<CustomerForSalesPersonResponse> CustomersForCurrentSalesPerson(
            this Connection conn,
            IClientState state,
            string searchFor,
            int? page,
            int? pageSize
        )
        {

            var restRequest = conn.CreateRestRequestJson(
                Method.GET,
                "/services/v3/salespersons/current/customers"
            );

            if (searchFor.ToNullIfWhite() != null)
            {
                restRequest.AddParameter(
                    "search",
                    searchFor,
                    ParameterType.QueryString
                );
            }

            if (page != null)
            {
                restRequest.AddParameter(
                    "p",
                    page,
                    ParameterType.QueryString
                );
            }

            if (pageSize != null)
            {
                restRequest.AddParameter(
                    "rp",
                    pageSize,
                    ParameterType.QueryString
                );
            }


            var (_, response) = conn.Execute<DataResponse<CustomerForSalesPersonResponse>>(
                restRequest,
                state,
                Includes.Auth
            );

            return response;
        }
    }
}
