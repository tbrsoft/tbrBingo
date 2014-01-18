using System;
using System.Collections.Generic;
using System.Text;

namespace BLBingo
{

    /// <summary>
    /// Manual o Automatico, es decir, si se usa bolillero o no
    /// Me parece que esta enumeracion era para otra cosa.
    /// </summary>
    public enum eTipoBingo
    {
        Automatico=0,
        ConBolillero=1
    }

    public enum eEstadoCarton
    {
#warning revisar definicion de estados
        Vendido=1,
		Devuelto=2,
		AsignadoAVendedor=3,
        SinAsignar=4

    } 

    public enum eEstadoSorteo
    {
		NoIniciado=1,
		EnJuego=2,
		Finalizado=3
    }
    
    public enum eEstadoBingo
    {
		NoIniciado=1,
		EnJuego=2,
		Finalizado=3
    }

    public enum eCodigoPremio
    {
        Bingo,
        Linea
    }
}
