using CommerceClient.Api.Model.RequestModels.Registration;
using CommerceClient.Api.Online;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Coverage.Registration
{
    public class RegistrationCoverage : BaseHandler
    {

        public void VerifyHello() {

            _connection.VerifyHello(_clientState, new AppRegistrationVerificationRequest());
        }

        public void Hello()
        {
            var obj = new AppRegistrationRequest()
            {
                ApiKey= "FiftyTwoPos",
                RegistrationSecret="Unicorn"
            };
            _connection.Hello(_clientState, obj);
        }

        public void Renew()
        {

            _connection.Renew(_clientState);
        }

        public void AuthenticateAsSalePerson()
        {

            _connection.AuthenticateAsSalesPerson(_clientState, "uah", "1234");
        }
    }
}
