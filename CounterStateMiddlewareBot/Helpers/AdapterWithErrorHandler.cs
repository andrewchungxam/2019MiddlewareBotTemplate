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
        public AdapterWithErrorHandler(ICredentialProvider credentialProvider, ILogger<BotFrameworkHttpAdapter> logger, TemplateMiddleware templateMiddleware, TemplateMiddleware2 templateMiddleware2, TemplateMiddleware3 templateMiddleware3, TemplateMiddleware4 templateMiddleware4, TemplateMiddleware5 templateMiddleware5)
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

            if (templateMiddleware == null)
            {
                throw new NullReferenceException(nameof(templateMiddleware));
            }

            if (templateMiddleware2 == null)
            {
                throw new NullReferenceException(nameof(templateMiddleware2));
            }

            if (templateMiddleware3 == null)
            {
                throw new NullReferenceException(nameof(templateMiddleware3));
            }
            
            if (templateMiddleware4 == null)
            {
                throw new NullReferenceException(nameof(templateMiddleware4));
            }

            // Add the template middleware to the adapter's middleware pipeline
            Use(templateMiddleware);
            Use(templateMiddleware2);
            Use(templateMiddleware3);
            Use(templateMiddleware4);
            Use(templateMiddleware5);

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
