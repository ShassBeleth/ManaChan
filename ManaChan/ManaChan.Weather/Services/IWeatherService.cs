using ManaChan.Weather.Models;
using System.Threading.Tasks;

namespace ManaChan.Weather.Services {

	/// <summary>
	/// 天気情報サービス
	/// </summary>
	public interface IWeatherService {
		
		/// <summary>
		/// 今日の天気情報
		/// </summary>
		CurrentWeatherDataModel CurrentWeatherDataModel { get; }

		/// <summary>
		/// 5日間の天気予報情報
		/// </summary>
		FiveDayWeatherForecastModel FiveDayWeatherForecastModel { get; }

		/// <summary>
		/// 天気情報取得
		/// </summary>
		Task SendCurrentWeatherAsync();


		/// <summary>
		/// 5日間の天気予報情報取得
		/// </summary>
		Task SendFiveDayWeatherForecastAsync();

	}

}
