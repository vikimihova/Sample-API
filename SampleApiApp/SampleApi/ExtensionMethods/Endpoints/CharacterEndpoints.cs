using SampleApi.Data;

namespace SampleApi.ExtensionMethods.Endpoints
{
    public static class CharacterEndpoints
    {
        public static void AddCharacterEndpoints(this WebApplication app)
        {
            app.MapGet("/characters", (Deserializer deserializer) =>
            {
                return deserializer.Characters;
            });
        }
    }
}
