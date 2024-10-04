using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Client;
using Microsoft.Identity.Client.AppConfig;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MessageReaction
{
   public class AuthHelper
    {
        private static readonly string _prdUrl = "https://zebra-ai-webapi-prd.azurewebsites.net/";
        private static readonly string _uatUrl = "https://zebra-ai-webapi-uat.azurewebsites.net/";
        private static readonly string _devUrl = "https://localhost:7242/";

        private readonly IConfiguration _configuration;

        public AuthHelper()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            _configuration = builder.Build();
        }

        //SET THIS TO THE API ENVIRONMENT YOU WANT TO USE (see above)
        public static string ApiEndpoint = _prdUrl;

        private static string _apiToken = "";

        public async Task<string?> GetAPPEntraIdToken()
        {
            try
            {
                if (_apiToken != "")
                {
                    return _apiToken;
                }
                else
                {
                 
                    var clientId =_configuration["MicrosoftAppId"];
                    var clientSecret = _configuration["MicrosoftAppPassword"];
                    var tenantId = _configuration["MicrosoftAppTenantId"];
                    var scope = "api://9021b3a5-1f0d-4fb7-ad3f-d6989f0432d8/.default";

                    var client = new HttpClient();
                    var request = new HttpRequestMessage(HttpMethod.Post, $"https://login.microsoftonline.com/{tenantId}/oauth2/v2.0/token");

                    var body = new FormUrlEncodedContent(new[]
                    {
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret),
            new KeyValuePair<string, string>("scope", scope),
            new KeyValuePair<string, string>("grant_type", "client_credentials")
        });

                    request.Content = body;

                    var response = await client.SendAsync(request);
                    var responsestring = await response.Content.ReadAsStringAsync();
                    _apiToken = JObject.Parse(responsestring)["access_token"].ToString();
                    return _apiToken;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error getting token: " + ex.Message);
                //Console.WriteLine(ex.ToString());
                return null;
            }
        }

       
        public  async Task<string?> GetToken()
        {

            return await GetAPPEntraIdToken();


        }
    }
}
