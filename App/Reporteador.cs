using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador
    {
        Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;
        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> discObsEsc)
        {
            if (discObsEsc == null)
            {
                throw new ArgumentNullException(nameof(discObsEsc));
            }
            _diccionario = discObsEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluacion()
        {
            if (_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
                //Escribir en el log de auditoria
            }
        }

        //SOBRECARGA DE METODOS PARA EVITAR PASARLE UNA LISTA DE EVALUACIONES EN EL METODO
        //PRIMERA SOBRECARGA
        public IEnumerable<string> GetListaAsignatura()
        {
            return GetListaAsignatura(out var dummy);
        }
        //SEGUNDA SOBRECARGA
        public IEnumerable<string> GetListaAsignatura(out IEnumerable<Evaluacion> listaEvaluaciones)
        {
            listaEvaluaciones = GetListaEvaluacion();

            //USO DE LINQ
            //ESTABLECEMOS UNA SECUENCIA DE DATOS
            return (from ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvalxAsig()
        {
            var rtadiccionario = new Dictionary<string, IEnumerable<Evaluacion>>();

            var listaAsig = GetListaAsignatura(out var listaEval);

            foreach (var asig in listaAsig)
            {
                var evalAsig = from eval in listaEval
                               where eval.Asignatura.Nombre == asig
                               select eval;

                rtadiccionario.Add(asig, evalAsig);
            }

            return rtadiccionario;
        }

        public Dictionary<string, IEnumerable<AlumnoPromedio>> GetPromeAlumnPorAsig()
        {
            var rta = new Dictionary<string, IEnumerable<AlumnoPromedio>>();

            var dicEvaXAsig = GetDicEvalxAsig();

            foreach (var asigConEval in dicEvaXAsig)
            {
                var promAlumn = from eval in asigConEval.Value
                            group eval by new 
                            {
                                eval.Alumno.UniqueId,
                                eval.Alumno.Nombre
                            } 
                            into grupoEvalsAlumn
                            select new AlumnoPromedio
                            {
                                alumnoid = grupoEvalsAlumn.Key.UniqueId,
                                alumnoNombre = grupoEvalsAlumn.Key.Nombre,
                                promedio = grupoEvalsAlumn.Average( evaluacion => evaluacion.Nota)

                            };
                rta.Add(asigConEval.Key, promAlumn);
            }
            return rta;
        }

         public Dictionary<string, IEnumerable<AlumnoPromedio>> GetListaTopPromedio(int x)
        {
            var resp = new Dictionary<string, IEnumerable<AlumnoPromedio>>();
            var dicPromAlumPorAsignatura = GetPromeAlumnPorAsig();

            foreach (var item in dicPromAlumPorAsignatura)
            {
                var dummy = (from ap in item.Value
                             orderby ap.promedio descending
                             select ap).Take(x);

                resp.Add(item.Key, dummy);
            }

            return resp;
        }
    }
}