using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{
    public static class Test
    {


        public static List<int> GetDefault(this List<int> list)
        {
            var listaOrdenada = list.OrderBy(x=>x).ToList();
            List<int> auxiliar = new List<int>();

           for (int i = 1; i < listaOrdenada.Count; i++)
            {

                if (listaOrdenada[i-1] == listaOrdenada[i])
                {
                    if (!auxiliar.Contains(listaOrdenada[i]))
                    {
                        auxiliar.Add(listaOrdenada[i]);
                    }
                }

            }
 
            return auxiliar;
        }



    }
}