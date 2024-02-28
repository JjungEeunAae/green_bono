using project_nanibono.main;
using project_nanibono.word;

namespace project_nanibono
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

                   
           // Application.Run(new FormAdminMain());
            //Application.Run(new FormLogin());
            Application.Run(new FormMain());

            //Application.Run(new FormSignUp());
            //Application.Run(new FormAdminWord());
        }
    }
}