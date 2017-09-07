using ManaChan.Weather.Models;
using ManaChan.Weather.Services;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace ManaChan.Weather.ViewModels {

	/// <summary>
	/// DetailPopUpViewのViewModel
	/// </summary>
	public class DetailPopUpViewModel : BindableBase {

		#region 固定文言
		
		/// <summary>
		/// 天気文字列
		/// </summary>
		public string WeatherContent { get; } = "天気";

		/// <summary>
		/// 都市名文字列
		/// </summary>
		public string CityNameContent { get; } = "都市名";

		/// <summary>
		/// 最高気温/最低気温文字列
		/// </summary>
		public string MaxAndMinTemperatureContent { get; } = "最高気温/最低気温";

		/// <summary>
		/// 湿度文字列
		/// </summary>
		public string HumidityContent { get; } = "湿度";

		/// <summary>
		/// 風速文字列
		/// </summary>
		public string WindSpeedContent { get; } = "風速";

		/// <summary>
		/// 日付文字列
		/// </summary>
		public string DateContent { get; } = "日付";

		/// <summary>
		/// 閉じるボタン文字列
		/// </summary>
		public string CloseButtonContent { get; } = "閉じる";

		#endregion

		#region デフォ値

		/// <summary>
		/// デフォルトタイトル
		/// </summary>
		private const string DefaultTitle = "----/--/--(-)の天気";

		/// <summary>
		/// デフォルト更新日時
		/// </summary>
		private const string DefaultUpdate = "更新日時:----/--/-- --:--:--";

		/// <summary>
		/// デフォルト天気情報
		/// </summary>
		private const string DefaultWeather = "---";

		/// <summary>
		/// デフォルト都市名
		/// </summary>
		private const string DefaultCityName = "---";

		/// <summary>
		/// デフォルト温度
		/// </summary>
		private const string DefaultTemperature = "--℃";

		/// <summary>
		/// デフォルト湿度
		/// </summary>
		private const string DefaultHumidity = "--%";

		/// <summary>
		/// デフォルト風速
		/// </summary>
		private const string DefaultWindSpeed = "--m/s";

		#endregion

		/// <summary>
		/// タイトル文字列
		/// </summary>
		private string titleContent = DefaultTitle;

		/// <summary>
		/// タイトル文字列
		/// </summary>
		public string TitleContent {
			private set => SetProperty( ref this.titleContent , value );
			get => this.titleContent;
		}

		/// <summary>
		/// 更新日時文字列
		/// </summary>
		private string updateContent = DefaultUpdate;

		/// <summary>
		/// 更新日時文字列
		/// </summary>
		public string UpdateContent {
			private set => SetProperty( ref this.updateContent , value );
			get => this.updateContent;
		}

		/// <summary>
		/// 天気結果文字列
		/// </summary>
		private string weatherResultContent = DefaultWeather;

		/// <summary>
		/// 天気結果文字列
		/// </summary>
		public string WeatherResultContent {
			private set => SetProperty( ref this.weatherResultContent , value );
			get => this.weatherResultContent;
		}

		/// <summary>
		/// 都市名結果文字列
		/// </summary>
		private string cityNameResultContent = DefaultCityName;

		/// <summary>
		/// 都市名結果文字列
		/// </summary>
		public string CityNameResultContent {
			private set => SetProperty( ref this.cityNameResultContent , value );
			get => this.cityNameResultContent;
		}

		/// <summary>
		/// 最低気温最高気温結果文字列
		/// </summary>
		private string maxAndMinTemperatureResultContent = DefaultTemperature + "/" + DefaultTemperature;

		/// <summary>
		/// 最低気温最高気温結果文字列
		/// </summary>
		public string MaxAndMinTemperatureResultContent {
			private set => SetProperty( ref this.maxAndMinTemperatureResultContent , value );
			get => this.maxAndMinTemperatureResultContent;
		}

		/// <summary>
		/// 湿度結果文字列
		/// </summary>
		private string humidityResultContent = DefaultHumidity;

		/// <summary>
		/// 湿度結果文字列
		/// </summary>
		public string HumidityResultContent {
			private set => SetProperty( ref this.humidityResultContent , value );
			get => this.humidityResultContent;
		}

		/// <summary>
		/// 風速結果文字列
		/// </summary>
		private string windSpeedResultContent = DefaultWindSpeed;

		/// <summary>
		/// 風速結果文字列
		/// </summary>
		public string WindSpeedResultContent {
			private set => SetProperty( ref this.windSpeedResultContent , value );
			get => this.windSpeedResultContent;
		}

		/// <summary>
		/// 1日後の日付
		/// </summary>
		private string dateContentAfter1Day = "--/--(--)";

		/// <summary>
		/// 1日後の日付
		/// </summary>
		public string DateContentAfter1Day {
			private set => SetProperty( ref this.dateContentAfter1Day , value );
			get => this.dateContentAfter1Day;
		}

		/// <summary>
		/// 2日後の日付
		/// </summary>
		private string dateContentAfter2Day = "--/--(--)";
		
		/// <summary>
		/// 2日後の日付
		/// </summary>
		public string DateContentAfter2Day {
			private set => SetProperty( ref this.dateContentAfter2Day , value );
			get => this.dateContentAfter2Day;
		}

		/// <summary>
		/// 3日後の日付
		/// </summary>
		private string dateContentAfter3Day = "--/--(--)";

		/// <summary>
		/// 3日後の日付
		/// </summary>
		public string DateContentAfter3Day {
			private set => SetProperty( ref this.dateContentAfter3Day , value );
			get => this.dateContentAfter3Day;
		}

		/// <summary>
		/// 4日後の日付
		/// </summary>
		private string dateContentAfter4Day = "--/--(--)";

		/// <summary>
		/// 4日後の日付
		/// </summary>
		public string DateContentAfter4Day {
			private set => SetProperty( ref this.dateContentAfter4Day , value );
			get => this.dateContentAfter4Day;
		}

		/// <summary>
		/// 5日後の日付
		/// </summary>
		private string dateContentAfter5Day = "--/--(--)";

		/// <summary>
		/// 5日後の日付
		/// </summary>
		public string DateContentAfter5Day {
			private set => SetProperty( ref this.dateContentAfter5Day , value );
			get => this.dateContentAfter5Day;
		}

		/// <summary>
		/// 1日後の最高気温/最低気温
		/// </summary>
		private string maxAndMinTemperatureResultContentAfter1Day = DefaultTemperature + "/" + DefaultTemperature;

		/// <summary>
		/// 1日後の最高気温/最低気温
		/// </summary>
		public string MaxAndMinTemperatureResultContentAfter1Day {
			private set => SetProperty( ref this.maxAndMinTemperatureResultContentAfter1Day , value );
			get => this.maxAndMinTemperatureResultContentAfter1Day;
		}

		/// <summary>
		/// 2日後の最高気温/最低気温
		/// </summary>
		private string maxAndMinTemperatureResultContentAfter2Day = DefaultTemperature + "/" + DefaultTemperature;

		/// <summary>
		/// 1日後の最高気温/最低気温
		/// </summary>
		public string MaxAndMinTemperatureResultContentAfter2Day {
			private set => SetProperty( ref this.maxAndMinTemperatureResultContentAfter2Day , value );
			get => this.maxAndMinTemperatureResultContentAfter2Day;
		}

		/// <summary>
		/// 3日後の最高気温/最低気温
		/// </summary>
		private string maxAndMinTemperatureResultContentAfter3Day = DefaultTemperature + "/" + DefaultTemperature;

		/// <summary>
		/// 1日後の最高気温/最低気温
		/// </summary>
		public string MaxAndMinTemperatureResultContentAfter3Day {
			private set => SetProperty( ref this.maxAndMinTemperatureResultContentAfter3Day , value );
			get => this.maxAndMinTemperatureResultContentAfter3Day;
		}

		/// <summary>
		/// 4日後の最高気温/最低気温
		/// </summary>
		private string maxAndMinTemperatureResultContentAfter4Day = DefaultTemperature + "/" + DefaultTemperature;

		/// <summary>
		/// 1日後の最高気温/最低気温
		/// </summary>
		public string MaxAndMinTemperatureResultContentAfter4Day {
			private set => SetProperty( ref this.maxAndMinTemperatureResultContentAfter4Day , value );
			get => this.maxAndMinTemperatureResultContentAfter4Day;
		}

		/// <summary>
		/// 5日後の最高気温/最低気温
		/// </summary>
		private string maxAndMinTemperatureResultContentAfter5Day = DefaultTemperature + "/" + DefaultTemperature;

		/// <summary>
		/// 1日後の最高気温/最低気温
		/// </summary>
		public string MaxAndMinTemperatureResultContentAfter5Day {
			private set => SetProperty( ref this.maxAndMinTemperatureResultContentAfter5Day , value );
			get => this.maxAndMinTemperatureResultContentAfter5Day;
		}

		/// <summary>
		/// 天気情報サービス
		/// </summary>
		private IWeatherService WeatherService { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public DetailPopUpViewModel( IWeatherService weatherService ) {
			this.WeatherService = weatherService;
			this.TestCommand = new DelegateCommand( () => UpdateWatherData() , () => true );
		}

		private DelegateCommand testCommand;

		public DelegateCommand TestCommand {
			private set => SetProperty( ref this.testCommand , value );
			get => this.testCommand;
		}

		/// <summary>
		/// データ更新
		/// </summary>
		public async void UpdateWatherData() {

			CurrentWeatherDataModel currentWeatherDataModel = await this.WeatherService.GetCurrentWeatherAsync();
			FiveDayWeatherForecastModel fiveDayWeatherForecastModel = await this.WeatherService.GetFiveDayWeatherForecastAsync();

			Console.WriteLine( JsonConvert.SerializeObject( currentWeatherDataModel ) );
			Console.WriteLine( JsonConvert.SerializeObject( fiveDayWeatherForecastModel ) );
			
			this.TitleContent = this.ConvertTitleContent( currentWeatherDataModel?.DateTime );
			this.UpdateContent = this.ConvertUpdateDateTime( currentWeatherDataModel?.DateTime );
			this.WeatherResultContent = this.ConvertWeather( currentWeatherDataModel?.Weathers );
			this.CityNameResultContent = this.ConvertCityName( currentWeatherDataModel?.CityName );
			this.MaxAndMinTemperatureResultContent = this.ConvertTemperature( currentWeatherDataModel?.Main?.MinTemperature , currentWeatherDataModel?.Main?.MaxTemperature );
			this.HumidityResultContent = this.ConvertHumidity( currentWeatherDataModel?.Main?.Humidity );
			this.WindSpeedResultContent = this.ConvertWind( currentWeatherDataModel?.Wind?.Speed , currentWeatherDataModel?.Wind?.Degree );

			FiveDayWeatherForecastModel.ForecastModel[][] splitForecastsEachDay = this.SplitForecastsEachDay( fiveDayWeatherForecastModel?.Forecasts );
			bool isTodayIncludes = false;
			for( int i = 0 ; i < splitForecastsEachDay.Length ; i++ ){

				// 当日の予報はいらない
				if( splitForecastsEachDay[ i ][ 0 ] == null || currentWeatherDataModel.DateTime.ToString( "MM/dd(ddd)" ).Equals( splitForecastsEachDay[ i ][ 0 ].DateTime.ToString( "MM/dd(ddd)" ) ) ) {
					isTodayIncludes = true;
					continue;
				}

				this.ConvertForecastDate( i - ( isTodayIncludes ? 1 : 0 ) , splitForecastsEachDay[ i ][ 0 ].DateTime );
				this.ConvertForecastWeather( i - ( isTodayIncludes ? 1 : 0 ) , splitForecastsEachDay[ i ] );
				this.ConvertForecastTemperature( i - ( isTodayIncludes ? 1 : 0 ) , splitForecastsEachDay[ i ] );
				
			}
			
		}
		
		/// <summary>
		/// タイトル変換
		/// </summary>
		/// <param name="dateTime">日時</param>
		/// <returns></returns>
		private string ConvertTitleContent( DateTime? dateTime )
		=> dateTime?.ToString( "yyyy/MM/dd(ddd)の天気" ) ?? DefaultTitle;

		/// <summary>
		/// 更新日時変換
		/// </summary>
		/// <param name="dateTime">日時</param>
		/// <returns></returns>
		private string ConvertUpdateDateTime( DateTime? dateTime )
		=> dateTime?.ToString( "更新日時:yyyy/MM/dd HH:mm:ss" ) ?? DefaultUpdate;

		/// <summary>
		/// 天気情報変換
		/// </summary>
		/// <param name="weatherOfModelData">天気情報</param>
		/// <returns></returns>
		private string ConvertWeather( CurrentWeatherDataModel.WeatherModel[] weathers ) {

			string result = "";

			foreach( CurrentWeatherDataModel.WeatherModel weather in weathers ) {
				if( !"".Equals( result ) )
					result += "のち";

				result +=
					"Rain".Equals( weather.Main ) ? "雨" :
					"Mist".Equals( weather.Main ) ? "曇り" :
					"";

			}

			return "".Equals( result ) ? DefaultWeather : result;

		}

		/// <summary>
		/// 都市名変換
		/// </summary>
		/// <param name="cityName">都市名</param>
		/// <returns></returns>
		private string ConvertCityName( string cityName )
		=> "Aichi-ken".Equals( cityName ) ? "愛知県" : 
			"Nagoya-shi".Equals( cityName ) ? "愛知県名古屋市" : 
			DefaultCityName;

		/// <summary>
		/// 最高気温／最低気温変換
		/// </summary>
		/// <param name="min"></param>
		/// <param name="max"></param>
		/// <returns></returns>
		private string ConvertTemperature( double? min , double? max ) =>
			( max.HasValue ? string.Format( "{0:f2}℃" , max - 273.15 ) : DefaultTemperature ) +
			"/" +
			( min.HasValue ? string.Format( "{0:f2}℃" , min - 273.15 ) : DefaultTemperature );

		/// <summary>
		/// 湿度変換
		/// </summary>
		private string ConvertHumidity( double? humidity )
		=> string.Format( "{0:f0}%" , humidity ) ?? DefaultHumidity;

		/// <summary>
		/// 風速変換
		/// </summary>
		private string ConvertWind( double? speed , double? degree ) => 
			degree.HasValue && speed.HasValue ?
				"(" +
				(
					360.0 * 15 / 16 <= degree || degree < 360.0 / 16 ? "北" :
					360.0 / 16 <= degree && degree < 360.0 * 3 / 16 ? "北東" :
					360.0 * 3 / 16 <= degree && degree < 360.0 * 5 / 16 ? "東" :
					360.0 * 5 / 16 <= degree && degree < 360.0 * 7 / 16 ? "南東" :
					360.0 * 7 / 16 <= degree && degree < 360.0 * 9 / 16 ? "南" :
					360.0 * 9 / 16 <= degree && degree < 360.0 * 11 / 16 ? "南西" :
					360.0 * 11 / 16 <= degree && degree < 360.0 * 13 / 16 ? "西" :
					360.0 * 13 / 16 <= degree && degree < 360.0 * 15 / 16 ? "北西" :
					"-"
				) +
				")" +
				speed + "m/s" :
				DefaultWindSpeed;

		/// <summary>
		/// 日毎に予報情報を分割する
		/// </summary>
		/// <param name="forecasts">予報</param>
		/// <returns></returns>
		private FiveDayWeatherForecastModel.ForecastModel[][] SplitForecastsEachDay( FiveDayWeatherForecastModel.ForecastModel[] forecasts ) {

			if( forecasts == null )
				return null;

			FiveDayWeatherForecastModel.ForecastModel[][] resultData = new FiveDayWeatherForecastModel.ForecastModel[1][];
			resultData[ 0 ] = new FiveDayWeatherForecastModel.ForecastModel[ 1 ];
			resultData[ 0 ][ 0 ] = forecasts[ 0 ];

			for( int i = 1 , j = 0 ; i < forecasts.Length ; i++ ) {

				if( resultData[ j ][ 0 ].DateTime.ToString( "MM/dd(ddd)" ).Equals( forecasts[ i ].DateTime.ToString( "MM/dd(ddd)" ) ) ){
					Array.Resize( ref resultData[j] , resultData[j].Length + 1 );
					resultData[ j ][ resultData[ j ].Length - 1 ] = forecasts[ i ];
				}
				else {
					Array.Resize( ref resultData , resultData.Length + 1 );
					++j;
					resultData[ j ] = new FiveDayWeatherForecastModel.ForecastModel[ 1 ];
					resultData[ j ][ 0 ] = forecasts[ i ];
				}

			}
			
			return resultData;
		}

		/// <summary>
		/// 天気予報の日付変換
		/// </summary>
		/// <param name="index">要素番号</param>
		/// <param name="dateTime">日付</param>
		private void ConvertForecastDate( int index , DateTime dateTime ) {
			string result = dateTime.ToString( "MM/dd(ddd)" );
			switch( index ) {
				case 0:
					this.DateContentAfter1Day = result;
					break;
				case 1:
					this.DateContentAfter2Day = result;
					break;
				case 2:
					this.DateContentAfter3Day = result;
					break;
				case 3:
					this.DateContentAfter4Day = result;
					break;
				case 4:
					this.DateContentAfter5Day = result;
					break;
			}
		}

		/// <summary>
		/// 天気予報の天気変換
		/// </summary>
		/// <param name="index">要素番号</param>
		/// <param name="forecasts">予報情報</param>
		private void ConvertForecastWeather( int index , FiveDayWeatherForecastModel.ForecastModel[] forecasts ) {
			
		}

		/// <summary>
		/// 天気予報の気温変換
		/// </summary>
		/// <param name="index">要素番号</param>
		/// <param name="forecasts">予報情報</param>
		private void ConvertForecastTemperature( int index , FiveDayWeatherForecastModel.ForecastModel[] forecasts ) {

			double min = forecasts[ 0 ].Main.MinTemperature;
			double max = forecasts[ 0 ].Main.MaxTemperature;
			for( int i = 1 ; i < forecasts.Length ; i++ ) {
				if( forecasts[ i ].Main.MinTemperature < min )
					min = forecasts[ i ].Main.MinTemperature;
				if( max < forecasts[ i ].Main.MaxTemperature )
					max = forecasts[ i ].Main.MaxTemperature;
			}

			switch( index ) {
				case 0:
					this.MaxAndMinTemperatureResultContentAfter1Day = string.Format( "{0:f2}℃" , max - 273.15 ) + "/" + string.Format( "{0:f2}℃" , min - 273.15 );
					break;
				case 1:
					this.MaxAndMinTemperatureResultContentAfter2Day = string.Format( "{0:f2}℃" , max - 273.15 ) + "/" + string.Format( "{0:f2}℃" , min - 273.15 );
					break;
				case 2:
					this.MaxAndMinTemperatureResultContentAfter3Day = string.Format( "{0:f2}℃" , max - 273.15 ) + "/" + string.Format( "{0:f2}℃" , min - 273.15 );
					break;
				case 3:
					this.MaxAndMinTemperatureResultContentAfter4Day = string.Format( "{0:f2}℃" , max - 273.15 ) + "/" + string.Format( "{0:f2}℃" , min - 273.15 );
					break;
				case 4:
					this.MaxAndMinTemperatureResultContentAfter5Day = string.Format( "{0:f2}℃" , max - 273.15 ) + "/" + string.Format( "{0:f2}℃" , min - 273.15 );
					break;

			}

		}

	}

}
