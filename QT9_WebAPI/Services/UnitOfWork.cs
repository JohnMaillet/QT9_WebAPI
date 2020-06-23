using QT9_WebAPI.DAL;
using QT9_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
namespace QT9_WebAPI.Services
{
    public class UnitOfWork : IDisposable
    {
        private QT9Context _qt9Context;
        private GenericRepository<tblMovie> movieRepo;

        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _qt9Context = serviceProvider.GetService<QT9Context>();
        }
        public GenericRepository<tblMovie> MovieRepository
        {
            get
            {

                if (this.movieRepo == null)
                {
                    this.movieRepo = new GenericRepository<tblMovie>(_qt9Context);
                }
                return movieRepo;
            }
        }
        public void Save()
        {
            _qt9Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _qt9Context.Dispose();
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
