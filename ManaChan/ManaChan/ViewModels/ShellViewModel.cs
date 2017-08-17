using ManaChan.Models.ScreenSize;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using System;

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
		private Action CharacterSpecialLargeExecuteOfContextMenu() => () => this.UpdateCharacterSize();

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
		private Action CharacterLargeExecuteOfContextMenu() => () => this.UpdateCharacterSize();

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
		private Action CharacterMediumExecuteOfContextMenu() => () => this.UpdateCharacterSize();

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
		private Action CharacterSmallExecuteOfContextMenu() => () => this.UpdateCharacterSize();

		/// <summary>
		/// 小可否
		/// </summary>
		/// <returns></returns>
		private Func<bool> CanCharacterSmallExecuteOfContextMenu() => () => true;

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

		#endregion

		/// <summary>
		/// キャラクターのサイズ更新
		/// </summary>
		private void UpdateCharacterSize() {

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

			// 実際の倍率
			double heightMagnification = 0;
			double widthMagnification = 0;

			switch( this.CharacterSize ) {
				case Size.SpecialLarge:
					heightMagnification = specialLargeHeightMagnification;
					widthMagnification = specialLargeWidthMagnification;
					break;

				case Size.Large:
					heightMagnification = largeHeightMagnification;
					widthMagnification = largeWidthMagnification;
					break;

				case Size.Medium:
					heightMagnification = mediumHeightMagnification;
					widthMagnification = mediumWidthMagnification;
					break;

				case Size.Small:
					heightMagnification = smallHeightMagnification;
					widthMagnification = smallWidthMagnification;
					break;
					
			}
			
			this.CharacterHeight = (int)( this.PrimaryScreenSize.Height * heightMagnification );
			this.CharacterWidth = (int)( this.PrimaryScreenSize.Width * widthMagnification );

		}

		/// <summary>
		/// キャラクターの座標更新
		/// </summary>
		private void UpdateCharacterPosition() {

			this.CharacterPosX = (int)this.PrimaryScreenSize.Width - this.CharacterWidth;
			this.CharacterPosY = (int)this.PrimaryScreenSize.Height - this.CharacterHeight;

		}

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ShellViewModel() {

			// コマンド作成
			this.AlartTextCommandOfContextMenu = new DelegateCommand( this.AlartTextExecuteOfContextMenu() , this.CanAlartTextExecuteOfContextMenu() );
			this.CharacterSpecialLargeCommandOfContextMenu = new DelegateCommand( this.CharacterSpecialLargeExecuteOfContextMenu() , this.CanCharacterSpecialLargeExecuteOfContextMenu() );
			this.CharacterLargeCommandOfContextMenu = new DelegateCommand( this.CharacterLargeExecuteOfContextMenu() , this.CanCharacterLargeExecuteOfContextMenu() );
			this.CharacterMediumCommandOfContextMenu = new DelegateCommand( this.CharacterMediumExecuteOfContextMenu() , this.CanCharacterMediumExecuteOfContextMenu() );
			this.CharacterSmallCommandOfContextMenu = new DelegateCommand( this.CharacterSmallExecuteOfContextMenu() , this.CanCharacterSmallExecuteOfContextMenu() );
			this.QuitCommandOfContextMenu = new DelegateCommand( this.QuitExecuteOfContextMenu() , this.CanQuitExecuteOfContextMenu() );

			// キャラクターのサイズ更新
			this.UpdateCharacterSize();

			// キャラクターの座標更新
			this.UpdateCharacterPosition();
		}

	}

}