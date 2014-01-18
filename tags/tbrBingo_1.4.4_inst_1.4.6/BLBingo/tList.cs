using System;
using System.Collections.Generic;
using System.Text;

namespace BLBingo
{
    /// <summary>
    /// Por ahora usamos List, despues vemos de implementar mas eficiente.
    /// </summary>
    public class tList:List<int>
    {
        /// <summary>
        /// Convierte a string la lista de numeros para guardarla en la base de datos.
        /// </summary>
        /// <returns></returns>
        public string Serialize()
        {
            string ret = "";
            foreach (int var in this)
            {
                ret += var + ";";
            }
            if(ret.Length!=0)ret = ret.Substring(0, ret.Length - 1);
            return ret;
        }
        public string GetNumberStr(int index)
        {
            string ret = "";
            ret = this[index].ToString();
            if (ret.Length != 2) ret = "0" + ret;
            return ret;
        }
        
        /// <summary>
        /// Convierte a string la lista de numeros para guardarla en la base de datos.
        /// </summary>
        /// <param name="separator">Cadena que separa los numeros.</param>
        /// <returns></returns>
        public string Serialize(string separator)
        {
            string ret = "";
            foreach (int var in this)
            {
                ret += (var<10?"0"+var.ToString():var.ToString()) + separator;
            }
            ret = ret.Substring(0, ret.Length - separator.Length);
            return ret;
        }

        /// <summary>
        /// Carga la lista de numeros desde la cadena serializada con la funcion serialize.
        /// </summary>
        /// <param name="pSerialized"></param>
        public void Load(string pSerialized)
        {
            string [] s= pSerialized.Split(new char[]{';'},StringSplitOptions.RemoveEmptyEntries);
            foreach (string var in s)
            {
                this.Add(int.Parse(var));
            }
        }
        public override string ToString()
        {
            return Serialize();
        }
    }
}
