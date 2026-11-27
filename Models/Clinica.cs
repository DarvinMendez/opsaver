namespace opsaver.Models
{
    public class Clinica
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = string.Empty;

        public string Direccion { get; set; } = string.Empty;

        public string Telefono { get; set; } = string.Empty;

        public string Correo { get; set; } = string.Empty;

        public ICollection<Medico> Medicos { get; set; } = new List<Medico>();
    }
}