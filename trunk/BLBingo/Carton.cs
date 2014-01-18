///////////////////////////////////////////////////////////
//  Carton.cs
//  Implementation of the Class Carton
//  Generated by Enterprise Architect
//  Created on:      07-Ago-2009 09:05:01 p.m.
//  Original author: Paliza Martin
///////////////////////////////////////////////////////////

using DataBaseManager;
using System;

namespace BLBingo
{
    public class Carton
    {
        private long m_Id;
        private tList m_Numeros;        
		// no se como acceder desde aca a la propiedad cantidadBolillas de "bingo"
		// TODO es necesario saber el itervalo de los numeros que se pueden usar
		// por ejemplo 1-99 o 1-90 como el caso que estamos haciendo ahora
		//momentanemente implemento esto
		public int CantBol=90;//TODO quizas sea 91
		// no encontre ni aqui ni en bingo la cantidad de numeros de cada carton
		// temporalmente implemento esto
		public int NumsEnCarton=10;
		
        
        #region Constructores
        public Carton(long pId, string pNumeros)
        {
            m_Id = pId;
            tList t = new tList();
            t.Load(pNumeros);
            m_Numeros = t;
        }

        public Carton(long pId)
        {
            m_Id = pId;
			tList t = new tList();//necesito que este creada para el "add"
			m_Numeros=t;
        } 
        #endregion

        #region Propiedades
        public long Id
        {
            get {return m_Id;}
            set {m_Id = value;}
        }

        public tList Numeros
        {
            get
            {
                return m_Numeros;
            }
            set
            {
                m_Numeros = value;
            }
        } 
        #endregion



        public static bool operator ==(Carton c, Carton c2)
        {
            for (int i = 0; i < c.Numeros.Count; i++)//todo supongo que es en base 1
            {
                if (c.Numeros[i] != c2.Numeros[i])
                { return false; }
            }
            //si llega hasta aqui quiere decir que todos son iguales
            return true;
        }

        public static bool operator !=(Carton c, Carton c2)
        {
            for (int i = 0; i < c.Numeros.Count; i++)//todo supongo que es en base 1
            {
                if (c.Numeros[i] != c2.Numeros[i])
                { return true; }
            }
            //si llega hasta aqui quiere decir que todos son iguales
            return false;
        }

        /// <summary>
        /// Guarda el carton con un nuevo id, no esta previsto el update
        /// </summary>
        public void Save()
        {
            ParameterManager pM = new ParameterManager();
            pM.Add("id",m_Id, true);
            pM.Add("numeros", m_Numeros.Serialize());

            Id=BaseDatos.DB.ExecuteInsertCommandWithId(MyTables.Carton, pM);            
        }

    }//end Carton 
}