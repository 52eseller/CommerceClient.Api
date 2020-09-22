namespace CommerceClient.Api.Model
{
    public class ApiError
    {
        /// <summary>
        /// Severity enumeration
        /// </summary>
        public int Code { get; set; }
        /// <summary>
        /// ResultCode enumeration
        /// </summary>
        public string Reason { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// ErrorCode (text)
        /// </summary>
        public string Id { get; set; }

        public string MoreInfo { get; set; }

        public string AdditionalInfo { get; set; }

        /// <summary>
        /// Refers to what kind of item is subject to the message.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Reference to the item subject to the message.
        /// This is an id, a comma-separated array of ids, or an array of json-alike structure for complex keys (think of itemKey).
        /// </summary>
        public string Reference { get; internal set; }
    }
}