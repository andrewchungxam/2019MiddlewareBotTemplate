using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
using StateMiddlewareBot;
using StateMiddlewareBot.StateManagement;
//using MiddlewareBot.Middleware;

namespace MiddlewareBot
{
    /// <summary>
    /// Middleware for translating text between the user and bot.
    /// Uses the Microsoft Translator Text API.
    /// </summary>
    public class TemplateMiddleware5 : IMiddleware
    {

        private BotState _conversationState;
        private BotState _userState;
        private BotState _counterState;

        public TemplateMiddleware5(ConversationState conversationState, UserState userState)
        {
            _conversationState = conversationState;
            _userState = userState;
        }

        public TemplateMiddleware5(ConversationState conversationState, UserState userState, CounterState counterState)
        {
            _conversationState = conversationState;
            _userState = userState;
            _counterState = counterState;
        }

        /// <summary>
        /// Processes an incoming activity.
        /// </summary>
        /// <param name="turnContext">Context object containing information for a single turn of conversation with a user.</param>
        /// <param name="next">The delegate to call to continue the bot middleware pipeline.</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {

            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            //// STEP 3
            //// UNCOMMENT BELOW CODE
            //// Get the conversation state from the turn context.
            
            //// Get the state properties from the turn context.
            //var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            //var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());

            //var userStateAccessors = _userState.CreateProperty<UserProfile>(nameof(UserProfile));
            //var userProfile = await userStateAccessors.GetAsync(turnContext, () => new UserProfile());

            //if (turnContext == null)
            //{
            //    throw new ArgumentNullException(nameof(turnContext));
            //}

            //if (turnContext.Activity.Type == ActivityTypes.Message)
            //{
            //    turnContext.Activity.Text = await TranslateMessageActivityAsync(turnContext.Activity.AsMessageActivity());

            //    // Get the conversation state from the turn context.
            //    var oldStateMethod2 = conversationData.CounterData;   //.GetAsync(turnContext, () => new CounterState());

            //    // Bump the turn count for this conversation.
            //    var newStateMethod2 = new CounterData { TurnCount = oldStateMethod2.TurnCount + 1 };

            //    conversationData.CounterData = newStateMethod2;

            //    await conversationStateAccessors.SetAsync(turnContext, conversationData);

            //    // Echo back to the user whatever they typed.
            //    var responseMessage2 = $"Middleware5: Turn {newStateMethod2.TurnCount}: You sent '{turnContext.Activity.Text}'\n";
            //    await turnContext.SendActivityAsync(responseMessage2);

            //}
            //// END STEP 3
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////

            await next(cancellationToken).ConfigureAwait(false);

            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            //// STEP 4
            //// UNCOMMENT BELOW CODE

            //if (turnContext.Activity.Type == ActivityTypes.Message)
            //{
            //// Get the conversation state from the turn context.

            //turnContext.Activity.Text = await TranslateMessageAfterNextActivityAsync(turnContext.Activity.AsMessageActivity());

            //// Get the conversation state from the turn context.
            //var oldStateMethod2 = conversationData.CounterData;   //.GetAsync(turnContext, () => new CounterState());

            //// Bump the turn count for this conversation.
            //var newStateMethod2 = new CounterData { TurnCount = oldStateMethod2.TurnCount + 1 };

            //conversationData.CounterData = newStateMethod2;

            //await conversationStateAccessors.SetAsync(turnContext, conversationData);

            ////EXPERIMENT 1 - COMMENT OUT THE TWO "SaveChangesAsync" LINES
            ////THIS IS NECESSARY BECAUSE THE CHANGES GET SAVED AFTER THE TURN WHICH HAPPENS BEFORE THE `await next(cancellationToken).ConfigureAwait(false);`
            //await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            //await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
            ////END EXPERIMENT 1 - COMMENT OUT THE TWO "SaveChangesAsync" LINES

            //// Echo back to the user whatever they typed.
            //var responseMessage2 = $"Middleware5AfterNext: Turn {newStateMethod2.TurnCount}: You sent '{turnContext.Activity.Text}'\n";
            //await turnContext.SendActivityAsync(responseMessage2);
            //}

            //// END STEP 4
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////

        }

        private async Task<string> TranslateMessageActivityAsync(IMessageActivity activity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (activity.Type == ActivityTypes.Message)
            {
                var appendableString = activity.Text;
                appendableString += " + by Middleware5";
                return appendableString;
            }
            else
            {
                return "";
            }
        }

        private async Task<string> TranslateMessageAfterNextActivityAsync(IMessageActivity activity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (activity.Type == ActivityTypes.Message)
            {
                var appendableString = activity.Text;
                appendableString += " + after the NEXT by Middleware5";
                return appendableString;
            }
            else
            {
                return "";
            }
        }
    }
}