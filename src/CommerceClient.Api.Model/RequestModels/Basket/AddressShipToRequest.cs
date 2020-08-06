using CommerceClient.Api.Model.Misc;
using CommerceClient.Api.Model.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.RequestModels.Basket
{
    public class AddressShipToRequest
    {
        public bool? IsEnabled { get; set; }
        [InputFieldPolicy(InputFieldPolicyKeys.ShipToCompanyName)] public string CompanyName { get; set; }
        [InputFieldPolicy(InputFieldPolicyKeys.ShipToAttention)] public string Attention { get; set; }
        [InputFieldPolicy(InputFieldPolicyKeys.ShipToName)] public string Name { get; set; }
        [InputFieldPolicy(InputFieldPolicyKeys.ShipToAddress)] public string Address { get; set; }
        [InputFieldPolicy(InputFieldPolicyKeys.ShipToAddress2)] public string Address2 { get; set; }
        [InputFieldPolicy(InputFieldPolicyKeys.ShipToZipCode)] public string ZipCode { get; set; }
        [InputFieldPolicy(InputFieldPolicyKeys.ShipToCity)] public string City { get; set; }
        [InputFieldPolicy(InputFieldPolicyKeys.ShipToCountryId)] public CountryKey CountryId { get; set; }
    }
}
