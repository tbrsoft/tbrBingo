using System;
using System.Collections.Generic;
using System.Text;

namespace BLBingo
{
    /// <summary>
    /// En esta clase esta la configuracion del programa.
    /// </summary>
    public class Configuration
    {
#warning cambiar urgente!
        
        private string m_PathDB = @"E:\tbrSoft\tbrBingo\trunk\tbrBingo\DB\database.mdb";
        /// <summary>
        /// Incluye el nombre del archivo.
        /// </summary>
        public string PathDB
        {
            get
            {
                //HACER ALGO SI NO EXISTE !!!!
                if (System.IO.File.Exists(m_PathDB))
                { return m_PathDB; }
                else
                { return "NO HAY BASE DE DATOS"; }//hecho por andres mientras reniega depurando
            }
            set 
                { m_PathDB = value; }
        }

        public void Reload()
        {
            s_Configuration = null;
        }

        public void Save()
        {
            throw new NotImplementedException("Implementar!");
        }

        #region Singleton
        private static Configuration s_Configuration;

        public static Configuration Config
        {
            get
            {
                if (s_Configuration == null)
                {
                    s_Configuration = new Configuration();

                }
                return s_Configuration;
            }
        }
        #endregion
               
    }
}
