namespace GestaoOcorrencias.Domain.Entities
{
    public class Ocorrencia
    {
        public Guid Id { get; set; }
        public OcorrenciaStatus Status { get; set; }
        public string Descricao { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataOcorrencia { get; set; }
        public Cliente? ResponsavelAbertura { get; set; }
        public string? CodResponsavelAbertura { get; set; }
        public Cliente? ResponsavelOcorrencia { get; set; }
        public string? Conclusao { get; set; }
    }
}