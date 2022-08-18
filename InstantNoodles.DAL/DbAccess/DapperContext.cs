using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantNoodles.DAL.DbAccess;
public class DapperContext
{
    private readonly IConfiguration _config;
    private readonly string _connectionString;

    public DapperContext(IConfiguration config)
    {
        _config = config;
        _connectionString = config.GetConnectionString("Default");  
    }
    public IDbConnection CreateConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
