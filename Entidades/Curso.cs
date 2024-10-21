using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase
    {

        public TipoJornada? Jornada {get; set;}
        public List<Asignatura>? Asignaturas{get;set;}
        public List<Alumno>? Alumnos{get;set;}

        public Curso( string name, TipoJornada jornada){
            //ASIGNACION DE ID MEDIANTE EL METODO GUID);
            //ASIGNACION OBLIGATORIA MEDIANTE EL CONSTRUCTOR
            this.Jornada = jornada;
        }


    }
}