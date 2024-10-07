using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    public class Evaluaciones
    {
        public string UniqueId {get; private set;}
        public required string Name { get; set; }

        public required Alumno Alumno {get; set;}
        public required Asignatura Asignatura {get; set;}
        public float Nota {get; set;}

        public Evaluaciones() => UniqueId = Guid.NewGuid().ToString();
    }
}