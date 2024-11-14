using CoreEscuela.Entidades;
using CoreEscuela.Util;
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
        #region INICIALIZADOR   
        public void inicializar()
        {
            EscuelaA = new Escuela("Escuela triste", 1998, TiposEscuela.Secundaria, departamento: "cochabamba");

            CargarCursos();
            CargarAsignaturas();
            CargarEvaluaciones();
        }
        #endregion

        public void ImprimirDiccionario(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dic, bool imprEval = false)
        {
            foreach (var obj in dic)
            {
                Printer.WriteTittle(obj.Key.ToString());

                foreach (var val in obj.Value)
                {
                    if (val is Evaluacion)
                    {
                        if (imprEval)
                            Console.WriteLine(val);
                    }
                    else if (val is Escuela)
                    {
                        Console.WriteLine("ESCUELA " + val);
                    }
                    else if (val is Alumno)
                    {
                        Console.WriteLine("ALUMNO " + val);
                    }
                    else
                    {
                        Console.WriteLine(val);
                    }
                }
            }
        }

        #region OBTENER OBJETOS
        public Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> GetDiccionarioObjetos()
        {
            var diccionario = new Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>>();
            var listaTemporal = new List<Evaluacion>();
            var listaTemporalas = new List<Asignatura>();
            var listaTemporalal = new List<Alumno>();

            diccionario.Add(LlaveDiccionario.Escuela, new[] { EscuelaA });
            diccionario.Add(LlaveDiccionario.Curso, EscuelaA.Cursos.Cast<ObjetoEscuelaBase>());

            foreach (var cur in EscuelaA.Cursos)
            {
                listaTemporalas.AddRange(cur.Asignaturas);
                listaTemporalal.AddRange(cur.Alumnos);

                foreach (var alum in cur.Alumnos)
                {
                    listaTemporal.AddRange(alum.Evaluaciones);
                }
            }
            diccionario.Add(LlaveDiccionario.Asignatura, listaTemporalas.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Alumno, listaTemporalal.Cast<ObjetoEscuelaBase>());
            diccionario.Add(LlaveDiccionario.Evaluacion, listaTemporal.Cast<ObjetoEscuelaBase>());
            return diccionario;
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignatura = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuela(out int dummy, out dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignatura = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out int dummy, out dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignatura = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out conteoCursos, out int dummy, out dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            out int conteoEvaluaciones,
            out int conteoCursos,
            out int conteoAsignaturas,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignatura = true,
            bool traeCursos = true)
        {
            return GetObjetoEscuela(out conteoEvaluaciones, out conteoCursos, out conteoAsignaturas, out int dummy);
        }

        public IReadOnlyList<ObjetoEscuelaBase> GetObjetoEscuela(
            //parametros de salida
            out int conteoEvaluaciones,
            out int conteoAlumnos,
            out int conteoAsignaturas,
            out int conteoCursos,
            bool traeEvaluaciones = true,
            bool traeAlumnos = true,
            bool traeAsignatura = true,
            bool traeCursos = true)
        {
            conteoEvaluaciones = 0;
            conteoAlumnos = 0;
            conteoAsignaturas = 0;
            conteoCursos = 0;
            var listObj = new List<ObjetoEscuelaBase>();
            listObj.Add(EscuelaA);

            if (traeCursos)
            {
                listObj.AddRange(EscuelaA.Cursos);
                conteoCursos += EscuelaA.Cursos.Count;
                foreach (var curso in EscuelaA.Cursos)
                {
                    conteoAsignaturas += curso.Asignaturas.Count;
                    conteoAlumnos += curso.Alumnos.Count;
                    if (traeAsignatura)
                        listObj.AddRange(curso.Asignaturas);

                    if (traeAlumnos)
                    {
                        listObj.AddRange(curso.Alumnos);

                        if (traeEvaluaciones)
                        {
                            foreach (var alumno in curso.Alumnos)
                            {
                                listObj.AddRange(alumno.Evaluaciones);
                                conteoEvaluaciones += alumno.Evaluaciones.Count;

                            }
                        }
                    }
                }
            }

            return (listObj.AsReadOnly());
        }
        #endregion
        #region  METODOS PARA GENERAR
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
        #endregion 
        #region METODOS DE CARGA 
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
        #endregion
    }
}