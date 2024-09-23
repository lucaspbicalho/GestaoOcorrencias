namespace GestaoOcorrencias.Web.Models.Dtos
{
    public class EnderecoDto
    {
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string UF { get; set; }
        public double CEP { get; set; }
    }
}
