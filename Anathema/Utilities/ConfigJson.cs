// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using Newtonsoft.Json;

namespace Anathema.Utilities
{
    public struct ConfigJson
    {
        [JsonProperty("botToken")]
        public string Token { get; private set; }

        [JsonProperty("botPrefix")]
        public string Prefix { get; private set; }

        [JsonProperty("databaseHost")]
        public string DBHost { get; private set; }

        [JsonProperty("databaseName")]
        public string DBName { get; private set; }

        [JsonProperty("databaseUser")]
        public string DBUser { get; private set; }

        [JsonProperty("databasePassword")]
        public string DBPassword { get; private set; }
    }
}