using System;
using CoreEscuela.Entidades;

namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Hello World!");
            //CREACION DE ESCUELAS
            var escuela = new Escuela("Escuela feliz", 1997);
            var escuela2 = new Escuela("Escuela triste", 1998, TiposEscuela.Secundaria);

            //ARREGLO DE CURSOS
            var arregloCurso = new Curso[3];

            arregloCurso[0] = new Curso("105", TipoJornada.Noche);
            var curso6 = new Curso("106", TipoJornada.Mañana);
            arregloCurso[1] = curso6;
            arregloCurso[2] = new Curso("107", TipoJornada.Tarde);


            //CREACION DE CURSOS
            var  curso1 = new Curso("101", TipoJornada.Mañana);

            var curso2 = new Curso("102", TipoJornada.Tarde);

            var curso3 = new Curso("103", TipoJornada.Noche);
            
            escuela.TipoEscuela = TiposEscuela.Primaria;
            escuela.Departamento = "Cochabamba";

            System.Console.WriteLine("ESCUELAS");
            System.Console.WriteLine("==============");
            Console.WriteLine(escuela);
            Console.WriteLine(escuela2);
            System.Console.WriteLine("CURSOS");
            System.Console.WriteLine("==============");
            System.Console.WriteLine(curso1.Name + " " + curso1.UniqueId);
            System.Console.WriteLine($"{curso2.Name} {curso2.UniqueId}");
            System.Console.WriteLine(curso3.Name + " " +  curso3.UniqueId);
            System.Console.WriteLine("ARREGLO DE  CURSOS");
            System.Console.WriteLine("==============");
            ImprimirCursos(arregloCurso);
        }

        private static void ImprimirCursos(Curso[] arregloCurso){
            int contador = 0;
            while(contador < arregloCurso.Length){
                System.Console.WriteLine($"Nombre: {arregloCurso[contador].Name}, Id: {arregloCurso[contador].UniqueId}");
                contador++;
            }
        }
    }

}

