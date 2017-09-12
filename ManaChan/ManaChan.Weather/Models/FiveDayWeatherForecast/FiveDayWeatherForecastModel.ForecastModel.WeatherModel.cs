using Newtonsoft.Json;

namespace ManaChan.Weather.Models.FiveDayWeatherForecast {
	public partial class FiveDayWeatherForecastModel {
		public partial class ForecastModel {

			/// <summary>
			/// 天気情報
			/// </summary>
			[JsonObject]
			public class WeatherModel {

				/// <summary>
				/// メイン情報
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
}
