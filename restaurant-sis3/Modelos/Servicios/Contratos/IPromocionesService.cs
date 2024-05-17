namespace restaurant_sis3.Modelos.Servicios.Contratos
{
    public interface IPromocionesService
    {
        Task InsertarPromociones(Promociones Promociones);
        Task<List<Promociones>> ListarPromociones();
        Task ModificarPromociones(Promociones Promociones);
        Task EliminarPromociones(int id);
    }
}
