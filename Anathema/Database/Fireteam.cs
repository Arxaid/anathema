// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using MySql.Data.MySqlClient;

namespace Anathema.Database
{
    public static class Fireteam
    {
        public static bool FireteamCreate(ulong fireteamID, ulong guildID, ulong leaderID)
        {
            using (MySqlConnection connection = Connection.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(@"INSERT INTO fireteam(fireteam_id, fireteam_guild, fireteam_time, fireteam_leader)" +
                                                         "VALUES (@FireteamID, @FireteamGuild, UTC_TIMESTAMP(), @FireteamLeader);", connection);

                    cmd.Parameters.AddWithValue("@FireteamID", fireteamID);
                    cmd.Parameters.AddWithValue("@FireteamGuild", guildID);
                    cmd.Parameters.AddWithValue("@FireteamLeader", leaderID);
                    cmd.Prepare();

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public static bool FireteamDelete(ulong fireteamID)
        {
            using (MySqlConnection connection = Connection.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(@"DELETE FROM fireteam WHERE fireteam_id=@FireteamID", connection);

                    cmd.Parameters.AddWithValue("@FireteamID", fireteamID);
                    cmd.Prepare();

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public static ulong FireteamGetLeader(ulong fireteamID)
        {
            using (MySqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(@"SELECT fireteam_leader FROM fireteam WHERE fireteam_id=@FireteamID", connection);

                cmd.Parameters.AddWithValue("@FireteamID", fireteamID);
                cmd.Prepare();

                MySqlDataReader result = cmd.ExecuteReader();
                if (result.Read())
                {
                    var fireteamLeader = (ulong)result["fireteam_leader"];
                    return fireteamLeader;
                }
                result.Close();
            }
            return 1;
        }

        public static bool FireteamAddMember(ulong fireteamID, int memberCounter, ulong memberID)
        {
            using (MySqlConnection connection = Connection.GetConnection())
            {
                try
                {
                    connection.Open();

                    MySqlCommand cmd = new MySqlCommand(@"UPDATE fireteam SET fireteam_member_" + memberCounter +
                                                         "=@FireteamMember WHERE fireteam_id=@FireteamID;", connection);

                    cmd.Parameters.AddWithValue("@FireteamMember", memberID);
                    cmd.Parameters.AddWithValue("@FireteamID", fireteamID);
                    cmd.Prepare();

                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (MySqlException)
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }

        public static ulong FireteamGetMember(ulong fireteamID, int memberCounter)
        {
            using (MySqlConnection connection = Connection.GetConnection())
            {
                connection.Open();

                MySqlCommand cmd = new MySqlCommand(@"SELECT fireteam_member_" + memberCounter + " FROM fireteam WHERE fireteam_id=@FireteamID", connection);

                cmd.Parameters.AddWithValue("@FireteamID", fireteamID);
                cmd.Prepare();

                MySqlDataReader result = cmd.ExecuteReader();

                if (result.Read())
                {
                    var fireteamMember = (ulong)result["fireteam_member_" + memberCounter];
                    return fireteamMember;
                }
                result.Close();

                return 1;
            }
        }
    }
}