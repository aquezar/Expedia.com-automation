﻿using System;

namespace Expedia.com.Framework
{
    class Helper
    {
        public static string ConvertDate(string date, char splitSymbol, string format)
        {
            string departureDate;
            var t = date.Split(splitSymbol);
            int day;
            int month;
            int year;
            int.TryParse(t[2], out year);
            int.TryParse(t[0], out month);
            int.TryParse(t[1], out day);
            DateTime convertedDate = new DateTime(year, month, day);
            departureDate = convertedDate.ToString(format);
            return departureDate;
        }
    }
}