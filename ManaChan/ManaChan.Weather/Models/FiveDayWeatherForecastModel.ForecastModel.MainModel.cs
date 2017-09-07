using Newtonsoft.Json;

namespace ManaChan.Weather.Models {
	public partial class FiveDayWeatherForecastModel {
		public partial class ForecastModel {

			/// <summary>
			/// メイン情報
			/// </summary>
			[JsonObject]
			public class MainModel {

				/// <summary>
				/// 最低気温
				/// </summary>
				[JsonProperty( "temp_min" )]
				public double MinTemperature { set; get; }

				/// <summary>
				/// 最高気温
				/// </summary>
				[JsonProperty( "temp_max" )]
				public double MaxTemperature { set; get; }

			}

		}
	}
}
