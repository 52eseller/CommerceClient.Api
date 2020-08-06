using CommerceClient.Api.Model.Misc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CommerceClient.Api.Model.RequestModels.Basket
{

    public class BasketAnnotationRequest
    {
        private string _Comment;

        /// <summary>
        /// Sets an optional comment that is the customers remarks to the order.
        /// </summary>
        [InputFieldPolicy(InputFieldPolicyKeys.BasketCustomerComment)]
        public string Comment
        {
            get => _Comment;

            set
            {
                CommentIsSet = true;
                _Comment = value;
            }
        }

        [JsonIgnore]
        public bool CommentIsSet { get; set; }

        private string _BasketName;

        /// <summary>
        /// Sets an an optional name for the basket, that help distinguish this basket in multi-basket scenarios.
        /// </summary>
        [InputFieldPolicy(InputFieldPolicyKeys.BasketName)]
        public string BasketName
        {
            get => _BasketName;

            set
            {
                BasketNameIsSet = true;
                _BasketName = value;
            }
        }

        [JsonIgnore]
        public bool BasketNameIsSet { get; set; }


        private DateTime? _DeliveryDate;

        /// <summary>
        /// Sets an optional (wish for) specific delivery time.
        /// </summary>
        public DateTime? DeliveryDate
        {
            get => _DeliveryDate;

            set
            {
                DeliveryDateIsSet = true;
                _DeliveryDate = value;
            }
        }

        [JsonIgnore]
        public bool DeliveryDateIsSet { get; set; }
    }
}
