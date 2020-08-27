using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.ResponseModels.Menu
{
    public enum TreeBranchContent
    {
        /// <summary>
        /// Represents the top item in eseller tree, i.e. the "page" without any parent.
        /// </summary>
        /// <remarks></remarks>
        Page = 1,

        /// <summary>
        /// Represents the bridge to customer favorites. This may be obsoleted with introduction of bookmarks.
        /// </summary>
        ProductlistCustomerFavorites = 2,

        /// <summary>
        /// Represents the bridge to search result page. This may be obsoleted with the introduction of bookmarks.
        /// </summary>
        ProductlistSearchResult = 3,

        /// <summary>
        /// Represents the bridge to product menues.
        /// </summary>
        ProductMenu = 4,

        /// <summary>
        /// Represents the bridge to info menue 1.
        /// </summary>
        CmsInfoMenu1 = 5,

        /// <summary>
        /// Represents the bridge to info menue 2.
        /// </summary>
        CmsInfoMenu2 = 6,

        /// <summary>
        /// Represents the bridge to top menues.
        /// </summary>
        CmsTopMenu = 7,

        /// <summary>
        /// Represents the bridge to bottom menues.
        /// </summary>
        CmsBottomMenu = 8,

        /// <summary>
        /// Represents the bridge to FAQ menues.
        /// </summary>
        CmsFaq = 9,

        /// <summary>
        /// Represents the bridge to info menue 3.
        /// </summary>
        CmsInfoMenu3 = 10,

        /// <summary>
        /// Represents the bridge to info menue 4.
        /// </summary>
        CmsInfoMenu4 = 11
    }
}
