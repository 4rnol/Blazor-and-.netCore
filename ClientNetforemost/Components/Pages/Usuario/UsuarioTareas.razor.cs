using ClientNetforemost.Servicios.Usuario;
using Microsoft.AspNetCore.Components;

namespace ClientNetforemost.Components.Pages.Usuario
{
    public partial class UsuarioTareas : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }

        [Inject]
        private IUsuarioServicio IUsuarioServicio { get; set; }

        private Entidad.Usuario usuario = new Entidad.Usuario();

        private bool cargando = true;

        protected override async Task OnInitializedAsync()
        {
            usuario = await IUsuarioServicio.ObtenerUsuarioAsync(Id);
            cargando = false;
        }
    }
}