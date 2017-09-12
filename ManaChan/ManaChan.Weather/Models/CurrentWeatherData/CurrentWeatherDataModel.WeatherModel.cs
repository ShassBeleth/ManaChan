using Newtonsoft.Json;

namespace ManaChan.Weather.Models.CurrentWeatherData {
	public partial class CurrentWeatherDataModel {

		/// <summary>
		/// 天気情報
		/// </summary>
		[JsonObject]
		public class WeatherModel {

			/// <summary>
			/// 天気情報
			/// </summary>
			[JsonProperty( "main" )]
			public string Main { set; get; }

			/// <summary>
			/// アイコン
			/// </summary>
			[JsonProperty( "icon" )]
			public string Icon { set; get; }

		}

	}
}


