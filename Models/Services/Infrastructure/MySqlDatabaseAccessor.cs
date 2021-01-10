using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using kampus.Models.ValueTypes;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

namespace KampusStudioProto.Models.Services.Infrastructure
{
    public class MySqlDatabaseAccessor : IDatabaseAccessor
    {
        private readonly IConfiguration configuration;
        public MySqlDatabaseAccessor(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public async Task<DataSet> QueryAsync(FormattableString formattableQuery)
        {
            /* INIZIO codice che serve per evitare la SQL-injection */
            var queryArguments = formattableQuery.GetArguments();
            var mySqlParameters = new List<MySqlParameter>();
            for (var i = 0; i < queryArguments.Length; i++)
            {
                var parameter = new MySqlParameter(i.ToString(), queryArguments[i]);
                mySqlParameters.Add(parameter);
                queryArguments[i] = "@" + i;
            }
            string query = formattableQuery.ToString();
            /* FINE codice che serve per evitare la SQL-injection */

            string connectionString = configuration.GetConnectionString("Default");
            using(var conn = new MySqlConnection(connectionString))
            {
                await conn.OpenAsync();
                using(var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddRange(mySqlParameters.ToArray());
                    using(var reader = await cmd.ExecuteReaderAsync())
                    {
                        var dataSet = new DataSet();
                        dataSet.EnforceConstraints = false;
                        do
                        {
                            var dataTable = new DataTable();
                            dataSet.Tables.Add(dataTable);
                            dataTable.Load(reader);
                        } while (!reader.IsClosed);
                        return dataSet;
                    }
                }
            }
        }
    }
}