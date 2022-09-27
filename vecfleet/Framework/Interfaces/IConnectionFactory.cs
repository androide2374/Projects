using System;
using System.Data.Common;

namespace Framework.Interfaces
{
    public interface IConnectionFactory
    {
        DbConnection CreateDbConnection();
    }
}

