using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.IO;
using System.Security.Cryptography;
using tbrBingo;

namespace LicenciaBasica
{
    public static class LicenciaBasica
    {
        internal static string GetProcessorNumber()
        {
            try
            {
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                string aux="";
                foreach (ManagementObject mo in moc)
                {
                    aux = mo.Properties["ProcessorId"].Value.ToString();
                    mo.Dispose();
                    break;
                }
                aux += new string('a', 32);
                return aux.Substring(1, 32);
            }
            catch { return ""; };      
        }

        public static bool EstaHabilitado(string pPath)
        {
            string palabra = CriptoUtil.Desencriptar(FileUtility.ReadFile(pPath), GetProcessorNumber(), "oprutrew7.37hAES");
            if (palabra == "palabraencriptada")
            {
                return true;
            }
            else
            {
                return false;
            }           

        }

        public static bool GenerarInformacionLicencia(string pPath)
        {
            try
            {
                string cadena = CriptoUtil.Encriptar(GetProcessorNumber(), "12una34clave45dificil56fde89desc", "oprutrew7.37hAES");
                FileUtility.WriteFile(pPath, cadena); 
                
            }
            catch { return false; } 
            return true;
        }

        /// <summary>
        /// Generar un archivo de licencia en base al leido.
        /// </summary>
        /// <param name="pPath">El archivo a leer, el generado lo guarda en el mismo directorio con otro nombre.</param>
        /// <returns></returns>
        public static bool HabilitarLicencia(string pPath)
        {
            try
            {
                string clave = CriptoUtil.Desencriptar(FileUtility.ReadFile(pPath), "12una34clave45dificil56fde89desc", "oprutrew7.37hAES");
                string palabra = CriptoUtil.Encriptar("palabraencriptada", clave, "oprutrew7.37hAES");
                FileUtility.WriteFile(pPath.Replace(".lic", ".tli"), palabra);
                return true;
            }
            catch { return false; }

        }
        
    }
    
    class CriptoUtil
    {
        public static string Encriptar(string inputText, string key, string iv)
        {
            byte[] _key = Encoding.ASCII.GetBytes(key);

            byte[] _iv = Encoding.ASCII.GetBytes(iv);

            byte[] inputBytes = Encoding.ASCII.GetBytes(inputText);

            byte[] encripted;

            RijndaelManaged cripto = new RijndaelManaged();

            using (MemoryStream ms =

                new MemoryStream(inputBytes.Length))
            {

                using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(_key, _iv), CryptoStreamMode.Write))
                {

                    objCryptoStream.Write(inputBytes, 0, inputBytes.Length);

                    objCryptoStream.FlushFinalBlock();

                    objCryptoStream.Close();

                }

                encripted = ms.ToArray();
            }
            return Convert.ToBase64String(encripted);
        }


        public static string Desencriptar(string inputText, string key, string iv)
        {
            byte[] _key = Encoding.ASCII.GetBytes(key);
            byte[] _iv = Encoding.ASCII.GetBytes(iv);

            byte[] inputBytes = Convert.FromBase64String(inputText);
            byte[] resultBytes = new byte[inputBytes.Length];
            string textoLimpio = String.Empty;

            RijndaelManaged cripto = new RijndaelManaged();

            using (MemoryStream ms = new MemoryStream(inputBytes))
            {
                using (CryptoStream objCryptoStream =

                new CryptoStream(ms, cripto.CreateDecryptor(_key, _iv), CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(objCryptoStream, true))
                    {
                        textoLimpio = sr.ReadToEnd();
                    }
                }
            }

            return textoLimpio;
        }

    }
}
