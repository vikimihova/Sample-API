namespace SampleTestUI.ViewModels
{
    public class CharacterViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Species { get; set; } = null!;

        public string Gender { get; set; } = null!;

        public string? House { get; set; }

        public string? DateOfBirth { get; set; }

        public int? YearOfBirth { get; set; }

        public WandViewModel? Wand { get; set; }

        public string? Patronus { get; set; }
    }
}
