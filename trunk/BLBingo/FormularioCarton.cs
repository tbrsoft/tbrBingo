using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataBaseManager;


namespace BLBingo
{
    public class FormularioCarton
    {
        private byte[] mImagen;
        private List<CamposCarton>  m_Campos;
        private long  m_Id;
        private string m_FontName;
        private float  m_FontSize;
        private int m_FontColor;
        private bool m_FontBold;

        public bool FontBold
        {
            get { return m_FontBold; }
            set { m_FontBold = value; }
        }
	
    
        public int FontColor
        {
            get { return m_FontColor; }
            set { m_FontColor = value; }
        }
	

        public float  FontSize
        {
            get { return  m_FontSize; }
            set {  m_FontSize = value; }
        }
	
                        
        public string FontName
        {
            get { return m_FontName; }
            set { m_FontName = value; }
        }
	

        public long Id
        {
            get { return m_Id; }
            set { m_Id = value; }
        }

        public List<CamposCarton> Campos
        {
            get { return m_Campos; }
            set { m_Campos = value; }
        }

        public byte[] Imagen
        {
            get { return mImagen; }
            set { mImagen = value; }
        }

        public void Save(Bingo pBingo)
        {

            //manu
            System.IO.BinaryWriter Bugg;


            ParameterManager parametros = new ParameterManager();
            parametros.Add("idBingo", pBingo.Id);
            parametros.Add("campos", Serialize(Campos));
            parametros.Add("fontbold", FontBold);
            parametros.Add("fontname", FontName);
            parametros.Add("fontsize", FontSize);
            parametros.Add("fontcolor", FontColor);
            if (mImagen != null) parametros.Add("imagen", mImagen);
            parametros.Add("id", Id, true);

            //manu
            /*System.IO.File.WriteAllText("C:\\bingo_00.txt", pBingo.Id.ToString);
            System.IO.File.WriteAllText("C:\\bingo_01.txt", Serialize(Campos).ToString);
            System.IO.File.WriteAllText("C:\\bingo_02.txt", FontBold.to);
            System.IO.File.WriteAllText("C:\\bingo_03.txt", pBingo.Id.ToString);
            System.IO.File.WriteAllText("C:\\bingo_04.txt", pBingo.Id.ToString);
            System.IO.File.WriteAllText("C:\\bingo_05.txt", pBingo.Id.ToString);
            System.IO.File.WriteAllText("C:\\bingo_06.txt", pBingo.Id.ToString);
            System.IO.File.WriteAllText("C:\\bingo_07.txt", pBingo.Id.ToString);
            */
            //-------------------------------------------------------------------------------

            if (Id == 0)
            {
                Id = BaseDatos.DB.ExecuteInsertCommandWithId(MyTables.FormularioCarton, parametros);
            }
            else
            {
                BaseDatos.DB.ExecuteUpdateCommand(MyTables.FormularioCarton, parametros);
            }
            
        }
               

        public bool Load(Bingo pBingo)
        {
            ParameterManager parametros = new ParameterManager();
            parametros.Add("idBingo", pBingo.Id,true);  
            DataTable dt = BaseDatos.DB.ExecuteSelectCommand(MyTables.FormularioCarton,parametros);
            if (dt.Rows.Count != 0)
            {
                DataRow dr = dt.Rows[0]; //siempre viene solo uno...
                object img=dr["imagen"];
                if (img != System.DBNull.Value)
                {
                    mImagen = (byte[])dr["imagen"];
                }
                try
                {
                    FontColor = int.Parse(dr["fontcolor"].ToString());
                    FontName = dr["fontName"].ToString();
                    FontSize = float.Parse(dr["fontsize"].ToString());
                    FontBold = bool.Parse(dr["fontbold"].ToString());
                }catch{
                
                }
                Campos = Deserialize(dr["campos"].ToString());
                Id = long.Parse(dr["Id"].ToString());
                return true;
            }
            return false;           
        }

        public static bool ExisteFormulario(Bingo pBingo)
        {
            ParameterManager parametros = new ParameterManager();
            parametros.Add("idBingo", pBingo.Id,true);  
            DataTable dt = BaseDatos.DB.ExecuteSelectCommand(MyTables.FormularioCarton,parametros);
            return (dt.Rows.Count != 0);
        }
        /// <summary>
        /// Serializa los campos a un string.
        /// </summary>
        /// <param name="Campos"></param>
        /// <returns></returns>
        private string Serialize(List<CamposCarton> pCampos)
        {
            string s = "";
            foreach (CamposCarton cc in pCampos)
            {
                s += "|" + cc.Serialize(); 
            }
            return s;
        }

        /// <summary>
        /// Obtiene la lista de campos a partir de un string.
        /// </summary>
        /// <param name="pSerialized"></param>
        /// <returns></returns>
        internal List<CamposCarton> Deserialize(string pSerialized)
        {
            List<CamposCarton> campos = new List<CamposCarton>(); 
            CamposCarton cc;
            string[] sCampos = pSerialized.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string str in sCampos)
            {
                cc = new CamposCarton(str);
                campos.Add(cc);
            }
            return campos; 
        } 
 
    }

    public class CamposCarton
    {
        private int m_Width;
        private int m_Height;
        private int m_Top;
        private int m_Left;

        public int Left
        {
            get { return m_Left; }
            set { m_Left = value; }
        }

        public int Top
        {
            get { return m_Top; }
            set { m_Top = value; }
        }

        public int Height
        {
            get { return m_Height; }
            set { m_Height = value; }
        }

        public int Width
        {
            get { return m_Width; }
            set { m_Width = value; }
        }

        internal string Serialize()
        {
            return Left.ToString() + ";" + Top.ToString() + ";" + Height.ToString() + ";" + Width.ToString(); 
        }
        
        public CamposCarton(string pSerialized)
	    {
            string[] campos = pSerialized.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            Left = int.Parse(campos[0]);
            Top = int.Parse(campos[1]);
            Height = int.Parse(campos[2]);
            Width = int.Parse(campos[3]);
	    }
        public CamposCarton()
        {

        }

    }
}
