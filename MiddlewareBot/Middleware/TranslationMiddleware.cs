using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

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
    }
}
