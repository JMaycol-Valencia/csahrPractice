using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Util;

namespace CoreEscuela.Entidades
{
    public class Curso:ObjetoEscuelaBase, ILugar
    {

        public TipoJornada Jornada {get; set;}
        public List<Asignatura> Asignaturas{get;set;}
        public List<Alumno> Alumnos{get;set;}

        public string Direccion { get; set; }

        public void limpiarLugar()
        {
            Printer.DrawLine();
            Console.WriteLine("Limpiando Curso...");
            Console.WriteLine($"Curso {Nombre} limpio");
        }
    }
}