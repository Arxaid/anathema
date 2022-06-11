// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Interactivity;
using DSharpPlus.Interactivity.Extensions;

using Anathema.Commands;
using Anathema.Utilities;
using Anathema.Database;

namespace Anathema
{
    internal class Auth
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }
        public InteractivityExtension Interactivity { get; private set; }
        public Utilities.EventHandler Handler { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;
            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);
            var configJson = JsonConvert.DeserializeObject<Utilities.ConfigJson>(json);

            var clientConfig = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
                Intents = DiscordIntents.All
            };
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                DmHelp = false,
                EnableMentionPrefix = true
            };
            var interactivityConfig = new InteractivityConfiguration
            {
                Timeout = TimeSpan.FromMinutes(10)
                //Timeout = TimeSpan.FromDays(7)
            };

            Connection.SetConnectionString(configJson.DBHost, 3306, configJson.DBName, configJson.DBUser, configJson.DBPassword);
            Tables.SetupTables();

            this.Client = new DiscordClient(clientConfig);
            this.Handler = new Utilities.EventHandler(this.Client);

            this.Client.Ready += this.Handler.OnClientReady;
            this.Client.MessageReactionAdded += this.Handler.OnReactionAdded;
            this.Client.MessageReactionRemoved += this.Handler.OnReactionRemoved;
            this.Client.UseInteractivity(interactivityConfig);

            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.SetHelpFormatter<CustomHelpFormatter>();
            Commands.RegisterCommands<BaseCommands>();
            Commands.RegisterCommands<FireteamCommands>();

            await this.Client.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}