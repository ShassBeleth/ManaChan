using Prism.Mvvm;

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
		
		/// <summary>
		/// タイトル文字列
		/// </summary>
		private string titleContent = "----/--/--(-)の天気";

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
		private string updateContent = "更新日時:----/--/-- --:--:--";

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
		private string weatherResultContent = "---";

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
		private string cityNameResultContent = "---";

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
		private string maxAndMinTemperatureResultContent = "--℃/--℃";

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
		private string humidityResultContent = "--%";

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
		private string windSpeedResultContent = "--m/s(--)";

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
		private string maxAndMinTemperatureResultContentAfter1Day = "--℃/--℃";

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
		private string maxAndMinTemperatureResultContentAfter2Day = "--℃/--℃";

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
		private string maxAndMinTemperatureResultContentAfter3Day = "--℃/--℃";

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
		private string maxAndMinTemperatureResultContentAfter4Day = "--℃/--℃";

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
		private string maxAndMinTemperatureResultContentAfter5Day = "--℃/--℃";

		/// <summary>
		/// 1日後の最高気温/最低気温
		/// </summary>
		public string MaxAndMinTemperatureResultContentAfter5Day {
			private set => SetProperty( ref this.maxAndMinTemperatureResultContentAfter5Day , value );
			get => this.maxAndMinTemperatureResultContentAfter5Day;
		}
		
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public DetailPopUpViewModel() {
			

		}

	}

}
