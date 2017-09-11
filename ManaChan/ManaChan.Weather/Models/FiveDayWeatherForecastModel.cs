using System;
using Newtonsoft.Json;

namespace ManaChan.Weather.Models {

	/// <summary>
	/// 5日間の天気予報情報Model
	/// </summary>
	[JsonObject]
	public partial class FiveDayWeatherForecastModel {
		
		/// <summary>
		/// 予報情報
		/// </summary>
		[JsonProperty( "list" )]
		public ForecastModel[] Forecasts { set; get; }
		
		/// <summary>
		/// 日付の文字列
		/// </summary>
		/// <param name="afterDayNum">当日よりも何日先か</param>
		/// <returns>日付の文字列</returns>
		public string ToDateString( int afterDayNum ) {
			ForecastModel[] resultData = this.SplitForecastsEachDay( afterDayNum );
			return resultData.Length > 0 ? resultData?[ 0 ]?.ToDateTimeString() ?? "--/--(---)" : "--/--(---)";
		}

		/// <summary>
		/// 最大気温と最低気温の文字列
		/// </summary>
		/// <param name="afterDayNum">当日よりも何日先か</param>
		/// <returns>最大気温と最低気温の文字列</returns>
		public string ToMinAndMaxTemperatureString( int afterDayNum ) {

			string minStr = "--℃";
			string maxStr = "--℃";

			ForecastModel[] resultData = this.SplitForecastsEachDay( afterDayNum );

			if( resultData.Length > 0 ) {

				double min = resultData?[ 0 ]?.Main?.MinTemperature ?? 999.999;
				double max = resultData?[ 0 ]?.Main?.MaxTemperature ?? -999.999;
				for( int i = 1 ; i < resultData.Length ; i++ ) {
					if( ( resultData?[ i ]?.Main?.MinTemperature ?? 999.999 ) < min ) {
						min = resultData[ i ].Main.MinTemperature;
						minStr = resultData[ i ].Main.ToMinTemperatureString();
					}
					if( max < ( resultData?[ i ]?.Main?.MaxTemperature ?? -999.999 ) ) {
						max = resultData[ i ].Main.MaxTemperature;
						maxStr = resultData[ i ].Main.ToMaxTemperatureString();
					}
				}

			}

			return maxStr + "/" + minStr;

		}

		/// <summary>
		/// 日毎に予報情報を分割する
		/// </summary>
		/// <param name="afterDayNum">当日より何日先か</param>
		/// <returns>指定日の予報情報</returns>
		private ForecastModel[] SplitForecastsEachDay( int afterDayNum ) {

			if( this.Forecasts == null )
				return new ForecastModel[0];

			ForecastModel[] resultData = new ForecastModel[0];
			DateTime specified = DateTime.Today.AddDays( afterDayNum );

			for( int i = 0 ; i < this.Forecasts.Length ; i++ ) {
				if( specified.ToString( "MM/dd(ddd)" ).Equals( this.Forecasts[ i ].ToDateTimeString() ) ) {
					Array.Resize( ref resultData , resultData.Length + 1 );
					resultData[ resultData.Length - 1 ] = this.Forecasts[ i ];
				}
			}

			return resultData;
		}

	}

}
