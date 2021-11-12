using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Laura_Gagliani
{
    class Agente : Persona
    {
       
        public string AreaGeografica { get; set; }

        public int AnnoInizio { get; set; }


        public Agente()
        {

        }
        public Agente(string nome, string cognome, string codiceFiscale, string areaGeografica, int annoInizio)
            :base (nome, cognome, codiceFiscale)
        {
            AreaGeografica = areaGeografica;
            AnnoInizio = annoInizio;
        }


        public override bool Equals(object obj)
        {
            Agente a = (Agente)obj;       
            
            if (this.CodiceFiscale == a.CodiceFiscale)
            {
                return true;
            }
            else return false;
        }

        public override string ToString()
        {
            return $"CF: {CodiceFiscale} - Nome: {Nome} – Cognome: {Cognome} – Anni di Servizio: {GetAnniServizio()}";
        }

        private int GetAnniServizio()
        {
            int annoCorrente = DateTime.Today.Year;
            return annoCorrente - AnnoInizio;
        }

    }
}
