using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Atelie
{
    public class UnitOfWorkStub : IUnitOfWork
    {
        public async Task BeginTransaction()
        {

        }

        public async Task Commit()
        {

        }

        public async Task Rollback()
        {

        }
    }
}
