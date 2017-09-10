using System;
using System.Windows;
using ManaChan.Infrastructure.Enums;
using ManaChan.Infrastructure.Models.ScreenSize;
using ManaChan.MainWindow.Models.Providers.InputPinCode;
using ManaChan.MainWindow.Models.Publishers.ChangeCharacterType;
using ManaChan.Twitter.Services;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;
using ManaChan.MainWindow.Models.Publishers.ChangeCharacterEmotionType;

namespace ManaChan.MainWindow.ViewModels {

	public partial class MainWindowViewModel : BindableBase {
		
		/// <summary>
		/// 画面サイズ
		/// </summary>
		[Dependency]
		public PrimaryScreenSize PrimaryScreenSize { get; } = new PrimaryScreenSize();

		/// <summary>
		/// キャラクター種別発行者
		/// </summary>
		[Dependency]
		public IChangeCharacterTypePublisher ChangeCharacterTypePublisher { set; get; }

		/// <summary>
		/// キャラクター表情種別発行者
		/// </summary>
		[Dependency]
		public IChangeCharacterEmotionTypePublisher ChangeCharacterEmotionTypePublisher { set; get; }
		
		#region Services

		/// <summary>
		/// ツイッター認証サービス
		/// </summary>
		[Dependency]
		private IAuthenticatedService AuthenticatedService { get; }
		
		#endregion

		#region ポップアップ表示／非表示

		private Visibility inputPinCodePopUpVisibility = Visibility.Hidden;

		public Visibility InputPinCodePopUpVisibility {
			private set => SetProperty( ref this.inputPinCodePopUpVisibility , value );
			get => this.inputPinCodePopUpVisibility;
		}

		#endregion

		#region 画面を閉じるかどうか

		/// <summary>
		/// 画面を閉じるかどうか
		/// </summary>
		private bool isCloseWindow = false;

		/// <summary>
		/// 画面を閉じるかどうか
		/// </summary>
		public bool IsCloseWindow {
			private set => SetProperty( ref this.isCloseWindow , value );
			get => this.isCloseWindow;
		}

		#endregion

		#region 右クリックメニュー

		#region Twitter

		/// <summary>
		/// Twitterグループ文字列
		/// </summary>
		public string TwitterGroupHeaderOfContextMenu { get; } = "Twitter";

		#region ツイッター認証

		/// <summary>
		/// ツイッター認証文字列
		/// </summary>
		public string TwitterAuthenticateHeaderOfContextMenu { get; } = "Twitter認証";

		/// <summary>
		/// ツイッター認証コマンド
		/// </summary>
		private DelegateCommand twitterAuthenticateCommandOfContextMenu;

		/// <summary>
		/// ツイッター認証コマンド
		/// </summary>
		public DelegateCommand TwitterAuthenticateCommandOfContextMenu {
			private set => SetProperty( ref this.twitterAuthenticateCommandOfContextMenu , value );
			get => this.twitterAuthenticateCommandOfContextMenu;
		}

		/// <summary>
		/// ツイッター認証イベント
		/// </summary>
		/// <returns></returns>
		private Action TwitterAuthenticateExecuteOfContextMenu() => () => {
			this.AuthenticatedService.Authorize();
			this.InputPinCodePopUpVisibility = Visibility.Visible;
		};

		/// <summary>
		/// ツイッター認証イベント可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanTwitterAuthenticateExecuteOfContextMenu() => () => true;

		#endregion

		#region テストツイート

		/// <summary>
		/// テストツイート文字列
		/// </summary>
		public string TestTweetHeaderOfContextMenu { get; } = "テストツイート";

		/// <summary>
		/// テストツイートコマンド
		/// </summary>
		private DelegateCommand testTweetCommandOfContextMenu;

		/// <summary>
		/// テストツイートコマンド
		/// </summary>
		public DelegateCommand TestTweetCommandOfContextMenu {
			private set => SetProperty( ref this.testTweetCommandOfContextMenu , value );
			get => this.testTweetCommandOfContextMenu;
		}

		/// <summary>
		/// テストツイートイベント
		/// </summary>
		/// <returns></returns>
		private Action TestTweetExecuteOfContextMenu() => () => this.AuthenticatedService.Tweet( "茜ちゃんから投稿\nｱｶﾈﾁｬﾝｶﾜｲｲﾔｯﾀｰ!\n" + DateTime.Now );

		/// <summary>
		/// テストツイートイベント可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanTestTweetExecuteOfContextMenu() => () => true;

		#endregion

		#endregion

		#region 天気

		/// <summary>
		/// 天気文字列
		/// </summary>
		public string WeatherInfoHeaderOfContextMenu { get; } = "天気";

		/// <summary>
		/// 天気コマンド
		/// </summary>
		private DelegateCommand weatherInfoCommandOfContextMenu;

		/// <summary>
		/// 天気コマンド
		/// </summary>
		public DelegateCommand WeatherInfoCommandOfContextMenu {
			private set => SetProperty( ref this.weatherInfoCommandOfContextMenu , value );
			get => this.weatherInfoCommandOfContextMenu;
		}

		/// <summary>
		/// 天気イベント
		/// </summary>
		private Action WeatherInfoExecuteOfContextMenu() => () => {
			Console.WriteLine( "weather" );
		};

		/// <summary>
		/// 天気イベント可否
		/// </summary>
		private Func<bool> CanWeatherInfoExecuteOfContextMenu() => () => true;

		#endregion

		#region キャラクターサイズ

		/// <summary>
		/// キャラクターサイズ
		/// </summary>
		private Size characterSize = Size.Medium;

		/// <summary>
		/// キャラクターサイズ
		/// </summary>
		public Size CharacterSize {
			set => SetProperty( ref this.characterSize , value );
			get => this.characterSize;
		}

		/// <summary>
		/// キャラクターサイズ変更グループ文字列
		/// </summary>
		public string ChangeCharacterGroupHeaderOfContextMenu { get; } = "キャラクターサイズ変更";

		#region ドアップ

		/// <summary>
		/// ドアップ文字列
		/// </summary>
		public string CharacterSpecialLargeHeaderOfContextMenu { get; } = "ドアップ";

		/// <summary>
		/// ドアップコマンド
		/// </summary>
		private DelegateCommand characterSpecialLargeCommandOfContextMenu;

		/// <summary>
		/// ドアップコマンド
		/// </summary>
		public DelegateCommand CharacterSpecialLargeCommandOfContextMenu {
			private set => SetProperty( ref this.characterSpecialLargeCommandOfContextMenu , value );
			get => this.characterSpecialLargeCommandOfContextMenu;
		}

		/// <summary>
		/// ドアップイベント
		/// </summary>
		/// <returns></returns>
		private Action CharacterSpecialLargeExecuteOfContextMenu() => () => this.UpdateSizeAndPosition();

		/// <summary>
		/// ドアップ可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanCharacterSpecialLargeExecuteOfContextMenu() => () => true;

		#endregion

		#region 大

		/// <summary>
		/// 大文字列
		/// </summary>
		public string CharacterLargeHeaderOfContextMenu { get; } = "大";

		/// <summary>
		/// 大コマンド
		/// </summary>
		private DelegateCommand characterLargeCommandOfContextMenu;

		/// <summary>
		/// 大コマンド
		/// </summary>
		public DelegateCommand CharacterLargeCommandOfContextMenu {
			private set => SetProperty( ref this.characterLargeCommandOfContextMenu , value );
			get => this.characterLargeCommandOfContextMenu;
		}

		/// <summary>
		/// 大イベント
		/// </summary>
		/// <returns></returns>
		private Action CharacterLargeExecuteOfContextMenu() => () => this.UpdateSizeAndPosition();

		/// <summary>
		/// 大可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanCharacterLargeExecuteOfContextMenu() => () => true;

		#endregion

		#region 中

		/// <summary>
		/// 中文字列
		/// </summary>
		public string CharacterMediumHeaderOfContextMenu { get; } = "中";

		/// <summary>
		/// 中コマンド
		/// </summary>
		private DelegateCommand characterMediumCommandOfContextMenu;

		/// <summary>
		/// 中コマンド
		/// </summary>
		public DelegateCommand CharacterMediumCommandOfContextMenu {
			private set => SetProperty( ref this.characterMediumCommandOfContextMenu , value );
			get => this.characterMediumCommandOfContextMenu;
		}

		/// <summary>
		/// 中イベント
		/// </summary>
		/// <returns></returns>
		private Action CharacterMediumExecuteOfContextMenu() => () => this.UpdateSizeAndPosition();

		/// <summary>
		/// 中可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanCharacterMediumExecuteOfContextMenu() => () => true;

		#endregion

		#region 小

		/// <summary>
		/// 小文字列
		/// </summary>
		public string CharacterSmallHeaderOfContextMenu { get; } = "小";

		/// <summary>
		/// 小コマンド
		/// </summary>
		private DelegateCommand characterSmallCommandOfContextMenu;

		/// <summary>
		/// 小コマンド
		/// </summary>
		public DelegateCommand CharacterSmallCommandOfContextMenu {
			private set => SetProperty( ref this.characterSmallCommandOfContextMenu , value );
			get => this.characterSmallCommandOfContextMenu;
		}

		/// <summary>
		/// 小イベント
		/// </summary>
		/// <returns></returns>
		private Action CharacterSmallExecuteOfContextMenu() => () => this.UpdateSizeAndPosition();

		/// <summary>
		/// 小可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanCharacterSmallExecuteOfContextMenu() => () => true;

		#endregion

		#endregion

		#region キャラクター種別

		/// <summary>
		/// 選択中のキャラクター
		/// </summary>
		private CharacterType selectedCharacter = CharacterType.Akane;

		/// <summary>
		/// 選択中のキャラクター
		/// </summary>
		public CharacterType SelectedCharacter {
			set => SetProperty( ref this.selectedCharacter , value );
			get => this.selectedCharacter;
		}

		/// <summary>
		/// キャラクター変更グループ文字列
		/// </summary>
		public string ChangeCharacterGraphicGroupHeaderOfContextMenu { get; } = "キャラクター変更";

		#region 琴葉 茜

		/// <summary>
		/// 琴葉 茜文字列
		/// </summary>
		public string AkaneHeaderOfContextMenu { get; } = "琴葉 茜";

		/// <summary>
		/// 琴葉 茜コマンド
		/// </summary>
		private DelegateCommand akaneCommandOfContextMenu;

		/// <summary>
		/// 琴葉 茜コマンド
		/// </summary>
		public DelegateCommand AkaneCommandOfContextMenu {
			private set => SetProperty( ref this.akaneCommandOfContextMenu , value );
			get => this.akaneCommandOfContextMenu;
		}

		/// <summary>
		/// 琴葉 茜イベント
		/// </summary>
		/// <returns></returns>
		private Action AkaneExecuteOfContextMenu() => () => this.ChangeCharacterTypePublisher.Publish( CharacterType.Akane );

		/// <summary>
		/// 琴葉 茜可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanAkaneExecuteOfContextMenu() => () => true;

		#endregion

		#region 琴葉 葵

		/// <summary>
		/// 琴葉 葵文字列
		/// </summary>
		public string AoiHeaderOfContextMenu { get; } = "琴葉 葵";

		/// <summary>
		/// 琴葉 葵コマンド
		/// </summary>
		private DelegateCommand aoiCommandOfContextMenu;

		/// <summary>
		/// 琴葉 葵コマンド
		/// </summary>
		public DelegateCommand AoiCommandOfContextMenu {
			private set => SetProperty( ref this.aoiCommandOfContextMenu , value );
			get => this.aoiCommandOfContextMenu;
		}

		/// <summary>
		/// 琴葉 葵イベント
		/// </summary>
		/// <returns></returns>
		private Action AoiExecuteOfContextMenu() => () => this.ChangeCharacterTypePublisher.Publish( CharacterType.Aoi );

		/// <summary>
		/// 琴葉 葵可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanAoiExecuteOfContextMenu() => () => true;

		#endregion

		#region 弦巻 マキ

		/// <summary>
		/// 弦巻 マキ文字列
		/// </summary>
		public string MakiHeaderOfContextMenu { get; } = "弦巻 マキ";

		/// <summary>
		/// 弦巻 マキコマンド
		/// </summary>
		private DelegateCommand makiCommandOfContextMenu;

		/// <summary>
		/// 弦巻 マキコマンド
		/// </summary>
		public DelegateCommand MakiCommandOfContextMenu {
			private set => SetProperty( ref this.makiCommandOfContextMenu , value );
			get => this.makiCommandOfContextMenu;
		}

		/// <summary>
		/// 弦巻 マキイベント
		/// </summary>
		/// <returns></returns>
		private Action MakiExecuteOfContextMenu() => () => this.ChangeCharacterTypePublisher.Publish( CharacterType.Maki );

		/// <summary>
		/// 弦巻 マキ可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanMakiExecuteOfContextMenu() => () => true;

		#endregion

		#region 結月 ゆかり

		/// <summary>
		/// 結月 ゆかり文字列
		/// </summary>
		public string YukariHeaderOfContextMenu { get; } = "結月 ゆかり";

		/// <summary>
		/// 結月 ゆかりコマンド
		/// </summary>
		private DelegateCommand yukariCommandOfContextMenu;

		/// <summary>
		/// 結月 ゆかりコマンド
		/// </summary>
		public DelegateCommand YukariCommandOfContextMenu {
			private set => SetProperty( ref this.yukariCommandOfContextMenu , value );
			get => this.yukariCommandOfContextMenu;
		}

		/// <summary>
		/// 結月 ゆかりイベント
		/// </summary>
		/// <returns></returns>
		private Action YukariExecuteOfContextMenu() => () => this.ChangeCharacterTypePublisher.Publish( CharacterType.Yukari );

		/// <summary>
		/// 結月 ゆかり可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanYukariExecuteOfContextMenu() => () => true;

		#endregion

		#region 東北 ずん子

		/// <summary>
		/// 東北 ずん子文字列
		/// </summary>
		public string ZunkoHeaderOfContextMenu { get; } = "東北 ずん子";

		/// <summary>
		/// 東北 ずん子コマンド
		/// </summary>
		private DelegateCommand zunkoCommandOfContextMenu;

		/// <summary>
		/// 東北 ずん子コマンド
		/// </summary>
		public DelegateCommand ZunkoCommandOfContextMenu {
			private set => SetProperty( ref this.zunkoCommandOfContextMenu , value );
			get => this.zunkoCommandOfContextMenu;
		}

		/// <summary>
		/// 東北 ずん子イベント
		/// </summary>
		/// <returns></returns>
		private Action ZunkoExecuteOfContextMenu() => () => this.ChangeCharacterTypePublisher.Publish( CharacterType.Zunko );

		/// <summary>
		/// 東北 ずん子可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanZunkoExecuteOfContextMenu() => () => true;

		#endregion

		#endregion

		#region キャラクター表情種別

		/// <summary>
		/// 選択中のキャラクター表情
		/// </summary>
		private CharacterEmotionType selectedCharacterEmotion = CharacterEmotionType.Normal;

		/// <summary>
		/// 選択中のキャラクター表情
		/// </summary>
		public CharacterEmotionType SelectedCharacterEmotion {
			set => SetProperty( ref this.selectedCharacterEmotion , value );
			get => this.selectedCharacterEmotion;
		}

		/// <summary>
		/// キャラクター表情変更グループ文字列
		/// </summary>
		public string ChangeCharacterEmotionGraphicGroupHeaderOfContextMenu { get; } = "キャラクター表情変更";

		#region 通常

		/// <summary>
		/// 通常文字列
		/// </summary>
		public string NormalHeaderOfContextMenu { get; } = "通常";

		/// <summary>
		/// 通常コマンド
		/// </summary>
		private DelegateCommand normalCommandOfContextMenu;

		/// <summary>
		/// 通常コマンド
		/// </summary>
		public DelegateCommand NormalCommandOfContextMenu {
			private set => SetProperty( ref this.normalCommandOfContextMenu , value );
			get => this.normalCommandOfContextMenu;
		}

		/// <summary>
		/// 通常イベント
		/// </summary>
		/// <returns></returns>
		private Action NormalExecuteOfContextMenu() => () => this.ChangeCharacterEmotionTypePublisher.Publish( CharacterEmotionType.Normal );

		/// <summary>
		/// 通常可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanNormalExecuteOfContextMenu() => () => true;

		#endregion

		#region 暑い

		/// <summary>
		/// 暑い文字列
		/// </summary>
		public string HotHeaderOfContextMenu { get; } = "暑い";

		/// <summary>
		/// 暑いコマンド
		/// </summary>
		private DelegateCommand hotCommandOfContextMenu;

		/// <summary>
		/// 暑いコマンド
		/// </summary>
		public DelegateCommand HotCommandOfContextMenu {
			private set => SetProperty( ref this.hotCommandOfContextMenu , value );
			get => this.hotCommandOfContextMenu;
		}

		/// <summary>
		/// 暑いイベント
		/// </summary>
		/// <returns></returns>
		private Action HotExecuteOfContextMenu() => () => this.ChangeCharacterEmotionTypePublisher.Publish( CharacterEmotionType.Hot );

		/// <summary>
		/// 暑い可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanHotExecuteOfContextMenu() => () => true;

		#endregion

		#region 興奮

		/// <summary>
		/// 興奮文字列
		/// </summary>
		public string ExcitementHeaderOfContextMenu { get; } = "興奮";

		/// <summary>
		/// 興奮コマンド
		/// </summary>
		private DelegateCommand excitementCommandOfContextMenu;

		/// <summary>
		/// 興奮コマンド
		/// </summary>
		public DelegateCommand ExcitementCommandOfContextMenu {
			private set => SetProperty( ref this.excitementCommandOfContextMenu , value );
			get => this.excitementCommandOfContextMenu;
		}

		/// <summary>
		/// 興奮イベント
		/// </summary>
		/// <returns></returns>
		private Action ExcitementExecuteOfContextMenu() => () => this.ChangeCharacterEmotionTypePublisher.Publish( CharacterEmotionType.Excitement );

		/// <summary>
		/// 興奮可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanExcitementExecuteOfContextMenu() => () => true;

		#endregion

		#region 眠い

		/// <summary>
		/// 眠い文字列
		/// </summary>
		public string SleepyHeaderOfContextMenu { get; } = "眠い";

		/// <summary>
		/// 眠いコマンド
		/// </summary>
		private DelegateCommand sleepyCommandOfContextMenu;

		/// <summary>
		/// 眠いコマンド
		/// </summary>
		public DelegateCommand SleepyCommandOfContextMenu {
			private set => SetProperty( ref this.sleepyCommandOfContextMenu , value );
			get => this.sleepyCommandOfContextMenu;
		}

		/// <summary>
		/// 眠いイベント
		/// </summary>
		/// <returns></returns>
		private Action SleepyExecuteOfContextMenu() => () => this.ChangeCharacterEmotionTypePublisher.Publish( CharacterEmotionType.Sleepy );

		/// <summary>
		/// 眠い可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanSleepyExecuteOfContextMenu() => () => true;

		#endregion

		#region 驚き

		/// <summary>
		/// 驚き文字列
		/// </summary>
		public string SurpriseHeaderOfContextMenu { get; } = "驚き";

		/// <summary>
		/// 驚きコマンド
		/// </summary>
		private DelegateCommand surpriseCommandOfContextMenu;

		/// <summary>
		/// 驚きコマンド
		/// </summary>
		public DelegateCommand SurpriseCommandOfContextMenu {
			private set => SetProperty( ref this.surpriseCommandOfContextMenu , value );
			get => this.surpriseCommandOfContextMenu;
		}

		/// <summary>
		/// 驚きイベント
		/// </summary>
		/// <returns></returns>
		private Action SurpriseExecuteOfContextMenu() => () => this.ChangeCharacterEmotionTypePublisher.Publish( CharacterEmotionType.Surprise );

		/// <summary>
		/// 驚き可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanSurpriseExecuteOfContextMenu() => () => true;

		#endregion
		
		#endregion

		#region 終了

		/// <summary>
		/// 終了文字列
		/// </summary>
		public string QuitHeaderOfContextMenu { get; } = "終了";

		/// <summary>
		/// 終了ボタン押下可否
		/// </summary>
		private bool isQuitEnabledOfContextMenu = true;

		/// <summary>
		/// 終了ボタン押下可否
		/// </summary>
		public bool IsQuitEnabledOfContextMenu {
			private set => SetProperty( ref this.isQuitEnabledOfContextMenu , value );
			get => this.isQuitEnabledOfContextMenu;
		}

		/// <summary>
		/// 終了コマンド
		/// </summary>
		private DelegateCommand quitCommandOfContextMenu;

		/// <summary>
		/// 終了コマンド
		/// </summary>
		public DelegateCommand QuitCommandOfContextMenu {
			private set => SetProperty( ref this.quitCommandOfContextMenu , value );
			get => this.quitCommandOfContextMenu;
		}

		/// <summary>
		/// 終了イベント
		/// </summary>
		/// <returns></returns>
		private Action QuitExecuteOfContextMenu() => () => this.IsCloseWindow = true;

		/// <summary>
		/// 終了可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanQuitExecuteOfContextMenu() => () => this.IsQuitEnabledOfContextMenu;

		#endregion

		#endregion

		#region キャラクターの表示座標

		#region キャラクターの高さ

		/// <summary>
		/// キャラクターの描画高さ
		/// </summary>
		private int characterHeight = 0;

		/// <summary>
		/// キャラクターの描画高さ
		/// </summary>
		public int CharacterHeight {
			set => SetProperty( ref this.characterHeight , value );
			get => this.characterHeight;
		}

		#endregion

		#region キャラクターの幅

		/// <summary>
		/// キャラクターの描画幅
		/// </summary>
		private int characterWidth = 0;

		/// <summary>
		/// キャラクターの描画幅
		/// </summary>
		public int CharacterWidth {
			set => SetProperty( ref this.characterWidth , value );
			get => this.characterWidth;
		}

		#endregion

		#region キャラクターのX座標

		/// <summary>
		/// キャラクターのX座標
		/// </summary>
		private int characterPosX;

		/// <summary>
		/// キャラクターのX座標
		/// </summary>
		public int CharacterPosX {
			set => SetProperty( ref this.characterPosX , value );
			get => this.characterPosX;
		}

		#endregion

		#region キャラクターのY座標

		/// <summary>
		/// キャラクターのY座標
		/// </summary>
		private int characterPosY;

		/// <summary>
		/// キャラクターのY座標
		/// </summary>
		public int CharacterPosY {
			set => SetProperty( ref this.characterPosY , value );
			get => this.characterPosY;
		}

		#endregion

		/// <summary>
		/// キャラクターのサイズ更新
		/// </summary>
		private void UpdateSizeAndPosition() {

			// 変更前のサイズと座標を保持
			double beforeWidth = this.CharacterWidth;
			double beforeHeight = this.CharacterHeight;
			int beforePosX = this.CharacterPosX;
			int beforePosY = this.CharacterPosY;

			// ドアップ時の倍率
			const double specialLargeHeightMagnification = 5;
			const double specialLargeWidthMagnification = 3;

			// 大時の倍率
			const double largeHeightMagnification = 1;
			const double largeWidthMagnification = 0.5;

			// 中時の倍率
			const double mediumHeightMagnification = 0.5;
			const double mediumWidthMagnification = 0.25;

			// 小時の倍率
			const double smallHeightMagnification = 0.25;
			const double smallWidthMagnification = 0.20;

			// 画面からはみ出さないように調節
			(int posX, int posY) CorrectionOverflow( int posX , int posY )
				=> (
					posX < 0 ? 0 :
					this.PrimaryScreenSize.Width - this.CharacterWidth < posX ?
						(int)( this.PrimaryScreenSize.Width - this.CharacterWidth ) :
					posX,
					posY < 0 ? 0 :
					this.PrimaryScreenSize.Height - this.CharacterHeight < posY ?
						(int)( this.PrimaryScreenSize.Height - this.CharacterHeight ) :
					posY
				);

			// 実際の倍率
			double heightMagnification = 0;
			double widthMagnification = 0;

			switch( this.CharacterSize ) {
				case Size.SpecialLarge:
					heightMagnification = specialLargeHeightMagnification;
					widthMagnification = specialLargeWidthMagnification;
					this.CharacterWidth = (int)( this.PrimaryScreenSize.Width * widthMagnification );
					this.CharacterHeight = (int)( this.PrimaryScreenSize.Height * heightMagnification );
					this.CharacterPosX = (int)( ( this.PrimaryScreenSize.Width - this.CharacterWidth ) / 2 );
					this.CharacterPosY = (int)( -this.PrimaryScreenSize.Height * 0.4 );
					break;

				case Size.Large:
					heightMagnification = largeHeightMagnification;
					widthMagnification = largeWidthMagnification;
					this.CharacterWidth = (int)( this.PrimaryScreenSize.Width * widthMagnification );
					this.CharacterHeight = (int)( this.PrimaryScreenSize.Height * heightMagnification );
					this.CharacterPosY = 0;
					(this.CharacterPosX, this.CharacterPosY) = CorrectionOverflow( this.CharacterPosX , this.CharacterPosY );
					break;

				case Size.Medium:
					heightMagnification = mediumHeightMagnification;
					widthMagnification = mediumWidthMagnification;
					this.CharacterWidth = (int)( this.PrimaryScreenSize.Width * widthMagnification );
					this.CharacterHeight = (int)( this.PrimaryScreenSize.Height * heightMagnification );
					(this.CharacterPosX, this.CharacterPosY) = CorrectionOverflow( this.CharacterPosX , this.CharacterPosY );
					break;

				case Size.Small:
					heightMagnification = smallHeightMagnification;
					widthMagnification = smallWidthMagnification;
					this.CharacterWidth = (int)( this.PrimaryScreenSize.Width * widthMagnification );
					this.CharacterHeight = (int)( this.PrimaryScreenSize.Height * heightMagnification );
					(this.CharacterPosX, this.CharacterPosY) = CorrectionOverflow( this.CharacterPosX , this.CharacterPosY );
					break;

			}

		}

		/// <summary>
		/// キャラクターの座標初期化
		/// </summary>
		private void InitialCharacterPosition() {

			this.CharacterPosX = (int)this.PrimaryScreenSize.Width - this.CharacterWidth;
			this.CharacterPosY = (int)this.PrimaryScreenSize.Height - this.CharacterHeight;

		}

		#endregion

		#region Provider.PropertyChanged 

		/// <summary>
		/// PINコード入力時イベント
		/// </summary>
		/// <param name="pinCode">PINコード</param>
		private void PinCodeChangedEvent( int pinCode ) {

			this.AuthenticatedService.SetPinCode( pinCode );
			this.InputPinCodePopUpVisibility = Visibility.Hidden;

		}

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		/// <param name="authenticatedService">認証サービス</param>
		/// <param name="pinCodeProvider">PINコード購読者</param>
		public MainWindowViewModel(
			IAuthenticatedService authenticatedService , 
			IInputPinCodeProvider pinCodeProvider 
		) {

			this.AuthenticatedService = authenticatedService;

			#region コマンド作成

			this.TwitterAuthenticateCommandOfContextMenu = new DelegateCommand( this.TwitterAuthenticateExecuteOfContextMenu() , this.CanTwitterAuthenticateExecuteOfContextMenu() );
			this.TestTweetCommandOfContextMenu = new DelegateCommand( this.TestTweetExecuteOfContextMenu() , this.CanTestTweetExecuteOfContextMenu() );

			this.WeatherInfoCommandOfContextMenu = new DelegateCommand( this.WeatherInfoExecuteOfContextMenu() , this.CanWeatherInfoExecuteOfContextMenu() );

			this.CharacterSpecialLargeCommandOfContextMenu = new DelegateCommand( this.CharacterSpecialLargeExecuteOfContextMenu() , this.CanCharacterSpecialLargeExecuteOfContextMenu() );
			this.CharacterLargeCommandOfContextMenu = new DelegateCommand( this.CharacterLargeExecuteOfContextMenu() , this.CanCharacterLargeExecuteOfContextMenu() );
			this.CharacterMediumCommandOfContextMenu = new DelegateCommand( this.CharacterMediumExecuteOfContextMenu() , this.CanCharacterMediumExecuteOfContextMenu() );
			this.CharacterSmallCommandOfContextMenu = new DelegateCommand( this.CharacterSmallExecuteOfContextMenu() , this.CanCharacterSmallExecuteOfContextMenu() );

			this.AkaneCommandOfContextMenu = new DelegateCommand( this.AkaneExecuteOfContextMenu() , this.CanAkaneExecuteOfContextMenu() );
			this.AoiCommandOfContextMenu = new DelegateCommand( this.AoiExecuteOfContextMenu() , this.CanAoiExecuteOfContextMenu() );
			this.MakiCommandOfContextMenu = new DelegateCommand( this.MakiExecuteOfContextMenu() , this.CanMakiExecuteOfContextMenu() );
			this.YukariCommandOfContextMenu = new DelegateCommand( this.YukariExecuteOfContextMenu() , this.CanYukariExecuteOfContextMenu() );
			this.ZunkoCommandOfContextMenu = new DelegateCommand( this.ZunkoExecuteOfContextMenu() , this.CanZunkoExecuteOfContextMenu() );

			this.NormalCommandOfContextMenu = new DelegateCommand( this.NormalExecuteOfContextMenu() , this.CanNormalExecuteOfContextMenu() );
			this.HotCommandOfContextMenu = new DelegateCommand( this.HotExecuteOfContextMenu() , this.CanHotExecuteOfContextMenu() );
			this.ExcitementCommandOfContextMenu = new DelegateCommand( this.ExcitementExecuteOfContextMenu() , this.CanExcitementExecuteOfContextMenu() );
			this.SleepyCommandOfContextMenu = new DelegateCommand( this.SleepyExecuteOfContextMenu() , this.CanSleepyExecuteOfContextMenu() );
			this.SurpriseCommandOfContextMenu = new DelegateCommand( this.SurpriseExecuteOfContextMenu() , this.CanSurpriseExecuteOfContextMenu() );
			
			this.QuitCommandOfContextMenu = new DelegateCommand( this.QuitExecuteOfContextMenu() , this.CanQuitExecuteOfContextMenu() );

			#endregion
			
			pinCodeProvider.PropertyChanged += ( _ , e ) => {
				if( e.PropertyName == "PinCode" )
					this.PinCodeChangedEvent( pinCodeProvider.PinCode );
			};
			
			// キャラクターのサイズ更新
			this.UpdateSizeAndPosition();

			// キャラクターの座標更新
			this.InitialCharacterPosition();


		}


	}

}
