using Dapper;
using EvaluacionNet.Util;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionNet.Repository
{
    public class DapperManager<T> : IDisposable
    {
        private readonly IDbConnection connection;

        public DapperManager(string connectionString)
        {
            connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            connection.Close();
            connection.Dispose();
        }
        
        /// <summary>
        /// Ejecutar Stored Procedured con Dapper
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="parametros"></param>
        /// <returns></returns>
        public async Task<ResultResponse<T>> ExecuteQueryCustom<T>(string sql, Dictionary<string, Object> parametros = null)
        {
            if(connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
            try
            {
                DynamicParameters dynamicParameters = new DynamicParameters(parametros);
                if (parametros != null)
                {
                    foreach (var kvp in parametros)
                    {
                        dynamicParameters.Add(kvp.Key, kvp.Value);
                    }
                }

                List<T> values = new List<T>();
                values = (await connection.QueryAsync<T>(sql, dynamicParameters, commandType: CommandType.StoredProcedure)).ToList();
                return new ResultResponse<T> { ResultData = values };
            }
            catch(Exception ex)
            {
                return new ResultResponse<T> 
                { 
                    Error = true, 
                    ResponseCode = (int)HttpStatusCode.InternalServerError,
                    ErrorMessage = ex.Message,
                };
            }

        }

    }

}
