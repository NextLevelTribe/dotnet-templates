using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArchitecture.Web.Features.Weather.GetWeatherForecast;

internal sealed class WeatherApiClient(HttpClient httpClient)
{
    internal async Task<WeatherForecast[]> GetWeather(int maxItems = 10, CancellationToken cancellationToken = default)
    {
        List<WeatherForecast> response = new(maxItems);

        IAsyncEnumerable<WeatherForecast?> forecasts = httpClient.GetFromJsonAsAsyncEnumerable<WeatherForecast>("/weatherforecast", cancellationToken);
        await foreach (WeatherForecast? forecast in forecasts)
        {
            if (response.Count >= maxItems)
            {
                break;
            }

            if (forecast is not null)
            {
                response.Add(forecast);
            }
        }

        return (response.Count > 0) ? response.ToArray() : [];
    }
}
