using EvaluacionNet.Entities;
using EvaluacionNet.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionNet.Bussines.interfaces.Calculo
{
    public interface ICalculoBussines
    {
        Task<ResultResponse<CalculoModel>> InsertarCalculo(string nombre, int limite);
        Task<ResultResponse<CalculoModel>> ActualizarCalculo(CalculoModel calculo);
        Task<ResultResponse<CalculoModel>> EliminarCalculo(int id);
        Task<ResultResponse<CalculoModel>> ListaCalculos();
    }
}
