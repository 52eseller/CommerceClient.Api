using System;
using System.Reflection;
using CommerceClient.Api.Model;
using CommerceClient.Api.Model.RequestModels;
using CommerceClient.Api.Online;
using CommerceClient.Api.Coverage.BasketApi;
using CommerceClient.Api.Model.RequestModels.Basket;

namespace CommerceClient.Api.Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.Write("Hit return to start.");
            Console.ReadLine();

            //For testing purpose only:

            //int basketId = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("basketId"));
            //new BasketCoverage().DeleteBasket(basketId);
            //new BasketCoverage()(basketId);
            //new BasketCoverage().CreateNewBasket();
            //new BasketCoverage().UpdateShipToAddress(basketId, addressShipToRequest);
            //new BasketCoverage().DeleteAllBasketUserValues(basketId);
      
            Console.Write("Hit return to exit.");
            Console.ReadLine();

        }
    }
}
