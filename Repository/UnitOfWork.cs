using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW.Repository
{
    public class UnitOfWork : IDisposable
    {
        private BookReviewContext context = new BookReviewContext();
        private GenericRepository<Carti> cartiRepository;
        private GenericRepository<Autori> autoriRepository;
        private GenericRepository<Gen> genRepository;
        private GenericRepository<Locatie> locatieRepository;

        public GenericRepository<Carti> CartiRepository
        {
            get
            {

                if (this.cartiRepository == null)
                {
                    this.cartiRepository = new GenericRepository<Carti>(context);
                }
                return cartiRepository;
            }
        }

        public GenericRepository<Autori> AutoriRepository
        {
            get
            {

                if (this.autoriRepository == null)
                {
                    this.autoriRepository = new GenericRepository<Autori>(context);
                }
                return autoriRepository;
            }
        }

        public GenericRepository<Gen> GenRepository
        {
            get
            {

                if (this.genRepository == null)
                {
                    this.genRepository = new GenericRepository<Gen>(context);
                }
                return genRepository;
            }
        }

        public GenericRepository<Locatie> LocatieRepository
        {
            get
            {

                if (this.locatieRepository == null)
                {
                    this.locatieRepository = new GenericRepository<Locatie>(context);
                }
                return locatieRepository;
            }
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
