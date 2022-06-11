// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using System;

namespace Anathema.Utilities
{
    public class Activities
    {
        public static string PendingActivityContent(string arg)
        {
            /*                 No switches?
             *                 
             * ⠀⣞⢽⢪⢣⢣⢣⢫⡺⡵⣝⡮⣗⢷⢽⢽⢽⣮⡷⡽⣜⣜⢮⢺⣜⢷⢽⢝⡽⣝
             * ⠸⡸⠜⠕⠕⠁⢁⢇⢏⢽⢺⣪⡳⡝⣎⣏⢯⢞⡿⣟⣷⣳⢯⡷⣽⢽⢯⣳⣫⠇
             * ⠀⠀⢀⢀⢄⢬⢪⡪⡎⣆⡈⠚⠜⠕⠇⠗⠝⢕⢯⢫⣞⣯⣿⣻⡽⣏⢗⣗⠏
             * ⠀⠪⡪⡪⣪⢪⢺⢸⢢⢓⢆⢤⢀⠀⠀⠀⠀⠈⢊⢞⡾⣿⡯⣏⢮⠷⠁⠀
             * ⠀⠀⠀⠈⠊⠆⡃⠕⢕⢇⢇⢇⢇⢇⢏⢎⢎⢆⢄⠀⢑⣽⣿⢝⠲⠉⠀
             * ⠀⠀⠀⠀⠀⡿⠂⠠⠀⡇⢇⠕⢈⣀⠀⠁⠡⠣⡣⡫⣂⣿⠯⢪⠰⠂
             * ⠀⠀⠀⠀⡦⡙⡂⢀⢤⢣⠣⡈⣾⡃⠠⠄⠀⡄⢱⣌⣶⢏⢊⠂⠀
             * ⠀⠀⠀⠀⢝⡲⣜⡮⡏⢎⢌⢂⠙⠢⠐⢀⢘⢵⣽⣿⡿⠁⠁
             * ⠀⠀⠀⠀⠨⣺⡺⡕⡕⡱⡑⡆⡕⡅⡕⡜⡼⢽⡻⠏⠀⠀
             * ⠀⠀⠀⠀⣼⣳⣫⣾⣵⣗⡵⡱⡡⢣⢑⢕⢜⢕⡝⠀
             * ⠀⠀⠀⣴⣿⣾⣿⣿⣿⡿⡽⡑⢌⠪⡢⡣⣣⡟
             * ⠀⠀⠀⡟⡾⣿⢿⢿⢵⣽⣾⣼⣘⢸⢸⣞⡟⠀⠀
             * ⠀⠀⠀⠀⠁⠇⠡⠩⡫⢿⣝⡻⡮⣒⢽⠋⠀    ⠀⠀⠀⠀⠀
            */
            if (arg == "vod") { return "Vow of the Disciple"; };
            if (arg == "vog") { return "Vault of Glass"; };
            if (arg == "dsc") { return "Deep Stone Crypt"; };
            if (arg == "gos") { return "Garden of Salvation"; };
            if (arg == "lw") { return "The Last Wish"; };
            if (arg == "gm") { return "Ordeal Grandmaster"; };
            if (arg == "throne") { return "Shattered Throne"; };
            if (arg == "pit") { return "Pit of Heresy"; };
            if (arg == "prophecy") { return "The Prophecy"; };
            if (arg == "grasp") { return "Grasp of Avarice"; };
            return "Custom activity";
        }
        public static string PendingActivityImage(string arg)
        {
            if (arg == "vod") { return "https://i.imgur.com/eRx9fJJ.png"; };
            if (arg == "vog") { return "https://i.imgur.com/I27dEso.png"; };
            if (arg == "dsc") { return "https://i.imgur.com/1xWBXOF.png"; };
            if (arg == "gos") { return "https://i.imgur.com/uifPE7L.png"; };
            if (arg == "lw") { return "https://i.imgur.com/66WxX1F.png"; };
            if (arg == "gm" || arg == "nf") { return "https://i.imgur.com/c2ECtCC.png"; };
            if (arg == "grasp" || arg == "prophecy" || arg == "pit" || arg == "throne") { return "https://i.imgur.com/Lbu7kLw.png"; };
            return "https://i.imgur.com/qMIkdUq.png";
        }
        public static string PendingActivityTime(string arg)
        {
            char[] separators = { '.', '-' };
            string[] parsedTimeString = arg.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string modifiedTimeString = string.Empty;
            modifiedTimeString += parsedTimeString[0] + " ";

            if (parsedTimeString[1] == "01") { modifiedTimeString += "January"; };
            if (parsedTimeString[1] == "02") { modifiedTimeString += "February"; };
            if (parsedTimeString[1] == "03") { modifiedTimeString += "March"; };
            if (parsedTimeString[1] == "04") { modifiedTimeString += "Arpil"; };
            if (parsedTimeString[1] == "05") { modifiedTimeString += "May"; };
            if (parsedTimeString[1] == "06") { modifiedTimeString += "June"; };
            if (parsedTimeString[1] == "07") { modifiedTimeString += "July"; };
            if (parsedTimeString[1] == "08") { modifiedTimeString += "August"; };
            if (parsedTimeString[1] == "09") { modifiedTimeString += "September"; };
            if (parsedTimeString[1] == "10") { modifiedTimeString += "October"; };
            if (parsedTimeString[1] == "11") { modifiedTimeString += "November"; };
            if (parsedTimeString[1] == "12") { modifiedTimeString += "December"; };

            modifiedTimeString += ", " + parsedTimeString[2];
            return modifiedTimeString;
        }
    }
}