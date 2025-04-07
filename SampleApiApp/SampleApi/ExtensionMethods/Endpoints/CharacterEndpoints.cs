using SampleApi.Data;
using SampleApi.Data.DTOs;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace SampleApi.ExtensionMethods.Endpoints
{
    public static class CharacterEndpoints
    {
        // ENDPOINTS
        public static void AddCharacterEndpoints(this WebApplication app)
        {
            app.MapGet("/characters", GetAllCharactersAsync);
            app.MapGet("/characters/{id}", GetCharacterByIdAsync);
        }

        // RETURN RESULT LOGIC
        private static async Task<IResult> GetAllCharactersAsync(
            Deserializer deserializer, 
            string? gender, 
            string? nameSearch, 
            int? delay)
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

            // STEP 4 - Implement a delay
            if (delay is not null)
            {
                delay = EnforceDelayLimits((int)delay);
                await Task.Delay((int)delay);
            }

            return Results.Ok(result);
        }

        private static async Task<IResult> GetCharacterByIdAsync(
            Deserializer deserializer, 
            int id,
            int? delay)
        {
            CharacterDTO? result = deserializer.Characters.FirstOrDefault(c => c.Id == id);

            if (result == null)
            {
                return Results.NotFound();
            }

            if (delay is not null)
            {
                delay = EnforceDelayLimits((int)delay);
                await Task.Delay((int)delay);
            }

            return Results.Ok(result);
        }

        private static int EnforceDelayLimits(int delay)
        {
            if (delay > 300000)
            {
                delay = 300000;
            }

            if (delay < 0)
            {
                delay = 0;
            }

            return delay;
        }
    }
}
