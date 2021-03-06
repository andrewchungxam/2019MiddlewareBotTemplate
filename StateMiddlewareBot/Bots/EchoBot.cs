// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using StateMiddlewareBot;
using StateMiddlewareBot.StateManagement;

namespace MiddlewareBot.Bots
{
    public class EchoBot : ActivityHandler
    {

        private BotState _conversationState;
        private BotState _userState;

        //part of method 3
        private BotState _counterState;


        public EchoBot(ConversationState conversationState, UserState userState)
        {
            _conversationState = conversationState;
            _userState = userState;
        }

        public EchoBot(ConversationState conversationState, UserState userState, CounterState counterState)
        {
            _conversationState = conversationState;
            _userState = userState;
            _counterState = counterState;
        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default(CancellationToken))
        {
            await base.OnTurnAsync(turnContext, cancellationToken);

            // Save any state changes that might have occured during the turn.
            await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(MessageFactory.Text($"Echo: {turnContext.Activity.Text}"), cancellationToken);

            // Get the state properties from the turn context.

            var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());

            var userStateAccessors = _userState.CreateProperty<UserProfile>(nameof(UserProfile));
            var userProfile = await userStateAccessors.GetAsync(turnContext, () => new UserProfile());

            ////////////////////////////////////////////////////////////////////////
            ///METHOD 1

            ////Get the conversation state from the turn context.
            //var oldStateMethod1 = conversationData.CounterData;

            //// Bump the turn count for this conversation.
            //var newStateMethod1 = new CounterData { TurnCount = oldStateMethod1.TurnCount + 1 };

            //conversationData.CounterData= newStateMethod1;

            //// Echo back to the user whatever they typed.
            //var responseMessage = $"Turn {newStateMethod1.TurnCount}: You sent '{turnContext.Activity.Text}'\n";
            //await turnContext.SendActivityAsync(responseMessage);

            ////////////////////////////////////////////////////////////////////////
            ///METHOD 2

            // Get the conversation state from the turn context.
            var oldStateMethod2 = conversationData.CounterData;   //.GetAsync(turnContext, () => new CounterState());

            // Bump the turn count for this conversation.
            var newStateMethod2 = new CounterData { TurnCount = oldStateMethod2.TurnCount + 1 };

            conversationData.CounterData = newStateMethod2;

            await conversationStateAccessors.SetAsync(turnContext, conversationData);

            // Echo back to the user whatever they typed.
            var responseMessage2 = $"Turn {newStateMethod2.TurnCount}: You sent '{turnContext.Activity.Text}'\n";
            await turnContext.SendActivityAsync(responseMessage2);

            ////////////////////////////////////////////////////////////////////////
            ///METHOD 3
            ///

            ////Give counter state it's own property
            //var counterStateAccessorsMethod3 = _counterState.CreateProperty<CounterData>(nameof(CounterData));
            //var counterStateMethod3 = await counterStateAccessorsMethod3.GetAsync(turnContext, () => new CounterData());

            //var oldStateMethod3 = counterStateMethod3;

            //// Bump the turn count for this conversation.
            //var newStateMethod3 = new CounterData { TurnCount = oldStateMethod3.TurnCount + 1 };

            //await counterStateAccessorsMethod3.SetAsync(turnContext, newStateMethod3);

            //// Echo back to the user whatever they typed.
            //var responseMessageMethod3 = $"Turn {newStateMethod3.TurnCount}: You sent '{turnContext.Activity.Text}'\n";
            //await turnContext.SendActivityAsync(responseMessageMethod3);

            ////////////////////////////////////////////////////////////////////////////////////////////////////



            if (string.IsNullOrEmpty(userProfile.Name))
            {
                // First time around this is set to false, so we will prompt user for name.
                if (conversationData.PromptedUserForName)
                {
                    // Set the name to what the user provided.
                    userProfile.Name = turnContext.Activity.Text?.Trim();

                    // Acknowledge that we got their name.
                    await turnContext.SendActivityAsync($"Thanks {userProfile.Name}. To see conversation data, type anything.");

                    // Reset the flag to allow the bot to go though the cycle again.
                    conversationData.PromptedUserForName = false;
                }
                else
                {
                    // Prompt the user for their name.
                    await turnContext.SendActivityAsync($"What is your name?");

                    // Set the flag to true, so we don't prompt in the next turn.
                    conversationData.PromptedUserForName = true;
                }
            }
            else
            {
                // Add message details to the conversation data.
                // Convert saved Timestamp to local DateTimeOffset, then to string for display.
                var messageTimeOffset = (DateTimeOffset)turnContext.Activity.Timestamp;
                var localMessageTime = messageTimeOffset.ToLocalTime();
                conversationData.Timestamp = localMessageTime.ToString();
                conversationData.ChannelId = turnContext.Activity.ChannelId.ToString();

                // Display state data.
                await turnContext.SendActivityAsync($"{userProfile.Name} sent: {turnContext.Activity.Text}");
                await turnContext.SendActivityAsync($"Message received at: {conversationData.Timestamp}");
                await turnContext.SendActivityAsync($"Message received from: {conversationData.ChannelId}");
            }
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and Welcome!"), cancellationToken);
                }
            }
        }
    }
}





