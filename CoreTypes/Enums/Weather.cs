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

        /// <summary>
        /// <para>Extracts items of the enum list and returns an array containing string values.</para>                        
        /// <example>
        /// <para>Example usage:</para>
        /// <code>
        /// string [] weekDays = WeatherClass.GetDaysArray();     
        /// </code>
        /// <returns><strong>Returns:</strong> string[ ]</returns>        
        /// </example>       
        /// </summary> 
        public static string[] GetDaysArray()
        {
            string[] daysOfWeek = new string[Enum.GetValues(typeof(EnumDays)).Length];
            int daysIndex = 0;

            foreach (EnumDays day in Enum.GetValues(typeof(EnumDays))) daysOfWeek[daysIndex++] = day.ToString();

            return daysOfWeek;
        }

        /// <summary>
        /// <para>Displays all days of week within a single string.</para>                        
        /// <example>
        /// <para>Example usage:</para>
        /// <code>
        /// WeatherClass.DisplayAllDays();     
        /// </code>
        /// <returns><strong>Returns:</strong> string</returns>
        /// </example>
        /// </summary>
        public static string DisplayAllDays()
        {
            string[] daysOfWeek = GetDaysArray();

            StringBuilder sb = new StringBuilder();
            foreach (string day in daysOfWeek)
            {
                sb.Append(day);
                if (day != daysOfWeek[daysOfWeek.Length - 1]) sb.Append(", ");
            }

            return sb.ToString(); // Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
        }

        /// <summary>
        /// <para>Displays all temperature specifications within a single string.</para>                        
        /// <example>
        /// <para>Example usage:</para>
        /// <code>
        /// WeatherClass.DisplayAllTemperatures();     
        /// </code>
        /// <returns><strong>Returns:</strong> string</returns>
        /// </example>
        /// </summary> 
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

            return sb.ToString();
        }

    }
}
