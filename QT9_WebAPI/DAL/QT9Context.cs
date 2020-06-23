using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QT9_WebAPI.DAL
{
    public class QT9Context : DbContext
    {
        public QT9Context(DbContextOptions<QT9Context> options)
            : base(options)
        {
        }

        public DbSet<QT9_WebAPI.Models.tblMovie> tblMovie { get; set; }
    }
}
