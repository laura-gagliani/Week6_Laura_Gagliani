using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week6_Laura_Gagliani
{
    interface IManager<T>
    {
        public List<T> GetAll();

        public List<T> GetByAreaGeografica(string area);

        public List<T> GetByAnniServizioMinimi(int anniMin);

        public bool Add(T item);

        public T GetByCodiceFiscale(string codFiscale);
    }
}
