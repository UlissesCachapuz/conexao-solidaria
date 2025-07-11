public class PontoApoio
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Tipo { get; set; } // Ex: "Comida", "Abrigo"
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string? Endereco { get; set; }  // <-- novo campo
    public string? Descricao { get; set; }

}