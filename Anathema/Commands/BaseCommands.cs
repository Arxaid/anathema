// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using System.Linq;
using System.Threading.Tasks;

using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;

namespace Anathema.Commands
{
    public class BaseCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Default alive check.")]
        [Aliases("pong")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
        }
    }
}