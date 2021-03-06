﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SamplePostGraphile.Shared
{
    // クエリー
    // query allWeatherForecasts {
    //   allWeatherForecasts {
    //     nodes {
    //       id
    //       dt
    //       temperatureC
    //       summary
    //     }
    //   }
    // }
    public class WeatherForecast
    {
        public int Id { get; set; }

        public DateTime Dt { get; set; }

        private double _tempC;
        public double TemperatureC
        {
            get
            {
                return _tempC;
            }
            set
            {
                _tempC = value;
            }
        }

        public double TemperatureF
        {
            get
            {
                return 32 + (_tempC / 0.5556);
            }
            set
            {
                _tempC = (value - 32) * 0.5556;
            }
        }

        public string Summary { get; set; }

        public WeatherForecast()
        {
            Dt = DateTime.Now.Date;
        }
    }

    // レスポンス例
    // {
    //   "data": {
    //     "allWeatherForecasts": {
    //       "nodes": [
    //         {
    //           "id": 1,
    //           "dt": "2000-01-01",
    //           "temperatureC": 7,
    //           "summary": "Hot"
    //         },
    //         {
    //           "id": 2,
    //           "dt": "2000-01-02",
    //           "temperatureC": -16,
    //           "summary": "Cool"
    //         },
    //
    //         （中略）
    //
    //       ]
    //     }
    //   }
    // }
    public class AllWeatherForecastsResponse
    {
        public AllWeatherForecastsContent allWeatherForecasts { get; set; }

        public class AllWeatherForecastsContent
        {
            public List<WeatherForecast> Nodes { get; set; }
        }
    }
}
