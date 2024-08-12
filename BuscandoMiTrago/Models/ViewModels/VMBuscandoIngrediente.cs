using System.Text.Json.Serialization;

namespace BuscandoMiTrago.Models.ViewModels
{
    public class VMBuscandoIngrediente
    {
        [JsonPropertyName("Id")]
        public string? idIngredient { get; set; }
        [JsonPropertyName("Ingrediente")]
        public string? strIngredient { get; set; }
        [JsonPropertyName("Descripción")]
        public string? strDescription { get; set; }
        [JsonPropertyName("Tipo")]
        public string? strType { get; set; }
        [JsonPropertyName("Alcohol")]
        public string? strAlcohol { get; set; }
        [JsonPropertyName("ABV")]
        public string? strABV { get; set; }
    }
}
