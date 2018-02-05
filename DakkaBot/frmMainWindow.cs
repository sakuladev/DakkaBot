using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Discord;
using Discord.Net;
using Discord.Commands;
using Discord.WebSocket;

namespace DakkaBot
{
    public partial class frmMainWindow : Form
    {
        public frmMainWindow()
        {
            InitializeComponent();
        }

        public Task Log(LogMessage msg)
        {
            txtLog.Text += msg.ToString();
            return Task.CompletedTask;
        }

        private DiscordSocketClient _client;

        public async Task Loop()
        {
            try
            {
                _client = new DiscordSocketClient();
                _client.Log += Log;

                string token = "NDA5OTc5MzE4NDg0MzM2NjQw.DVoI0Q.Yn-JkxV5KjwTn58FKgyc4xejAUY";

                await _client.LoginAsync(TokenType.Bot, token);
                await _client.StartAsync();

                await Task.Delay(-1);
            }
            catch (Exception e)
            {
                txtLog.Text += "Error: " + e.Message;

            }
        }

        private void btnActivate_Click(object sender, EventArgs e)
            => new frmMainWindow().Loop().GetAwaiter().GetResult();
    }
}
