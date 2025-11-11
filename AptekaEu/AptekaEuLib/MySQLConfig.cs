using IniParser;
using IniParser.Model;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace AptekaEuLib
{
    public static class MySQLConfig
    {
        public static string DbConnectionString { get; private set; }

        public static bool Initialize()
        {
            try
            {
                var parser = new FileIniDataParser();
                IniData data = parser.ReadFile("config.ini");
                DbConnectionString = data["Db"]["ConnectionString"];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при чтении конфигурационного файла: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        public static bool CheckDbConnection()
        {
            try
            {
                using (MySqlConnection conn = new MySqlConnection(DbConnectionString))
                {
                    conn.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка при подключении к базе данных: {ex}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
