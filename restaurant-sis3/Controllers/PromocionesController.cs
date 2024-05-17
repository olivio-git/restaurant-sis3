using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restaurant_sis3.Modelos;
using restaurant_sis3.Modelos.Servicios.Contratos;

namespace restaurant_sis3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocionesController : ControllerBase
    {
        private readonly IPromocionesService _PromocionesService;

        public PromocionesController(IPromocionesService PromocionesService)
        {
            _PromocionesService = PromocionesService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Promociones>>> Index()
        {
            return await _PromocionesService.ListarPromociones();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Promociones Promociones)
        {
            if (Promociones != null)
            {
                await _PromocionesService.InsertarPromociones(Promociones);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Promociones Promociones)
        {
            if (id != Promociones.PromocionId)
            {
                return BadRequest("El ID de la Promociones no coincide con el ID proporcionado.");
            }

            try
            {
                await _PromocionesService.ModificarPromociones(Promociones);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la Promociones: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _PromocionesService.EliminarPromociones(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la Promociones: {ex.Message}");
            }
        }
    }
}
