using DakkaBot.Classes;
using System;
using System.Text;
using System.Windows.Forms;

namespace DakkaBot.Forms
{
    public partial class MainWindow : Form
    {
        public string MessageLog
        {
            get => txtLog.Text;
            set => txtLog.Text = value;
        }

        public void AddLogMessage(string message)
        {
            var logLinePrefix = $"[{DateTime.Now.ToString("hh:mm:ss")}] ";
            var logLine = new StringBuilder();
            logLine.Append(logLinePrefix);
            logLine.Append(message);
            logLine.AppendLine(Environment.NewLine);

            if(InvokeRequired)
            {
                Invoke(new Action<string>(AddLogMessage), new object[] { message });
                return;
            }

            MessageLog += logLine.ToString();
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void btnActivate_Click(object sender, EventArgs e)
        {
            var botLoop = new BotLoop(this);

            await botLoop.Loop();
        }
    }
}
