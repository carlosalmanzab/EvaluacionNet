using EvaluacionNet.Bussines.interfaces.Calculo;
using EvaluacionNet.Entities;
using EvaluacionNet.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EvaluacionNet.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly ICalculoBussines _calculoBusiness;

        public CalculoController(ICalculoBussines calculoBusiness)
        {
            _calculoBusiness = calculoBusiness;
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(ResultResponse<CalculoModel>))]
        [HttpGet("listarCalculo")]
        public async Task<IActionResult> listarCalculos()
        {
            ResultResponse<CalculoModel> response = await _calculoBusiness.ListaCalculos();
            return StatusCode(response.ResponseCode, response);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(ResultResponse<bool>))]
        [HttpPost("GuardarCalculo")]
        public async Task<IActionResult> GuardarCalculos(String username, int limit)
        {
            ResultResponse<CalculoModel> response = await _calculoBusiness.InsertarCalculo(username,limit);
            return StatusCode(response.ResponseCode, response);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(ResultResponse<bool>))]
        [HttpDelete("EliminarCalculo")]
        public async Task<IActionResult> EliminarCalculos(int id)
        {
            ResultResponse<CalculoModel> response = await _calculoBusiness.EliminarCalculo(id);
            return StatusCode(response.ResponseCode, response);
        }

        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        [Produces("application/json", Type = typeof(ResultResponse<bool>))]
        [HttpPut("ActualizarCalculo")]
        public async Task<IActionResult> ActualizarCalculos(CalculoModel calculo)
        {
            ResultResponse<CalculoModel> response = await _calculoBusiness.ActualizarCalculo(calculo);
            return StatusCode(response.ResponseCode, response);
        }
    }
}
