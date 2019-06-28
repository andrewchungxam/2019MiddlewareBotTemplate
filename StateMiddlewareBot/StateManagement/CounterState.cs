using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateMiddlewareBot
{
    public class CounterState
    {
        public int TurnCount { get; set; } = 0;
    }
}

//METHOD 3
namespace Microsoft.Bot.Builder
{
    public class CounterState3 : BotState
    {
        public int TurnCount { get; set; } = 0;

        public CounterState3(IStorage storage)
                    : base(storage, nameof(ConversationState))
        {
        }

        /// <summary>
        /// Gets the key to use when reading and writing state to and from storage.
        /// </summary>
        /// <param name="turnContext">The context object for this turn.</param>
        /// <returns>The storage key.</returns>
        protected override string GetStorageKey(ITurnContext turnContext)
        {
            var channelId = turnContext.Activity.ChannelId ?? throw new ArgumentNullException("invalid activity-missing channelId");
            var conversationId = turnContext.Activity.Conversation?.Id ?? throw new ArgumentNullException("invalid activity-missing Conversation.Id");
            return $"{channelId}/conversations/{conversationId}";
        }


        //public CounterState3(int turnCount)
        //{
        //    TurnCount = turnCount;
        //}

        //public CounterState3(IStorage storage, string contextServiceKey) : base(storage, contextServiceKey)
        //{
        //}


        //protected override string GetStorageKey(ITurnContext turnContext)
        //{
        //    throw new NotImplementedException();
        //}

        //public CounterState3(IStorage storage){};

        //protected override string GetStorageKey(ITurnContext turnContext);
    }
}
