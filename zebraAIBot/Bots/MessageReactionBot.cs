// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AdaptiveCards;
using MessageReaction.Bots;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using Newtonsoft.Json.Linq;


namespace Microsoft.BotBuilderSamples.Bots
{
    public class MessageReactionBot : ActivityHandler
    {
        private readonly ActivityLog _log;

       

        public MessageReactionBot(ActivityLog log)
        {
            _log = log;
            
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var welcomeText = "Hello, I'm your bot. Just as you are aware, I can help you to get zebra AI data. Please provide your information by following this format: CaseReview:CaseID. For example: Case Review:1111111111. Try to ask me about it!";
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }

        
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            string messagecontent;
            string caseid;
            string expeirementname;
            ExperimentDemo ExperimentDemo = new ExperimentDemo();

            const string expeirmentid = "your expeirementid";//casereview


            if (turnContext.Activity.Text.ToLower().Contains(":"))
            {
                
                    caseid = turnContext.Activity.Text.Split(':')[1];
                expeirementname = turnContext.Activity.Text.Split(':')[0];

              

                if (expeirementname.ToLower().Contains("case review"))
                {

                    messagecontent = await ExperimentDemo.Run(caseid, expeirmentid);
                    await SendMessageAndLogActivityId(turnContext, messagecontent, cancellationToken);
                }
               
                else
                {
                    messagecontent = "You have sent the wrong format. Please provide your information by following this format: CaseReview:CaseID. For example: Case Review:11111111. Try to ask me about it!";
                    await SendMessageAndLogActivityId(turnContext, messagecontent, cancellationToken);
                }
            }

            else
            {

                messagecontent = "You have sent the wrong format. Please provide your information by following this format: CaseReview:CaseID. For example: Case Review:1111111. Try to ask me about it!";
                await SendMessageAndLogActivityId(turnContext, messagecontent, cancellationToken);

            }

            }
                   

           
        private async Task SendMessageAndLogActivityId(ITurnContext turnContext, string text, CancellationToken cancellationToken)
        {
            // We need to record the Activity Id from the Activity just sent in order to understand what the reaction is a reaction too. 
            var replyActivity = MessageFactory.Text(text);
            var resourceResponse = await turnContext.SendActivityAsync(replyActivity, cancellationToken);
            await _log.Append(resourceResponse.Id, replyActivity);
        }
    }
}
