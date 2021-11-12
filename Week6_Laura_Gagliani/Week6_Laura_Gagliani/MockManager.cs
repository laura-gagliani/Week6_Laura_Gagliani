using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Laura_Gagliani
{
    class MockManager : IManager<Agente>
    {
        static List<Agente> mockDb = new List<Agente>()
        {
            new Agente ("Marta", "Petrini", "PTRMRT87", "Rifredi", 2001),
            new Agente ("Sergio", "Taccetti", "TCCSRG76", "Novoli", 1993),
            new Agente ("Elena", "Borselli", "BRSLNA80", "Centro", 2004),
        };

        public bool Add(Agente item)
        {
            int rows = mockDb.Count;
            mockDb.Add(item);

            if (mockDb.Count == rows++)
            {
                return true;
            }
            else return false;
        }

        public bool CheckDuplicates(Agente item)
        {
            foreach (Agente a in mockDb)
            {
                if (item.Equals(a))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Agente> GetAll()
        {
            return mockDb;
        }

        public List<string> GetAreas()
        {
            List<string> listaAree = new List<string>();

            foreach (Agente a in mockDb)
            {
                bool isDuplicate = false;

                foreach (string s in listaAree)
                {
                    if (a.AreaGeografica == s)
                    {
                        isDuplicate = true;
                    }
                }

                if (!isDuplicate)
                {
                    listaAree.Add(a.AreaGeografica);
                }
            }

            return listaAree;
        }

        public List<Agente> GetByAnniServizioMinimi(int anniMin)
        {
            List<Agente> sottolista = new List<Agente>();
            foreach (var item in mockDb)
            {
                if ((DateTime.Today.Year - item.AnnoInizio) >= anniMin)
                {
                    sottolista.Add(item);
                }
            }

            return sottolista;
        }

        public List<Agente> GetByAreaGeografica(string area)
        {
            List<Agente> sottolista = new List<Agente>();
            foreach (var item in mockDb)
            {
                if (item.AreaGeografica == area)
                {
                    sottolista.Add(item);
                }
            }

            return sottolista;
        }
    }
}
