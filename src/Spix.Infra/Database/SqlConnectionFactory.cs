using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Spix.Application.Interfaces;


namespace Spix.Infra.Database;

public sealed class SqlConnectionFactory : ISqlConnectionFactory
{
    private readonly IConfiguration _configuration;

    public SqlConnectionFactory(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public SqlConnection CreateConnection()
    {
        return new SqlConnection(
            _configuration.GetConnectionString("DefaultConnection"));
    }
}
