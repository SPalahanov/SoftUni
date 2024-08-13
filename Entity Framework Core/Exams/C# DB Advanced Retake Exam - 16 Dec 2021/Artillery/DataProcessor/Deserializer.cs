namespace Artillery.DataProcessor
{
    using Artillery.Data;
    using Artillery.Data.Models;
    using Artillery.Data.Models.Enums;
    using Artillery.DataProcessor.ImportDto;
    using Artillery.Utilities;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid data.";
        private const string SuccessfulImportCountry =
            "Successfully import {0} with {1} army personnel.";
        private const string SuccessfulImportManufacturer =
            "Successfully import manufacturer {0} founded in {1}.";
        private const string SuccessfulImportShell =
            "Successfully import shell caliber #{0} weight {1} kg.";
        private const string SuccessfulImportGun =
            "Successfully import gun {0} with a total weight of {1} kg. and barrel length of {2} m.";

        public static string ImportCountries(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportCountryDto[] countryDtos = XmlHelper.Deserialize<ImportCountryDto[]>(xmlString, "Countries");

            ICollection<Country> countries = new List<Country>();

            foreach (var countryDto in countryDtos)
            {
                if (!IsValid(countryDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Country country = new Country()
                {
                    CountryName = countryDto.CountryName,
                    ArmySize = countryDto.ArmySize
                };

                countries.Add(country);

                sb.AppendLine(String
                    .Format(SuccessfulImportCountry, country.CountryName, country.ArmySize));
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportManufacturers(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportManufacturersDto[] manufacturersDtos = XmlHelper.Deserialize<ImportManufacturersDto[]>(xmlString, "Manufacturers");

            ICollection<Manufacturer> manufacturers = new List<Manufacturer>();

            List<string> manufacturerNames = new List<string>();

            foreach (var manufacturersDto in manufacturersDtos)
            {
                if (!IsValid(manufacturersDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (manufacturerNames.Any(m => m == manufacturersDto.ManufacturerName))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                string[] foundedArray = manufacturersDto.Founded
                    .Split(", ")
                    .ToArray();

                string founded = foundedArray[foundedArray.Length - 2] + ", " + foundedArray[foundedArray.Length - 1];

                Manufacturer manufacturer = new Manufacturer()
                {
                    ManufacturerName = manufacturersDto.ManufacturerName,
                    Founded = manufacturersDto.Founded
                };

                manufacturerNames.Add(manufacturer.ManufacturerName);

                manufacturers.Add(manufacturer);
                sb.AppendLine(String.Format(SuccessfulImportManufacturer, manufacturer.ManufacturerName, founded));
            }

            context.Manufacturers.AddRange(manufacturers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportShells(ArtilleryContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            ImportShellDto[] shellDtos = XmlHelper.Deserialize<ImportShellDto[]>(xmlString, "Shells");

            ICollection<Shell> shells = new List<Shell>();

            foreach (var shellDto in shellDtos)
            {
                if (!IsValid(shellDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Shell shell = new Shell()
                {
                    ShellWeight = shellDto.ShellWeight,
                    Caliber = shellDto.Caliber
                };

                shells.Add(shell);
                sb.AppendLine(String.Format(SuccessfulImportShell, shell.Caliber, shell.ShellWeight));
            }

            context.Shells.AddRange(shells);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportGuns(ArtilleryContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();

            var gunDtos = JsonConvert.DeserializeObject<ImportGunDto[]>(jsonString);

            ICollection<Gun> guns = new List<Gun>();

            foreach (var gunDto in gunDtos)
            {
                if (!IsValid(gunDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (gunDto.GunType != "AntiTankGun" &&
                    gunDto.GunType != "Howitzer" &&
                    gunDto.GunType != "Mortar" &&
                    gunDto.GunType != "FieldGun" &&
                    gunDto.GunType != "AntiAircraftGun" &&
                    gunDto.GunType != "MountainGun")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Gun gun = new Gun()
                {
                    ManufacturerId = gunDto.ManufacturerId,
                    GunWeight = gunDto.GunWeight,
                    BarrelLength = gunDto.BarrelLength,
                    NumberBuild = gunDto.NumberBuild,
                    Range = gunDto.Range,
                    GunType = (GunType)Enum.Parse(typeof(GunType), gunDto.GunType),
                    ShellId = gunDto.ShellId
                };

                foreach (var id in gunDto.Countries)
                {
                    CountryGun countryGun = new CountryGun()
                    {
                        Gun = gun,
                        CountryId = id.Id,
                        
                    };

                    gun.CountriesGuns.Add(countryGun);
                }

                guns.Add(gun);

                sb.AppendLine(String
                    .Format(SuccessfulImportGun, gun.GunType, gun.GunWeight, gun.BarrelLength));
            }

            context.Guns.AddRange(guns);
            context.SaveChanges();

            return sb.ToString().Trim();
        }
        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}