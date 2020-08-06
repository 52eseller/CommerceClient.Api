namespace CommerceClient.Api.Model.RequestModels.Basket
{
    public class BasketContextRequestBody
    {
        public long? LocationKey { get; set; }
        public int? CurrencyKey { get; set; }
        public int? LanguageKey { get; set; }
    }
}