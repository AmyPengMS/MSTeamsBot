using Microsoft.Extensions.Configuration.UserSecrets;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using MessageReaction.Model;
using System.Net.Http.Json;

namespace MessageReaction.Bots
{
    internal class ExperimentDemo
    {
        // experimentId is the Id for your experiment that you have setup on the ZebraAI site
        // it must also have been provisioned for the API by the ZebraAI team

        DateTime startTime = DateTime.Now;
        static String formattedStartTime = "2024-09-03T10:40:32Z";

      

        public  async Task<string> Run(string caseid,string experimentId)
        {
            AuthHelper AuthHelper = new AuthHelper();
            //use the AuthHelper class to get the API endpoint and token
            string apiEndpoint = AuthHelper.ApiEndpoint;
            string oauthToken = await AuthHelper.GetToken();
            string responsecontent = "11";

            //prepare the URIs for the API calls
            Uri experimentUri = new Uri(apiEndpoint + "experiment/" + experimentId);


            //setup an https client with auth to post data to the ZebraAI API
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", oauthToken);

           
            RunModel runModel = new RunModel();
            runModel.DataSearchOptions = new DataSearchOptionsModel();
            runModel.DataSearchOptions.Search = caseid;
            runModel.MaxNumberOfRows = 3; //since we are only searching for 3 cases

            //Post the data to the API
            var content = new StringContent(JsonConvert.SerializeObject(runModel));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = client.PostAsync(experimentUri, content).GetAwaiter().GetResult();

            //check the response
            if (response.IsSuccessStatusCode)
            {
                //deserialize the response to a RunModel
                runModel = await response.Content.ReadFromJsonAsync<RunModel>();
            }
            else
            {
                return "error happend";
            }

            //Sample 2 - from the previous response, add a new message to the chat and resend while keeping the context/chathistory
            //Console.WriteLine(">Experiment API - Sample 2 - Chat continuation");
            runModel.ChatHistory.Messages.Add(new MessageItem()
            {
                Role = "user",
                Content = "Which case is likely the most severe?"
            });

            //Post the data to the API
            content = new StringContent(JsonConvert.SerializeObject(runModel));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            response = client.PostAsync(experimentUri, content).GetAwaiter().GetResult();

            //check the response
            if (response.IsSuccessStatusCode)
            {
                //deserialize the response to a RunModel
                runModel = await response.Content.ReadFromJsonAsync<RunModel>();
                Console.WriteLine("ZebraAI Experiment API returned:");
                //pretty print the response
                var Jsondata = JsonConvert.SerializeObject(runModel, Formatting.Indented);


                var message = runModel.ChatHistory.Messages;

                foreach (var messageitem in message)
                {
                    if (messageitem.Role == "assistant")
                    {
                        responsecontent = messageitem.Content;
                        break;
                    }
                }

                return responsecontent;
            }
            else
            {
                return "error happend";
                //Environment.Exit((int)response.StatusCode);
            }
        }

    }
}
