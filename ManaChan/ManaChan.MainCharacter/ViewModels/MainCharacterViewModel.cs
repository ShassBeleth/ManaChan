using System;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;

namespace ManaChan.ViewModels {

	/// <summary>
	/// ShellのViewModel
	/// </summary>
	public class ShellViewModel : BindableBase {

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

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public ShellViewModel() {
			this.QuitCommandOfContextMenu = new DelegateCommand( this.QuitExecuteOfContextMenu() , this.CanQuitExecuteOfContextMenu() );
			this.AlartTextCommandOfContextMenu = new DelegateCommand( this.AlartTextExecuteOfContextMenu() , this.CanAlartTextExecuteOfContextMenu() );
		}


	}
}
