

namespace ClientNetforemost.Servicios.Usuario
{
    public interface IUsuarioServicio
    {
        Task<List<Entidad.Usuario>> ObtenerUsuariosAsync();
        Task<Entidad.Usuario> ObtenerUsuarioAsync(int id);
        Task EditarUsuario(Entidad.Usuario usuario);
        Task CrearUsuario(Entidad.Usuario usuario);
    }
}
