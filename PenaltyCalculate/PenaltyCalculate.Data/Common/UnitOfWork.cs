﻿using System;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace PenaltyCalculate.Data.Common
{
    /// <summary>
    /// The Entity Framework implementation of IUnitOfWork
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// The DbContext
        /// </summary>
        private DbContext _dbContext;
        private IDbTransaction _transaction;
        /// <summary>
        /// Initializes a new instance of the UnitOfWork class.
        /// </summary>
        /// <param name="context">The object context</param>
        public UnitOfWork(DbContext context)
        {
            _dbContext = context;
        }


        /// <summary>
        /// Gets the Context Object
        /// </summary>
        /// <returns>Returns Current Context Class Object</returns>
        public DbContext getContext()
        {
            return _dbContext;
        }

        /// <summary>
        /// Begins a transaction by creating a transaction object
        /// </summary>
        public void BeginTransaction()
        {
            if (_dbContext.Database.Connection.State == ConnectionState.Open)
            {
                return;
            }
            _dbContext.Database.Connection.Open();
            _transaction = _dbContext.Database.Connection.BeginTransaction();
        }

        /// <summary>
        /// Saves all pending changes
        /// </summary>
        /// <returns>The number of objects in an Added, Modified, or Deleted state</returns>
        public int Commit()
        {
            _transaction.Commit();
            // Save changes with the default options
            int retVal = 0;
            bool saveFailed;
            do
            {
                saveFailed = false;
                try
                {
                    retVal = _dbContext.SaveChanges();
                }
                catch (System.Data.Entity.Infrastructure.DbUpdateConcurrencyException ex)
                {
                    saveFailed = true;
                    try
                    {
                        // Update original values from the database
                        var entry = ex.Entries.Single();
                        entry.OriginalValues.SetValues(entry.GetDatabaseValues());
                    }
                    catch { }
                }
            } while (saveFailed);
            return retVal;
        }

        /// <summary>
        /// Disposes the current object
        /// </summary>
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}
        public void Dispose()
        {
            if (_dbContext != null)
            {
                _dbContext.Dispose();
            }
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// Disposes all external resources.
        /// </summary>
        /// <param name="disposing">The dispose indicator.</param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_dbContext != null)
                {
                    _dbContext.Dispose();
                    _dbContext = null;
                }
            }
        }

        /// <summary>
        /// Rollbacks a particular Transaction
        /// </summary>
        public void RollBack()
        {
            _transaction.Rollback();
        }
    }
}
