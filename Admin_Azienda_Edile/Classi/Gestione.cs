using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Admin_Azienda_Edile
{
    public class Gestione
    {
        public int IdDipendente { get; set; }
        public int IdStipendio { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Indirizzo { get; set; }
        public string Cod_Fisc { get; set; }
        public bool Coniugato { get; set; }
        public int Figli { get; set; }
        public string Mansione { get; set; }
        public string TipoStipendio { get; set; }

        public DateTime DataPag { get; set; }

        public double StipendioMensile { get; set; }

        public double ImportoPag { get; set; }


        public double LastStipendio()
        {
            return StipendioMensile - ImportoPag;
        }
    }
}