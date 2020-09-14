using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.RequestModels.Registration
{
    public class AppRegistrationRequest
    {
        public string ApiKey { get; set; }

        /// <summary>
        /// Used for trusted apps.
        /// A value, that is used to confirm that the app being approved is indeed the correct one.
        /// This should be a value displayed by the app on the device, which administrator can see in the backend on
        /// the registration record, that creates a visual confirmation of the authenticity of the device.
        /// </summary>
        public string VerificationToken { get; set; }

        /// <summary>
        /// Required if the api key requires you to know it.
        /// </summary>
        public string RegistrationSecret { get; set; }
    }
}
