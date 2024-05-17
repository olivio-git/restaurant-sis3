using Microsoft.EntityFrameworkCore;
using restaurant_sis3.Contexto;
using restaurant_sis3.Modelos.Servicios.Contratos;

namespace restaurant_sis3.Modelos.Servicios.Implementacion
{
    public class ProveedoresService : IProveedoresService
    {
        RestaurantContext restaurantContext;
        public ProveedoresService(RestaurantContext _restaurantContext)
        {
            restaurantContext = _restaurantContext;
        }
        public async Task<List<Proveedores>> ListarProveedores()
        {
            var lista = await restaurantContext.Proveedores.ToListAsync();
            return lista;
        }

        public async Task InsertarProveedores(Proveedores Proveedores)
        {
            restaurantContext.Proveedores.Add(Proveedores);
            await restaurantContext.SaveChangesAsync();
        }
        public async Task EliminarProveedores(int id)
        {
            var Proveedores = await restaurantContext.Proveedores.FindAsync(id);
            if (Proveedores != null)
            {
                restaurantContext.Proveedores.Remove(Proveedores);
                await restaurantContext.SaveChangesAsync();
            }
        }
        public async Task ModificarProveedores(Proveedores ProveedoresModificada)
        {
            restaurantContext.Entry(ProveedoresModificada).State = EntityState.Modified;
            await restaurantContext.SaveChangesAsync();
        }


    }
}
