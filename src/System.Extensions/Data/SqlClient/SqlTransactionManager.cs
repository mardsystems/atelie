using System.Threading.Tasks;
using System.Transactions;

namespace System.Data.SqlClient
{
    public class SqlTransactionManager : IUnitOfWork
    {
        private readonly SqlConnection connection;

        private SqlTransaction transaction;

        private ConnectionState previousConnectionState;

        private int transactionsCount;

        public SqlTransactionManager(SqlConnection connection)
        {
            this.connection = connection;

            transactionsCount = 0;
        }

        public SqlCommand CreateCommand(string sql)
        {
            if (transaction == null)
            {
                connection.Open();

                return new SqlCommand(sql, connection);
            }
            else
            {
                return new SqlCommand(sql, connection, transaction);
            }
        }

        public void OpenConnectionIfClosed()
        {
            previousConnectionState = connection.State;

            if ((connection.State | ConnectionState.Open) != ConnectionState.Open)
            {
                connection.Open();
            }
        }

        public void CloseConnectionIfPreviouslyWasOpen()
        {
            if ((previousConnectionState | ConnectionState.Open) != ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public async Task BeginTransaction()
        {
            if (transactionsCount == 0)
            {
                await connection.OpenAsync();

                transaction = connection.BeginTransaction();
            }

            transactionsCount++;
        }

        public async Task Commit()
        {
            if (transactionsCount < 2)
            {
                transaction.Commit();

                transaction = null;

                connection.Close();
            }

            transactionsCount--;

            await Task.Run(() => { });
        }

        public async Task Rollback()
        {
            if (transactionsCount < 2)
            {
                transaction.Rollback();

                transaction = null;

                connection.Close();
            }

            transactionsCount--;

            await Task.Run(() => { });
        }
    }
}
