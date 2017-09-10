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
				/// 温度のフォーマット
				/// </summary>
				private string TemperatureFormat { get; } = "{0:f2}℃";
				
				/// <summary>
				/// KからCへの変換用温度差分
				/// </summary>
				private double DifferenceTemperature { get; } = -273.15;

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

				/// <summary>
				/// 最低気温の文字列
				/// </summary>
				/// <returns>最低気温の文字列</returns>
				public string ToMinTemperatureString()
				=> string.Format( this.TemperatureFormat , this.MinTemperature + this.DifferenceTemperature );

				/// <summary>
				/// 最高気温の文字列
				/// </summary>
				/// <returns>最高気温の文字列</returns>
				public string ToMaxTemperatureString()
				=> string.Format( this.TemperatureFormat , this.MaxTemperature + this.DifferenceTemperature );

			}

		}
	}
}
