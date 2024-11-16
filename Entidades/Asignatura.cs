using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    public class Asignatura:ObjetoEscuelaBase
    {
        public override string ToString()
        {
            return $"Asignatura: {Nombre}, ID: {UniqueId}";
        }
    }
    
}