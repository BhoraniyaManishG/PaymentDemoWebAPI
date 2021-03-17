using Microsoft.EntityFrameworkCore;
using PaymentDemoRepository.IRepositories;
using PaymentDemoRepository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoRepository.Abstraction
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        DbContext _dbContext;

        
        public UnitOfWork(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UnitOfWork()
        {

        }

        public int Commit()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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

        //

        private PaymentInfoRepo paymentInfoRepo;
        public IPaymentInfoRepo PaymentInfoRepo => this.paymentInfoRepo ?? (this.paymentInfoRepo = new PaymentInfoRepo(_dbContext));

        private PaymentStatusInfoRepo paymentStatusInfoRepo;
        public IPaymentStatusInfoRepo PaymentStatusInfoRepo => this.paymentStatusInfoRepo ?? (this.paymentStatusInfoRepo = new PaymentStatusInfoRepo(_dbContext));

    }
}
