using Microsoft.Bot.Builder;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using EchoBotEx.Greeting;
using EchoBotEx.ProcessMessages;

namespace EchoBotEx.Bots
{
    public class BankInteligentBot : ActivityHandler
    {
        private readonly IGreetingMessage greetingMessage;
        private readonly IProcessMessage processMessage;
        public BankInteligentBot(IGreetingMessage greetingMessage,
            IProcessMessage processMessage) {
            this.greetingMessage = greetingMessage;
            this.processMessage = processMessage;
        }
        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var replyText = await processMessage.MessageController(turnContext.Activity.Text).ConfigureAwait(false);
            //var replyText = await greetingMessage.GreetingMessage("Hi").ConfigureAwait(false);//turnContext.Activity.Text + "welcome to Inteligent Bot";
            await turnContext.SendActivityAsync(MessageFactory.Text(replyText, replyText), cancellationToken);
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        
        {
            var welcomeText = "Hello and welcome!";
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }
    }
}
