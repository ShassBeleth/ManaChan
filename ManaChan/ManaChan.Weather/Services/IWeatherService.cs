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
		Task<string> GetWeatherAsync();
		
	}

}
