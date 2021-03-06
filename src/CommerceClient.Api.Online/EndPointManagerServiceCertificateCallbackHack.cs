﻿using System.Linq;

namespace CommerceClient.Api.Online
{
    public static class EndPointManagerServiceCertificateCallbackHack
    {
#pragma warning disable CA1823
        private static object ServerCertificateValidationCallbackDelegate =
            RegisterServerCertificateValidationCallback();
#pragma warning restore CA1823

        private static object RegisterServerCertificateValidationCallback()
        {
            return System.Net.ServicePointManager.ServerCertificateValidationCallback +=
                       ServerCertificateValidationCallback;
        }

        /// <summary>
        /// Add this header to your web request / RestRequest to ignore any certificate errors due to having test or self-signed certificates on an endpoint
        /// serving your request.
        /// </summary>
        public const string IgnoreSslErrorsHeaderKey = "X-IgnoreSslErrors";

        private static bool ServerCertificateValidationCallback(
            object sender,
            System.Security.Cryptography.X509Certificates.X509Certificate certificate,
            System.Security.Cryptography.X509Certificates.X509Chain chain,
            System.Net.Security.SslPolicyErrors sslpolicyerrors
        )
        {
            if (sslpolicyerrors != System.Net.Security.SslPolicyErrors.None)
            {
                // Bypass Ssl errors only when header X-IgnoreSslErrors have a value of "true".
                if (sender is System.Net.HttpWebRequest req)
                {
                    var val = req.Headers.GetValues(IgnoreSslErrorsHeaderKey)?.FirstOrDefault();
                    if (val != null && val == "true")
                    {
                        return true;
                    }
                }

                return false;
            }

            return true;
        }
    }
}