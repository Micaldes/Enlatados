using Enlatados.Scenes.Core.Code.Objects;
using Raylib_cs;
using System.Collections.Generic;

namespace Enlatados.Scenes.Core.Code.ObjectPool
{
    public class LataPool : IPool<Lata>
    {
        public List<Lata> coleccion { get; set; }

        public LataPool(int tamaño, Texture2D texture, float speed, GameLoop parent)
        {
            coleccion = new List<Lata>();

            for (int i = 0; i < tamaño; i++)
            {
                coleccion.Add(new Lata(texture, speed, parent));
            }
        }

        public Lata getNextAvailable()
        {
            for (int i = 0; i < coleccion.Count; i++)
            {
                if (!coleccion[i].isActive())
                {
                    coleccion[i].setActive(); // Primero la activas
                    return coleccion[i];      // Luego la devuelves
                }
            }

            return null; // Solo devuelve null si recorrió TODA la lista y no había ninguna libre
        }

        public void returnObject(Lata dato)
        {
            if (dato != null)
            {
                dato.setInactive();
            }
        }
    }
}