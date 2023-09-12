using EvaluacionNet.Entities;
using EvaluacionNet.Util;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvaluacionNet.Repository.interfaces.Calculo
{
    public interface ICalculoRepository
    {
        Task<ResultResponse<CalculoModel>> InsertarCalculo(CalculoModel calculo);
        Task<ResultResponse<CalculoModel>> ActualizarCalculo(CalculoModel calculo);
        Task<ResultResponse<CalculoModel>> EliminarCalculo(int id);
        Task<ResultResponse<CalculoModel>> ListaCalculos();

    }
}
