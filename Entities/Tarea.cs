namespace Entidad
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Finalizado { get; set; }
        public bool Eliminado { get; set; }
        public string Tags { get; set; }

        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public int UsuarioId { get; set; }


        public Usuario Usuario { get; set; }
        public int PrioridadId { get; set; }
        public Prioridad Prioridad { get; set; }


    }
}
