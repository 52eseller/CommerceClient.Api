using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.Misc
{
    public static class InputFieldPolicyKeys
    {
        public const string LookupLanguage = "Language";
        public const string LookupCurrency = "Currency";
        public const string LookupCountry = "Country";
        public const string LookupLocation = "Location";

        public const string PathToAnnotation = "Annotation";
        public const string PathToSellToAddress = "Address.SellTo";
        public const string PathShipToAddress = "Address.ShipTo";
        public const string PathToCreateCustomer = "Customer.Create";
        public const string PathToModifyCustomer = "Customer.Modify";
        public const string PathToModifyCustomerLogin = "CustomerLogin.Modify";
        public const string PathToCreateCustomerLogin = "CustomerLogin.Create";
        public const string PathToBasket = "Basket.All";

        public const string BasketName = "BasketName";
        public const string BasketCustomerComment = "CustomerComment";

        public const string LoginName = "LoginName";
        public const string LoginUserName = "LoginUserName";
        public const string LoginPassword = "LoginPassword";
        public const string LoginLanguage = "LoginLanguage";
        public const string LoginCurrency = "LoginCurrency";

        public const string CustomerEmail = "CustomerEmail";
        public const string CustomerCompanyName = "CustomerCompanyName";
        public const string CustomerAttention = "CustomerAttention";
        public const string CustomerName = "CustomerName";
        public const string CustomerAddress = "CustomerAddress";
        public const string CustomerAddress2 = "CustomerAddress2";
        public const string CustomerZipCode = "CustomerZipCode";
        public const string CustomerCity = "CustomerCity";
        public const string CustomerCountryId = "CustomerCountry";
        public const string CustomerReference = "CustomerReference";
        public const string CustomerPhoneNumber = "CustomerPhoneNumber";
        public const string CustomerMobilePhoneNumber = "CustomerMobilePhoneNumber";
        public const string CustomerFaxNumber = "CustomerFaxNumber";
        public const string CustomerVatNumber = "CustomerVATNumber";
        public const string EanInvoiceCustomerReference = "EInvoiceCustomerReference";
        public const string EanInvoiceCustomerExtDocNo = "EInvoiceCustomerExtDocNo";
        public const string EanInvoiceCustomerReceiverCode = "EInvoiceCustomerReceiverCode";
        public const string EanInvoiceCustomerIntPostingNo = "EInvoiceCustomerIntPostingNo";

        public const string ShipToCompanyName = "ShipmentCompanyName";
        public const string ShipToAttention = "ShipmentAttention";
        public const string ShipToName = "ShipmentName";
        public const string ShipToAddress = "ShipmentAddress";
        public const string ShipToAddress2 = "ShipmentAddress2";
        public const string ShipToZipCode = "ShipmentZipCode";
        public const string ShipToCity = "ShipmentCity";
        public const string ShipToCountryId = "ShipmentCountry";

    }
}
