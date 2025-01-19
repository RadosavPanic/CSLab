using System;
using System.Text;
using System.Linq;

namespace CSLab.CoreTypes.Enums
{
    internal class Weather
    {
        private enum EnumDays { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }

        private enum EnumTemperatures
        {
            NeutralZero = -18,
            FreezingPoint = 0,
            LightJacketWeather = 16,
            SwimmingWeather = 22,
            BoilingPoint = 100
        }

        public static string[] GetDaysArray()
        {
            string[] daysOfWeek = new string[Enum.GetValues(typeof(EnumDays)).Length];
            int daysIndex = 0;

            foreach (EnumDays day in Enum.GetValues(typeof(EnumDays))) daysOfWeek[daysIndex++] = day.ToString();

            return daysOfWeek;
        }

        public static string DisplayAllDays(string[] daysOfWeek)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string day in daysOfWeek)
            {
                sb.Append(day);
                if (day != daysOfWeek[daysOfWeek.Length - 1]) sb.Append(", ");
            }

            return sb.ToString(); // Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }

        public static string DisplayAllTemperatures()
        {
            Dictionary<string, int> tempDict = new Dictionary<string, int>();

            foreach (EnumTemperatures temp in Enum.GetValues(typeof(EnumTemperatures))) tempDict.Add(temp.ToString(), (int)temp);

            StringBuilder sb = new StringBuilder();

            foreach (var entry in tempDict)
            {
                sb.Append($"{entry.Key}: {entry.Value}");
                if (entry.Key != tempDict.Last().Key)
                {
                    sb.Append(", ");
                }
            }

            return sb.ToString(); // FreezingPoint: 0, LightJacketWeather: 16, SwimmingWeather: 22, BoilingPoint: 100, NeutralZero: -18
        }

    }
}
