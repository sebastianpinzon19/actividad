using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BateadorDesignado : Jugador
    {
        private int hits;
        public int Hits
        {
            get { return hits; }
            set { Validaciones.ValidarNumero(value); hits = value; }
        }

        public BateadorDesignado(int numeroUniforme, string nombre, int hits)
            : base(numeroUniforme, nombre, "Bateador Designado")
        {
            Hits = hits;
        }

        public override string MostrarDatos()
        {
            return $"Número de uniforme: {NumeroUniforme}, Nombre: {Nombre}, Posición: {Posicion}, Hits Bateados: {Hits}";
        }
    }
}
