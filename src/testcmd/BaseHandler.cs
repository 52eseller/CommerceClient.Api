using CommerceClient.Api.Model.RequestModels;
using CommerceClient.Api.Online;
using System;
using System.Collections.Generic;
using System.Text;

namespace CommerceClient.Api.Coverage
{
    public class BaseHandler
    {
        public Connection _connection { get; set; }
        public ClientState _clientState { get; set; }
        public BaseHandler() {
            _connection = new Connection(System.Configuration.ConfigurationManager.AppSettings.Get("hostname"))
            {
                HostOverride = System.Configuration.ConfigurationManager.AppSettings.Get("hostoverride"),
                Authentication = System.Configuration.ConfigurationManager.AppSettings.Get("authentication")
            };
            try
            {
                _clientState = new ClientState();
                var (setHeaders, descriptiveContext) = _connection.GetContext(_clientState);
                _clientState = _clientState.ChangeState(setHeaders);
                _clientState.ApiKey = "eseller";
                _clientState.ApiSecret = "abc"; // Yes, you guessed correctly - this is not a real production key :)
               // LogRequestTest(_connection, _clientState);
            }
            catch (NotFoundException e)
            {
                Console.WriteLine();
                Console.WriteLine("Whoops - the resource was not found:");
                Console.WriteLine("=====================");
                Console.WriteLine(e.ErrorResponse?.ToJsonRaw());
            }
            catch (UnauthorizedException e)
            {
                Console.WriteLine();
                Console.WriteLine("Insufficient priviledges:");
                Console.WriteLine("=========================");
                Console.WriteLine(e.Challenge);
                Console.WriteLine("  - Additional info:");

                foreach (var eReason in e.Reasons)
                {
                    Console.WriteLine($"    - {eReason}");

                }
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("Something went wrong:");
                Console.WriteLine("=====================");
                Console.WriteLine(e.ToString());
            }
        }
        private static void LogRequestTest(Connection cnn, ClientState clientState)
        {
            var response =
                cnn.WriteLog(
                clientState,
                new LogRequest() { AppComponent = "ostebutik", Header = "Jeg tester app mac" }
            );
            Console.Write(response.ToJsonRaw());
        }
    }

}
