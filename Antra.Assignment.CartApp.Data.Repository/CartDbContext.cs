using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Antra.Assignment.CartApp.Data.Repository
{
    class CartDbContext
    {
        
        public IDbConnection GetDataConnection()
        {
                string conn = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build().GetConnectionString("CartApp");
                return new SqlConnection(conn);
        }
        
    }
}
