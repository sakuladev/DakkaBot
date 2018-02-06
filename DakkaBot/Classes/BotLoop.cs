using DakkaBot.Forms;
using DakkaBot.Helpers;
using Discord;
using Discord.Net.Providers.WS4Net;
using Discord.WebSocket;
using System;
using System.Threading.Tasks;

namespace DakkaBot.Classes
{
    public class BotLoop
    {
        private DiscordSocketClient _client;
        private MainWindow _mainWindow;

        public BotLoop(MainWindow mainWindow)
        {
            _client = new DiscordSocketClient(new DiscordSocketConfig()
            {
                LogLevel = LogSeverity.Verbose,
                WebSocketProvider = WS4NetProvider.Instance
            });
            _mainWindow = mainWindow;
        }

        public Task Log(LogMessage msg)
        {
            _mainWindow.AddLogMessage(msg.ToString());
            return Task.CompletedTask;
        }

        public async Task Loop()
        {
            try
            {
                _client.Log += Log;

                var token = AppGlobal.BotToken;

                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();

                await Task.Delay(-1);
            }
            catch (Exception e)
            {
                _mainWindow.AddLogMessage("Error: " + e.Message);
            }
        }
    }
}
