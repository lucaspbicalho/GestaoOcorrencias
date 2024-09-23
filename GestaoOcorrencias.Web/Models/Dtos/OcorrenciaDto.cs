namespace GestaoOcorrencias.Web.Models.Dtos
{
    public class OcorrenciaDto
    {
        public Guid Id { get; set; }
        public OcorrenciaStatus Status { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataOcorrencia { get; set; }
        public ClienteDto? ResponsavelAbertura { get; set; }
        public string? CodResponsavelAbertura { get; set; }
        public ClienteDto? ResponsavelOcorrencia { get; set; }
        public string? Conclusao { get; set; }
    }
}
