using CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Application;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Adapters;

internal sealed class WebApiAdapter(UseCase useCase)
{
    private readonly UseCase _useCase = useCase;

    internal ResponseVM[] Handle()
    {
        WeatherForecast[] weatherForecasts = _useCase.Handle();

        ResponseVM[] response = new ResponseVM[weatherForecasts.Length];
        for (int i = 0; i < weatherForecasts.Length; i++)
        {
            // In a real-word app angularsen/UnitsNet would be used for conversation.
            int teamperatureF = 32 + (int)(weatherForecasts[i].TemperatureC / 0.5556);
            ResponseVM viewModel = new(weatherForecasts[i].Date, weatherForecasts[i].TemperatureC, teamperatureF, weatherForecasts[i].Summary);
            response[i] = viewModel;
        }

        return response;
    }
}
