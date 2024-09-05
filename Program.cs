using System;
using CoreEscuela.Entidades;
using static System.Console;


namespace CoreEscuela
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Hello World!");

            //CREACION DE ESCUELAS
            var escuela = new Escuela("Escuela feliz", 1997);
            var escuela2 = new Escuela("Escuela triste", 1998, TiposEscuela.Secundaria);

            //ARREGLO DE CURSOS SIMPLIFIACADO
            var arregloCurso = new Curso[3]{
                new Curso("105", TipoJornada.Noche),
                new Curso("106", TipoJornada.Mañana),
                new Curso("107", TipoJornada.Tarde)
            };

            //system.collections.generic
            //modificando la asignacion dearreglo a una coleccion
            var listaCurso = new List<Curso>(){
                new Curso("201", TipoJornada.Mañana),
                new Curso("202", TipoJornada.Tarde),
                new Curso("203", TipoJornada.Noche)
            };

            //creacion de una lista extra
            var otraLista = new List<Curso>(){
                new Curso("207", TipoJornada.Noche),
                new("208", TipoJornada.Mañana),
                new Curso("209", TipoJornada.Mañana),

            };

            //ASIGNACION DE LA LISTA A LA ESCUELA
            escuela2.Cursos = listaCurso;

            //AGREGACION DE PROPIEDAD ANTES DESPUES DE QUE SE HAYA CREADO EL OBJETO
            escuela2.Cursos.Add(new Curso("204", TipoJornada.Noche));
            escuela2.Cursos.Add(new Curso("205", TipoJornada.Tarde));
            escuela2.Cursos.Add(new Curso("206", TipoJornada.Tarde));

            //CURSO TEMPORAL PARA ELIMINAR
            Curso cursoTemp = new Curso("666", TipoJornada.Mañana);
            escuela2.Cursos.Add(cursoTemp);

            //AGREGANDO LISTA EXTRA
            escuela2.Cursos.AddRange(otraLista);
        
            // escuela2.Cursos = new Curso[]{
            //     new Curso("201", TipoJornada.Mañana),
            //     new Curso("202", TipoJornada.Tarde),
            //     new Curso("203", TipoJornada.Noche)
            // };

            //ARREGLO DE CURSOS SIMPLIFICADO 2
            // Curso[] arregloCurso2 = {
            //     new Curso("105", TipoJornada.Noche),
            //     new Curso("106", TipoJornada.Mañana),
            //     new Curso("107", TipoJornada.Tarde)
            // };
            
            //ARREGLO DE CURSOS CON ASIGNACION DE OBJETOS
            arregloCurso[0] = new Curso("105", TipoJornada.Noche);
            var curso6 = new Curso("106", TipoJornada.Mañana);
            arregloCurso[1] = curso6;
            arregloCurso[2] = new Curso("107", TipoJornada.Tarde);

            //CREACION DE CURSOS INDIVIDUALES SOBRE VARIABLES
            var  curso1 = new Curso("101", TipoJornada.Mañana);
            var curso2 = new Curso("102", TipoJornada.Tarde);
            var curso3 = new Curso("103", TipoJornada.Noche);

            //ASIGNACION DE VALORES A LA ESCUELA
            escuela.TipoEscuela = TiposEscuela.Primaria;
            escuela.Departamento = "Cochabamba";

            //LLAMADAS POR CONSOLA
            WriteLine("ESCUELAS");
            WriteLine("==============");
            WriteLine(escuela);
            WriteLine(escuela2);
            WriteLine("CURSOS");
            WriteLine("==============");
            WriteLine(curso1.Name + " " + curso1.UniqueId);
            WriteLine($"{curso2.Name} {curso2.UniqueId}");
            WriteLine(curso3.Name + " " +  curso3.UniqueId);
            WriteLine("RRECORRIDO DE ARREGLO");
            WriteLine("FOREACH");
            WriteLine("==============");
            ImprimirCursosForEach(arregloCurso);

            //eliminar
            otraLista.Clear();

            //imprimir hash
            WriteLine("=============");
            WriteLine("HASHCODE " + cursoTemp.GetHashCode());

            //imprimir cursos de escuela
            ImprimirCursosEscuelas(escuela2);

            //ASIGNACION DE PREDICATE            
            // Predicate<Curso> miAlgortimo = Predicado;
            
            //ELIMINANDO EL ELEMENTO APUNTADO POR EL PREDICATE DIRECTO
            //escuela2.Cursos.RemoveAll(Predicado);

            //ELIMINANDO EL ELEMENTO CON FUNCION Y PREDICATE
            //escuela2.Cursos.RemoveAll(delegate (Curso cur) {return cur.Name == "666";});

            //ELIMINANDO EL ELEMENTO CON FUNCION LAMBDA SIMPLIFICADA Y PREDICATE
            escuela2.Cursos.RemoveAll((Curso cur) => cur.Name == "666" && cur.Jornada == TipoJornada.Mañana);

            WriteLine("==============");
            WriteLine("CURSO ELIMINADO CON PREDICATE");
            //imprimir cursos de escuela 2
            ImprimirCursosEscuelas(escuela2);

        }

        private static bool Predicado(Curso curobj)
        {
            return curobj.Name == "666";
        }

        private static void ImprimirCursosEscuelas(Escuela escuela2)
        {
            WriteLine("================");
            WriteLine("CURSOS DE ESCUELA");
            WriteLine("================");

            if(escuela2?.Cursos != null){
                foreach(var curso in escuela2.Cursos){
                    WriteLine($"Name: {curso.Name}, ID: {curso.UniqueId}");
                }
            }
        }
        private static void ImprimirCursosForEach(Curso[] arregloCurso){
            foreach(var curso in arregloCurso){
                WriteLine($"Name: {curso.Name} ID: {curso.UniqueId} Jornada: {curso.Jornada}");
            }
        }
    }

}

