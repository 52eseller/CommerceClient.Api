using CommerceClient.Api.Model.RequestModels;
using CommerceClient.Api.Model.RequestModels.Basket;
using CommerceClient.Api.Online;

namespace CommerceClient.Api.Coverage.BasketApi
{
    public class BasketCoverage : BaseHandler
    {
        public void CreateNewBasket() {
            _connection.CreateNewBasket(_clientState);
        }

        public void DeleteBasket(int basketId) {
            _connection.DeleteBasket(_clientState, basketId);
        }

        public void GetBaskets() {
            _connection.GetBaskets(_clientState);
        }

        public void GetBasket(int basketId){
            _connection.GetBasket(_clientState,basketId);
        }

        public void UpdateShipToAddress(int basketId, AddressShipToRequest addressShipToRequest){
            _connection.UpdateShipTo(_clientState, basketId, addressShipToRequest);
        }

        public void UpdateSellToAddress(int basketId, AddressSellToRequest addressSellToRequest)
        {
            _connection.UpdateSellTo(_clientState, basketId, addressSellToRequest);
        }

        public void UpdateBasketAnnotation(int basketId, BasketAnnotationRequest basketAnnotationRequest)
        {
            _connection.UpdateBasketAnnotation(_clientState, basketId, basketAnnotationRequest);
        }

        public void MergeBasket(int basketId, BasketMergeRequest basketMergeRequest)
        {
            _connection.MergeBasket(_clientState, basketId, basketMergeRequest);
        }

        public void DeleteAllBasketUserValue(int basketId, string uservaluekey)
        {
            _connection.DeleteAllBasketUserValue(_clientState, basketId, uservaluekey);
        }

        public void DeleteAllBasketUserValues(int basketId)
        {
            _connection.DeleteAllBasketUserValues(_clientState, basketId);
        }

        public void GetBasketStatus(int basketId)
        {
            _connection.GetBasketStatus(_clientState, basketId);
        }

        public void CheckoutBasket(int basketId)
        {
            _connection.CheckoutBasket(_clientState, basketId);
        }

        public void TakeBasketOwnerShip(int basketId)
        {
            _connection.TakeBasketOwnerShip(_clientState, basketId);
        }

        public void RemoveCoupon(int basketId, string couponId)
        {
            _connection.RemoveCoupon(_clientState, basketId, couponId);
        }

        public void RemoveCoupons(int basketId)
        {
            _connection.RemoveCoupons(_clientState, basketId);
        }

        public void DeleteBasketLines(int basketId)
        {
            _connection.DeleteBasketLines(_clientState, basketId);
        }

        public void DeleteBasketLine(int basketId, int lineId)
        {
            _connection.DeleteBasketLine(_clientState, basketId, lineId);
        }

        public void CreateUserKeyValue(int basketId, BasketUserValueRequest basketUserValueRequest)
        {
            _connection.CreateUserKeyValue(_clientState, basketId, basketUserValueRequest);
        }

        public void GetState(int basketId)
        {
            _connection.GetBasketState(_clientState, basketId);
        }
    }
}
