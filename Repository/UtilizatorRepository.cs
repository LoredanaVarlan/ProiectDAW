using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repository
{
    public class UtilizatorRepository : IUtilizatorRepository, IDisposable
    {
        private BookReviewContext context;

        public UtilizatorRepository(BookReviewContext context)
        {
            this.context = context;
        }

        public IEnumerable<Utilizator> GetUtilizator()
        {
            return context.utilizator.ToList();
        }

        public Utilizator GetUtilizatorByID(int id)
        {
            return context.utilizator.Find(id);
        }

        public void InsertUtilizator(Utilizator utilizator)
        {
            context.utilizator.Add(utilizator);
        }

        public void DeleteUtilizator(int ID)
        {
            Utilizator utilizator = context.utilizator.Find(ID);
            context.utilizator.Remove(utilizator);
        }

        public void UpdateUtilizator(Utilizator utilizator)
        {
            context.Entry(utilizator).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
