using BlazorBootstrap;
using ClientNetforemost.Servicios.Usuario;
using Microsoft.AspNetCore.Components;

namespace ClientNetforemost.Components.Pages
{
    public partial class Home
    {
        [Inject] private IUsuarioServicio IUsuarioServicio { get; set; }

        [Inject] private NavigationManager NavigationManager { get; set; }

        private List<Entidad.Usuario> usuarios = new List<Entidad.Usuario>();
        private Entidad.Usuario usuario = new Entidad.Usuario();
        private Entidad.Usuario crear = new Entidad.Usuario();
        private bool cargando = false;

        List<ToastMessage> messages = new List<ToastMessage>();

        private Modal modalCrear;
        private Modal modalEditar;

        private async Task OnShowModalCrearClick()
        {
            await modalCrear?.ShowAsync();
        }

        private async Task OnHideModalCrearClick()
        {
            await modalCrear?.HideAsync();
        }
        private async Task OnShowModalEditarClick()
        {
            await modalEditar?.ShowAsync();
        }
        private async Task OnHideModalEditarClick()
        {
            await modalEditar?.HideAsync();
        }
        private void ShowMessage(ToastType toastType, string msg)
        {
            messages.Add(CreateToastMessage(toastType, msg));
        }

        private ToastMessage CreateToastMessage(ToastType toastType, string msg)
            => new ToastMessage
            {
                Type = toastType,
                Message = $"{msg}: {DateTime.Now}",
            };

        protected override async Task OnInitializedAsync()
        {
            await CargarUsuarios();
        }

        private async Task CargarUsuarios()
        {
            usuarios = await IUsuarioServicio.ObtenerUsuariosAsync();
        }

        private void EditarUsuario(Entidad.Usuario usr)
        {
            usuario = usr;
            OnShowModalEditarClick();
        }

        private async Task EnviarUsuarioEditado()
        {
            await IUsuarioServicio.EditarUsuario(usuario);
            await CargarUsuarios();
            await modalEditar?.HideAsync();
            ShowMessage(ToastType.Success, "Usuario Editado Correctamente");
        }

        private async Task EnviarUsuarioCreado()
        {
            await IUsuarioServicio.CrearUsuario(crear);
            await CargarUsuarios();
            await modalCrear?.HideAsync();
            ShowMessage(ToastType.Success, "Usuario Creado Correctamente");
        }

        private void EditarTareas(Entidad.Usuario usr)
        {
            NavigationManager.NavigateTo($"/usuario/{usr.Id}");
        }
    }
}