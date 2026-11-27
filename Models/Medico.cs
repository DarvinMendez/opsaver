namespace opsaver.Models
{
    public class Medico
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public string Especialidad { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public ICollection<Clinica> Clinicas { get; set; } = new List<Clinica>();
    }
}
