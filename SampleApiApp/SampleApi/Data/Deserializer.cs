using SampleApi.Data.DTOs;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;

namespace SampleApi.Data
{
    public class Deserializer
    {
        private readonly List<CharacterDTO> characters;

        public Deserializer()
        {
            var options = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
            };

            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "Datasets", "hp-characters.json");
            string json = File.ReadAllText(filePath);

            this.characters = JsonSerializer.Deserialize<List<CharacterDTO>>(json, options) ?? new List<CharacterDTO>();
        }

        public List<CharacterDTO> Characters { get { return characters; } }
    }
}
