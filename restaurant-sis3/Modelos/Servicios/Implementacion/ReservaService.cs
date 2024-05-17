using Microsoft.EntityFrameworkCore;
using restaurant_sis3.Contexto;
using restaurant_sis3.Modelos.Servicios.Contratos;
using restaurant_sis3.Modelos;

namespace restaurant_sis3.Modelos.Servicios.Implementacion
{
    public class ReservaService : IReservasService
    {
        RestaurantContext restaurantContext;
        public ReservaService(RestaurantContext _restaurantContext)
        {
            restaurantContext = _restaurantContext;
        }
        public async Task<List<Reserva>> ListarReserva()
        {
            var lista = await restaurantContext.Reservas.ToListAsync();
            return lista;
        }

        public async Task InsertarReserva(Reserva Reserva)
        {
            restaurantContext.Reservas.Add(Reserva);
            await restaurantContext.SaveChangesAsync();
        }
        public async Task EliminarReserva(int id)
        {
            var Reserva = await restaurantContext.Reservas.FindAsync(id);
            if (Reserva != null)
            {
                restaurantContext.Reservas.Remove(Reserva);
                await restaurantContext.SaveChangesAsync();
            }
        }
        public async Task ModificarReserva(Reserva ReservaModificada)
        {
            restaurantContext.Entry(ReservaModificada).State = EntityState.Modified;
            await restaurantContext.SaveChangesAsync();
        }


    }
}
