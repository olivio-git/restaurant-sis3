namespace restaurant_sis3.Modelos.Servicios.Contratos
{
    public interface IProveedoresService
    {
        Task InsertarProveedores(Proveedores Proveedores);
        Task<List<Proveedores>> ListarProveedores();
        Task ModificarProveedores(Proveedores Proveedores);
        Task EliminarProveedores(int id);
    }
}
