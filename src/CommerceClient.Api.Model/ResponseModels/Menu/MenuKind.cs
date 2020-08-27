using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.ResponseModels.Menu
{
    public enum MenuKind
    {
        NotDefined = 0,

        /// <summary>
        /// Represents top level items, or pages. Although they do not directly act as menues, they still form the top level tree where menues are placed.
        /// </summary>
        /// <remarks></remarks>
        Page = 1,

        /// <summary>
        /// Represents the bridge to product menues.
        /// </summary>
        ProductMenu = 2,

        /// <summary>
        /// Represents an info menu. This kind is a generic value for an info menu, and should generally not be used.
        /// Info menues are logically grouped into infomenu 1, 2, 3 and 4, and top- bottom and faq, and when
        /// stored and in / or returned from the document model, the MenuKind will be set accordingly.
        /// </summary>
        InfoMenu = 3,
        InfoMenu1 = 4,
        InfoMenu2 = 5,
        InfoMenu3 = 6,
        InfoMenu4 = 7,
        InfoMenuTop = 8,
        InfoMenuBottom = 9,
        InfoMenuFaq = 10,
    }
}
