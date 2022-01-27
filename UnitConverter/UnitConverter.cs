using System;

namespace Converter
{
    public static class UnitConverter
    {
        public static string Convert(string from, string to)
        {
            var fromUnit = GetUnitFromString(from);
            var toUnit = GetUnitFromString(to);

            if (fromUnit.UnitType != toUnit.UnitType)
            {
                throw new ArgumentException();
            }

            toUnit.Amount = ConvertToNonBaseUnit(fromUnit.Amount, toUnit.StringUnit) * GetMultiplier(fromUnit.Prefix - toUnit.Prefix);
            return $"{toUnit.Amount} {(toUnit.Prefix == Prefix.none ? "" : toUnit.Prefix.ToString())}{toUnit.StringUnit}";
        }

        private static Unit GetUnitFromString(string stringUnit)
        {
            var unit = new Unit();
            if (stringUnit.Length > 0 && (char.IsDigit(stringUnit[0]) || (stringUnit[0] == '-' && char.IsDigit(stringUnit[1]))))
            {
                var split = stringUnit.Split(" ");
                unit.Prefix = GetAndRemovePrefix(ref split[1]);
                unit.UnitType = GetUnitType(split[1]);
                unit.StringUnit = split[1];
                unit.Amount = ConvertToBaseUnit(decimal.Parse(split[0]), unit.StringUnit);
            }
            else
            {
                unit.Prefix = GetAndRemovePrefix(ref stringUnit);
                unit.UnitType = GetUnitType(stringUnit);
                unit.StringUnit = stringUnit;
            }

            return unit;
        }

        private static decimal GetMultiplier(int power)
        {
            return (decimal)Math.Pow(10, power);
        }

        private static UnitType GetUnitType(string unit)
        {
            switch (unit)
            {
                case "meters":
                    return UnitType.Length;
                case "inches":
                    return UnitType.Length;
                case "feet":
                    return UnitType.Length;
                case "bits":
                    return UnitType.Data;
                case "bytes":
                    return UnitType.Data;
                case "celsius":
                    return UnitType.Temperature;
                case "fahrenheit":
                    return UnitType.Temperature;
                default:
                    throw new NotImplementedException();
            }
        }

        private static Prefix GetAndRemovePrefix(ref string unit)
        {
            foreach (var prefix in Enum.GetNames(typeof(Prefix)))
            {
                if (unit.StartsWith(prefix))
                {
                    unit = unit.Remove(0, prefix.Length);
                    return (Prefix)Enum.Parse(typeof(Prefix), prefix);
                }
            }

            return Prefix.none;
        }

        private static decimal ConvertToBaseUnit(decimal amount, string unit)
        {
            switch (unit)
            {
                case "inches":
                    return amount / 39.37m;
                case "feet":
                    return amount / 3.2808m;
                case "bits":
                    return amount / 8m;
                case "fahrenheit":
                    return (amount - 32) * 5 / 9;
            }

            return amount;
        }

        private static decimal ConvertToNonBaseUnit(decimal amount, string unit)
        {
            switch (unit)
            {
                case "inches":
                    return amount * 39.37m;
                case "feet":
                    return amount * 3.2808m;
                case "bits":
                    return amount * 8m;
                case "fahrenheit":
                    return (amount / 5 * 9) + 32;
            }

            return amount;
        }
    }
}
