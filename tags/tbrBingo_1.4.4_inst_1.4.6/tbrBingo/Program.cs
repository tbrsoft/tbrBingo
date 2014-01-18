using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLBingo;
namespace tbrBingo
{

    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #if DEBUG
                Configuration.Config.PathDB = AppDomain.CurrentDomain.BaseDirectory+ @"..\..\db\databasecondatos.mdb";                
            #else
                Configuration.Config.PathDB = AppDomain.CurrentDomain.BaseDirectory+ @"db\database.mdb";                
            #endif 
            Common.PathLicencia = AppDomain.CurrentDomain.BaseDirectory + "bingo.tli";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            Application.Run(new MDI());
#else
            try
            {
                Application.Run(new MDI());
            }
            catch (Exception ex)
            {
                frmError frm = new frmError();
                frm.ShowError(ex);
            }
#endif
            //Application.Run(new frmAbout());
        }
    }
}