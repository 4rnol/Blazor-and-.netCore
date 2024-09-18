using BlazorBootstrap;
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
        private Entidad.Tarea tareaEditar = new Entidad.Tarea();

        private List<Entidad.Prioridad> prioridades = new List<Entidad.Prioridad>();

        private bool cargando = true;

        List<ToastMessage> messages = new List<ToastMessage>();

        private void ShowMessage(ToastType toastType)
        {
            messages.Add(CreateToastMessage(toastType));
        }

        private ToastMessage CreateToastMessage(ToastType toastType)
            => new ToastMessage
            {
                Type = toastType,
                Message = $"Hello, world! This is a simple toast message. DateTime: {DateTime.Now}",
            };

        protected override async Task OnInitializedAsync()
        {
            tareaCrear.FechaVencimiento = DateTime.Now;
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
            ShowMessage(ToastType.Success);
        }

        private async Task EditarTarea()
        {
            await ITareaServicio.EditarTarea(tareaEditar);
            await CargarTareas();
            ShowMessage(ToastType.Success);
        }

    }
}