using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;
//using MiddlewareBot.Middleware;

namespace MiddlewareBot
{
    /// <summary>
    /// Middleware for translating text between the user and bot.
    /// Uses the Microsoft Translator Text API.
    /// </summary>
    public class TemplateMiddleware3 : IMiddleware
    {
        public TemplateMiddleware3()
        {

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

            if (turnContext.Activity.Type == ActivityTypes.Message)
            {
                turnContext.Activity.Text = await TranslateMessageActivityAsync(turnContext.Activity.AsMessageActivity());
            }

            turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
            {
                List<Task> tasks = new List<Task>();
                foreach (Activity currentActivity in activities.Where(a => a.Type == ActivityTypes.Message))
                {
                    tasks.Add(TranslateMessageActivityAsync(currentActivity.AsMessageActivity())); //, userLanguage));
                }

                if (tasks.Any())
                {
                    await Task.WhenAll(tasks).ConfigureAwait(false);
                }

                return await nextSend();
            });

            turnContext.OnUpdateActivity(async (newContext, activity, nextUpdate) =>
            {
                //// Translate messages sent to the user to user language
                if (activity.Type == ActivityTypes.Message)
                {
                    await TranslateMessageActivityAsync(activity.AsMessageActivity());//, userLanguage);
                }
                return await nextUpdate();
            });

            await next(cancellationToken).ConfigureAwait(false);
        }

        private async Task<string> TranslateMessageActivityAsync(IMessageActivity activity, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (activity.Type == ActivityTypes.Message)
            {
                var appendableString = activity.Text;
                appendableString += " + by Middleware";
                return appendableString;
            }
            else
            {
                return "";
            }
        }
    }
}