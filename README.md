# 2019MiddlewareBotTemplate
2019 Middleware Bot Template

There are two projects included:

One is called the Middlewarebot; it is based on the official Bot Framework v4 echo bot sample.

This bot has been created using [Bot Framework](https://dev.botframework.com), it shows how to create a simple bot that accepts input from the user and echoes it back.

There has been several elements that contain changes from the standard template:
- Startup.cs
- AdapterWithErrorHandler.cs
- TemplateMiddleware.cs
- TemplateMiddleware2.cs
- TemplateMiddleware3.cs

When you want to add your own middleware, you'll need to know where all the middleware pieces need to be declared.  Search in the project for TemplateMiddleware3 as an example. 

The other is called StateMiddlewareBot.  

It is duplicated from the MiddlewareBot and then added the ability to maintain UserState.

Comment out all Middleware - you'll see the normal Echo + counter behavior with each interaction adding one count to the displayed counter.  
- Then in the StateMiddleware, we'll simply have the middleware add one count (ie. you'll see the counter jump up more than one at a time.)  
- Then in StateMiddleware2, we'll have the middleware add another count (you'll see futher jumps.)   -Finally in StateMiddleware3, we'll have the middleware add a count for each message that is sent out (you'll see accelerated jumps.)

By doing these three examples, we'll see how Middleware interacts with your bot, interacts with each other (when there is multiple parts to your Middleware), and finally, how you can fine-tune your Middleware to only act in certain instances.

In StateMiddleware, 

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
