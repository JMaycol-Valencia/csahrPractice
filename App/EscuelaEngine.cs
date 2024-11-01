using CoreEscuela.Entidades;
using System.Linq;
using System.Xml;

namespace CoreEscuela
{
    public sealed class EscuelaEngine
    {
        public Escuela EscuelaA { get; set; }

        public EscuelaEngine()
        {

        }

        public void inicializar()
        {
            EscuelaA = new Escuela("Escuela triste", 1998, TiposEscuela.Secundaria, departamento: "cochabamba");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }

        private void CargarCursos()
        {
            if (EscuelaA?.Cursos == null)
            {
                return;
            }

            EscuelaA.Cursos = new List<Curso>(){
                new Curso(){ Nombre = "101", Jornada = TipoJornada.Mañana},
                new Curso(){Nombre = "201", Jornada = TipoJornada.Mañana},
                new Curso(){Nombre = "301", Jornada = TipoJornada.Mañana},
                new Curso(){Nombre = "401", Jornada = TipoJornada.Tarde},
                new Curso(){Nombre = "501", Jornada = TipoJornada.Tarde},
            };

            //GENERANDO NUMERO RANDOM PARA CARGARALUMNOS A LOS CURSOS
            Random r = new Random();
            foreach (var c in EscuelaA.Cursos)
            {
                var random = r.Next(5, 20);
                c.Alumnos = (List<Alumno>)GenerarAlumnos(random);
            }
        }


        private void CargarAsignaturas()
        {
            //FOREACH PARA CARGAR LAS ASIGNATURAS
            if (EscuelaA?.Cursos != null)
            {
                foreach (var curso in EscuelaA.Cursos)
                {
                    var listaAsignaturas = new List<Asignatura>()
                    {
                        new Asignatura{Nombre="Matematicas"},
                        new Asignatura{Nombre="Ciencias Sociales"},
                        new Asignatura{Nombre="Eduacion Fisica"},
                        new Asignatura{Nombre="Castellano"}
                    };
                    curso.Asignaturas = listaAsignaturas;

                };
            }
        }
        private List<Alumno> GenerarAlumnos(int cantidad)
        {
            string[] name1 = { "Juan", "Carlos", "Pelaes", "Nicolas", "Alvaro" };
            string[] apellido1 = { "Jerias", "Ket", "Linton", "Porteo", "Jundio" };
            string[] name2 = { "Pedro", "Messi", "Ronaldo", "Sidan", "Mijael" };

            //USANDO LINQ PARA EL MANEJO DE DATOS Y CREACION DE UN PRODUCTO CARTECIANO
            var listaAlumnos = from n1 in name1
                               from n2 in name2
                               from ape1 in apellido1
                               select new Alumno { Nombre = $"{n1} {n2} {ape1}" };

            //AL ORDENAR POR EL UNIQUEID , EL ORDEN SERA ALEATORIO YA QUE EL UNIQUE ID SE GENERA ALEATORIAMENTE PARA CADA ALUMNO
            return listaAlumnos.OrderBy((al) => al.UniqueId).Take(cantidad).ToList();
        }
        private void CargarEvaluaciones()
        {
            // Verificar si EscuelaA o su propiedad Cursos es null
            if (EscuelaA?.Cursos == null)
            {
                return;
            }

            foreach (var curso in EscuelaA.Cursos)
            {
                // Verificar si la propiedad Asignaturas de curso es null
                if (curso.Asignaturas == null)
                {
                    continue;
                }

                foreach (var asignatura in curso.Asignaturas)
                {
                    // Verificar si la propiedad Alumnos de curso es null
                    if (curso.Alumnos == null)
                    {
                        continue;
                    }

                    foreach (var alumno in curso.Alumnos)
                    {
                        // Verificar si la propiedad Evaluaciones de alumno es null
                        if (alumno.Evaluaciones == null)
                        {
                            alumno.Evaluaciones = new List<Evaluacion>();
                        }

                        var rnd = new Random(System.Environment.TickCount);

                        for (int i = 0; i < 5; i++)
                        {
                            var ev = new Evaluacion
                            {
                                Asignatura = asignatura,
                                Nombre = $"{asignatura.Nombre} Ev#{i + 1}",
                                Nota = (float)(5 * rnd.NextDouble()),
                                Alumno = alumno
                            };
                            alumno.Evaluaciones.Add(ev);
                        }
                    }
                }
            }
        }
        public List<ObjetoEscuelaBase> GetObjetoEscuela()
        {
            var listObj = new List<ObjetoEscuelaBase>();

            // Validacion para que  EscuelaA sea una instancia de la clase Escuela
            if (EscuelaA != null)
            {
                listObj.Add(EscuelaA);

                if (EscuelaA.Cursos != null)
                {
                    listObj.AddRange(EscuelaA.Cursos);

                    foreach (var curso in EscuelaA.Cursos)
                    {
                        if (curso.Asignaturas != null)
                        {
                            listObj.AddRange(curso.Asignaturas);
                        }

                        if (curso.Alumnos != null)
                        {
                            listObj.AddRange(curso.Alumnos);

                            foreach (var alumno in curso.Alumnos)
                            {
                                if (alumno.Evaluaciones != null)
                                {
                                    listObj.AddRange(alumno.Evaluaciones);
                                }
                            }
                        }
                    }
                }
            }

            return listObj;
        }
    }
}