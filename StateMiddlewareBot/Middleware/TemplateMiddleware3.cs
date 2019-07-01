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

            ////EXPERIMENT 1 - 
            // IN VISUAL STUDIO > CREATE BREAK POINT ON THE LINE CONTAINING `activities,Where(a=>...)` , THEN OPEN AND PIN VARIABLES > 1) ACTIVITIES + 2) TEXT + 3) TYPE
            ///
            //turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
            //{
            //    List<Task> tasks = new List<Task>();
            //    foreach (Activity currentActivity in activities.Where(a => a.Type == ActivityTypes.Message))
            //    {
            //        tasks.Add(TranslateMessageActivityAsync(currentActivity.AsMessageActivity())); //, userLanguage));
            //    }
            //
            //    if (tasks.Any())
            //    {
            //        await Task.WhenAll(tasks).ConfigureAwait(false);
            //    }
            //
            //    await nextSend();
            //
            // IN VISUAL STUDIO > CREATE BREAK POINT ON THE LINE CONTAINING `activities,Where(a=>...)` , THEN OPEN AND PIN VARIABLES > 1) ACTIVITIES + 2) TEXT + 3) TYPE
            //    List<Task> tasksAfterNextSend = new List<Task>();
            //    foreach (Activity currentActivityAfterNextSend in activities.Where(a => a.Type == ActivityTypes.Message))
            //    {
            //        tasksAfterNextSend.Add(TranslateMessageActivityAsync(currentActivityAfterNextSend.AsMessageActivity())); //, userLanguage));
            //    }
            //
            //    if (tasksAfterNextSend.Any())
            //    {
            //        await Task.WhenAll(tasksAfterNextSend).ConfigureAwait(false);
            //    }
            //
            //    return await nextSend();
            //});
            //END OF EXPERIMENT 1

            //EXPERIMENT 2
            // IN VISUAL STUDIO > CREATE BREAK POINT ON THE LINE CONTAINING `activities,Where(a=>...)` , THEN OPEN AND PIN VARIABLES > 1) ACTIVITIES + 2) TEXT + 3) TYPE
            //turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
            //{
            //    List<Task> tasks = new List<Task>();
            //    foreach (Activity currentActivity in activities.Where(a => a.Type == ActivityTypes.Message))
            //    {
            //        tasks.Add(TranslateMessageActivityAsync(currentActivity.AsMessageActivity())); //, userLanguage));
            //    }
            //
            //    if (tasks.Any())
            //    {
            //        await Task.WhenAll(tasks).ConfigureAwait(false);
            //    }
            //
            //    return await nextSend();
            //
            //});
            //END OF EXPERIMENT 2


            //EXPERIMENT 3
            // IN VISUAL STUDIO > CREATE BREAK POINT ON THE LINE CONTAINING `activities,Where(a=>...)` , THEN OPEN AND PIN VARIABLES > 1) ACTIVITIES + 2) TEXT + 3) TYPE
            // SCROLL DOWN TO METHOD TranslateMessageActivityAsync AND OPEN/PIN VARIABLE FOR RETURN appendableString
            //turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
            //{
            //    List<Task> tasks = new List<Task>();
            //    foreach (Activity currentActivity in activities.Where(a => a.Type == ActivityTypes.Message))
            //    {
            //        tasks.Add(TranslateMessageActivityAsync(currentActivity.AsMessageActivity())); //, userLanguage));
            //
            //        var appendedString = await TranslateMessageActivityAsync(currentActivity.AsMessageActivity());
            //        await turnContext.SendActivityAsync(appendedString);
            //    }
            //
            //    if (tasks.Any())
            //    {
            //        await Task.WhenAll(tasks).ConfigureAwait(false);
            //    }
            //
            //    return await nextSend();
            //
            //});
            //END OF EXPERIMENT 3


            //EXPERIMENT 4
            // IN VISUAL STUDIO > CREATE BREAK POINT ON THE LINE CONTAINING `activities,Where(a=>...)` , THEN OPEN AND PIN VARIABLES > 1) ACTIVITIES + 2) TEXT + 3) TYPE
            // SCROLL DOWN TO METHOD TranslateMessageActivityAsync AND OPEN/PIN VARIABLE FOR RETURN appendableString
            turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
            {
                List<Task> tasks = new List<Task>();
                foreach (Activity currentActivity in activities.Where(a => a.Type == ActivityTypes.Message))
                {
                    tasks.Add(TranslateMessageActivityAsync(currentActivity.AsMessageActivity())); //, userLanguage));

                    var appendedString = await TranslateMessageActivityAsync(currentActivity.AsMessageActivity());
                    currentActivity.Text = appendedString;
                }

                if (tasks.Any())
                {
                    await Task.WhenAll(tasks).ConfigureAwait(false);
                }

                return await nextSend();

            });
            //END OF EXPERIMENT 4


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

            //BONUS : UNCOMMENT NOTICE THAT IT DOESN'T DO ANYTHING!
            //THIS DOES NOT ADD ANYTHING AND WONT BE CALLED
            //ALTHOUGH THIS IS WRITEN AFTER THE NEXT(CANCELLATIONTOKEN).CONFIGUREAWAIT(FALSE); 
            //THE turnContext.OnSendActivities...CAN SIMPLY BE WRITTEN ABOVE IT AND THEN WITHIN THE METHOD YOU CAN SPLIT BEFORE / AFTER SEND CODE WITH AN AWAIT NEXTSEND() IN THE METHOD.
            //
            //turnContext.OnSendActivities(async (nextContext, activities, nextSend) =>
            //{
            //    List<Task> tasks = new List<Task>();
            //    foreach (Activity currentActivity in activities.Where(a => a.Type == ActivityTypes.Message))
            //    {
            //        tasks.Add(TranslateMessageActivityAsync(currentActivity.AsMessageActivity())); //, userLanguage));
            //    }
            //
            //    if (tasks.Any())
            //    {
            //        await Task.WhenAll(tasks).ConfigureAwait(false);
            //    }
            //
            //    await nextSend();
            //
            //    List<Task> tasksAfterNextSend = new List<Task>();
            //    foreach (Activity currentActivityAfterNextSend in activities.Where(a => a.Type == ActivityTypes.Message))
            //    {
            //        tasks.Add(TranslateMessageActivityAsync(currentActivityAfterNextSend.AsMessageActivity())); //, userLanguage));
            //    }
            //
            //    if (tasks.Any())
            //    {
            //        await Task.WhenAll(tasks).ConfigureAwait(false);
            //    }
            //
            //    return await nextSend();
            //});
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