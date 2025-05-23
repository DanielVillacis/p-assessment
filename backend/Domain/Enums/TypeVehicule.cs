using System.Text.Json.Serialization;

namespace TestProgi.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TypeVehicule
    {
        Ordinaire,
        Deluxe,
    }

    public static class TypeVehiculeExtensions
    {
        public static List<string> GetAvailableTypes()
        {
            return Enum.GetNames(typeof(TypeVehicule)).ToList();
        }
    }

}
