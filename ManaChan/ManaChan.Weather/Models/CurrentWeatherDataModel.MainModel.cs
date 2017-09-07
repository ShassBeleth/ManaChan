using Newtonsoft.Json;

namespace ManaChan.Weather.Models {
	public partial class CurrentWeatherDataModel {

		/// <summary>
		/// メイン情報
		/// </summary>
		[JsonObject]
		public class MainModel {

			/// <summary>
			/// 気温
			/// </summary>
			[JsonProperty( "temp" )]
			public double Temperature { set; get; }

			/// <summary>
			/// 湿度
			/// </summary>
			[JsonProperty( "humidity" )]
			public double Humidity { set; get; }

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


