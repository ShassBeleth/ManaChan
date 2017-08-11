using Prism.Mvvm;

namespace ManaChan.ViewModels.Windows {

	/// <summary>
	/// MainWindowのViewModel
	/// </summary>
	public class MainWindowViewModel : BindableBase {

		#region 右クリックメニュー

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

		#endregion

	}

}
