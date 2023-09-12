using EvaluacionNet.Bussines.interfaces.Calculo;
using EvaluacionNet.Entities;
using EvaluacionNet.Repository.interfaces.Calculo;
using EvaluacionNet.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionNet.Bussines.Calculo
{
    public class CalculoBussines : ICalculoBussines
    {
        private readonly ICalculoRepository _repository;

        public CalculoBussines(ICalculoRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResultResponse<CalculoModel>> ActualizarCalculo(CalculoModel calculo)
        {
            int valor = Operaciones.SumarMultiplosDeTresYCinco((int)calculo.limite);
            ResultResponse<CalculoModel> resultResponse = new ResultResponse<CalculoModel>();

            try
            {
                if (valor < 0)
                {
                    throw new Exception("El limite es cero o inferior");
                }

                calculo.Valor = valor;
                resultResponse = await _repository.ActualizarCalculo(calculo);

                return resultResponse;
            }
            catch (Exception ex)
            {
                resultResponse = new ResultResponse<CalculoModel>
                {
                    Error = true,
                    ErrorMessage = ex.Message,
                    ResponseCode = (int)HttpStatusCode.InternalServerError,
                    ResponseMessage = HttpStatusCode.InternalServerError.ToString()
                };
                return resultResponse;
            }
        }

        public async Task<ResultResponse<CalculoModel>> EliminarCalculo(int id)
        {
            ResultResponse<CalculoModel> resultResponse = new ResultResponse<CalculoModel>();

            try
            {
                resultResponse = await _repository.EliminarCalculo(id);

                return resultResponse;
            }
            catch (Exception ex)
            {
                resultResponse = new ResultResponse<CalculoModel>
                {
                    Error = true,
                    ErrorMessage = ex.Message,
                    ResponseCode = (int)HttpStatusCode.InternalServerError,
                    ResponseMessage = HttpStatusCode.InternalServerError.ToString()
                };
                return resultResponse;
            }
        }

        public async Task<ResultResponse<CalculoModel>> InsertarCalculo(string nombre, int limite)
        {
            int valor = Operaciones.SumarMultiplosDeTresYCinco(limite);
            ResultResponse<CalculoModel> resultResponse = new ResultResponse<CalculoModel>();

            try
            {
                if (valor <= 0)
                {
                    throw new Exception("El limite es cero o inferior");
                }
                if (!Validaciones.UsuarioEsValido(nombre))
                {
                    throw new Exception("El usuaio no es valido");
                }

                CalculoModel calculo = new CalculoModel
                {
                    Id = 0,
                    Valor = valor,
                    Usuario = nombre,
                    Fecha = DateTime.Now,
                    limite = limite
                };

                resultResponse = await _repository.InsertarCalculo(calculo);

                return resultResponse;
            }
            catch (Exception ex)
            {
                resultResponse = new ResultResponse<CalculoModel>
                {
                    Error = true,
                    ErrorMessage = ex.Message,
                    ResponseCode = (int)HttpStatusCode.InternalServerError,
                    ResponseMessage = HttpStatusCode.InternalServerError.ToString()
                };
                return resultResponse;
            }
        }

        public async Task<ResultResponse<CalculoModel>> ListaCalculos()
        {
            ResultResponse<CalculoModel> resultResponse = new ResultResponse<CalculoModel>();

            try
            {
                resultResponse = await _repository.ListaCalculos();

                return resultResponse;
            }
            catch (Exception ex)
            {
                resultResponse = new ResultResponse<CalculoModel>
                {
                    Error = true,
                    ErrorMessage = ex.Message,
                    ResponseCode = (int)HttpStatusCode.InternalServerError,
                    ResponseMessage = HttpStatusCode.InternalServerError.ToString()
                };
                return resultResponse;
            }
        }
    }
}
