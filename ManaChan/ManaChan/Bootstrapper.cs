using Microsoft.Practices.Unity;
using Prism.Unity;
using System.Windows;
using ManaChan.Views;
using Prism.Modularity;
using ManaChan.MainCharacter;
using ManaChan.Twitter;
using ManaChan.PopUp;
using ManaChan.MainWindow;

namespace ManaChan {

	/// <summary>
	/// Boootstrapper
	/// </summary>
	public class Bootstrapper : UnityBootstrapper {

		/// <summary>
		/// コンテナからShellを作成
		/// </summary>
		/// <returns></returns>
		protected override DependencyObject CreateShell() => this.Container.Resolve<Shell>();

		/// <summary>
		/// Shellの表示
		/// </summary>
		protected override void InitializeShell() {

			base.InitializeShell();

			Application.Current.MainWindow = (Window)this.Shell;
			Application.Current.MainWindow.Show();

		}

		/// <summary>
		/// モジュールの設定
		/// </summary>
		protected override void ConfigureModuleCatalog() {

			base.ConfigureModuleCatalog();
			
			ModuleCatalog catalog = (ModuleCatalog)this.ModuleCatalog;
			catalog.AddModule( typeof( TwitterModule ) );
			catalog.AddModule( typeof( PopUpModule ) );
			catalog.AddModule( typeof( MainCharacterModule ) );
			catalog.AddModule( typeof( MainWindowModule ) );
			
		}

	}

}