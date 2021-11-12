using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Laura_Gagliani
{
    class DbManager : IManager<Agente>
    {
        public bool Add(Agente item)
        {
            throw new NotImplementedException();
        }

        public List<Agente> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Agente> GetByAnniServizioMinimi(int anniMin)
        {
            throw new NotImplementedException();
        }

        public List<Agente> GetByAreaGeografica(string area)
        {
            throw new NotImplementedException();
        }

        public Agente GetByCodiceFiscale(string codFiscale)
        {
            throw new NotImplementedException();
        }
    }
}
