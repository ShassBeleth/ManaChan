using System;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace ManaChan.ViewModels.Windows {

	/// <summary>
	/// MainWindowのViewModel
	/// </summary>
	public class MainWindowViewModel : BindableBase {

		/// <summary>
		/// 画面幅
		/// </summary>
		private double primaryScreenWidth = SystemParameters.PrimaryScreenWidth;

		/// <summary>
		/// 画面幅
		/// </summary>
		public double PrimaryScreenWidth {
			private set => SetProperty( ref this.primaryScreenWidth , value );
			get => this.primaryScreenWidth;
		}

		/// <summary>
		/// 画面高さ
		/// </summary>
		private double primaryScreenHeight = SystemParameters.PrimaryScreenHeight;

		/// <summary>
		/// 画面高さ
		/// </summary>
		public double PrimaryScreenHeight {
			private set => SetProperty( ref this.primaryScreenHeight , value );
			get => this.primaryScreenHeight;
		}

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
			private set => SetProperty( ref this.quitHeaderOfContextMenu , value );
			get => this.quitHeaderOfContextMenu;
		}

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
		private Func<bool> QuitCanExecuteOfContextMenu() => () => this.IsQuitEnabledOfContextMenu;

		#endregion

		#endregion

		/// <summary>
		/// コンストラクタ
		/// </summary>
		public MainWindowViewModel() => this.QuitCommandOfContextMenu = new DelegateCommand( this.QuitExecuteOfContextMenu() , this.QuitCanExecuteOfContextMenu() );

	}

}
