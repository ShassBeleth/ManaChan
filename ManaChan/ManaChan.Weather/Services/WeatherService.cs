using System;
using System.Configuration;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManaChan.Weather.Services {

	/// <summary>
	/// 天気情報サービス
	/// </summary>
	/// <remarks>
	/// APIリファレンス：https://openweathermap.org/
	/// </remarks>
	public class WeatherService : IWeatherService {
		
		/// <summary>
		/// APIキー
		/// </summary>
		private string ApiKey { get; }

		/// <summary>
		/// 天気情報取得
		/// </summary>
		/// <returns></returns>
		public async Task<string> GetWeatherAsync() {

			HttpClient client = new HttpClient();
			string result = null;
			try {
				HttpResponseMessage response = await client.GetAsync( "http://api.openweathermap.org/data/2.5/weather?APPID=" + this.ApiKey + "&lat=35.181469&lon=136.906403" );
				result = await response.Content.ReadAsStringAsync();
			}
			catch( ArgumentException ex ) {
				Console.WriteLine( "ArgumentException : " + ex.Message );
			}
			
			return result ?? "";

		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public WeatherService()
			=> this.ApiKey = Encoding.GetEncoding( "UTF-8" ).GetString( 
				Convert.FromBase64String( 
					ConfigurationManager.AppSettings[ "OpenWeatherMapKey" ] 
				) 
			);
		
	}

}
