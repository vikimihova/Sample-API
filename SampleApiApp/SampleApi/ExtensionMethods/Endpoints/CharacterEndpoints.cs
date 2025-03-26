using SampleApi.Data;
using SampleApi.Data.DTOs;

namespace SampleApi.ExtensionMethods.Endpoints
{
    public static class CharacterEndpoints
    {
        public static void AddCharacterEndpoints(this WebApplication app)
        {
            app.MapGet("/characters", GetAllCharacters);
        }

        // RETURN RESULT LOGIC
        private static IResult GetAllCharacters(Deserializer deserializer, string? gender, string? nameSearch)
        {
            // STEP 1 - Get all
            List<CharacterDTO> result = deserializer.Characters;

            // STEP 2 - Filter by gender
            if (string.IsNullOrWhiteSpace(gender) == false) 
            {
                if (gender.ToLowerInvariant() != "female" &&
                    gender.ToLowerInvariant() != "male")
                {
                    return Results.BadRequest();
                }

                result.RemoveAll(c => c.Gender.ToLowerInvariant() != gender.ToLowerInvariant());
            }

            // STEP 3 - Search by name
            if (string.IsNullOrWhiteSpace(nameSearch) == false)
            {
                result.RemoveAll(c => !c.Name.ToLowerInvariant().Contains(nameSearch.ToLowerInvariant()));

                if (!result.Any())
                {
                    return Results.NotFound();
                }
            }

            return Results.Ok(result);
        }

        }
    }
}
