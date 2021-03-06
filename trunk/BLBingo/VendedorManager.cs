///////////////////////////////////////////////////////////
//  VendedorManager.cs
//  Implementation of the Class VendedorManager
//  Generated by Enterprise Architect
//  Created on:      07-Ago-2009 09:05:10 p.m.
//  Original author: Admin
///////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Data;
using DataBaseManager;

namespace BLBingo
{
    public class VendedorManager:List<Vendedor>
    {

        public VendedorManager()
        {

        }
       
        public static VendedorManager FindAll()
        {
            VendedorManager vendedores = new VendedorManager();
            Vendedor vendedor;
            DataTable dt = BaseDatos.DB.ExecuteSelectCommand(MyTables.VendedorPersona);
            foreach (DataRow  dr in dt.Rows)
            {
                vendedor = new Vendedor();
                vendedor.FillFromDataRow(dr);
                vendedores.Add(vendedor); 
            }
            return vendedores;
        }
        public static Vendedor FindById(long pId)
        {
            VendedorManager vendedores = new VendedorManager();
            Vendedor vendedor= new Vendedor();
            ParameterManager pM= new ParameterManager();
            pM.Add("id",pId,true);
            DataTable dt = BaseDatos.DB.ExecuteSelectCommand(MyTables.VendedorPersona,pM);
            
            
            vendedor.FillFromDataRow(dt.Rows[0]);
                
            
            return vendedor;
        }

        public Vendedor GetById(long pId)
        {
            foreach (Vendedor m in this)
            {
                if (m.Id == pId) return m;
            }
            return null;
        }
    }//end VendedorManager 
}