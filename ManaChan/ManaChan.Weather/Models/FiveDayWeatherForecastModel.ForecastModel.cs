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
			/// 月と日と曜日のみの日付フォーマット
			/// </summary>
			private string SimpleDateFormat { get; } = "MM/dd(ddd)";

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

			/// <summary>
			/// 予測時間の文字列
			/// </summary>
			/// <returns>予測時間の文字列</returns>
			public string ToDateTimeString()
			=> this.DateTime.ToString( this.SimpleDateFormat );

			/// <summary>
			/// 最高気温／最低気温の文字列
			/// </summary>
			/// <returns>最高気温／最低気温の文字列</returns>
			public string ToMinAndMaxTemperatureString()
			=> this.Main?.MaxTemperature is null || this.Main?.MinTemperature is null ?
				"---℃/---℃" :
				this.Main.ToMaxTemperatureString() + "/" + this.Main.ToMinTemperatureString();

			/// <summary>
			/// 天気情報の文字列
			/// </summary>
			/// <returns>天気情報の文字列</returns>
			public string ToWeathersString() {

				string defaultText = "---";

				if( this.Weathers is null )
					return defaultText;

				string result = "";

				foreach( FiveDayWeatherForecastModel.ForecastModel.WeatherModel weather in this.Weathers ) {

					if( !"".Equals( result ) )
						result += "のち";

					result +=
						"Rain".Equals( weather.Main ) ? "雨" :
						"Mist".Equals( weather.Main ) ? "霧" :
						"Clouds".Equals( weather.Main ) ? "曇り" :
						"";

				}

				return "".Equals( result ) ? defaultText : result;

			}

		}
		
	}
}
