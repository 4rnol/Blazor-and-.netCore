namespace ClientNetforemost.Servicios.Tarea
{
    public interface ITareaServicio
    {
        Task EditarTarea(Entidad.Tarea tarea);
        Task CrearTarea(Entidad.Tarea tarea);
    }
}
