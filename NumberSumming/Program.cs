using NumberSumming.Views;
using System;
using System.Windows.Forms;

namespace NumberSumming
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SumForm());
        }
    }
}
