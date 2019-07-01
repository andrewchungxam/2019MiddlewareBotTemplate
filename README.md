# 2019MiddlewareBotTemplate
2019 Middleware Bot Template

There are two projects included:

### MiddlewareBot
One is called the Middlewarebot; it is based on the official Bot Framework v4 echo bot sample.

This bot has been created using [Bot Framework](https://dev.botframework.com), it shows how to create a simple bot that accepts input from the user and echoes it back.

There has been several elements that contain changes from the standard template:
- Startup.cs
- AdapterWithErrorHandler.cs
- TemplateMiddleware.cs
- TemplateMiddleware2.cs
- TemplateMiddleware3.cs

When you want to add your own middleware, you'll need to know where all the middleware pieces need to be declared.  Search in the project for TemplateMiddleware3 as an example. 

### CounterStateMiddlewareBot
The other is called StateMiddlewareBot.  

It is duplicated from the MiddlewareBot and then added the ability to maintain UserState.

Comment out all Middleware - you'll see the normal Echo + counter behavior with each interaction adding one count to the displayed counter.  
- Then in the StateMiddleware, we'll simply have the middleware add one count (ie. you'll see the counter jump up more than one at a time.)  
- Then in StateMiddleware2, we'll have the middleware add another count (you'll see futher jumps.)   -Finally in StateMiddleware3, we'll have the middleware add a count for each message that is sent out (you'll see accelerated jumps.)

Through these interactions, we'll see how Middleware interacts with your bot, interacts with each other (when there is multiple parts to your Middleware), and saves state, and finally, how you can fine-tune your Middleware to only act in certain instances.


### StateMiddlewareBot
The other is called StateMiddlewareBot.  

It is duplicated from the MiddlewareBot and then added the ability to maintain UserState (similar to what we did with the CounterStateMiddlewareBot).
It also contains elements from the project [Bot Builder project](https://github.com/microsoft/botbuilder-dotnet).  Look at the project, StateManagementBot there and look at the StateManagementBot.cs file.

Look in the Middleware folder - TemplateMiddleware and TemplateMiddleware2.cs.  The  ```await turnContext.SendActivityAsync($"ABC ");``` are commented out so these files are mostly inert.  You can uncomment these statements to see how it interact with the rest of the Middleware / Bot.

The main meat of the sample is in TemplateMiddleware3.cs.
There are 4 experiments.  Manage the commenting/uncommenting of code so that you only have 1 experiment running at a time.

Each experiment has instructions on pinning variables in Visual Studio. This will help you see what variables/values are flowing through your code.  https://blogs.msdn.microsoft.com/benwilli/2015/04/08/visual-studio-tip-2-pin-your-data-tips/

#### Run Experiment 1 
Uncomment Experiment 1 - run the project.  What changed about the sent messages?   

Do you notice anything about outputs that are sent? Set a breakpoint before and after ```await nextSend();``` and pay attention the sequence of sent messages as it relates to the ```await nextSend();``` The idea of this is to realize how / when the following code is run: 
```
//WHEN DOES THIS HAPPEN?
turnContext.OnSendActivities(async (newContext, activities, nextSend) =>
{
  //wHEN DOES THIS HAPPEN?
  await nextSend();
  //WHEN DOES THIS HAPPEN? 
}
```
#### Run Experiment 2
The code for experiment 2 is similar but the code after the ```await nextSend()``` has been eliminated.  

Uncomment Experiment 2 - remember to re-comment out Experiment 1.  Run the project.  What changed about the sent messages?   

#### Run Experiment 3
Before we run the next experiment - take a step back.  You've pinned the variable, you're noticing that after the TranslateMessageActivityAsync is hit, the string changes.  However, when you look at the sent messages, the messages sent originating from the Bot are not being changed.  

Now in the previous project, the CounterStateMiddlewareBot we added ```turnContext.SendActivityAsync(string);``` in various points in the middleware to send messages to the user.  Let's do that again in this experiment - Experiment 3. 

Uncomment Experiment 3 - remember to re-comment out Experiment 2.  Run the project.  What happens? Why did it happen?

#### Run experiment 4
After Experiment 3 - if there are any issues, you may need to close the project and Visual Studio and run it again.

Uncomment Experiment 4 - remember to re-comment out Experiment 3.  Run the project.   What happens to the messages?  What gets changed?  Why did it change?  What was added to the code to create the behavior you see.



<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />

## Prerequisites

- [.NET Core SDK](https://dotnet.microsoft.com/download) version 2.1

  ```bash
  # determine dotnet version
  dotnet --version
  ```

## To try this sample

- In a terminal, navigate to `MiddlewareBot`

    ```bash
    # change into project folder
    cd # MiddlewareBot
    ```

- Run the bot from a terminal or from Visual Studio, choose option A or B.

  A) From a terminal

  ```bash
  # run the bot
  dotnet run
  ```

  B) Or from Visual Studio

  - Launch Visual Studio
  - File -> Open -> Project/Solution
  - Navigate to `MiddlewareBot` folder
  - Select `MiddlewareBot.csproj` file
  - Press `F5` to run the project

## Testing the bot using Bot Framework Emulator

[Bot Framework Emulator](https://github.com/microsoft/botframework-emulator) is a desktop application that allows bot developers to test and debug their bots on localhost or running remotely through a tunnel.

- Install the Bot Framework Emulator version 4.3.0 or greater from [here](https://github.com/Microsoft/BotFramework-Emulator/releases)

### Connect to the bot using Bot Framework Emulator

- Launch Bot Framework Emulator
- File -> Open Bot
- Enter a Bot URL of `http://localhost:3978/api/messages`

## Deploy the bot to Azure

To learn more about deploying a bot to Azure, see [Deploy your bot to Azure](https://aka.ms/azuredeployment) for a complete list of deployment instructions.

## Further reading

- [Bot Framework Documentation](https://docs.botframework.com)
- [Bot Basics](https://docs.microsoft.com/azure/bot-service/bot-builder-basics?view=azure-bot-service-4.0)
- [Activity processing](https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-concept-activity-processing?view=azure-bot-service-4.0)
- [Azure Bot Service Introduction](https://docs.microsoft.com/azure/bot-service/bot-service-overview-introduction?view=azure-bot-service-4.0)
- [Azure Bot Service Documentation](https://docs.microsoft.com/azure/bot-service/?view=azure-bot-service-4.0)
- [.NET Core CLI tools](https://docs.microsoft.com/en-us/dotnet/core/tools/?tabs=netcore2x)
- [Azure CLI](https://docs.microsoft.com/cli/azure/?view=azure-cli-latest)
- [Azure Portal](https://portal.azure.com)
- [Language Understanding using LUIS](https://docs.microsoft.com/en-us/azure/cognitive-services/luis/)
- [Channels and Bot Connector Service](https://docs.microsoft.com/en-us/azure/bot-service/bot-concepts?view=azure-bot-service-4.0)
