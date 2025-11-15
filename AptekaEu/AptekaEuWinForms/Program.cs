using AptekaEuLib;
using System;
using System.Windows.Forms;

namespace AptekaEuWinForms
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!MySQLConfig.Initialize())
            {
                return;
            }

            if (!MySQLConfig.CheckDbConnection())
            {
                return;
            }

            Application.Run(new MainForm());
        }
    }
}
