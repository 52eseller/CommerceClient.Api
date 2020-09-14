using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Model.RequestModels.Registration
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class RegisterAppResponse
    {
        /// <summary>
        /// Provides a secret key for hmac authorization.
        /// Normally, this information will have to be entered manually, but in case of an untrusted app,
        /// you can get this information programmatically. An untrusted app is defined as an app on an untrusted
        /// device, and is typically and end user app, exposing no other information than the ones that are already
        /// readily available through public api and web pages. (i.e. the secret key is not really secret at all anyway)
        /// </summary>
        public string SecretKey { get; set; }

        /// <summary>
        /// This is a unique id assigned to the app upon registration.
        /// </summary>
        public string InstallationId { get; set; }
    }
}
