using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repository
{
    public interface IUtilizatorRepository : IDisposable
    {
        IEnumerable<Utilizator> GetUtilizator();
        Utilizator GetUtilizatorByID(int Id);
        void InsertUtilizator(Utilizator utilizator);
        void DeleteUtilizator(int ID);
        void UpdateUtilizator(Utilizator utilizator);
        void Save();
    }
}
