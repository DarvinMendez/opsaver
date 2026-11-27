namespace opsaver.Models
{
    public class Paciente
    {
        public int Id { get; set; }

        public string NombreCompleto { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;
    }
}