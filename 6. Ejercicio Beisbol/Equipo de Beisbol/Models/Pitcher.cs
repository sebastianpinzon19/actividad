using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Pitcher : Jugador
    {
        private int ponches;
        public int Ponches
        {
            get { return ponches; }
            set { Validaciones.ValidarNumero(value); ponches = value; }
        }

        private int errores;
        public int Errores
        {
            get { return errores; }
            set { Validaciones.ValidarNumero(value); errores = value; }
        }
        public Pitcher(int numeroUniforme, string nombre, int ponches, int errores)
            : base(numeroUniforme, nombre, "Pitcher")
        {
            Ponches = ponches;
            Errores = errores;
        }

        public override string MostrarDatos()
        {
            return $"Número de Uniforme: {NumeroUniforme}, Nombre: {Nombre}, Posición: {Posicion}, Ponches realizados: {Ponches}, Errores Cometidos {Errores}";
        }
    }
}
