using BLL;

namespace Models
{
    public class CambioDivisas
    {
		private double pesos;

		public double Pesos
		{
			get { return pesos; }
			set { Validaciones.ValidarPesos(value); pesos = value; }
		}
		private double tipoCambio;

		public double TipoCambio
		{
			get { return tipoCambio; }
			set { Validaciones.ValidarCambio(value); tipoCambio = value; }
		}

        public CambioDivisas(double p,double tc)
        {
			Pesos = p;
            TipoCambio = tc;
        }

		public double ConvertirADolares(double pesos, double tipoCambio)
		{
			
			return pesos / tipoCambio;
		}
    }
}
