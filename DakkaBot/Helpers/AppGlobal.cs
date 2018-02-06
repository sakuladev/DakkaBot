using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DakkaBot.Helpers
{
    public static class AppGlobal
    {
        public static string BotToken
        {
            get { return ConfigurationManager.AppSettings["BotToken"]; }
        }
    }
}
