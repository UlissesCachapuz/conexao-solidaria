namespace ConexaoSolidaria.Models
{
    public class Pessoa
    {
        public int Id { get; set; }
        public string? NomeCompleto { get; set; }
        public string? DataNascimento { get; set; }
        public string? CPF { get; set; }
        public string? RG { get; set; }
        public string? NomeMae { get; set; }
        public string? Foto { get; set; }
        public string? TelefoneCelular { get; set; }
        public string? TelefoneFixo { get; set; }
        public string? NumeroPessoasFamilia { get; set; }
        public string? EnderecoReferencia { get; set; }
        public string? Renda { get; set; }
        public string? Profissao { get; set; }
        public string? ProgramaSocial { get; set; }
        public string? TempoPermanenciaRua { get; set; }
        public string? MotivoSituacaoRua { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }
        public string? Necessidade { get; set; }
        public string? Tipo { get; set; } 
    }
}