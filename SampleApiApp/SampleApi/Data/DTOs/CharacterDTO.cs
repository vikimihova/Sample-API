using System.ComponentModel.DataAnnotations;

namespace SampleApi.Data.DTOs
{
    public class CharacterDTO
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Species { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        public string? House { get; set; }

        public string? DateOfBirth { get; set; }

        public int? YearOfBirth { get; set; }

        public WandDTO? Wand { get; set; }

        public string? Patronus { get; set; }
    }
}
