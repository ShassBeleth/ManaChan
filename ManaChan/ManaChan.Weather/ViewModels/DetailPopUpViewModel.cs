using ManaChan.Weather.Services.Weather;
using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using System;
using Microsoft.Practices.Unity;
using ManaChan.Weather.Models.CurrentWeatherData;
using ManaChan.Weather.Models.FiveDayWeatherForecast;
using ManaChan.Infrastructure.Models.Publishers.ClosePopUps;
using ManaChan.Infrastructure.Models.Providers.CallServices;
using ManaChan.Infrastructure.Enums;

namespace ManaChan.Weather.ViewModels {

	/// <summary>
	/// DetailPopUpViewのViewModel
	/// </summary>
	public class DetailPopUpViewModel : BindableBase {

		/// <summary>
		/// ダイアログを閉じるための発行者
		/// </summary>
		[Dependency]
		public ClosePopUpPublisher ClosePopUpPublisher { set; get; }

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
		/// 気温文字列
		/// </summary>
		public string TemperatureContent { get; } = "気温";

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
		/// デフォルト風速
		/// </summary>
		private const string DefaultWindSpeed = "--m/s";

		#endregion

		#region 表示項目

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
		private string weatherResultContent;

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
		private string cityNameResultContent;

		/// <summary>
		/// 都市名結果文字列
		/// </summary>
		public string CityNameResultContent {
			private set => SetProperty( ref this.cityNameResultContent , value );
			get => this.cityNameResultContent;
		}

		/// <summary>
		/// 気温結果文字列
		/// </summary>
		private string temperatureResultContent;

		/// <summary>
		/// 気温結果文字列
		/// </summary>
		public string TemperatureResultContent {
			private set => SetProperty( ref this.temperatureResultContent , value );
			get => this.temperatureResultContent;
		}

		/// <summary>
		/// 湿度結果文字列
		/// </summary>
		private string humidityResultContent;

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
		private string maxAndMinTemperatureResultContentAfter1Day;

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
		private string maxAndMinTemperatureResultContentAfter2Day;

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
		private string maxAndMinTemperatureResultContentAfter3Day;

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
		private string maxAndMinTemperatureResultContentAfter4Day;

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
		private string maxAndMinTemperatureResultContentAfter5Day;

		/// <summary>
		/// 1日後の最高気温/最低気温
		/// </summary>
		public string MaxAndMinTemperatureResultContentAfter5Day {
			private set => SetProperty( ref this.maxAndMinTemperatureResultContentAfter5Day , value );
			get => this.maxAndMinTemperatureResultContentAfter5Day;
		}

		#endregion

		#region 閉じるボタン

		/// <summary>
		/// 閉じるボタンコマンド
		/// </summary>
		private DelegateCommand closeButtonCommand;

		/// <summary>
		/// 閉じるボタンコマンド
		/// </summary>
		public DelegateCommand CloseButtonCommand {
			private set => SetProperty( ref this.closeButtonCommand , value );
			get => this.closeButtonCommand;
		}

		/// <summary>
		/// 閉じるボタン実行
		/// </summary>
		/// <returns></returns>
		private Action CloseButtonExecute() => () => { this.ClosePopUpPublisher.Publish( PopUpNames.Weather ); };

		/// <summary>
		/// 閉じるボタン実行可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanCloseButtonExecute() => () => true;

		#endregion

		#region テスト用更新ボタン

		private DelegateCommand testCommand;

		public DelegateCommand TestCommand {
			private set => SetProperty( ref this.testCommand , value );
			get => this.testCommand;
		}

		#endregion

		/// <summary>
		/// 天気情報サービス
		/// </summary>
		private IWeatherService WeatherService { get; }

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="weatherService">天気情報サービス</param>
		/// <param name="callServiceProvider">サービス呼び出し購読者</param>
		public DetailPopUpViewModel( 
			IWeatherService weatherService ,
			ICallServiceProvider callServiceProvider ) {

			this.WeatherService = weatherService;

			this.CloseButtonCommand = new DelegateCommand( this.CloseButtonExecute() , this.CanCloseButtonExecute() );
			this.TestCommand = new DelegateCommand( () => UpdateWatherData() , () => true );

			callServiceProvider.PropertyChanged += ( _ , e ) => {
				Console.WriteLine( "aaa" );
				if( e.PropertyName == "Guid" )
					this.UpdateWatherData();
			};

		}

		#region privateロジック

		/// <summary>
		/// データ更新
		/// </summary>
		public async void UpdateWatherData() {

			await this.WeatherService.SendCurrentWeatherAsync();
			await this.WeatherService.SendFiveDayWeatherForecastAsync();

			CurrentWeatherDataModel currentData = this.WeatherService.CurrentWeatherDataModel;
			FiveDayWeatherForecastModel fiveData = this.WeatherService.FiveDayWeatherForecastModel;

			Console.WriteLine( JsonConvert.SerializeObject( currentData ) );
			Console.WriteLine( JsonConvert.SerializeObject( fiveData ) );
			
			this.TitleContent = DateTime.Today.ToString( "yyyy/MM/dd(ddd)" ) + "の天気";
			this.UpdateContent = "更新日時:" + currentData.ToDateTimeString();
			this.WeatherResultContent = currentData.ToWeathersString();
			this.CityNameResultContent = currentData.ToCityNameString();
			this.TemperatureResultContent = currentData.Main?.ToTemperatureString() ?? "---℃";
			this.HumidityResultContent = currentData.Main?.ToHumidityString();
			this.WindSpeedResultContent = currentData.ToWindString();

			for( int i = 1 ; i <= 5 ; i++ ){
				this.ConvertForecastDate( i , fiveData );
				this.ConvertForecastTemperature( i , fiveData );
				
			}
			
		}
		
		/// <summary>
		/// 天気予報の日付変換
		/// </summary>
		/// <param name="afterDayNum">何日後か</param>
		/// <param name="fiveData">5日間の予測情報</param>
		private void ConvertForecastDate( int afterDayNum , FiveDayWeatherForecastModel fiveData ) {
			switch( afterDayNum ) {
				case 1:
					this.DateContentAfter1Day = fiveData.ToDateString( afterDayNum );
					break;
				case 2:
					this.DateContentAfter2Day = fiveData.ToDateString( afterDayNum );
					break;
				case 3:
					this.DateContentAfter3Day = fiveData.ToDateString( afterDayNum );
					break;
				case 4:
					this.DateContentAfter4Day = fiveData.ToDateString( afterDayNum );
					break;
				case 5:
					this.DateContentAfter5Day = fiveData.ToDateString( afterDayNum );
					break;
			}
		}

		/// <summary>
		/// 天気予報の気温変換
		/// </summary>
		/// <param name="afterDayNum">何日後か</param>
		/// <param name="forecasts">5日間の予測情報</param>
		private void ConvertForecastTemperature( int afterDayNum , FiveDayWeatherForecastModel fiveData ) {

			switch( afterDayNum ) {
				case 1:
					this.MaxAndMinTemperatureResultContentAfter1Day = fiveData.ToMinAndMaxTemperatureString( afterDayNum );
					break;
				case 2:
					this.MaxAndMinTemperatureResultContentAfter2Day = fiveData.ToMinAndMaxTemperatureString( afterDayNum );
					break;
				case 3:
					this.MaxAndMinTemperatureResultContentAfter3Day = fiveData.ToMinAndMaxTemperatureString( afterDayNum );
					break;
				case 4:
					this.MaxAndMinTemperatureResultContentAfter4Day = fiveData.ToMinAndMaxTemperatureString( afterDayNum );
					break;
				case 5:
					this.MaxAndMinTemperatureResultContentAfter5Day = fiveData.ToMinAndMaxTemperatureString( afterDayNum );
					break;

			}

		}

		#endregion

	}

}
