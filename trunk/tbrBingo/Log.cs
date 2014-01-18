using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace tbrBingo
{
    public class Log
    {    
        private  eLogMode mMode=eLogMode.Basic;
        private string mPath;
        private string mAuxLog="";
        private long mMaxLen = 1000;
        public eLogMode Mode
        {
            get { return mMode; }
            set { mMode = value; }
        }
        /// <summary>
        /// Crea un log en la ubicacion especificada.
        /// </summary>
        /// <param name="pPath">Path del log.</param>
        public Log(string pPath)
        {
            string aux = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, pPath);
            string aux2;
            int ind = 0;
            if (File.Exists(aux))
            {
                ind = aux.LastIndexOf(".");
                aux2 =aux.Substring(0, ind - 1)+ "BackUp" + aux.Substring(ind , aux.Length-ind);
                if (File.Exists(aux2)) {
                    File.Delete(aux2);
                }
                File.Move(aux, aux2 );
            }
            FileStream f = File.Create(aux);
            f.Close();
            mPath = aux ;
        }

        private void addValue(string pValue)
        {
            long len = mAuxLog.Length;
            mAuxLog = mAuxLog + "\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff ") + pValue;
            if (len > mMaxLen ) {
                writeLog();
                mAuxLog = "";
            }

        }
        private void addValue(string pValue, bool hardWrite) {
            long len = mAuxLog.Length;
            mAuxLog= mAuxLog+"\r\n" + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss.fff ")+pValue;
            if (hardWrite) {
                writeLog();
                mAuxLog = "";
            }            
        }
        private void addException(Exception pEx) {
            addValue("Source: " + pEx.Source.ToString().Trim(), false);
            addValue("Method: " + pEx.TargetSite.Name.ToString(), false);
            addValue("Error: " + pEx.Message.ToString().Trim(), false);
            addValue("Stack Trace: " + pEx.StackTrace.ToString(), false);
            if (pEx.InnerException != null)
            {
                addValue("Begin InnerException:",false);
                addException(pEx.InnerException); 
                addValue("End InnerException.",false);
            }
            writeLog();        
        }
        private void writeLog() {
            StreamWriter sw = new StreamWriter(mPath, true);           
            sw.Write(mAuxLog);
            sw.Flush();
            sw.Close();
            mAuxLog = "";        
        }
        /// <summary>
        /// Escribe una entrada al log.
        /// </summary>
        /// <param name="Value"></param>
        /// <param name="hardWrite">Si es verdadero escribe al Disco inmediatamente</param>
        
        public void Write(string pValue, bool hardWrite)
        {
            if (hardWrite ){
                    addValue(pValue,true );
                    
            }else{
                Write(pValue);            
            }        
        }      
        /// <summary>
        /// Escribe una entrada al log ( No se guarda al disco inmediatamente).
        /// </summary>
        /// <param name="value"></param>
        public void Write(string value)
        {
            addValue(value);
        }
       
        /// <summary>
        /// Escribe una entrada al log solo si log.Mode= Full;
        /// </summary>
        /// <param name="value">Entrada que se escribe en el log.</param>
        
        public void WriteDebug(string value)
        {
            if (mMode == eLogMode.Full) {
                Write(value);            
            }
        }

        /// <summary>
        /// Escribe una entrada al log con informacion sobre la excepcion y lo guarda al disco duro
        /// </summary>
        /// <param name="pValue">Informacion adicional que se quiera agregar</param>
        /// <param name="pEx"></param>
        public void Write(string pValue, Exception pEx) {
            addValue(pValue);
            addException(pEx);

        }
        /// <summary>
        /// Escribe una entrada al log con informacion sobre la excepcion y lo guarda al disco duro
        /// </summary>
        /// <param name="pValue"></param>
        /// <param name="pEx"></param>
        public void Write(Exception pEx) {
            addException(pEx);
        }
       
        static Log mLog;

        public static Log PublicLog
        {
            get
            {
                if (mLog == null)
                {

                    mLog = new Log("Error.log");
                }
                return Log.mLog;
            }
            set { Log.mLog = value; }
        }
    }
    public enum eLogMode
    {
        Full,
        Basic
    }
}
