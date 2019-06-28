//TAKE A LOOK HERE FOR REFERENCE:
// BOT STATE
// https://github.com/microsoft/botbuilder-dotnet/blob/master/libraries/Microsoft.Bot.Builder/BotState.cs
// CONVERSATION STATE
// https://github.com/microsoft/botbuilder-dotnet/blob/master/libraries/Microsoft.Bot.Builder/ConversationState.cs
//
//

using Microsoft.Bot.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StateMiddlewareBot

{
    public class CounterState : BotState
    {
        public CounterState(IStorage storage)
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
    }
}


////METHOD 3
//namespace Microsoft.Bot.Builder
//{
//    public class CounterState : BotState
//    {
//        //       public int TurnCount { get; set; } = 0;

//        public CounterState(IStorage storage)
//                    : base(storage, nameof(ConversationState))
//        {
//        }

//        /// <summary>
//        /// Gets the key to use when reading and writing state to and from storage.
//        /// </summary>
//        /// <param name="turnContext">The context object for this turn.</param>
//        /// <returns>The storage key.</returns>
//        protected override string GetStorageKey(ITurnContext turnContext)
//        {
//            var channelId = turnContext.Activity.ChannelId ?? throw new ArgumentNullException("invalid activity-missing channelId");
//            var conversationId = turnContext.Activity.Conversation?.Id ?? throw new ArgumentNullException("invalid activity-missing Conversation.Id");
//            return $"{channelId}/conversations/{conversationId}";
//        }


//        //public CounterState3(int turnCount)
//        //{
//        //    TurnCount = turnCount;
//        //}

//        //public CounterState3(IStorage storage, string contextServiceKey) : base(storage, contextServiceKey)
//        //{
//        //}


//        //protected override string GetStorageKey(ITurnContext turnContext)
//        //{
//        //    throw new NotImplementedException();
//        //}

//        //public CounterState3(IStorage storage){};

//        //protected override string GetStorageKey(ITurnContext turnContext);
//    }
//}
