using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CommerceClient.Api.Model.RequestModels.Basket
{
    public class BasketMergeRequest
    {
        public enum MergeTarget
        {
            This
        }

        public int FromBasketId { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public MergeTarget MergeTo { get; set; }
    }
}
