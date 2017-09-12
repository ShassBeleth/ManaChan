using Newtonsoft.Json;

namespace ManaChan.Weather.Models.CurrentWeatherData {
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

			/// <summary>
			/// 風向きの文字列
			/// </summary>
			/// <returns>風向きの文字列</returns>
			public string ToDegreeString()
			=> "(" +
				(
					360.0 * 15 / 16 <= this.Degree || this.Degree < 360.0 / 16 ? "北" :
					360.0 / 16 <= this.Degree && this.Degree < 360.0 * 3 / 16 ? "北東" :
					360.0 * 3 / 16 <= this.Degree && this.Degree < 360.0 * 5 / 16 ? "東" :
					360.0 * 5 / 16 <= this.Degree && this.Degree < 360.0 * 7 / 16 ? "南東" :
					360.0 * 7 / 16 <= this.Degree && this.Degree < 360.0 * 9 / 16 ? "南" :
					360.0 * 9 / 16 <= this.Degree && this.Degree < 360.0 * 11 / 16 ? "南西" :
					360.0 * 11 / 16 <= this.Degree && this.Degree < 360.0 * 13 / 16 ? "西" :
					360.0 * 13 / 16 <= this.Degree && this.Degree < 360.0 * 15 / 16 ? "北西" :
					"-"
				) +
				")";

			/// <summary>
			/// 風速の文字列
			/// </summary>
			/// <returns>風速の文字列</returns>
			public string ToSpeedString()
			=> this.Speed + "m/s";

		}

	}
}


