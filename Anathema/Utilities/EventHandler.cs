// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;

using Anathema.Database;
using Anathema.Commands;

namespace Anathema.Utilities
{
    internal class EventHandler
    {
        private DiscordClient Client;
        public EventHandler(DiscordClient client) { this.Client = client; }

        internal Task OnClientReady(DiscordClient discordClient, ReadyEventArgs eventArgs)
        {
            Client.UpdateStatusAsync(new DiscordActivity("v1.03 | m!help", ActivityType.Watching), UserStatus.DoNotDisturb);
            return Task.CompletedTask;
        }

        internal async Task OnReactionAdded(DiscordClient discordClient, MessageReactionAddEventArgs eventArgs)
        {
            var joinEmoji = DiscordEmoji.FromName(discordClient, ":heavy_plus_sign:");
            var memberCounter = FireteamCommands.searchEmbed.Fields.Count;

            if (eventArgs.Emoji == joinEmoji && eventArgs.User != eventArgs.Message.Author)
            {
                Fireteam.FireteamAddMember(eventArgs.Message.Id, memberCounter, eventArgs.User.Id);

                await eventArgs.Message.ModifyAsync(msg => {
                    if (memberCounter > 1) { FireteamCommands.searchEmbed.RemoveFieldAt(1); }
                    FireteamCommands.searchEmbed.AddField("Fireteam members", "#" + memberCounter + " " + eventArgs.User.Mention + " - " + eventArgs.User.Username, inline: false);
                    msg.Embed = FireteamCommands.searchEmbed.Build();
                });
            }
        }

        internal async Task OnReactionRemoved(DiscordClient discordClient, MessageReactionRemoveEventArgs eventArgs)
        {
            var joinEmoji = DiscordEmoji.FromName(discordClient, ":heavy_plus_sign:");

            if (eventArgs.Emoji == joinEmoji)
            {
                if (eventArgs.User != eventArgs.Message.Author)
                {
                    await eventArgs.Message.ModifyAsync(msg =>
                    {
                        //FireteamCommands.searchEmbed
                        //msg.Embed = FireteamCommands.searchEmbed.Build();
                    });
                }
            }
        }
    }
}