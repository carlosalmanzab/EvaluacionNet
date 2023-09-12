using EvaluacionNet.Entities;
using EvaluacionNet.Repository.interfaces.Calculo;
using EvaluacionNet.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionNet.Repository.Calculo
{
    public class CalculoRepository: ICalculoRepository
    {
        private readonly Dictionary<string, Object> parametros;
        private ResultResponse<CalculoModel> resultCalculoModel;
        private readonly string connectionRepository;

        public CalculoRepository(IConfiguration conf) 
        {
            this.parametros = new Dictionary<string, Object>();
            this.resultCalculoModel = new ResultResponse<CalculoModel>();
            connectionRepository = conf.GetConnectionString("MyConnection");
        }

        public async Task<ResultResponse<CalculoModel>> InsertarCalculo(CalculoModel calculo)
        {
            parametros.Clear();
            parametros.Add("@Usuario", calculo.Usuario);
            parametros.Add("@Limite", calculo.limite);
            parametros.Add("@Valor", calculo.Valor);
            parametros.Add("@Fecha", DateTime.Now);

            using (DapperManager<CalculoModel> dapper = new DapperManager<CalculoModel>(connectionRepository))
            {
                resultCalculoModel = await dapper.ExecuteQueryCustom<CalculoModel>("INSERT_Calculo", parametros);
            }
            return resultCalculoModel;
        }

        public async Task<ResultResponse<CalculoModel>> ActualizarCalculo(CalculoModel calculo)
        {
            parametros.Clear();
            parametros.Add("@Id", calculo.Id);
            parametros.Add("@Usuario", calculo.Usuario);
            parametros.Add("@Limite", calculo.limite);
            parametros.Add("@Valor", calculo.Valor);
            parametros.Add("@Fecha", calculo.Fecha);

            using (DapperManager<bool> dapper = new DapperManager<bool>(connectionRepository))
            {
                //resultCalculoModel = await dapper.ExecuteQueryCustom("UPDATE_Calculo", parametros);
            }
            return resultCalculoModel;
        }

        public async Task<ResultResponse<CalculoModel>> EliminarCalculo(int id)
        {
            parametros.Clear();
            parametros.Add("@Id", id);

            using (DapperManager<CalculoModel> dapper = new DapperManager<CalculoModel>(connectionRepository))
            {
                resultCalculoModel = await dapper.ExecuteQueryCustom<CalculoModel>("DELETE_Calculo", parametros);
            }
            return resultCalculoModel;
        }


        public async Task<ResultResponse<CalculoModel>> ListaCalculos()
        {
            parametros.Clear();
            using (DapperManager<CalculoModel> dapper = new DapperManager<CalculoModel>(connectionRepository))
            {
                resultCalculoModel = await dapper.ExecuteQueryCustom<CalculoModel>("SELECT_Calculo", parametros);
            }
            return resultCalculoModel;
        }
    }
}
