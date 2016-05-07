using GMap.NET;
using System.Text.RegularExpressions;
using System;


namespace SimulationOfBusRoute.Utils
{
    public static class CPointLatLngHelper
    {
        public static string ToDbString(this PointLatLng point)
        {
            return string.Format("({0};{1})", point.Lat, point.Lng);
        }

        public static PointLatLng Parse(string str)
        {
            Regex vectorPattern = new Regex("\\((.*?);(.*?)\\)", RegexOptions.Singleline);

            Match vectorMatch = vectorPattern.Match(str);

            if (!vectorMatch.Success)
            {
                throw new FormatException("Can't parse string to PointLatLng");
            }

            return new PointLatLng(double.Parse(vectorMatch.Groups[1].Value), double.Parse(vectorMatch.Groups[2].Value));
        }
    }
}
