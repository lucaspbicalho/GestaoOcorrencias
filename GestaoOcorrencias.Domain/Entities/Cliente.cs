namespace GestaoOcorrencias.Domain.Entities
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public double ClienteId { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public Endereco? Endereco { get; set; }
    }
}