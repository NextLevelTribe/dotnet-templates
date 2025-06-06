using CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Application;

namespace CleanArchitecture.ApiService.Features.Weather.GetWeatherForecast.Adapters;

internal sealed class WebApiAdapter(UseCase useCase)
{
    private readonly UseCase _useCase = useCase;

    internal WebApiVM[] Handle()
    {
        WeatherForecastModel[] weatherForecasts = _useCase.Handle();

        WebApiVM[] response = new WebApiVM[weatherForecasts.Length];
        for (int i = 0; i < weatherForecasts.Length; i++)
        {
            int teamperatureF = 32 + (int)(weatherForecasts[i].TemperatureC / 0.5556);
            WebApiVM viewModel = new(weatherForecasts[i].Date, weatherForecasts[i].TemperatureC, teamperatureF, weatherForecasts[i].Summary);
            response[i] = viewModel;
        }

        return response;
    }
}
