using System.Data;

namespace BookStore.Interfaces
{
    public interface IDapperDbConnection
    {
        public IDbConnection CreateConnection();
    }
}
