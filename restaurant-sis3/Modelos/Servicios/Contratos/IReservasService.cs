namespace restaurant_sis3.Modelos.Servicios.Implementacion
{
    public interface IReservasService
    {
        Task InsertarReserva(Reserva Reserva);
        Task<List<Reserva>> ListarReserva();
        Task ModificarReserva(Reserva Reserva);
        Task EliminarReserva(int id);
    }
}