namespace opsaver.Models
{
    public class Resena
    {
        public int Id { get; set; }

        public int Calificacion { get; set; }

        public string Comentario { get; set; } = string.Empty;

        public DateTime Fecha { get; set; }

        public int MedicoId { get; set; }

        public int PacienteId { get; set; }

        public Medico? Medico { get; set; }

        public Paciente? Paciente { get; set; }
    }
}