namespace Trucks.Data
{
    public class DataConstraints
    {
        //Despatcher
        public const int DespatcherNameMinLength = 2;
        public const int DespatcherNameMaxLength = 40;

        //Client
        public const int ClientNameMinLength = 3;
        public const int ClientNameMaxLength = 40;

        public const int ClientNationalityMinLength = 2;
        public const int ClientNationalityMaxLength = 40;

        //Truck
        public const int TruckTankCapacityMinValue = 950;
        public const int TruckTankCapacityMaxValue = 1420;

        public const int TruckCargoCapacityMinValue = 5_000;
        public const int TruckCargoCapacityMaxValue = 29_000;

        public const int TruckVinNumberLength = 17;

        public const string TruckRegistrationNumberRegex = @"[A-Z]{2}\d{4}[A-Z]{2}$";
    }
}
