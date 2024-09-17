using ClientNetforemost.Servicios.Usuario;
using Microsoft.AspNetCore.Components;

namespace ClientNetforemost.Components.Pages
{
    public partial class Home
    {
        [Inject] private IUsuarioServicio IUsuarioServicio { get; set; }

        private List<Entidad.Usuario> usuarios = new List<Entidad.Usuario>();
        private Entidad.Usuario usuario = new Entidad.Usuario();
        private Entidad.Usuario crear = new Entidad.Usuario();
        private bool cargando = true;

        protected override async Task OnInitializedAsync()
        {
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            usuarios = await IUsuarioServicio.ObtenerUsuariosAsync();
            cargando = false;
        }

        private void EditarUsuario(Entidad.Usuario usr)
        {
            usuario = usr;
        }

        private async Task EnviarUsuarioEditado()
        {
            await IUsuarioServicio.EditarUsuario(usuario);
            await CargarUsuarios(); 
        }

        private async Task EnviarUsuarioCreado()
        {
            await IUsuarioServicio.CrearUsuario(crear);
            await CargarUsuarios();
        }
    }
}