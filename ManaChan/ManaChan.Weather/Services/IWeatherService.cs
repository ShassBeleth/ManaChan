using ManaChan.Weather.Models;
using System.Threading.Tasks;

namespace ManaChan.Weather.Services {

	/// <summary>
	/// 天気情報サービス
	/// </summary>
	public interface IWeatherService {

		/// <summary>
		/// 天気情報取得
		/// </summary>
		/// <returns></returns>
		Task<CurrentWeatherDataModel> GetCurrentWeatherAsync();


		/// <summary>
		/// 5日間の天気予報情報取得
		/// </summary>
		/// <returns></returns>
		Task<FiveDayWeatherForecastModel> GetFiveDayWeatherForecastAsync();

	}

}
