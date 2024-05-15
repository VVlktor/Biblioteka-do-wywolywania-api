using System.Text.Json.Serialization;

namespace CallingApiClass
{
    public class Uzytkownik
    {
        [JsonPropertyName("ID")]
        public int ID { get; set; }
        [JsonPropertyName("imie")]
        public string Imie {  get; set; }
        [JsonPropertyName("haslo")]
        public string Haslo { get; set; }
        [JsonPropertyName("wiek")]
        public int Wiek { get; set; }
        [JsonPropertyName("opis")]
        public string Opis { get; set; }
        [JsonPropertyName("miasto")]
        public string Miasto {  get; set; }
    }
}
