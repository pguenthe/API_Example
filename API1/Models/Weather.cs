using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API1.Models
{
    public class Weather
    {
        //property name always has to align with the JSON key
        // (or you need some extra steps)
        //case-insensitive
        public WeatherData Data { get; set; }
        public WeatherTime Time { get; set; }
    }

    public class WeatherData
    {
        public int[] Temperature { get; set; }
        public string[] Iconlink { get; set; }
        public string[] Text { get; set; }
    }


    public class WeatherTime
    {
        public string[] StartPeriodName { get; set; }
    }
}
