using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.RequestModels.Registration
{
    public class AppRegistrationVerificationRequest
    {
        public string ApiKey { get; set; }

        /// <summary>
        /// Required if the api key requires you to know it.
        /// </summary>
        public string RegistrationSecret { get; set; }

        /// <summary>
        /// The installation id on which the client is known.
        /// </summary>
        public string InstallationId { get; set; }
    }
}
