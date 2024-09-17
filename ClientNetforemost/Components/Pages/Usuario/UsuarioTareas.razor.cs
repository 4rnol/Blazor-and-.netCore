using ClientNetforemost.Servicios.Prioridad;
using ClientNetforemost.Servicios.Tarea;
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

        [Inject]
        private IPrioridadService IPrioridadService { get; set; }

        [Inject]
        private ITareaServicio ITareaServicio { get; set; }

        private Entidad.Usuario usuario = new Entidad.Usuario();
        private List<Entidad.Usuario> usuarios = new List<Entidad.Usuario>();
        private Entidad.Tarea tareaCrear = new Entidad.Tarea();

        private List<Entidad.Prioridad> prioridades = new List<Entidad.Prioridad>();

        private bool cargando = true;

        protected override async Task OnInitializedAsync()
        {
            await CargarTareas();
            await CargarPrioridades();
        }

        private async Task CargarTareas()
        {
            usuario = await IUsuarioServicio.ObtenerUsuarioAsync(Id);
            cargando = false;
        }

        private async Task CargarPrioridades()
        {
            prioridades = await IPrioridadService.GetPrioridades();
            cargando = false;
        }

        private async Task CrearTarea()
        {

            tareaCrear.UsuarioId = Id;
            await ITareaServicio.CrearTarea(tareaCrear);
            await CargarTareas();
        }




    }
}