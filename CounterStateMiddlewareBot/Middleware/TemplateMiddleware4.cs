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
    public class TemplateMiddleware4 : IMiddleware
    {

        private BotState _conversationState;
        private BotState _userState;
        private BotState _counterState;

        public TemplateMiddleware4(ConversationState conversationState, UserState userState)
        {
            _conversationState = conversationState;
            _userState = userState;
        }

        public TemplateMiddleware4(ConversationState conversationState, UserState userState, CounterState counterState)
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
            if (turnContext == null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            //// STEP 1
            //// UNCOMMENT BELOW CODE
            //// Get the conversation state from the turn context.

            //if (turnContext.Activity.Type == ActivityTypes.Message)
            //{

            //    turnContext.Activity.Text = await TranslateMessageActivityAsync(turnContext.Activity.AsMessageActivity());

            //    // Get the state properties from the turn context.
            //    var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            //    var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());

            //    var userStateAccessors = _userState.CreateProperty<UserProfile>(nameof(UserProfile));
            //    var userProfile = await userStateAccessors.GetAsync(turnContext, () => new UserProfile());

            //    var oldStateMethod2 = conversationData.CounterData;   //.GetAsync(turnContext, () => new CounterState());

            //    // Bump the turn count for this conversation.
            //    var newStateMethod2 = new CounterData { TurnCount = oldStateMethod2.TurnCount + 1 };

            //    conversationData.CounterData = newStateMethod2;

            //    await conversationStateAccessors.SetAsync(turnContext, conversationData);

            //    // Echo back to the user whatever they typed.
            //    var responseMessage2 = $"Middleware4: Turn {newStateMethod2.TurnCount}: You sent '{turnContext.Activity.Text}'\n";
            //    await turnContext.SendActivityAsync(responseMessage2);
            //}
            //    // END STEP 1
            //    /////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            //    /////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////

            await next(cancellationToken).ConfigureAwait(false);

            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            //// STEP 2
            //// UNCOMMENT BELOW CODE
            //// Get the conversation state from the turn context.

            //if (turnContext.Activity.Type == ActivityTypes.Message)
            //{

            //turnContext.Activity.Text = await TranslateMessageAfterNextActivityAsync(turnContext.Activity.AsMessageActivity());

            //// Get the state properties from the turn context.
            //var conversationStateAccessors = _conversationState.CreateProperty<ConversationData>(nameof(ConversationData));
            //var conversationData = await conversationStateAccessors.GetAsync(turnContext, () => new ConversationData());

            //var userStateAccessors = _userState.CreateProperty<UserProfile>(nameof(UserProfile));
            //var userProfile = await userStateAccessors.GetAsync(turnContext, () => new UserProfile());

            //// Get the conversation state from the turn context.
            //var oldStateMethod2 = conversationData.CounterData;   //.GetAsync(turnContext, () => new CounterState());

            //// Bump the turn count for this conversation.
            //var newStateMethod2 = new CounterData { TurnCount = oldStateMethod2.TurnCount + 1 };

            //conversationData.CounterData = newStateMethod2;

            //await conversationStateAccessors.SetAsync(turnContext, conversationData);

            ////EXPERIMENT 2 - COMMENT OUT THE TWO "SaveChangesAsync" LINES
            ////THIS IS NECESSARY BECAUSE THE CHANGES GET SAVED AFTER THE TURN WHICH HAPPENS BEFORE THE `await next(cancellationToken).ConfigureAwait(false);`
            //await _conversationState.SaveChangesAsync(turnContext, false, cancellationToken);
            //await _userState.SaveChangesAsync(turnContext, false, cancellationToken);
            ////END EXPERIMENT 2 - COMMENT OUT THE TWO "SaveChangesAsync" LINES


            //// Echo back to the user whatever they typed.
            //var responseMessage2 = $"Middleware4AfterNext: Turn {newStateMethod2.TurnCount}: You sent '{turnContext.Activity.Text}'\n";
            //await turnContext.SendActivityAsync(responseMessage2);
            //}

            //// END STEP 2
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
            ///////////////////////////                /////////////////////////                /////////////////////////                /////////////////////////
        }

        private async Task<string> TranslateMessageActivityAsync(IMessageActivity activity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (activity.Type == ActivityTypes.Message)
            {
                var appendableString = activity.Text;
                appendableString += " + by Middleware4";
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
                appendableString += " + after the NEXT by Middleware4";
                return appendableString;
            }
            else
            {
                return "";
            }
        }
    }
}