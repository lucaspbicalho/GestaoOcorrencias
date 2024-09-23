namespace GestaoOcorrencias.Web.Models.Dtos
{
    public class ClienteDto
    {
        public Guid Id { get; set; }
        public double ClienteId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public EnderecoDto? Endereco { get; set; }

    }
}
