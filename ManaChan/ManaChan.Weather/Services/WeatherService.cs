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
		/// 今日の天気情報
		/// </summary>
		public CurrentWeatherDataModel CurrentWeatherDataModel {
			private set;
			get;
		}

		/// <summary>
		/// 5日間の天気予報情報
		/// </summary>
		public FiveDayWeatherForecastModel FiveDayWeatherForecastModel {
			private set;
			get;
		}
		
		/// <summary>
		/// 今日の天気情報取得
		/// </summary>
		/// <returns></returns>
		public async Task SendCurrentWeatherAsync() {
			
			HttpClient client = new HttpClient();
			try {
				HttpResponseMessage response = await client.GetAsync( "http://api.openweathermap.org/data/2.5/weather?APPID=" + this.ApiKey + "&q=Nagoya-Shi" );
				string result = await response.Content.ReadAsStringAsync();
				this.CurrentWeatherDataModel = JsonConvert.DeserializeObject<CurrentWeatherDataModel>( result );
			}
			catch( ArgumentException ex ) {
				Console.WriteLine( "ArgumentException : " + ex.Message );
			}
			
		}

		/// <summary>
		/// 5日間の天気予報情報取得
		/// </summary>
		/// <returns></returns>
		public async Task SendFiveDayWeatherForecastAsync() {
			
			HttpClient client = new HttpClient();
			try {
				HttpResponseMessage response = await client.GetAsync( "http://api.openweathermap.org/data/2.5/forecast?APPID=" + this.ApiKey + "&q=Nagoya-Shi" );
				string result = await response.Content.ReadAsStringAsync();
				this.FiveDayWeatherForecastModel = JsonConvert.DeserializeObject<FiveDayWeatherForecastModel>( result );
			}
			catch( ArgumentException ex ) {
				Console.WriteLine( "ArgumentException : " + ex.Message );
			}
			
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
