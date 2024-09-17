using BackendNetforemost.Contexto;
using BackendNetforemost.Controladores;
using Xunit;

namespace TestUnitarios
{
    public class UnitTest1
    {
        private readonly UsuariosController _usuariosController;
        private readonly ManejadorDeTareas _context;

        public UnitTest1()
        {
            _usuariosController = new UsuariosController(_context);
        }

        [Fact]
        public void Get_Ok()
        {
            var result = _usuariosController.GetUsuarios();
            Assert.NotNull(result);
        }

        [Fact]
        public void GetUsuario_Ok()
        {
            var result = _usuariosController.GetUsuario(1);
            Assert.NotNull(result);
        }

        [Fact]
        public void CreateUsuario_Ok()
        {
            var result = _usuariosController.CreateUsuario(new Entidad.Usuario());
            Assert.NotNull(result);
        }
    }
}