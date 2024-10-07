using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    public class Alumno
    {
        public string UniqueId {get; private set;}
        public required string Nombre { get; set; }

        public List<Evaluaciones> Evaluaciones { get; set; }
        public Alumno()
        {
            UniqueId = Guid.NewGuid().ToString();
            this.Evaluaciones = new List<Evaluaciones>(){};
        }
    }
}