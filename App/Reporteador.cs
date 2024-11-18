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

        public IEnumerable<Escuela> GetListaEvaluacion()
        {   
            IEnumerable<Escuela> rta;
            
            if(_diccionario.TryGetValue(LlaveDiccionario.Escuela, out IEnumerable<ObjetoEscuelaBase> lista))
            {
                rta = lista.Cast<Escuela>();
            }
            {
                rta = null;
                //Escribir en el log de auditoria
            }
            return rta;
        }
    }
}