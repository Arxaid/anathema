// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

namespace Anathema
{
    class Client
    {
        static void Main(string[] args)
        {
            var AnathemaBot = new Auth();
            AnathemaBot.RunAsync().GetAwaiter().GetResult();
        }
    }
}