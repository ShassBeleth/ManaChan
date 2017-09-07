using Newtonsoft.Json;
using System;

namespace ManaChan.Weather.Models {
	public partial class FiveDayWeatherForecastModel {

		/// <summary>
		/// 予報情報
		/// </summary>
		[JsonObject]
		public partial class ForecastModel {

			/// <summary>
			/// 予測時間
			/// </summary>
			[JsonProperty( "dt" )]
			public long UnixDateTime { set; get; }

			/// <summary>
			/// データ計算時間
			/// </summary>
			public DateTime DateTime {
				set {
					DateTime unixStart = new DateTime( 1970 , 1 , 1 , 0 , 0 , 0 , 0 , DateTimeKind.Utc );
					long unixTimeStampInTicks = ( value.ToUniversalTime() - unixStart ).Ticks;
					this.UnixDateTime = unixTimeStampInTicks / TimeSpan.TicksPerSecond;
				}
				get {
					DateTime unixStart = new DateTime( 1970 , 1 , 1 , 0 , 0 , 0 , 0 , DateTimeKind.Utc );
					long unixTimeStampInTicks = this.UnixDateTime * TimeSpan.TicksPerSecond;
					return new DateTime( unixStart.Ticks + unixTimeStampInTicks , DateTimeKind.Utc );
				}
			}

			/// <summary>
			/// メイン情報
			/// </summary>
			[JsonProperty( "main" )]
			public MainModel Main { set; get; }

			/// <summary>
			/// 天気情報
			/// </summary>
			[JsonProperty( "weather" )]
			public WeatherModel[] Weathers { set; get; }

		}
		
	}
}
