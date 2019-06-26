// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Connector.Authentication;
//using Microsoft.BotBuilderSamples.Translation;
using Microsoft.Extensions.Logging;

namespace MiddlewareBot
{
    public class AdapterWithErrorHandler : BotFrameworkHttpAdapter
    {
        public AdapterWithErrorHandler(ICredentialProvider credentialProvider, ILogger<BotFrameworkHttpAdapter> logger, TranslationMiddleware translationMiddleware, TranslationMiddleware2 translationMiddleware2, TranslationMiddleware3 translationMiddleware3)
            : base(credentialProvider)
        {
            if (credentialProvider == null)
            {
                throw new NullReferenceException(nameof(credentialProvider));
            }

            if (logger == null)
            {
                throw new NullReferenceException(nameof(logger));
            }

            if (translationMiddleware == null)
            {
                throw new NullReferenceException(nameof(translationMiddleware));
            }

            if (translationMiddleware2 == null)
            {
                throw new NullReferenceException(nameof(translationMiddleware2));
            }

            if (translationMiddleware3 == null)
            {
                throw new NullReferenceException(nameof(translationMiddleware2));
            }

            // Add translation middleware to the adapter's middleware pipeline
            Use(translationMiddleware);
            Use(translationMiddleware2);
            Use(translationMiddleware3);


            OnTurnError = async (turnContext, exception) =>
            {
                // Log any leaked exception from the application.
                logger.LogError($"Exception caught : {exception.Message}");

                // Send a catch-all apology to the user.
                await turnContext.SendActivityAsync("Sorry, it looks like something went wrong.");
            };
        }
    }
}
