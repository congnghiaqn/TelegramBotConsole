using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace TelegramBotConsole;

public static class Program
{
    private static TelegramBotClient? Bot;
    public static async Task Main()
    {
        Bot = new TelegramBotClient(BotConfig.BotToken);
        var me = await Bot.GetMeAsync();
        Console.Title = me.Username;
        using var cts = new CancellationTokenSource();
        Bot.StartReceiving(new DefaultUpdateHandler(BotHandler.HandleUpdateAsync, BotHandler.HandleErrorAsync),
                           cts.Token);
        Console.WriteLine($"Start listening for @{me.Username}");
        Console.ReadLine();
        cts.Cancel();
    }
}