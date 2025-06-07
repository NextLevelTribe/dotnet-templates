using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Features.Weather.GetWeatherForecast;

internal class WeatherApiClient(HttpClient httpClient)
{
    internal async Task<WeatherForecast[]> GetWeatherAsync(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<WeatherForecast> forecasts = new(maxItems);

        await foreach (WeatherForecast? forecast in httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/weatherforecast", cancellationToken))
        {
            if (forecasts.Count >= maxItems)
            {
                break;
            }

            if (forecast is not null)
            {
                forecasts.Add(forecast);
            }
        }

        return forecasts.Count > 0 ? forecasts.ToArray() : [];
    }
}
