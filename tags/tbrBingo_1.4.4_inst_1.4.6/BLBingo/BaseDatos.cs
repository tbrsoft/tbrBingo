using System;
using System.Collections.Generic;
using System.Text;
using DataBaseManager;
using System.Data;

namespace BLBingo
{
    public class ExcelReader
    {
        public static DataTable GetData(string pPath)
        {
            Database m_database = new Database("Provider=Microsoft.Jet.OLEDB.4.0; Data Source=" + pPath + "; Extended Properties=\"Excel 8.0;\"");
            return m_database.ExecuteSQLCommand("Select * from [Cartones$]"); 
        }

    }

    class BaseDatos
    {
        private static Database m_database;

        public static Database DB
        {
            get
            {
                if (m_database == null)
                {
                    m_database = new Database(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Configuration.Config.PathDB);
                }                
                return m_database;
            }
        }
    }

    public static class MyTables
    {       
        public static TableName Bingo
            {get {return new TableName("Bingo");}}

        public static TableName CartonBingo
        {
            get
            {
                return new TableName("CartonBingo");
            }
        }
        public static TableName Comprador
        {
            get
            {
                return new TableName("Comprador");
            }
        }
        public static TableName Vendedor
        {
            get
            {
                return new TableName("Vendedor");
            }
        }
        public static TableName VendedorPersona
        {
            get
            {
                return new TableName("VendedorPersona");
            }
        }

        public static TableName Persona
        {
            get
            {
                return new TableName("Persona");
            }
        }
        public static TableName Sorteo
        {
            get
            {
                return new TableName("Sorteo");
            }
        }
        public static TableName Carton
        {
            get
            {
                return new TableName("Carton");
            }
        }
        public static TableName CompradorPersona
        {
            get
            {
                return new TableName("CompradorPersona");
            }
        }
        public static TableName FormularioCarton
        {
            get
            {
                return new TableName("FormularioCarton");
            }
        }
        public static TableName GanadorXSorteo
        {
            get
            {
                return new TableName("GanadorXSorteo");
            }
        }
    }
}