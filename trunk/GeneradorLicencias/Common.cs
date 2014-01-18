using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;

namespace tbrBingo
{
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
}
