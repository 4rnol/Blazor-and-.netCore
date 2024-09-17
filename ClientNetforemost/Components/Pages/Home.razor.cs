using ClientNetforemost.Servicios.Usuario;
using Microsoft.AspNetCore.Components;

namespace ClientNetforemost.Components.Pages
{
    public partial class Home
    {
        [Inject] private IUsuarioServicio IUsuarioServicio { get; set; }

        private List<Entidad.Usuario> usuarios = new List<Entidad.Usuario>();
        private Entidad.Usuario usuario = new Entidad.Usuario();
        private bool cargando = true;

        protected override async Task OnInitializedAsync()
        {
            usuarios = await IUsuarioServicio.ObtenerUsuariosAsync();
            cargando = false;
        }

        private void EditarUsuario(Entidad.Usuario usr)
        {
            usuario = usr;
        }

        private void EnviarUsuarioEditado()
        {
            IUsuarioServicio.EditarUsuario(usuario);

        }
    }
}