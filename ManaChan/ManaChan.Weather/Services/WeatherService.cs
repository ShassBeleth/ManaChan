using ManaChan.Weather.Models;
using Newtonsoft.Json;
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
		/// 今日の天気情報取得
		/// </summary>
		/// <returns></returns>
		public async Task<CurrentWeatherDataModel> GetCurrentWeatherAsync() {

			CurrentWeatherDataModel resultModel = null;

			HttpClient client = new HttpClient();
			try {
				HttpResponseMessage response = await client.GetAsync( "http://api.openweathermap.org/data/2.5/weather?APPID=" + this.ApiKey + "&q=Nagoya-Shi" );
				string result = await response.Content.ReadAsStringAsync();
				resultModel = JsonConvert.DeserializeObject<CurrentWeatherDataModel>( result );
			}
			catch( ArgumentException ex ) {
				Console.WriteLine( "ArgumentException : " + ex.Message );
			}
			
			return resultModel;

		}

		/// <summary>
		/// 5日間の天気予報情報取得
		/// </summary>
		/// <returns></returns>
		public async Task<FiveDayWeatherForecastModel> GetFiveDayWeatherForecastAsync() {

			FiveDayWeatherForecastModel resultModel = null;

			HttpClient client = new HttpClient();
			try {
				HttpResponseMessage response = await client.GetAsync( "http://api.openweathermap.org/data/2.5/forecast?APPID=" + this.ApiKey + "&q=Nagoya-Shi" );
				string result = await response.Content.ReadAsStringAsync();
				resultModel = JsonConvert.DeserializeObject<FiveDayWeatherForecastModel>( result );
			}
			catch( ArgumentException ex ) {
				Console.WriteLine( "ArgumentException : " + ex.Message );
			}

			return resultModel;

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
