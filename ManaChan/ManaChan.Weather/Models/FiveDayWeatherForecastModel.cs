using Newtonsoft.Json;

namespace ManaChan.Weather.Models {

	/// <summary>
	/// 5日間の天気予報情報Model
	/// </summary>
	[JsonObject]
	public partial class FiveDayWeatherForecastModel {

		/// <summary>
		/// 都市情報
		/// </summary>
		[JsonProperty( "city" )]
		public CityModel City { set; get; }

		/// <summary>
		/// 予報情報
		/// </summary>
		[JsonProperty( "list" )]
		public ForecastModel[] Forecasts { set; get; }
		
	}

}
