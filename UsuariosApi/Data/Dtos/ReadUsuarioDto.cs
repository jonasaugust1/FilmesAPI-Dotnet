namespace UsuariosApi.Data.Dtos
{
    public class ReadUsuarioDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime HoraDaConsulta { get; set; }
    }
}
