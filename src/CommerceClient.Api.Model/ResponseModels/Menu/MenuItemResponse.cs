using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.ResponseModels.Menu
{
    public class MenuItemResponse<T> : ResponseBase where T : new()
    {
        public MenuItemResponse() => Data = new MenuItemsResponseBody<T>();

        /// <summary>
        /// Gets or sets the data portion of the response.
        /// </summary>
        public MenuItemsResponseBody<T> Data { get; set; }
    }
}
