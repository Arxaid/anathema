// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using System.Collections.Generic;

using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Converters;
using DSharpPlus.CommandsNext.Entities;
using DSharpPlus.Entities;

namespace Anathema.Utilities
{
    public class CustomHelpFormatter : BaseHelpFormatter
    {
        protected DiscordEmbedBuilder helpEmbed;

        public CustomHelpFormatter(CommandContext ctx) : base(ctx)
        {
            helpEmbed = new DiscordEmbedBuilder
            {
                Title = "Anathema Help",
                Color = DiscordColor.Black
            };
        }

        public override BaseHelpFormatter WithCommand(Command cmd)
        {
            helpEmbed.AddField(cmd.Name, cmd.Description);
            return this;
        }

        public override BaseHelpFormatter WithSubcommands(IEnumerable<Command> cmds)
        {
            foreach (var cmd in cmds)
            {
                helpEmbed.AddField(cmd.Name, cmd.Description);
            }
            return this;
        }

        public override CommandHelpMessage Build()
        {
            return new CommandHelpMessage(embed: helpEmbed);
        }
    }
}