using System;
using System.Windows.Forms;

namespace Query_Database
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Query_Database_2.MainForm());
        }
    }
}
