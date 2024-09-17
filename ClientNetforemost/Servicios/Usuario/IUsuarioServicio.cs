

namespace ClientNetforemost.Servicios.Usuario
{
    public interface IUsuarioServicio
    {
        Task<List<Entidad.Usuario>> ObtenerUsuariosAsync();
        Task<Entidad.Usuario> ObtenerUsuarioAsync(int id);
        void EditarUsuario(Entidad.Usuario usuario);
    }
}
