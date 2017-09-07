using Newtonsoft.Json;

namespace ManaChan.Weather.Models {
	public partial class CurrentWeatherDataModel {

		/// <summary>
		/// 風情報
		/// </summary>
		[JsonObject]
		public class WindModel {

			/// <summary>
			/// 風速
			/// </summary>
			[JsonProperty( "speed" )]
			public double Speed { set; get; }

			/// <summary>
			/// 風向
			/// </summary>
			[JsonProperty( "deg" )]
			public double Degree { set; get; }

		}

	}
}


