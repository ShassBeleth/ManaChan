using ManaChan.Models.ScreenSize;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;
using ManaChan.Models;
using ManaChan.Twitter.Services;
using ManaChan.Infrastructure.Enums;

namespace ManaChan.ViewModels {

	/// <summary>
	/// ShellのViewModel
	/// </summary>
	public partial class ShellViewModel : BindableBase {

		/// <summary>
		/// 画面サイズ
		/// </summary>
		[Dependency]
		public PrimaryScreenSize PrimaryScreenSize { get; } = new PrimaryScreenSize();

		/// <summary>
		/// タイトル
		/// </summary>
		public string Title { get; } = "ｱｶﾈﾁｬﾝｶﾜｲｲﾔｯﾀｰ";

		/// <summary>
		/// アラート用リクエスト
		/// </summary>
		public InteractionRequest<Notification> NotificationRequest { get; } = new InteractionRequest<Notification>();

		/// <summary>
		/// PINコード入力アラート用リクエスト
		/// </summary>
		public InteractionRequest<InputPinCodeNotification> InputNotificationRequest { get; } = new InteractionRequest<InputPinCodeNotification>();

		/// <summary>
		/// キャラクタータイプ値発行者
		/// TODO DIなってない
		/// </summary>
		[Dependency]
		public CharacterTypeValuePublisher CharacterTypeValuePublisher { set; get; }

		/// <summary>
		/// ツイッター認証サービス
		/// </summary>
		private IAuthenticatedService AuthenticatedService { get; } = new AuthenticatedService();

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
		/// PINコード
		/// </summary>
		private int pinCode;

		/// <summary>
		/// PINコード
		/// </summary>
		public int PinCode {
			set => SetProperty( ref this.pinCode , value );
			get => this.pinCode;
		}

		/// <summary>
		/// ツイッター認証イベント
		/// </summary>
		/// <returns></returns>
		private Action TwitterAuthenticateExecuteOfContextMenu() => () => {
			this.AuthenticatedService.Authorize();
			this.InputNotificationRequest.Raise( 
				new InputPinCodeNotification {
					Title = "AAA" ,
					InputPinCode = this.PinCode }
			);
		};

		/// <summary>
		/// ツイッター認証イベント可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanTwitterAuthenticateExecuteOfContextMenu() => () => true;

		#endregion

		#region アラートテスト

		/// <summary>
		/// アラートテスト文字列
		/// </summary>
		public string AlartTestHeaderOfContextMenu { get; } = "アラートテスト";

		/// <summary>
		/// アラートテストコマンド
		/// </summary>
		private DelegateCommand alartTextCommandOfContextMenu;

		/// <summary>
		/// アラートテストコマンド
		/// </summary>
		public DelegateCommand AlartTextCommandOfContextMenu {
			private set => SetProperty( ref this.alartTextCommandOfContextMenu , value );
			get => this.alartTextCommandOfContextMenu;
		}

		/// <summary>
		/// アラートテストイベント
		/// </summary>
		/// <returns></returns>
		private Action AlartTextExecuteOfContextMenu() => () => this.NotificationRequest.Raise( new Notification { Title = "アラート" , Content = "ｱｶﾈﾁｬﾝｶﾜｲｲﾔｯﾀｰ!" } );

		/// <summary>
		/// アラートテスト可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanAlartTextExecuteOfContextMenu() => () => true;

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
		private Action AkaneExecuteOfContextMenu() => () => this.CharacterTypeValuePublisher.Publish( CharacterType.Akane );

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
		private Action AoiExecuteOfContextMenu() => () => this.CharacterTypeValuePublisher.Publish( CharacterType.Aoi );

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
		private Action MakiExecuteOfContextMenu() => () => this.CharacterTypeValuePublisher.Publish( CharacterType.Maki );

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
		private Action YukariExecuteOfContextMenu() => () => this.CharacterTypeValuePublisher.Publish( CharacterType.Yukari );

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
		private Action ZunkoExecuteOfContextMenu() => () => this.CharacterTypeValuePublisher.Publish( CharacterType.Zunko );

		/// <summary>
		/// 東北 ずん子可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanZunkoExecuteOfContextMenu() => () => true;

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
					posX ,
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
					( this.CharacterPosX , this.CharacterPosY ) = CorrectionOverflow( this.CharacterPosX , this.CharacterPosY );
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

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ShellViewModel() {

			#region コマンド作成

			this.AlartTextCommandOfContextMenu = new DelegateCommand( this.AlartTextExecuteOfContextMenu() , this.CanAlartTextExecuteOfContextMenu() );
			this.TwitterAuthenticateCommandOfContextMenu = new DelegateCommand( this.TwitterAuthenticateExecuteOfContextMenu() , this.CanTwitterAuthenticateExecuteOfContextMenu() );

			this.CharacterSpecialLargeCommandOfContextMenu = new DelegateCommand( this.CharacterSpecialLargeExecuteOfContextMenu() , this.CanCharacterSpecialLargeExecuteOfContextMenu() );
			this.CharacterLargeCommandOfContextMenu = new DelegateCommand( this.CharacterLargeExecuteOfContextMenu() , this.CanCharacterLargeExecuteOfContextMenu() );
			this.CharacterMediumCommandOfContextMenu = new DelegateCommand( this.CharacterMediumExecuteOfContextMenu() , this.CanCharacterMediumExecuteOfContextMenu() );
			this.CharacterSmallCommandOfContextMenu = new DelegateCommand( this.CharacterSmallExecuteOfContextMenu() , this.CanCharacterSmallExecuteOfContextMenu() );

			this.AkaneCommandOfContextMenu = new DelegateCommand( this.AkaneExecuteOfContextMenu() , this.CanAkaneExecuteOfContextMenu() );
			this.AoiCommandOfContextMenu = new DelegateCommand( this.AoiExecuteOfContextMenu() , this.CanAoiExecuteOfContextMenu() );
			this.MakiCommandOfContextMenu = new DelegateCommand( this.MakiExecuteOfContextMenu() , this.CanMakiExecuteOfContextMenu() );
			this.YukariCommandOfContextMenu = new DelegateCommand( this.YukariExecuteOfContextMenu() , this.CanYukariExecuteOfContextMenu() );
			this.ZunkoCommandOfContextMenu = new DelegateCommand( this.ZunkoExecuteOfContextMenu() , this.CanZunkoExecuteOfContextMenu() );

			this.QuitCommandOfContextMenu = new DelegateCommand( this.QuitExecuteOfContextMenu() , this.CanQuitExecuteOfContextMenu() );

			#endregion

			// キャラクターのサイズ更新
			this.UpdateSizeAndPosition();

			// キャラクターの座標更新
			this.InitialCharacterPosition();
		}

	}

}