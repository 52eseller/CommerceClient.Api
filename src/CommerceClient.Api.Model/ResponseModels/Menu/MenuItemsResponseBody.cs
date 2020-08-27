using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.ResponseModels.Menu
{
    public class MenuItemsResponseBody<T> where T : new()
    {
        public List<T> Items { get; set; }
    }
}
