using Newtonsoft.Json;
using System;

namespace ManaChan.Weather.Models {

	/// <summary>
	/// 今日の天気情報Model
	/// </summary>
	[JsonObject]
	public partial class CurrentWeatherDataModel {

		/// <summary>
		/// 天気情報
		/// </summary>
		[JsonProperty( "weather" )]
		public WeatherModel[] Weathers { set; get; }

		/// <summary>
		/// メイン情報
		/// </summary>
		[JsonProperty( "main" )]
		public MainModel Main { set; get; }

		/// <summary>
		/// 風情報
		/// </summary>
		[JsonProperty( "wind" )]
		public WindModel Wind { set; get; }
		
		/// <summary>
		/// データ計算時間
		/// </summary>
		[JsonProperty( "dt" )]
		public long UnixDateTime { set; get; }

		/// <summary>
		/// データ計算時間
		/// </summary>
		public DateTime DateTime {
			set {
				DateTime unixStart = new DateTime( 1970 , 1 , 1 , 0 , 0 , 0 , 0 , DateTimeKind.Utc );
				long unixTimeStampInTicks = ( value.ToUniversalTime() - unixStart + new TimeSpan( +09 , 00 , 00 ) ).Ticks;
				this.UnixDateTime = unixTimeStampInTicks / TimeSpan.TicksPerSecond;
			}
			get {
				DateTime unixStart = new DateTime( 1970 , 1 , 1 , 0 , 0 , 0 , 0 , DateTimeKind.Utc );
				long unixTimeStampInTicks = this.UnixDateTime * TimeSpan.TicksPerSecond;
				return new DateTime( ( unixStart + new TimeSpan( +09 , 00 , 00 ) ).Ticks + unixTimeStampInTicks , DateTimeKind.Utc );
			}
		}

		/// <summary>
		/// 市の名前
		/// </summary>
		[JsonProperty( "name" )]
		public string CityName { set; get; }
		
	}

}
