using System;
using System.Collections.Generic;
using System.Text;

namespace BLBingo
{
    /// <summary>
    /// Implementar esta interfaz para obtener como strings los valores de propiedades compuestoas.
    /// </summary>
    public interface IListable
    {
        string GetProperty(string pPropertyName);        
    }
}
