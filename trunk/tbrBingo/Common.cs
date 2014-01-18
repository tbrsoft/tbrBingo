using System;
using System.Collections.Generic;
using System.Text;
using BLBingo;
using System.Drawing;
using System.IO;

namespace tbrBingo
{
    public delegate void tbrSelectedItemEventHandler<T>(T Item);
    public delegate void tbrItemActionEventHandler<T>(T Item);
    
    //ver qu hay un formclosedeventhandler
    public delegate void FormCanceledEventHandler();


#warning aca estan los delegados

    public enum eTipoABM
    {
        eAlta=1,
        eModificacion = 2
    }

    public enum eTipoConsulta
    {
        eConRetorno = 1,
        eSinRetorno = 2
    }

    public class Common
    {
        private static Bingo sBingo;
        public static Bingo BingoActual
        {
            set
            {
                sBingo = value;
            }
            get
            {
                return sBingo;
            }
        }
        private static Icon m_Icon;

        public static Icon Icono
        {
            get { return m_Icon; }
            set { m_Icon = value; }
        }
        private static string  m_PathLicencia;

        public static string PathLicencia
        {
            get { return m_PathLicencia; }
            set { m_PathLicencia = value; }
        }

        public static bool CheckLicence()
        {
            try
            {
                return LicenciaBasica.LicenciaBasica.EstaHabilitado(PathLicencia);
            }
            catch
            {
                return false;
            }             
        }
    }

    public static class FileUtility
    {
        public static string ReadFile(string pPath)
        {
            FileStream stream = new FileStream(pPath, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(stream);
            string cadena = reader.ReadToEnd();
            reader.Close();
            return cadena;
        }

        public static void WriteFile(string pPath, string pContents)
        {
            FileStream stream = new FileStream(pPath, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(pContents);
            writer.Close();
        }

    }

    class Encriptador
    {   /// <summary>
        /// Encripta un string usando SHA1 ( no se puede volver a desencriptar).
        /// Se utiliza para guardar password,para saber si el pass ingresado es correcto
        /// se lo encripta y se lo compara con el que esta guardado
        /// </summary>
        /// <param name="strToEncrypt"></param>
        /// <returns></returns>
        public static string encryptPass(string strToEncrypt)
        {

            System.Security.Cryptography.HashAlgorithm hashValue = new
            System.Security.Cryptography.SHA1CryptoServiceProvider();
            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(strToEncrypt);

            byte[] byteHash = hashValue.ComputeHash(bytes);

            hashValue.Clear();

            return (Convert.ToBase64String(byteHash));
        }        
    }
}
