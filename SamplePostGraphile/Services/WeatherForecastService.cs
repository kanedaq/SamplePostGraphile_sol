﻿using SamplePostGraphile.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using GraphQL;

namespace SamplePostGraphile.Services
{
    public class WeatherForecastService
    {
        // 行儀が良くないですが、今回はここにGraphQLエンドポイントのURLを書いてしまいます
        private const string graphql_http = "http://192.168.1.7/15000/graphql";

        public async Task<List<WeatherForecast>> GetForecastListAsync()
        {
            using var graphQLClient = new GraphQLHttpClient(graphql_http, new NewtonsoftJsonSerializer());
            var allWeatherForecasts = new GraphQLRequest
            {
                Query = @"
query allWeatherForecasts {
  allWeatherForecasts {
    nodes {
      id
      dt
      temperatureC
      summary
    }
  }
}
",
                OperationName = "allWeatherForecasts",
            };
            var graphQLResponse = await graphQLClient.SendQueryAsync<AllWeatherForecastsResponse>(allWeatherForecasts);
            return graphQLResponse.Data.allWeatherForecasts.Nodes;
        }

        //public async Task UpdateForecastAsync(WeatherForecast forecastToUpdate)
        //{
        //    未実装
        //}

        //public async Task DeleteForecastAsync(WeatherForecast forecastToRemove)
        //{
        //    未実装
        //}

        //public async Task InsertForecastAsync(WeatherForecast forecastToInsert)
        //{
        //    未実装
        //}
    }
}
