using Microsoft.EntityFrameworkCore;
using restaurant_sis3.Contexto;
using restaurant_sis3.Modelos.Servicios.Contratos;


namespace restaurant_sis3.Modelos.Servicios.Implementacion
{
    public class PromocionesService : IPromocionesService
    {
        RestaurantContext restaurantContext;
        public PromocionesService(RestaurantContext _restaurantContext)
        {
            restaurantContext = _restaurantContext;
        }
        public async Task<List<Promociones>> ListarPromociones()
        {
            var lista = await restaurantContext.Promociones.ToListAsync();
            return lista;
        }

        public async Task InsertarPromociones(Promociones promociones)
        {
            restaurantContext.Promociones.Add(promociones);
            await restaurantContext.SaveChangesAsync();
        }
        public async Task EliminarPromociones(int id)
        {
            var Promociones = await restaurantContext.Promociones.FindAsync(id);
            if (Promociones != null)
            {
                restaurantContext.Promociones.Remove(Promociones);
                await restaurantContext.SaveChangesAsync();
            }
        }
        public async Task ModificarPromociones(Promociones PromocionesModificada)
        {
            restaurantContext.Entry(PromocionesModificada).State = EntityState.Modified;
            await restaurantContext.SaveChangesAsync();
        }


    }
}
