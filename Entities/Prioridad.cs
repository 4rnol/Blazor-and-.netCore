namespace Entidad
{
    public class Prioridad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Tarea> Tareas { get; set; }
    }

}
