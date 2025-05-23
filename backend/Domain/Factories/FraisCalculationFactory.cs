using TestProgi.Domain.Enums;
using TestProgi.Domain.Strategies;

namespace TestProgi.Domain.Factories
{
    public static class FraisCalculationFactory
    {
        public static IFraisCalculationStrategy CreateFraisBaseStrategy(TypeVehicule typeVehicule)
        {
            switch (typeVehicule)
            {
                case TypeVehicule.Ordinaire:
                    return new FraisBaseOrdinaireStrategy();
                case TypeVehicule.Deluxe:
                    return new FraisBaseDeluxeStrategy();
                default:
                    throw new ArgumentException("Type de véhicule non supporté", nameof(typeVehicule));
            }
        }

        public static IFraisSpeciauxStrategy CreateFraisSpeciauxStrategy(TypeVehicule typeVehicule)
        {
            switch (typeVehicule)
            {
                case TypeVehicule.Ordinaire:
                    return new FraisSpeciauxOrdinaireStrategy();
                case TypeVehicule.Deluxe:
                    return new FraisSpeciauxDeluxeStrategy();
                default:
                    throw new ArgumentException("Type de véhicule non supporté", nameof(typeVehicule));
            }
        }

        public static IFraisAssociationStrategy CreateFraisAssociationStrategy()
        {
            return new FraisAssociationStrategy();
        }
    }
}