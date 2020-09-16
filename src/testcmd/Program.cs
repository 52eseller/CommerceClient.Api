using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Description;
using CommerceClient.Api.Model;
using CommerceClient.Api.Model.RequestModels;
using CommerceClient.Api.Online;
using CommerceClient.Api.Coverage.BasketApi;
using CommerceClient.Api.Coverage.ProductApi;
using CommerceClient.Api.Coverage.SalesPersonApi;
using CommerceClient.Api.Model.RequestModels.Basket;
using CommerceClient.Api.Coverage.Registration;

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
           //new RegistrationCoverage().AuthenticateAsSalePerson();
            //int basketId = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings.Get("basketId"));
            //new BasketCoverage().DeleteBasketLine(9598080, 50149172);
            //new BasketCoverage()(basketId);
            //new BasketCoverage().CreateNewBasket();
            //new BasketCoverage().UpdateShipToAddress(basketId, addressShipToRequest);
            //new BasketCoverage().DeleteAllBasketUserValues(basketId);
            //new BasketCoverage().GetCurrencies();

            // Product Coverage Testing
            //var searchFor = "Box";
            //var imageSizeTypeID = new List<int>();
            //imageSizeTypeID.Add(58);

            //int? menuID = null;
            //new ProductCoverage().SearchForProduct(searchFor, imageSizeTypeID, menuID);

            //var itemKey = new ItemKey(423305, TypeOfItem.Product);
            //var itemKeys = new List<ItemKey>();
            //itemKeys.Add(itemKey);

            //var imageSizeTypeID = new List<int>();
            //imageSizeTypeID.Add(1);

            //new ProductCoverage().GetSpecificItemById(itemKeys, imageSizeTypeID);

            //var imageSizeTypeID = new List<int>();
            //imageSizeTypeID.Add(65);

            //new ProductCoverage().GetAllProductMenus(imageSizeTypeID);

            //var menuId = 21485;
            //var depth = 3;
            //var imageSizeTypeID = new List<int>();
            //imageSizeTypeID.Add(65);

            //new ProductCoverage().GetSpecificProductMenusWithDepth(
            //    menuId,
            //    depth,
            //    imageSizeTypeID
            //);

            //new SalesPersonCoverage().GetCustomersForCurrentSalesPerson();


            Console.Write("Hit return to exit.");
            Console.ReadLine();

        }
    }
}
