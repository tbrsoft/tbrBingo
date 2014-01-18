
using System;

namespace BLBingo
{	
	public class GenerateCartonsOnce
	{		
		public GenerateCartonsOnce()
		{
		}
		
        //crea un carton manager aleatorio con mCantidad de cartones
		public CartonManager NewSerie(long mCantidad)
			{			
			CartonManager ret=new CartonManager();
            int i = 1;
			do
				{
				Carton c=GenerateOne(i);				//genera carton al azar
				if ( ! existeCarton(c,ret) )
					{ret.Add (c);                       // nunca agrega cartones repetidos
                     i++;
                    }                      
				
				}while (ret.Count < mCantidad);
            
            return ret;
			}
		
		//cada uno de los integrantes
		private Carton GenerateOne(int usePid)
			{
				//quedeaqui (tag de andresv, no quitar please)
				Carton c=new Carton(usePid);
				Random r = new Random(((int)(DateTime.Now.Ticks)));
                
				int f;//cada uno de los numeros
                
				do
					{//TODO deberia haber estrategias mas elaboradas y por fuera de esta clase
					 // es necesario que se generen numeros de menor a mayor de modo que la funcion que busca duplicados trabaje mucho más rápido
					 
					 f=r.Next(1,91);//no se como acceder a esta propiedad del total d numeros desde aqui

                     if (!c.Numeros.Contains(f))
                        { c.Numeros.Add(f); }
					
					} while(c.Numeros.Count < c.NumsEnCarton);
				
				//la siguiente linea hace que no compile. Creo que no esta definido como se ordena el tList
				c.Numeros.Sort();//simpre ordenados (para la comparacion y para la GUI)
			
                return c;
			}
		
		
        //para que no duplique cartones en la coleccion		
		private bool existeCarton(Carton c, CartonManager cm)
			{
				for (int i=0;i < cm.Count; i++)//todo seguramente hay algo mas lindo para iterar un tList
					{
					 if (c == (cm[i]) )//todo carton manager que es un tList tiene una funcion "exist", desconozco si sirvbe para nuestro caso. por eso no la use
				    	{return true;}
					}
				return false;
			}
		
	}
}