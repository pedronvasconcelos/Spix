using Microsoft.Data.SqlClient;

namespace Spix.Application.Interfaces;

public interface ISqlConnectionFactory
{
    SqlConnection CreateConnection();
}