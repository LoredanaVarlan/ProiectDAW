using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiect_DAW
{
    using System.Data.Entity;

    public class BookReviewContext : DbContext
    {
        public BookReviewContext()
        {

        }
        // Entities        
        public DbSet<Utilizator> utilizator { get; set; }
        public DbSet<Locatie> locatie { get; set; }
        public DbSet<Carti> carte { get; set; }
        public DbSet<Autori> autor { get; set; }
        public DbSet<Gen> gen { get; set; }
    }
}
