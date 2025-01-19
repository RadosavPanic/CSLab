using System;
using System.Text;
using EnumsSpace = CSLab.Enums;

namespace CSLab
{
    class CSLab
    {
        static void Main(string[] args)
        {
            string[] daysOfWeek = EnumsSpace.GetDaysArray();
            Console.WriteLine(EnumsSpace.DisplayAllDays(daysOfWeek));            

            Console.WriteLine(EnumsSpace.DisplayAllTemperatures());
        }
    }
}