﻿using System.Collections.Generic;
using CommerceClient.Api.Model.JsonConverters;
using Newtonsoft.Json;

namespace CommerceClient.Api.Model
{
    public class Customer
    {
        public int CustomerId { get; set; }

        [JsonConverter(typeof(FlagConverter))]
        public CustomerPolicies Policies { get; set; }

        /// <summary>
        /// The currency that should be considered preferred by customer if any.
        /// </summary>
        public Currency Currency { get; set; }

        public Address BillToAddress { get; set; }

        public Address SellToAddress { get; set; }

        public List<Address> ShipToAddresses { get; set; }
        public string ExtCustomerId { get; set; }
        public List<ResourceLink> Links { get; set; }
    }
}