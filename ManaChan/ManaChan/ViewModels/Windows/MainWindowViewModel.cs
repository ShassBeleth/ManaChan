using System;
using Prism.Commands;
using Prism.Mvvm;

namespace ManaChan.ViewModels.Windows {

	/// <summary>
	/// MainWindowのViewModel
	/// </summary>
	public class MainWindowViewModel : BindableBase {

		/// <summary>
		/// 画面を閉じるかどうか
		/// </summary>
		private bool isCloseWindow = false;

		/// <summary>
		/// 画面を閉じるかどうか
		/// </summary>
		public bool IsCloseWindow {
			set => SetProperty( ref this.isCloseWindow , value );
			get => this.isCloseWindow;
		}

		#region 右クリックメニュー

		#region 終了

		/// <summary>
		/// 終了文字列
		/// </summary>
		private string quitHeaderOfContextMenu = "終了";

		/// <summary>
		/// 終了文字列
		/// </summary>
		public string QuitHeaderOfContextMenu {
			set => SetProperty( ref this.quitHeaderOfContextMenu , value );
			get => this.quitHeaderOfContextMenu;
		}

		/// <summary>
		/// 終了コマンド
		/// </summary>
		public DelegateCommand QuitCommandOfContextMenu;
		
		/// <summary>
		/// 終了イベント
		/// </summary>
		/// <returns></returns>
		private Action QuitExecuteOfContextMenu() => () => this.IsCloseWindow = true;

		#endregion

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindowViewModel() => this.QuitCommandOfContextMenu = new DelegateCommand( this.QuitExecuteOfContextMenu() );

	}

}
