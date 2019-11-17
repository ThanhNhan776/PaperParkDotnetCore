using System;
using System.Data;
using PaperPark.Repository.Interface;

namespace PaperPark.Repository.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed;

        public UnitOfWork(IDbConnection connection)
        {
            Connection = connection;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }
        public void Begin()
        {
            if (Connection.State != ConnectionState.Open) Connection.Open();
            Transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            Transaction.Commit();
            Dispose();
        }

        public void Rollback()
        {
            Transaction.Rollback();
            Dispose();
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (Transaction != null)
                    {
                        Transaction.Dispose();
                        Transaction = null;
                    }
                }

                _disposed = true;
            }
        }
    }
}