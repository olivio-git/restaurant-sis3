using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using restaurant_sis3.Modelos.Servicios.Contratos;
using restaurant_sis3.Modelos;

namespace restaurant_sis3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly IProveedoresService _ProveedoresService;

        public ProveedoresController(IProveedoresService ProveedoresService)
        {
            _ProveedoresService = ProveedoresService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Proveedores>>> Index()
        {
            return await _ProveedoresService.ListarProveedores();
        }

        [HttpPost]
        public async Task<ActionResult> Post(Proveedores Proveedores)
        {
            if (Proveedores != null)
            {
                await _ProveedoresService.InsertarProveedores(Proveedores);
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Proveedores Proveedores)
        {
            if (id != Proveedores.ProveedorId)
            {
                return BadRequest("El ID de la Proveedores no coincide con el ID proporcionado.");
            }

            try
            {
                await _ProveedoresService.ModificarProveedores(Proveedores);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al actualizar la Proveedores: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _ProveedoresService.EliminarProveedores(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar la Proveedores: {ex.Message}");
            }
        }
    }
}
