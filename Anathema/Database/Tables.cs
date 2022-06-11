// This file is part of the Anathema project.
//
// Copyright (c) 2022 Vladislav Sosedov.

using MySql.Data.MySqlClient;

namespace Anathema.Database
{
    public static class Tables
    {
        public static void SetupTables()
        {
            using (MySqlConnection connection = Connection.GetConnection())
            {
                MySqlCommand createFireteam = new MySqlCommand(
                    "CREATE TABLE IF NOT EXISTS fireteam(" +
                    "id INT UNSIGNED NOT NULL PRIMARY KEY AUTO_INCREMENT," +
                    "fireteam_id BIGINT UNSIGNED NOT NULL," +
                    "fireteam_guild BIGINT UNSIGNED NOT NULL," +
                    "fireteam_time DATETIME NOT NULL," +
                    "fireteam_leader BIGINT UNSIGNED NOT NULL," +
                    "fireteam_member_1 BIGINT UNSIGNED," +
                    "fireteam_member_2 BIGINT UNSIGNED," +
                    "fireteam_member_3 BIGINT UNSIGNED," +
                    "fireteam_member_4 BIGINT UNSIGNED," +
                    "fireteam_member_5 BIGINT UNSIGNED)",
                    connection);

                connection.Open();
                createFireteam.ExecuteNonQuery();
            }
        }
    }
}