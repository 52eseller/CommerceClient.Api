using System.Collections.Generic;
using CommerceClient.Api.Model;
using CommerceClient.Api.Model.Misc;
using CommerceClient.Api.Model.RequestModels;
using CommerceClient.Api.Model.RequestModels.Basket;
using CommerceClient.Api.Model.ResponseModels;
using RestSharp;

namespace CommerceClient.Api.Online
{
    public static class BasketExtensions
    {
        /// <summary>
        /// Creates a new basket.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static BasketResponse CreateNewBasket(
            this Connection conn,
            ClientState state
        )
            => conn.Execute<DataResponse<BasketResponse>>(
                    conn.CreateRestRequestJson(
                        Method.POST,
                        "/services/v3/baskets"
                    ),
                    state,
                    Includes.Auth
                )
                .Response.Data;

        /// <summary>
        /// Gets all lines for the specified basket.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="state"></param>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public static List<BasketLineResponse> GetBasketLines(
            this Connection conn,
            IClientState state,
            int basketId
        )
        {
            var restRequest = conn.CreateRestRequestJson(
                    Method.GET,
                    "/services/v3/baskets/{basketId}/lines"
                )
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                )
                .AddParameter(
                    "include",
                    "description",
                    ParameterType.QueryString
                );


            var (_, response) = conn.Execute<DataItemsResponse<BasketLineResponse>>(
                restRequest,
                state,
                Includes.Auth
            );

            return response.Data.Items;
        }

        /// <summary>
        /// Adds one or more items to basket.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="state"></param>
        /// <param name="basketId"></param>
        /// <param name="items"></param>
        /// <returns></returns>
        public static List<ValidationMessageResponse> AddToBasket(
            this Connection conn,
            ClientState state,
            int basketId,
            List<BasketLineRequestBody> items
        ) =>
            conn.Execute<DataItemsResponse<ValidationMessageResponse>>(
                    items.CreateRestRequestJson(
                            Method.POST,
                            "/services/v3/baskets/{basketId}/lines"
                        )
                        .AddParameter(
                            "basketId",
                            basketId,
                            ParameterType.UrlSegment
                        ),
                    state,
                    Includes.Auth
                )
                .Response.Data?.Items;

        /// <summary>
        /// Removes a line from basket by its id.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="state"></param>
        /// <param name="basketId"></param>
        /// <param name="basketLineId"></param>
        public static void DeleteBasketLine(
            this Connection conn,
            ClientState state,
            int basketId,
            int basketLineId
        )
        {
            conn.Execute<object>(
                conn.CreateRestRequestJson(
                        Method.DELETE,
                        "/services/v3/baskets/{basketId}/lines/{lineId}"
                    )
                    .AddParameter(
                        "basketId",
                        basketId,
                        ParameterType.UrlSegment
                    )
                    .AddParameter(
                        "lineId",
                        basketLineId,
                        ParameterType.UrlSegment
                    ),
                state,
                Includes.Auth
            );
        }

        /// <summary>
        /// Gets detailed information on a specific basket.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="state"></param>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public static BasketResponse GetBasket(
            this Connection conn,
            IClientState state,
            int basketId
        )
        {
            var restRequest = conn.CreateRestRequestJson(
                    Method.GET,
                    "/services/v3/baskets/{basketId}"
                )
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                )
                .AddParameter(
                    "include",
                    "description",
                    ParameterType.QueryString
                );


            var (_, response) = conn.Execute<DataResponse<BasketResponse>>(
                restRequest,
                state,
                Includes.Auth
            );

            return response.Data;
        }

        /// <summary>
        /// Gets the state of the basket, i.e. properties, that may or should affect the client state. 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="state"></param>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public static (List<HeaderSetMessage> HeaderSetMessages, Context BasketResponse) GetBasketState(
            this Connection conn,
            IClientState state,
            int basketId
        )
        {
            var restRequest = conn.CreateRestRequestJson(
                    Method.GET,
                    "/services/v3/baskets/{basketId}/state"
                )
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                )
                .AddParameter(
                    "include",
                    "description",
                    ParameterType.QueryString
                );


            var (headerSetMessages, response) = conn.Execute<DataResponse<Context>>(
                restRequest,
                state,
                Includes.Auth
            );

            return (headerSetMessages, response.Data);
        }

        /// <summary>
        /// Gets status of the basket, expressed as a series of requisites, each composed of an action needed to be completed,
        /// an optional reference to the completion item, plus any (optional) requirements / actions that needs to complete
        /// in order to mark this action as completed.
        /// The action / requirement model depends on you to have an understanding how to fulfill each requirement.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="state"></param>
        /// <param name="basketId"></param>
        /// <returns></returns>
        public static DataItemsResponseBody<BasketRequisiteResponse> GetBasketStatus(
            this Connection conn,
            IClientState state,
            int basketId
        )
        {
            var restRequest = conn.CreateRestRequestJson(
                    Method.GET,
                    "/services/v3/baskets/{basketId}/status"
                )
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                );


            var (_, response) = conn.Execute<DataItemsResponse<BasketRequisiteResponse>>(
                restRequest,
                state,
                Includes.Auth
            );

            return response.Data;
        }

        /// <summary>
        /// Gets a list of your available baskets.
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public static List<BasketResponse> GetBaskets(this Connection conn, IClientState state)
        {
            var restRequest = new RestRequest("/services/v3/baskets")
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };

            restRequest.AddParameter(
                "include",
                "description",
                ParameterType.QueryString
            );


            var (_, response) = conn.Execute<DataItemsResponse<BasketResponse>>(
                restRequest,
                state,
                Includes.Auth
            );

            return response.Data.Items;
        }

        public static NoContentResponse DeleteBasket(this Connection conn, IClientState state, int basketId)
        {
#pragma warning disable CA1305 // Specify IFormatProvider
            var restRequest = new RestRequest(string.Format("{0}/{1}", "/services/v3/baskets", basketId))
#pragma warning restore CA1305 // Specify IFormatProvider
            {
                Method = Method.DELETE
            };


            var (_, response) = conn.Execute<NoContentResponse>(
                restRequest,
                state,
                Includes.Auth
            );

            return response;
        }

        public static void UpdateSellTo(
            this Connection conn,
            IClientState state,
            int basketId,
            AddressSellToRequest sellToRequest
        )
        {
            var restRequest = sellToRequest.CreateRestRequestJson(
                    Method.PUT,
                    "/services/v3/baskets/{basketId}/sellto"
                )
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                );


            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }

        public static void UpdateShipTo(this Connection conn,
                                        IClientState state,
                                        int basketId,
                                        AddressShipToRequest shipToRequest)
        {
            var restRequest = shipToRequest.CreateRestRequestJson(
                    Method.PUT,
                    "/services/v3/baskets/{basketId}/shipto"
                )
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                );


            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }

        public static void UpdateBasketAnnotation(this Connection conn,
                                IClientState state,
                                int basketId,
                                 BasketAnnotationRequest annotation)
        {
            var restRequest = annotation.CreateRestRequestJson(
                    Method.PUT,
                    "/services/v3/baskets/{basketId}/annotation"
                )
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                );


            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }

        public static List<ValidationMessageResponse> MergeBasket(this Connection conn,
                         IClientState state,
                         int basketId,
                          BasketMergeRequest basketMergeRequest)
        {
            var restRequest = basketMergeRequest.CreateRestRequestJson(
                    Method.POST,
                    "/services/v3/baskets/{basketId}/merge"
                )
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                );


            var (_, response) = conn.Execute<List<ValidationMessageResponse>>(
                restRequest,
                state,
                Includes.Auth
            );
            return response;
        }
        public static void DeleteAllBasketUserValue(this Connection conn,
                         IClientState state,
                         int basketId, string uservaluekey)
        {
            var restRequest =new RestRequest("/services/v3/baskets/{basketId}/uservalues/{uservaluekey}",Method.DELETE)
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                ).AddParameter(
                    "uservaluekey",
                    uservaluekey,
                    ParameterType.UrlSegment
                );


            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }

        public static void CheckoutBasket(this Connection conn,
                 IClientState state,
                 int basketId)
        {
            var restRequest = new RestRequest("/services/v3/baskets/{basketId}/checkout", Method.POST)
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                );

            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }

        public static void TakeBasketOwnerShip(this Connection conn,
                 IClientState state,
                 int basketId)
        {
            var restRequest = new RestRequest("/services/v3/baskets/{basketId}/takeownership", Method.PUT)
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                );


            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }

        public static void RemoveCoupons(this Connection conn,
         IClientState state,
         int basketId)
        {
            var restRequest = new RestRequest("/services/v3/baskets/{basketId}/coupons", Method.DELETE)
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                );


            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }

        public static void RemoveCoupon(this Connection conn,
        IClientState state, int basketId, string couponId)
        {
            var restRequest = new RestRequest("/services/v3/baskets/{basketId}/coupons/{couponid}", Method.DELETE)
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                )
                .AddParameter(
                    "couponid",
                    couponId,
                    ParameterType.UrlSegment
                );


            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }

        public static void AddCoupons(this Connection conn,
                                      IClientState state,
                                     int basketId, BasketCouponRequestBody basketCouponRequestBody)
        {
            var restRequest = new RestRequest("/services/v3/baskets/{basketId}/coupons", Method.POST)
                .AddParameter(
                    "basketId",
                    basketId,
                    ParameterType.UrlSegment
                ).AddJsonBody(basketCouponRequestBody);


            conn.ExecuteNonQuery(
                restRequest,
                state,
                Includes.Auth
            );
        }
    }
    
}