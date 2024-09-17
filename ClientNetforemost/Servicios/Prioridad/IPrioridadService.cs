namespace ClientNetforemost.Servicios.Prioridad
{
    public interface IPrioridadService
    {
        Task<List<Entidad.Prioridad>> GetPrioridades();
    }
}
