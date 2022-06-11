// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using System.Threading.Tasks;

using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

using Anathema.Database;
using Anathema.Utilities;

namespace Anathema.Commands
{
    [Group("fireteam")]
    [Description("ver.1.02")]
    public class FireteamCommands : BaseCommandModule
    {
        public static DiscordEmbedBuilder searchEmbed;

        [Command("search")]
        [Description("ver.1.02")]
        public async Task Search(CommandContext ctx, string ActivityType, string ActivityTime, params string[] ActivityContent)
        {
            var ActivityComment = string.Empty;
            foreach (var content in ActivityContent) { ActivityComment += content + " "; }

            searchEmbed = new DiscordEmbedBuilder
            {
                Title = Activities.PendingActivityContent(ActivityType) + " " + Activities.PendingActivityTime(ActivityTime),
                Description = ActivityComment,
                Color = DiscordColor.Black
            };
            searchEmbed.AddField("Fireteam leader", "#1 " + ctx.Member.Mention + " - " + ctx.Member.Username);
            searchEmbed.WithThumbnail(Activities.PendingActivityImage(ActivityType));

            await ctx.TriggerTypingAsync().ConfigureAwait(false);
            var searchMessage = await ctx.Channel.SendMessageAsync(embed: searchEmbed).ConfigureAwait(false);
            await searchMessage.ModifyAsync(msg => {
                searchEmbed.WithFooter("Fireteam search ID: " + searchMessage.Id.ToString());
                msg.Embed = searchEmbed.Build();
            }).ConfigureAwait(false);

            if (!Fireteam.FireteamCreate(searchMessage.Id, ctx.Guild.Id, ctx.Member.Id))
            {
                await ctx.Channel.SendMessageAsync(embed: CommandsEmbeds.errorDatabaseEmbed).ConfigureAwait(false);
            }

            var joinEmoji = DiscordEmoji.FromName(ctx.Client, ":heavy_plus_sign:");
            await searchMessage.CreateReactionAsync(joinEmoji).ConfigureAwait(false);
        }

        [Command("cancel")]
        [Description("ver.1.02")]
        public async Task Cancel(CommandContext ctx, ulong fireteamSearchID)
        {
            var cancelFireteam = await ctx.Channel.GetMessageAsync(fireteamSearchID).ConfigureAwait(false);
            var cancelUser = await ctx.Guild.GetMemberAsync(Fireteam.FireteamGetLeader(cancelFireteam.Id)).ConfigureAwait(false);
            var confirmEmoji = DiscordEmoji.FromName(ctx.Client, ":heavy_check_mark:");

            if (ctx.Member == cancelUser)
            {
                await cancelFireteam.DeleteAsync().ConfigureAwait(false);
                await ctx.Message.CreateReactionAsync(confirmEmoji).ConfigureAwait(false);
                Fireteam.FireteamDelete(cancelFireteam.Id);
            }
            else
            {
                await ctx.Channel.SendMessageAsync(embed: CommandsEmbeds.errorLeaderEmbed).ConfigureAwait(false);
            }
        }
    }
}