using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.Misc
{
    public enum Severity
    {
        Debug = 0,
        Info = 1,
        Warning = 2,
        Error = 3,
        Fatal = 4,
        Security = 10
    }

    public enum LinkRel
    {
        /// <summary>
        /// The link is pointing to itself, i.e. to the resource that generated the data.
        /// </summary>
        Self,

        /// <summary>
        /// If the resource is able to provide status information, f.inst due to having a defined lifecycle, this is where to obtain the status information.
        /// </summary>
        Status,

        /// <summary>
        /// This describes a resource that interacts with a specific part of the responding resource, i.e. getting or setting parts of an entity.
        /// This relation can be used when no other relation fits better
        /// </summary>
        Facet,

        /// <summary>
        /// Links to the data's item primary resource. This would be a product, offer or similar.
        /// </summary>
        Item,

        /// <summary>
        /// The link is point to a resource providing an image. An image is a resource, that can be inlined, i.e. a .jpg, .png, or gif etc....
        /// </summary>
        Image,

        /// <summary>
        /// The link points to a accompanying the data. A document is supposed to be served with content-disposition = attachment,
        /// and could be a download-able file, f.inst pdf, eps or any other file that is relevant to the data.
        /// </summary>
        Document,

        /// <summary>
        /// The resource responds with basket line
        /// </summary>
        BasketLine,

        /// <summary>
        /// Represents coupon in basket
        /// </summary>
        BasketCoupon,

        /// <summary>
        /// Represents user value in basket
        /// </summary>
        BasketUserValue,
        /// <summary>
        /// Represents a favorite (list)
        /// </summary>
        Favorite,
        FavoriteItem
    }

    public enum LinkAction
    {
        Get,
        Post,
        Put,
        Delete
    }

    public enum LinkTargetContent
    {
        /// <summary>
        /// Refers to an main entity, i.e. product, basket etc.
        /// </summary>
        Item,

        /// <summary>
        /// Describes data that are subordinate to an entity, f.inst a basket line, which belongs to a specific basket.
        /// </summary>
        ItemChild,

        /// <summary>
        /// Refers to a collection of entities.
        /// </summary>
        ItemCollection,

        /// <summary>
        /// Refers to a collection of ItemChilds.
        /// </summary>
        ItemChildCollection,

        /// <summary>
        /// The content is in an unstructured for, i.e. a stream of bytes.
        /// </summary>
        Stream,

        /// <summary>
        /// The content is in a structured form, f.inst json.
        /// Unlike entities, the data presented only describes small facets of an entity or operation. F.inst Rel Status would be expected to return Structured content.
        /// </summary>
        Structured
    }
}
