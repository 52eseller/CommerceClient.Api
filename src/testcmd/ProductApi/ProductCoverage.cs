using System;
using System.Collections.Generic;
using System.Text;
using CommerceClient.Api.Model;
using CommerceClient.Api.Online;
using JetBrains.Annotations;

namespace CommerceClient.Api.Coverage.ProductApi
{
    public class ProductCoverage : BaseHandler
    {
        public void SearchForProduct(string searchFor,
            IEnumerable<int> imageSizeTypes,
            int? menuId = null,
            int? pageNo = null, 
            int? pageSize = null, 
            int? maxSearchResults = null)
        {
            _connection.ProductSearch(
                _clientState,
                searchFor,
                imageSizeTypes,
                menuId,
                "",
                pageNo,
                pageSize,
                maxSearchResults
            );
        }

        public void GetSpecificItemById(IEnumerable<ItemKey> itemKeys, IEnumerable<int> imagesizetypeids,
            [CanBeNull] string sortOption = null,
            int? page = null,
            int? pageSize = null,
            int? maxSearchResults = null,
            string includes = null)
        {
            _connection.ProductsByItemKeys(
                _clientState,
                itemKeys,
                imagesizetypeids,
                sortOption,
                page,
                pageSize,
                maxSearchResults,
                includes
            );
        }

        public void GetAllProductMenus( IEnumerable<int> imagesizetypeids = null,
            [CanBeNull] string sortOption = null)
        {
            _connection.GetAllProductMenus(
                _clientState,
                imagesizetypeids,
                null,
                sortOption,
                null
            );
        }

        public void GetSpecificProductMenusWithDepth(int menuId, int depth, IEnumerable<int> imagesizetypeids = null)
        {
            _connection.GetSpecificProductMenusWithDepth(
                _clientState,
                menuId,
                imagesizetypeids,
                depth
            );
        }
    }
}
