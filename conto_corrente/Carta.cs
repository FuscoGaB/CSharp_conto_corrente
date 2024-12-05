using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace conto_corrente
{
    internal class Carta
    {
        private string num_seriale;
        private string pin;
        private Conto conto;
        public Carta(string num_seriale, string pin, Conto conto)
        {
            this.num_seriale = num_seriale;
            this.pin = pin;
            this.conto = conto;
        }
        public string Num_seriale
        {
            get { return num_seriale; }
        }
        public string Pin
        {
            get { return pin; }

        }
        public Conto Conto
        {
            get { return conto; }
            set { conto = value; }
        }
        public double Deposita(double value)
        {
            return conto.DepositaDenaro(value);
        }
        public double Preleva(double value)
        {
            return conto.PrelevaDenaro(value);
        }
    }
}
