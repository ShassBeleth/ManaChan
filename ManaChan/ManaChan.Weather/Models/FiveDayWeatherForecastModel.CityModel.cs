using Newtonsoft.Json;

namespace ManaChan.Weather.Models {
	public partial class FiveDayWeatherForecastModel {

		/// <summary>
		/// 都市情報Model
		/// </summary>
		[JsonObject]
		public class CityModel {

			/// <summary>
			/// 都市名
			/// </summary>
			[JsonProperty( "name" )]
			public string Name { set; get; }
			
		}
		
	}
}
