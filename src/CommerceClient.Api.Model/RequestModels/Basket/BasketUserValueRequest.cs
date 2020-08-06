namespace CommerceClient.Api.Model.RequestModels.Basket
{
    public class BasketUserValueRequest
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public bool IsVisibleOnOrder { get; set; }

        public string ContentType { get; set; }
    }
}