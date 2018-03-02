﻿using NetCoreDataAccess.Repository;
using System;
using Microsoft.EntityFrameworkCore;

namespace NetCoreDataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public Repository<T> GetRepository<T>() where T : class
        {
            var repository = new Repository<T>(_context);
            return repository;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        private bool _disposed;

        public virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}