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
    public class TranslationMiddleware : IMiddleware
    {
        public TranslationMiddleware()
        {
        }
        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (turnContext == null)
            {
                throw new ArgumentNullException(nameof(turnContext));
            }

            await turnContext.SendActivityAsync($"MIDDLEWARE1 - BEFORE ANY ACTIVITY ");

            await next(cancellationToken).ConfigureAwait(false);

            await turnContext.SendActivityAsync($"MIDDLEWARE1 - AFTER ANY ACTIVITY ");
            
        }


        //public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
        //{
        //    if (turnContext == null)
        //    {
        //        throw new ArgumentNullException(nameof(turnContext));
        //    }

        //    turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
        //    {

        //        // run full pipeline
        //        var responses = await nextSend().ConfigureAwait(false);

        //        foreach (var activity in activities)
        //        {
        //            //await _cosmosTranscriptStore.LogActivityAsync(activity);
        //        }

        //        return responses;
        //    });

        //    turnContext.OnUpdateActivity(async (newContext, activity, nextUpdate) =>
        //    {
        //        if (activity.Type == ActivityTypes.Message)
        //        {
        //        }

        //        return await nextUpdate();
        //    });

        //    await next(cancellationToken).ConfigureAwait(false);
        //}
    }
}


    //using System;
    //using System.Collections.Generic;
    //using System.Linq;
    //using System.Threading;
    //using System.Threading.Tasks;
    //using Microsoft.Bot.Builder;
    //using Microsoft.Bot.Schema;
    ////using MiddlewareBot.Middleware;

    //namespace MiddlewareBot
    //{

    //    public class TranslationMiddleware : IMiddleware
    //    {
    //        //private readonly CosmosTranscriptStore _cosmosTranscriptStore;
    //        //public TranslationMiddleware(CosmosTranscriptStore cosmosTranscriptStore)
    //        //{
    //        //    _cosmosTranscriptStore = cosmosTranscriptStore ?? throw new ArgumentNullException(nameof(cosmosTranscriptStore));
    //        //}

    //        //private static CosmosTranscriptStore _cosmosTranscriptStore = new CosmosTranscriptStore();
    //        public TranslationMiddleware()
    //        {
    //        }

    //        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
    //        {
    //            if (turnContext == null)
    //            {
    //                throw new ArgumentNullException(nameof(turnContext));
    //            }

    ////            await _cosmosTranscriptStore.LogActivityAsync(turnContext.Activity);

    //            turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
    //            {
    //                //await _cosmosTranscriptStore.LogActivityAsync(turnContext.Activity);
    //                //await _cosmosTranscriptStore.LogActivityAsync(activities[0]);

    //                //THIS IS CREATING SOME 

    //                //foreach (var activity in activities)
    //                //{
    //                //    if (activity.Text != null)
    //                //        await _cosmosTranscriptStore.LogActivityAsync(activity);
    //                //}
    //                //return await nextSend();


    //                //// run full pipeline
    //                //var responses = await nextSend().ConfigureAwait(false);

    //                //foreach (var activity in activities)
    //                //{
    //                //    _telemetryClient.TrackEvent(BotMsgSendEvent, FillSendEventProperties(activity));
    //                //}

    //                //return responses;

    //                // run full pipeline
    //                var responses = await nextSend().ConfigureAwait(false);

    //                foreach (var activity in activities)
    //                {
    //                    //await _cosmosTranscriptStore.LogActivityAsync(activity);
    //                }

    //                return responses;
    //            });

    //            turnContext.OnUpdateActivity(async (newContext, activity, nextUpdate) =>
    //            {
    //                if (activity.Type == ActivityTypes.Message)
    //                {
    //                }

    //                return await nextUpdate();
    //            });

    //            await next(cancellationToken).ConfigureAwait(false);
    //        }
    //    }

    //public class TranslationMiddleware : IMiddleware
    //{
    //    public TranslationMiddleware()
    //    {
    //    }

    //    public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
    //    {
    //        if (turnContext == null)
    //        {
    //            throw new ArgumentNullException(nameof(turnContext));
    //        }

    //        turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
    //        {
    //            return await nextSend();
    //        });

    //        turnContext.OnUpdateActivity(async (newContext, activity, nextUpdate) =>
    //        {
    //            if (activity.Type == ActivityTypes.Message)
    //            {
    //            }

    //            return await nextUpdate();
    //        });

    //        await next(cancellationToken).ConfigureAwait(false);
    //    }
    //}
//}


//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading;
//using System.Threading.Tasks;
//using Microsoft.Bot.Builder;
//using Microsoft.Bot.Schema;
////using MiddlewareBot.Middleware;

//namespace MiddlewareBot
//{

//    public class TranslationMiddleware : IMiddleware
//    {
//        private readonly CosmosTranscriptStore _cosmosTranscriptStore;
//        public TranslationMiddleware(CosmosTranscriptStore cosmosTranscriptStore)
//        {
//            _cosmosTranscriptStore = cosmosTranscriptStore ?? throw new ArgumentNullException(nameof(cosmosTranscriptStore));
//        }

//        //private static CosmosTranscriptStore _cosmosTranscriptStore = new CosmosTranscriptStore();
//        //public TranslationMiddleware()
//        //{
//        //}

//        public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
//        {
//            if (turnContext == null)
//            {
//                throw new ArgumentNullException(nameof(turnContext));
//            }

//            await _cosmosTranscriptStore.LogActivityAsync(turnContext.Activity);

//            turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
//            {
//                //await _cosmosTranscriptStore.LogActivityAsync(turnContext.Activity);
//                //await _cosmosTranscriptStore.LogActivityAsync(activities[0]);

//                //THIS IS CREATING SOME 

//                //foreach (var activity in activities)
//                //{
//                //    if (activity.Text != null)
//                //        await _cosmosTranscriptStore.LogActivityAsync(activity);
//                //}
//                //return await nextSend();


//                //// run full pipeline
//                //var responses = await nextSend().ConfigureAwait(false);

//                //foreach (var activity in activities)
//                //{
//                //    _telemetryClient.TrackEvent(BotMsgSendEvent, FillSendEventProperties(activity));
//                //}

//                //return responses;

//                // run full pipeline
//                var responses = await nextSend().ConfigureAwait(false);

//                foreach (var activity in activities)
//                {
//                    await _cosmosTranscriptStore.LogActivityAsync(activity);
//                }

//                return responses;
//            });

//            turnContext.OnUpdateActivity(async (newContext, activity, nextUpdate) =>
//            {
//                if (activity.Type == ActivityTypes.Message)
//                {
//                }

//                return await nextUpdate();
//            });

//            await next(cancellationToken).ConfigureAwait(false);
//        }
//    }

//    //public class TranslationMiddleware : IMiddleware
//    //{
//    //    public TranslationMiddleware()
//    //    {
//    //    }

//    //    public async Task OnTurnAsync(ITurnContext turnContext, NextDelegate next, CancellationToken cancellationToken = default(CancellationToken))
//    //    {
//    //        if (turnContext == null)
//    //        {
//    //            throw new ArgumentNullException(nameof(turnContext));
//    //        }

//    //        turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
//    //        {
//    //            return await nextSend();
//    //        });

//    //        turnContext.OnUpdateActivity(async (newContext, activity, nextUpdate) =>
//    //        {
//    //            if (activity.Type == ActivityTypes.Message)
//    //            {
//    //            }

//    //            return await nextUpdate();
//    //        });

//    //        await next(cancellationToken).ConfigureAwait(false);
//    //    }
//    //}
//}
