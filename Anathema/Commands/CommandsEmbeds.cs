// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using DSharpPlus.Entities;

namespace Anathema.Commands
{
    internal class CommandsEmbeds
    {
        public static DiscordEmbedBuilder errorDatabaseEmbed = new DiscordEmbedBuilder
        {
            Title = "Undefined database error.",
            Color = DiscordColor.Red
        };
        public static DiscordEmbedBuilder errorLeaderEmbed = new DiscordEmbedBuilder
        {
            Title = "Only the fireteam leader can cancel the search.",
            Color = DiscordColor.Red
        };
        public static DiscordEmbedBuilder errorExistingEmbed = new DiscordEmbedBuilder
        {
            Title = "Current fireteam does not exists.",
            Color = DiscordColor.Red
        };
    }
}