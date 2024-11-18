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
            if(discObsEsc == null)
            {
                throw new ArgumentNullException(nameof(discObsEsc));
            }
            _diccionario = discObsEsc;
        }

        public IEnumerable<Evaluacion> GetListaEvaluacion()
        {            
            if(_diccionario.TryGetValue(LlaveDiccionario.Evaluacion, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                return lista.Cast<Evaluacion>();
            }
            {
                return new List<Evaluacion>();
                //Escribir en el log de auditoria
            }
        }

        public IEnumerable<string> GetListaAsignatura()
        {
            var listaEvaluaciones = GetListaEvaluacion();

            //USO DE LINQ
            //ESTABLECEMOS UNA SECUENCIA DE DATOS
            return  (from ev in listaEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string, IEnumerable<Evaluacion>> GetDicEvalxAsig()
        {
            var rtadiccionario = new Dictionary<string, IEnumerable<Evaluacion>>();

            return rtadiccionario;
        }
    }
}