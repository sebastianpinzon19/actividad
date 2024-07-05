using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class JugadorDePosicion : Jugador
    {
        private int hits;
        public int Hits
        {
            get { return hits; }
            set { Validaciones.ValidarNumero(value); hits = value; }
        }

        private int errores;
        public int Errores
        {
            get { return errores; }
            set { Validaciones.ValidarNumero(value); errores = value; }
        }

        public JugadorDePosicion(int numeroUniforme, string nombre, int hits, int errores)
            : base(numeroUniforme, nombre, "Jugador de Posición")
        {
            Hits = hits;
            Errores = errores;
        }

        public override string MostrarDatos()
        {
            return $"Número de uniforme: {NumeroUniforme}, Nombre: {Nombre}, Posición: {Posicion}, Hits bateados: {Hits}, Errores cometidos: {Errores}";
        }
    }
}
