using SampleApi.Data;

namespace SampleApi.ExtensionMethods.Endpoints
{
    public static class CharacterEndpoints
    {
        public static void AddCharacterEndpoints(this WebApplication app)
        {
            app.MapGet("/characters", GetAllCharacters);
        }

        private static IResult GetAllCharacters(Deserializer deserializer)
        {
            return Results.Ok(deserializer.Characters);
        }
    }
}
