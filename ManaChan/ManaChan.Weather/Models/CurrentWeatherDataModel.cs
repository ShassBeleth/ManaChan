using Newtonsoft.Json;
using System;

namespace ManaChan.Weather.Models {

	/// <summary>
	/// 今日の天気情報Model
	/// </summary>
	[JsonObject]
	public partial class CurrentWeatherDataModel {

		/// <summary>
		/// 年月日と曜日と時間の日時フォーマット
		/// </summary>
		private string DateTimeFormat { get; } = "yyyy/MM/dd HH:mm:ss";

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

		/// <summary>
		/// データ計算時間の文字列
		/// </summary>
		/// <returns>データ計算時間の文字列</returns>
		public string ToDateTimeString()
		=> this.DateTime.ToString( this.DateTimeFormat );

		/// <summary>
		/// 天気情報の文字列
		/// </summary>
		/// <returns>天気情報の文字列</returns>
		public string ToWeathersString() { 

			string defaultText = "---";

			if( this.Weathers is null )
				return defaultText;

			string result = "";

			foreach( CurrentWeatherDataModel.WeatherModel weather in this.Weathers ) {
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
		
		/// <summary>
		/// 市の名前の文字列
		/// </summary>
		/// <returns>市の名前の文字列</returns>
		public string ToCityNameString()
		=>
			"Aichi-ken".Equals( this.CityName ) ? "愛知県" :
			"Nagoya-shi".Equals( this.CityName ) ? "愛知県名古屋市" :
			"---";

		/// <summary>
		/// 最高気温／最低気温の文字列
		/// </summary>
		/// <returns>最高気温／最低気温の文字列</returns>
		public string ToMinAndMaxTemperatureString()
		=> this.Main?.MaxTemperature is null || this.Main?.MinTemperature is null ?
			"---℃/---℃" :
			this.Main.ToMaxTemperatureString() + "/" + this.Main.ToMinTemperatureString();

		/// <summary>
		/// 風の文字列
		/// </summary>
		/// <returns>風の文字列</returns>
		public string ToWindString()
		=> this.Wind is null ? "(--)--m/s" : this.Wind.ToDegreeString() + this.Wind.ToSpeedString();

	}

}
