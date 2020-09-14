using CommerceClient.Api.Model;
using CommerceClient.Api.Model.RequestModels.Registration;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Online
{
    public static class AppRegistrationExtension
    {
        public static RegisterAppResponse VerifyHello(this Connection conn, ClientState state, AppRegistrationVerificationRequest appRegistrationVerificationRequest)
                    => conn.Execute<DataResponse<RegisterAppResponse>>(
                    appRegistrationVerificationRequest.CreateRestRequestJson(
                            Method.POST,
                            "/services/v3/auth/verifyhello"
                        ),
                    state,
                    Includes.Hmac
                )
                .Response.Data;

        public static RegisterAppResponse Hello(this Connection conn, ClientState state, AppRegistrationRequest appRegistrationRequest)
                 => conn.Execute<DataResponse<RegisterAppResponse>>(
                 appRegistrationRequest.CreateRestRequestJson(
                         Method.POST,
                         "/services/v3/auth/hello"
                     ),
                 state,
                 Includes.Hmac
             )
             .Response.Data;

        public static AuthenticationResponse Renew(this Connection conn, ClientState state)
           => conn.Execute<DataResponse<AuthenticationResponse>>(
                    conn.CreateRestRequestJson(
                        Method.POST,
                        "/services/v3/auth/renew"
                    ),
                    state,
                    Includes.Hmac
                )
                .Response.Data;
    }
}
