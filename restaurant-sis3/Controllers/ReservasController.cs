using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restaurant_sis3.Modelos.Servicios.Contratos;
using restaurant_sis3.Modelos;

namespace restaurant_sis3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly IReservaService _ReservaService;

        public ReservaController(IReservaService ReservaService)
        {
            _ReservaService = ReservaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Reserva>>> Index()
        {
            return await _ReservaService.ListarReserva();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Reserva Reserva)
        {
            if (Reserva != null)
            {
                await _ReservaService.InsertarReserva(Reserva);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Reserva Reserva)
        {
            if (id != Reserva.ReservaId)
            {
                return BadRequest("El ID de la Reserva no coincide con el ID proporcionado.");
            }

            try
            {
                await _ReservaService.ModificarReserva(Reserva);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la Reserva: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ReservaService.EliminarReserva(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la Reserva: {ex.Message}");
            }
        }
    }
}
