using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    public class Curso
    {
        public string UniqueId {get; private set;}
        public string? Name { get; set; }
        public TipoJornada? Jornada {get; set;}
        public List<Asignatura>? Asignaturas{get;set;}
        public List<Alumno> ?Alumnos{get;set;}

        public Curso( string name, TipoJornada jornada){
            //ASIGNACION DE ID MEDIANTE EL METODO GUID
            UniqueId = Guid.NewGuid().ToString();
            //ASIGNACION OBLIGATORIA MEDIANTE EL CONSTRUCTOR
            this.Name = name;
            this.Jornada = jornada;
        }


    }
}