namespace GestaoOcorrencias.Domain.Entities
{
    public class Endereco
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public double CEP { get; set; }

    }
}